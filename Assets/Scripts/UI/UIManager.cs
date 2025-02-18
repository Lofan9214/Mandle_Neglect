using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;

    public StatusWindow statusWindow;
    public MessageWindow messageWindow;
    public InteractablesWindow interactablesWindow;

    private void Start()
    {
        messageWindow.gameObject.SetActive(false);
    }
}