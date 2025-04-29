using UnityEngine;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DZCP.MapCreator.API.Extensions
{
    public static class BitwiseExtensions
    {
        public static bool HasFlag(this int value, int flag)
        {
            return (value & flag) == flag;
        }

        public static int AddFlag(this int value, int flag)
        {
            return value | flag;
        }

        public static int RemoveFlag(this int value, int flag)
        {
            return value & (~flag);
        }
    }
}