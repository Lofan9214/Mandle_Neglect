using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public enum Choice
    {
        Neglect,
        Accept
    }

    public EventTable.Data CurrentEvent { get; private set; }
    public bool EventExists { get; private set; }

    public UnityEvent<ResourceManager.ResourceType, int> OnResourceChange;
    public UnityEvent<int> OnEventScript;

    public void Random(float ratio)
    {
        float rand = UnityEngine.Random.value;

        var list = DataTableManager.EventTypeTable.GetValues();

        foreach (var item in list)
        {
            rand -= Mathf.Lerp(item.ProbabilityMin, item.ProbabilityMax, ratio);
            if (rand < 0f)
            {
                var events = DataTableManager.EventTable.GetValues(item.Type);
                int relativeRand = UnityEngine.Random.Range(0, events.Sum(p => p.RelativeProbability));
                foreach (var eventItem in events)
                {
                    relativeRand -= eventItem.RelativeProbability;
                    if (relativeRand < 0)
                    {
                        CurrentEvent = events[UnityEngine.Random.Range(0, events.Length)];
                        EventExists = true;
                        return;
                    }
                }
            }
        }

        EventExists = false;
        CurrentEvent = null;
    }

    public void DoChoice(Choice choice)
    {
        ChoiceScript(choice);
        switch (CurrentEvent.Type)
        {
            case EventTypeTable.EventType.Signal:
                break;
            case EventTypeTable.EventType.BreakDown:
                break;
            case EventTypeTable.EventType.Resource:
                if (choice == Choice.Accept)
                    ResourceParse(CurrentEvent.AcceptResult);
                else
                    ResourceParse(CurrentEvent.NeglectResult);
                break;
        }
    }

    private void ChoiceScript(Choice choice)
    {
        if (choice == Choice.Accept)
            OnEventScript.Invoke(CurrentEvent.AcceptScript);
        else
            OnEventScript.Invoke(CurrentEvent.NeglectScript);
    }

    private void ResourceParse(string result)
    {
        var results = result.Split('_');

        foreach (var res in results)
        {
            var items = res.Split('#');

            if (Enum.TryParse<ResourceManager.ResourceType>(items[0], true, out ResourceManager.ResourceType type)
                && int.TryParse(items[1], out int quantity))
            {
                OnResourceChange.Invoke(type, quantity);
            }
        }
    }
}