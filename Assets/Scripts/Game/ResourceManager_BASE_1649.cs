using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public enum ResourceType
    {
        Food,
        Energy,
        Oxygen,
    }

    public int Food { get; private set; }

    public int Energy { get; private set; }
    public int Oxygen { get; private set; }



    public void Init()
    {
        Food = DataTableManager.ResourceTable.Get(ResourceType.Food).StartQuantity;
        Energy = DataTableManager.ResourceTable.Get(ResourceType.Energy).StartQuantity;
        Oxygen = DataTableManager.ResourceTable.Get(ResourceType.Oxygen).StartQuantity;
    }

    public void NextTurn()
    {
        Food -= DataTableManager.ResourceTable.Get(ResourceType.Food).TurnUsage;
        Energy -= DataTableManager.ResourceTable.Get(ResourceType.Energy).TurnUsage;
        Oxygen  -= DataTableManager.ResourceTable.Get(ResourceType.Oxygen).TurnUsage;
    }

    public void AddResource(ResourceType type,int value)
    {
        switch (type)
        {
            case ResourceType.Food:
                Food += value;
                break;
            case ResourceType.Energy:
                Energy += value;
                break;
            case ResourceType.Oxygen:
                Oxygen += value;
                break;
            default:
                break;
        }

    }
}