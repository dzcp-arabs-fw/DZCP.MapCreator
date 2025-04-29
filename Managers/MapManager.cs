using System.Collections.Generic;
using System.IO;
using DZCP.MapCreator;
using DZCP.MapCreator.API;
using DZCP.MapCreator.API.Serialization;
using Exiled.API.Features;
using UnityEngine;
using YamlDotNet.Serialization;

public static class MapManager
    {
        private static readonly List<IDZCPObject> currentMapObjects = new();
        private static readonly IDeserializer deserializer = new DeserializerBuilder().Build();
        private static readonly ISerializer serializer = new SerializerBuilder().Build();

        public static void Initialize()
        {
            if (!Directory.Exists(Plugin.Instance.Config.MapsDirectory))
                Directory.CreateDirectory(Plugin.Instance.Config.MapsDirectory);
        }

        public static void Load(string mapName)
        {
            string path = Path.Combine(Plugin.Instance.Config.MapsDirectory, mapName + ".yml");
            if (!File.Exists(path))
            {
                Log.Warn($"[DZCP] ملف الخريطة {mapName} غير موجود.");
                return;
            }

            var yaml = File.ReadAllText(path);
            var loadedObjects = deserializer.Deserialize<List<IDZCPObject>>(yaml);

            foreach (var obj in loadedObjects)
            {
                AddObject(obj);
            }

            Log.Info($"[DZCP] تم تحميل {loadedObjects.Count} كائن من {mapName}.");
        }

      

        public static void AddObject(IDZCPObject obj)
        {
            currentMapObjects.Add(obj);
            AddObject(obj);
        }


        public static GameObject Spawn(SerializableObject obj)
        {
            PrimitiveType primitive = PrimitiveType.Cube;

            // استخدم نوع مختلف لكل ObjectType
            if (obj.ObjectType == "Door")
                primitive = PrimitiveType.Cylinder;
            else if (obj.ObjectType == "Light")
                primitive = PrimitiveType.Sphere;

            GameObject go = GameObject.CreatePrimitive(primitive);
            go.transform.position = obj.Position;
            go.transform.rotation = Quaternion.Euler(obj.Rotation);
            go.transform.localScale = obj.Scale;
        
            // يمكنك لاحقاً إضافة Scripts إضافية بناءً على نوع الكائن
            return go;
        }
        public static void Save(string mapName)
        {
            string yaml = serializer.Serialize(currentMapObjects);
            File.WriteAllText(Path.Combine(Plugin.Instance.Config.MapsDirectory, mapName + ".yml"), yaml);
            Log.Info($"[DZCP] تم حفظ {currentMapObjects.Count} كائن في {mapName}.");
        }


        public static void AddObject(string door, Vector3 pos)
        {
            throw new System.NotImplementedException();
        }
    }
    
