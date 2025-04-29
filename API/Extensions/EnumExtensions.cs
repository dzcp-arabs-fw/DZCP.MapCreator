using System;

namespace DZCP.MapCreator.API.Extensions
{
    public static class EnumExtensions
    {
        public static T ParseEnum<T>(this string value) where T : struct
        {
            return Enum.TryParse<T>(value, true, out var result) ? result : default;
        }
    }
}