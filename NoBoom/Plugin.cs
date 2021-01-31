using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System;
using IPALogger = IPA.Logging.Logger;
using HarmonyLib;
using System.Reflection;
using BeatSaberMarkupLanguage.Settings;

namespace NoBoom
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        internal static NoBoomViewController _viewController;

        public const string HarmonyId = "com.github.Spooky323.NoBoom";
        internal static readonly Harmony harmony = new Harmony(HarmonyId);

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public void Init(IPALogger logger, IPA.Config.Config conf )
        {
            Instance = this;
            Log = logger;
            Log.Info("NoBoom initialized.");
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");

        }

        #region BSIPA Config
        //Uncomment to use BSIPA's config
        /*
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");
        }
        */
        #endregion

        [OnStart]
        public void OnApplicationStart()
        {
            Log.Debug("OnApplicationStart");
            _viewController = new NoBoomViewController();
            BeatSaberMarkupLanguage.GameplaySetup.GameplaySetup.instance.AddTab("NoBoom", "NoBoom.Views.Settings.bsml", _viewController);
            // Call Harmony when the game starts if the config value is true
            if (Configuration.PluginConfig.Instance.Enabled)
            {
                ApplyPatch();
            }
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("OnApplicationQuit");
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
