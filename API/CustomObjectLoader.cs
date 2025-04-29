using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Exiled.API.Features;

namespace DZCP.MapCreator.API.CustomObjects
{
    public static class CustomObjectLoader
    {
        private static readonly Dictionary<string, GameObject> customPrefabs = new Dictionary<string, GameObject>();

        public static void LoadAll()
        {
            string path = Path.Combine(Paths.Configs, "DZCP/CustomPrefabs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Log.Warn($"[DZCP] مجلد الكائنات المخصصة غير موجود. تم إنشاؤه في: {path}");
                return;
            }

            foreach (string file in Directory.GetFiles(path, "*.prefab"))
            {
                string name = Path.GetFileNameWithoutExtension(file);
                // تحميل الـ prefab من الملف
                // ملاحظة: Unity لا يدعم تحميل الـ prefab مباشرة من الملف في وقت التشغيل
                // تحتاج إلى استخدام AssetBundle أو طريقة أخرى لتحميل الكائنات
                // هنا نضع مثالًا توضيحيًا فقط
                GameObject prefab = LoadPrefabFromFile(file);
                if (prefab != null)
                {
                    customPrefabs[name.ToLower()] = prefab;
                    Log.Info($"[DZCP] تم تحميل الكائن المخصص: {name}");
                }
                else
                {
                    Log.Warn($"[DZCP] فشل في تحميل الكائن المخصص: {name}");
                }
            }
        }

        public static GameObject GetPrefab(string name)
        {
            if (customPrefabs.TryGetValue(name.ToLower(), out GameObject prefab))
                return prefab;

            Log.Warn($"[DZCP] الكائن المخصص غير موجود: {name}");
            return null;
        }

        private static GameObject LoadPrefabFromFile(string filePath)
        {
            // هنا يجب عليك تنفيذ طريقة لتحميل الـ prefab من الملف
            // يمكن استخدام AssetBundle أو أي طريقة أخرى مناسبة
            return null;
        }
    }
}
