using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using SaveDataVC = SaveDataV1;
using BaseSaveDataVC = BaseSaveDataV1;


public class SaveLoadManager
{ 
    public static int SaveDataVersion { get; private set; } = 1;
    public static SaveDataVC SlotData {  get; set; }
    public static BaseSaveDataVC BaseData {  get; set; }

    private static readonly string[] SaveFileName =
    {
        "LoM_Save_Base.json",
        "LoM_Save1.json",
        "LoM_Save2.json",
        "LoM_Save3.json",
    };

    private static JsonSerializerSettings jsonSettings;

    static SaveLoadManager()
    {        
        if(!LoadBase())
        {
            BaseData = new BaseSaveDataVC();           
            SaveBase();
        }
    }

    public void Init()
    {

    }

    private static string SaveDirectory = $"{Application.persistentDataPath}/Save";
    
    public static bool Save(int slot)
    {
        if (SlotData == null || slot < 1 || slot > SaveFileName.Length)
        {
            Debug.Log($"File Save to slotIndex ({slot}) failed");
            return false;
        }

        if(!Directory.Exists(SaveDirectory))
        {
            Directory.CreateDirectory(SaveDirectory);
        }

        jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
        };

        var path = Path.Combine(SaveDirectory, SaveFileName[slot]);
        var json = JsonConvert.SerializeObject(SlotData, jsonSettings);
        File.WriteAllText(path, json);

        Debug.Log($"File Save to slotIndex ({slot}) successful");

        return true;
    }

    public static bool SaveBase()
    {
        if (!Directory.Exists(SaveDirectory))
        {
            Directory.CreateDirectory(SaveDirectory);
        }
        jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
        };

        var path = Path.Combine(SaveDirectory, SaveFileName[0]);
        var json = JsonConvert.SerializeObject(BaseData, jsonSettings);
        File.WriteAllText(path, json);

        Debug.Log($"Base file data save successful");

        return true;
    }

    public static bool Load(int slot)
    {
        if (slot < 1 || slot > SaveFileName.Length)
            return false;

        var path = Path.Combine(SaveDirectory, SaveFileName[slot]);
        if (!File.Exists(path))
            return false;

        jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
        };

        var json = File.ReadAllText(path);
        var saveData = JsonConvert.DeserializeObject<SaveData>(json, jsonSettings);

        while(saveData.Version < SaveDataVersion)
        {
            saveData = saveData.VersionUp();
        }
        SlotData = saveData as SaveDataVC;

        return true;
    }

    public static bool LoadBase()
    {
        var path = Path.Combine(SaveDirectory, SaveFileName[0]);
        if (!File.Exists(path))
            return false;

        jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
        };

        var json = File.ReadAllText(path);
        var saveData = JsonConvert.DeserializeObject<BaseSaveData>(json, jsonSettings);

        while (saveData.Version < SaveDataVersion)
        {
            saveData = saveData.VersionUp();
        }
        BaseData = saveData as BaseSaveDataVC;

        return true;
    }

    public static bool DeleteSlot(int slotIndex)
    {
        var path = Path.Combine(SaveDirectory, SaveFileName[slotIndex]);
        if(!File.Exists(path))
        {
            Debug.Log($"No file exists at path: {path}");
            return false;
        }
        else
        {
            File.Delete(path);
            Debug.Log($"File delete successful at path: {path}");
        }

        SaveBase();        
        return true;
    }
}
