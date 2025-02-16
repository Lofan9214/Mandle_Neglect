using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class AppearingText : LocalizationText
{
    public enum State
    {
        Appearing,
        AppearEnd,
    }

    private string script;

    public float chatSpeed = 45f;

    public State ScriptState { get; private set; }

    private bool coroutineRunning = false;

    WaitWhile wait;

    private void Start()
    {
        wait = new WaitWhile(() => coroutineRunning);
    }

    public override void OnChangedLanguage(Languages lang)
    {
        var stringTableId = DataTableIds.String[(int)lang];
        var stringTable = DataTableManager.Get<StringTable>(stringTableId);
        if (int.TryParse(stringId, out int id))
        {
            if (stringArgs != null && stringArgs.Length > 0)
                script = string.Format(stringTable.Get(id), stringArgs);
            else
                script = stringTable.Get(id);

            if (coroutineRunning)
                StartCoroutine(WaitScript());
            else
                StartCoroutine(ScriptStart());
        }
    }

    private IEnumerator WaitScript()
    {
        yield return wait;
        StartCoroutine(ScriptStart());
    }


    private IEnumerator ScriptStart()
    {
        coroutineRunning = true;
        ScriptState = State.Appearing;
        float charLength = 0f;
        while (ScriptState == State.Appearing && (int)charLength < script.Length)
        {
            charLength += Time.deltaTime * chatSpeed;
            int leng = Mathf.Min(script.Length, (int)charLength);
            text.text = script.Substring(0, leng);
            if (leng == script.Length)
            {
                ScriptState = State.AppearEnd;
                break;
            }
            yield return null;
        }
        if ((int)charLength < script.Length)
        {
            text.text = script;
        }
        coroutineRunning = false;
    }

    public void SkipScript()
    {
        ScriptState = State.AppearEnd;
    }
}
