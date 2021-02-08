using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System;
using IPALogger = IPA.Logging.Logger;
using HarmonyLib;
using System.Reflection;
using SiraUtil.Zenject;
using NoBoom.Installers;

namespace NoBoom
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        public const string HarmonyId = "com.github.Spooky323.NoBoom";
        internal static Harmony harmony;

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public Plugin(IPALogger logger, Zenjector zenjector)
        {
            Instance = this;
            Log = logger;
            harmony = new Harmony(HarmonyId);
            zenjector.OnMenu<NoBoomInstaller>();
        }

        #region BSIPA Config
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");
        }
        #endregion

        [OnEnable]
        public void OnEnable()
        {
            ApplyPatch();
        }

        [OnDisable]
        public void OnDisable()
        {
            RemovePatch();

        }
        public void ApplyPatch()
        {
            try
            {
                harmony.PatchAll(Assembly.GetExecutingAssembly());
                Log.Notice("NoBoom is Patched to the game");
            }
            catch (Exception e)
            {
                Log.Error("Error patching NoBoom");
                Log.Error(e);
            }
        }
        public void RemovePatch()
        {
            try
            {
                harmony.UnpatchAll(HarmonyId);
                Log.Notice("NoBoom is now UnPatched");
            }
            catch (Exception e)
            {
                Log.Error("Error UnPatching NoBoom");
                Log.Error(e);
            }
        }
    }
}
