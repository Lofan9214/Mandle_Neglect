using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public enum ResourceType
    {
        Food,
        ElectricalEnergy,
        Oxygen,
    }

    public int food { get; private set; }

    public int electricEnergy { get; private set; }
    public int oxygen { get; private set; }

    private ResourceType currentResourceType;


    public void Init()
    {

    }

    public void NextTurn()
    {
        food -= 1;
        oxygen -= 2;
        electricEnergy -= 1;
    }

    public void AddResource(ResourceType type,int value)
    {
        currentResourceType = type;
        switch (currentResourceType)
        {
            case ResourceType.Food:

                break;
            case ResourceType.ElectricalEnergy:
                break;
            case ResourceType.Oxygen:
                break;
            default:
                break;
        }

    }
}