using System;
using HarmonyLib;
namespace NoBoom
{
    [HarmonyPatch(typeof(BombExplosionEffect))]
    [HarmonyPatch("SpawnExplosion")]
    class BombEffectPatch
    {
        public static bool Prefix()
        {
            bool Enabled = Configuration.PluginConfig.Instance.Enabled;
            return !Enabled;
        }
    }
}
