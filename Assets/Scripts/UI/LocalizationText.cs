using TMPro;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizationText : MonoBehaviour
{
    [SerializeField]
    protected string stringId;
    [SerializeField]
    protected string[] stringArgs;

#if UNITY_EDITOR
    public Languages editorLang;
#endif

    protected TextMeshProUGUI text;

    public bool TextEnabled
    {
        get => text.enabled;
        set => text.enabled = value;
    }

    protected void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    protected void OnEnable()
    {
        if (Application.isPlaying)
        {
            OnChangedLanguage(Variables.currentLanguage);
        }
#if UNITY_EDITOR
        else
        {
            OnChangedLanguage(editorLang);
        }
#endif
    }

    public virtual void OnChangedLanguage(Languages lang)
    {
        var stringTableId = DataTableIds.String[(int)lang];
        var stringTable = DataTableManager.Get<StringTable>(stringTableId);
        if (int.TryParse(stringId, out int id))
        {
            if (stringArgs != null && stringArgs.Length > 0)
                text.text = string.Format(stringTable.Get(id), stringArgs);
            else
                text.text = stringTable.Get(id);
        }
    }

    public void SetString(string stringId)
    {
        this.stringId = stringId;
        stringArgs = null;
        OnEnable();
    }

    public void SetString(string[] str)
    {
        stringArgs = str;
        OnEnable();
    }

    public void SetString(string stringId, string[] str)
    {
        this.stringId = stringId;
        SetString(str);
    }

    public void SetString(string stringId, int[] strIds)
    {
        this.stringId = stringId;
        stringArgs = new string[strIds.Length];
        var stringTableId = DataTableIds.String[(int)Variables.currentLanguage];
        var stringTable = DataTableManager.Get<StringTable>(stringTableId);
        for (int i = 0; i < strIds.Length; ++i)
        {
            stringArgs[i] = stringTable.Get(strIds[i]);
        }
        OnEnable();
    }
}
