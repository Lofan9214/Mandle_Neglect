using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractablesWindow : MonoBehaviour
{
    public UIManager uiManager;
    public Button nextDayButton;

    [SerializeField] private float nextDayEnableDelay = 1f;

    public Button[] devices;

    private void Start()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        nextDayButton.onClick.AddListener(OnClickNextDay);
        devices[0].onClick.AddListener(OnClickOxygenGenerator);
        devices[1].onClick.AddListener(OnClickPowerGenerator);
        devices[2].onClick.AddListener(OnClickTransmitter);
    }

    private void OnClickNextDay()
    {
        uiManager.gameManager.NextTurn();
        //nextDayButton.interactable = false;
        //StartCoroutine(EnableNextDayButtonWithDelay(nextDayEnableDelay));
    }

    // temp methods
    public void OnClickOxygenGenerator()
    {

    }

    public void OnClickPowerGenerator()
    {

    }

    public void OnClickTransmitter()
    {

    }

    private IEnumerator EnableNextDayButtonWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        nextDayButton.interactable = true;
    }
}
