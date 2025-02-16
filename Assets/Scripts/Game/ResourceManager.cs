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

    }

    public void NextTurn()
    {
        Food -= 1;
        Energy -= 1;
        Oxygen -= 2;
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