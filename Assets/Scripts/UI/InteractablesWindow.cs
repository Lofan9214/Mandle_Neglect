using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractablesWindow : MonoBehaviour
{
    public UIManager uiManager;
    public Button nextDayButton;

    [SerializeField] private float nextDayEnableDelay = 1f;

    private void Start()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        nextDayButton.onClick.AddListener(OnClickNextDay);
    }

    private void OnClickNextDay()
    {
        uiManager.gameManager.NextTurn();
        //nextDayButton.interactable = false;
        //StartCoroutine(EnableNextDayButtonWithDelay(nextDayEnableDelay));
    }

    private IEnumerator EnableNextDayButtonWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        nextDayButton.interactable = true;
    }
}
