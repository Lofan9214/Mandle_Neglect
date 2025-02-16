using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventTable : DataTable
{
    public class Data
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public float ProbabilityMin { get; set; }
        public float ProbabilityMax { get; set; }
        public int Script { get; set; }
        public string TargetTable { get; set; }
        public int TargetTableId { get; set; }
    }

    private Dictionary<int, Data> dict = new Dictionary<int, Data>();

    public override void Load(string fileName)
    {
        var path = string.Format(FormatPath, fileName);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCsv<Data>(textAsset.text);

        dict.Clear();

        foreach (var item in list)
        {
            if (!dict.ContainsKey(item.ID))
            {
                dict.Add(item.ID, item);
            }
            else
            {
                Debug.Assert(false, $"Key Duplicated: {item.ID}");
            }
        }
    }

    public Data Get(int key)
    {
        if (!dict.ContainsKey(key))
        {
            return null;
        }
        return dict[key];
    }

    public Data[] GetValues()
    {
        return dict.Values.ToArray();
    }
}
