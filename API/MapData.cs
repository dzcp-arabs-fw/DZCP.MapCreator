using System.Collections.Generic;

namespace DZCP.MapCreator.API.Serialization
{
    public class MapData
    {
        public string MapName { get; set; } = "UnnamedMap";
        public List<SerializableObject> Objects { get; set; } = new List<SerializableObject>();
    }
}