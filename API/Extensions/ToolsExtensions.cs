namespace DZCP.MapCreator.API.Extensions
{
    public static class ToolsExtensions
    {
        public static string SanitizeFileName(this string name)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name;
        }
    
    public static string ToJson(this object obj)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
    }
    
    }
}

