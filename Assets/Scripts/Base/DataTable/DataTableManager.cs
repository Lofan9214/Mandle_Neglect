using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public static class DataTableManager
{
    private static readonly Dictionary<string, DataTable> tables = new Dictionary<string, DataTable>();

    static DataTableManager()
    {
#if UNITY_EDITOR
        foreach (var id in DataTableIds.String)
        {
            var table = new StringTable();
            table.Load(id);
            tables.Add(id, table);
        }
#else
        var table = new StringTable();
        var stringTableId = DataTableIds.String[(int)Variables.currentLanguage];
        table.Load(stringTableId);
        tables.Add(stringTableId, table);
#endif

        var resourceTable = new ResourceTable();
        var resourceTableId = DataTableIds.Resource;
        resourceTable.Load(resourceTableId);
        tables.Add(resourceTableId, resourceTable);

        //var eventTable = new EventTable();
        //var eventTableId = DataTableIds.Event;
        //eventTable.Load(eventTableId);
        //tables.Add(eventTableId, eventTable);
        //
        //var resourceEventTable = new ResourceEventTable();
        //var resourceEventTableId = DataTableIds.ResourceEvent;
        //resourceEventTable.Load(resourceEventTableId);
        //tables.Add(resourceEventTableId, resourceEventTable);
        //
        //var signalTable = new SignalTable();
        //var signalTableId = DataTableIds.Signal;
        //signalTable.Load(signalTableId);
        //tables.Add(signalTableId, signalTable);
    }

    public static T Get<T>(string id) where T : DataTable
    {
        if (!tables.ContainsKey(id))
        {
            Debug.LogError("Table Not Exists");
            return null;
        }
        return tables[id] as T;
    }

    public static StringTable StringTable
    {
        get
        {
            return Get<StringTable>(DataTableIds.String[(int)Variables.currentLanguage]);
        }
    }
}
