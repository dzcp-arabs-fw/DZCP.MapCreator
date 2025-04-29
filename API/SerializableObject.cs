using UnityEngine;

namespace DZCP.MapCreator.API.Serialization
{
    public class SerializableObject
    {
        public string ObjectType { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; } = Vector3.zero;
        public Vector3 Scale { get; set; } = Vector3.one;

        // لاحقاً يمكن إضافة خصائص إضافية مثل: لون - إعدادات خاصة - أحداث مرتبطة
    }
}