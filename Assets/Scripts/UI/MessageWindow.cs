using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    public UIManager uiManager;

    public LocalizationText centerMessage;

    public Button acceptButton;
    public Button neglectButton;
    public Button confirmButton;

    private void Start()
    {
        AddListeners();

    }
    public void SetupChoiceEvent()
    {
        acceptButton.gameObject.SetActive(true);
        neglectButton.gameObject.SetActive(true);
        confirmButton.gameObject.SetActive(false);
    }

    public void SetupResult()
    {
        acceptButton.gameObject.SetActive(false);
        neglectButton.gameObject.SetActive(false);
        confirmButton.gameObject.SetActive(true);
    }

    private void AddListeners()
    {
        acceptButton.onClick.AddListener(OnClickAccept);
        neglectButton.onClick.AddListener(OnClickNeglect);
        confirmButton.onClick.AddListener(OnClickConfirm);
    }

    private void OnClickAccept()
    {
        uiManager.gameManager.OnChoice(EventManager.Choice.Accept);
    }

    private void OnClickNeglect()
    {
        uiManager.gameManager.OnChoice(EventManager.Choice.Neglect);
    }

    private void OnClickConfirm()
    {
        gameObject.SetActive(false);
    }
}
