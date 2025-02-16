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
}

public class Variables
{
    public static Languages currentLanguage = Languages.Korean;
}