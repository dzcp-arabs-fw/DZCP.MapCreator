using System.Collections.Generic;
using System.IO;
using Exiled.API.Features;
using UnityEngine;
using YamlDotNet.Serialization;
using DZCP.MapCreator.API.Spawning;

namespace DZCP.MapCreator.API.Serialization
{
    public static class MapSerializer
    {
        public static MapData CurrentMap { get; private set; } = new MapData();

        public static void Load(string mapName)
        {
            string path = Path.Combine(Paths.Configs, $"DZCP/Maps/{mapName}.yml");
            if (!File.Exists(path))
            {
                Log.Warn($"[DZCP] ملف الخريطة غير موجود: {path}");
                return;
            }

            string yaml = File.ReadAllText(path);
            var deserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().Build();
            CurrentMap = deserializer.Deserialize<MapData>(yaml);

            foreach (var obj in CurrentMap.Objects)
            {
                Log.Info($"[DZCP] تحميل كائن: {obj.ObjectType} في {obj.Position}");
                ObjectSpawner.Spawn(obj);
            }
        }

        public static void Save(string mapName)
        {
            string path = Path.Combine(Paths.Configs, $"DZCP/Maps/{mapName}.yml");
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            var serializer = new SerializerBuilder().Build();
            string yaml = serializer.Serialize(CurrentMap);
            File.WriteAllText(path, yaml);
            Log.Info($"[DZCP] تم حفظ الخريطة إلى: {path}");
        }
    }
}