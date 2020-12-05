using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
namespace NoBoom
{
    [HarmonyPatch(typeof(BombExplosionEffect))]
    [HarmonyPatch("SpawnExplosion")]
    class BombEffectPatch
    {
        public static bool Prefix()
        {
            return false;
        }
    }
}
