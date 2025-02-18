using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourceManager))]
[RequireComponent(typeof(EventManager))]
public class GameManager : MonoBehaviour
{
    public int currentTurn;
    [SerializeField] private int health = 100;

    public float Ratio
    {
        get
        {
            return (currentTurn-1) / (GameInfos.lastTurn -1);
        }
    }

    // Connect on inspector
    [SerializeField] private UIManager uiManager;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private EventManager eventManager;

    private void Awake()
    {
        resourceManager = GetComponent<ResourceManager>();
        eventManager = GetComponent<EventManager>();
        currentTurn = GameInfos.initialTurn;
        UpdateUiContents();
    }

    private void Start()
    {
        Init();
    }
    
    private void Init()
    {
        resourceManager.Init();
    }

    public void NextTurn()
    {
        currentTurn++;
        resourceManager.NextTurn();
        eventManager.Random(Ratio);
        if(CheckGameOver())
        { }
        else if(eventManager.EventExists)
        {
            PopUpEventChoice();
        }
        UpdateUiContents();
    }

    private bool CheckGameOver()
    {
        if(resourceManager.Food < 0)
        {
            PopUpGameOverMessage(ResourceType.Food);
            return true;
        }
        if (resourceManager.Energy < 0)
        {
            PopUpGameOverMessage(ResourceType.Energy);
            return true;
        }
        if (resourceManager.Oxygen < 0)
        {
            PopUpGameOverMessage(ResourceType.Oxygen);
            return true;
        }
        return false;
    }


    public void PopUpGameOverMessage(ResourceType type)
    {
        uiManager.messageWindow.gameObject.SetActive(true);
        uiManager.messageWindow.SetupResult();
        int gameOverStringId;
        switch (type)
        {
            case ResourceType.Food:
                gameOverStringId = 11111111;
                //uiManager.messageWindow.centerMessage.SetString(gameOverStringId);
                break;
            case ResourceType.Energy:
                gameOverStringId = 22222222;
                //uiManager.messageWindow.centerMessage.SetString(gameOverStringId);
                break;
            case ResourceType.Oxygen:
                gameOverStringId = 33333333;
                //uiManager.messageWindow.centerMessage.SetString(gameOverStringId);
                break;
        }
    }

    public void PopUpEventChoice()
    {
        uiManager.messageWindow.gameObject.SetActive(true);
        uiManager.messageWindow.SetupChoiceEvent();
        uiManager.messageWindow.centerMessage.SetString(eventManager.CurrentEvent.Script.ToString());
    }

    public void OnChoice(EventManager.Choice choice)
    {
        eventManager.DoChoice(choice);
        uiManager.messageWindow.SetupResult();
        uiManager.messageWindow.centerMessage.SetString(eventManager.CurrentEvent.Script.ToString());
        UpdateUiContents();
    }

    public void UpdateUiContents()
    {
        uiManager.statusWindow.currentDayText.text = currentTurn.ToString();
        uiManager.statusWindow.resourceTexts[0].text = resourceManager.Food.ToString();
        uiManager.statusWindow.resourceTexts[1].text = resourceManager.Energy.ToString();
        uiManager.statusWindow.resourceTexts[2].text = resourceManager.Oxygen.ToString();
    }
}
