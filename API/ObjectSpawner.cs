using UnityEngine;
using DZCP.MapCreator.API.Serialization;
using DZCP.MapCreator.API.CustomObjects;

namespace DZCP.MapCreator.API.Spawning
{
    public static class ObjectSpawner
    {
        public static GameObject Spawn(SerializableObject obj)
        {
            GameObject go = null;

            // محاولة تحميل كائن مخصص
            go = CustomObjectLoader.GetPrefab(obj.ObjectType);
            if (go != null)
            {
                GameObject instance = GameObject.Instantiate(go);
                instance.transform.position = obj.Position;
                instance.transform.rotation = Quaternion.Euler(obj.Rotation);
                instance.transform.localScale = obj.Scale;
                return instance;
            }

            // إذا لم يتم العثور على كائن مخصص، استخدم الكائنات الافتراضية
            PrimitiveType primitive = PrimitiveType.Cube;

            switch (obj.ObjectType.ToLower())
            {
                case "door":
                    primitive = PrimitiveType.Cylinder;
                    break;
                case "light":
                    primitive = PrimitiveType.Sphere;
                    break;
                // يمكنك إضافة أنواع أخرى هنا
            }

            go = GameObject.CreatePrimitive(primitive);
            go.transform.position = obj.Position;
            go.transform.rotation = Quaternion.Euler(obj.Rotation);
            go.transform.localScale = obj.Scale;

            return go;
        }
    }
}