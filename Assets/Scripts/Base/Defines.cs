public enum Languages
{
    Korean,
    English,
    Japanese,
}

public class DataTableIds
{
    public static readonly string[] String =
    {
        "StringTableKr",
        //"StringTableEn",
        //"StringTableJp",
    };

    public const string Resource = "ResourceTable";
    public const string Event = "EventTable";
    public const string ResourceEvent = "ResourceEventTable";
    public const string Signal = "SignalTable";
}

public class Variables
{
    public static Languages currentLanguage = Languages.Korean;
}