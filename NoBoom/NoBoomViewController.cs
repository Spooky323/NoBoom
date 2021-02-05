using System;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using Zenject;

namespace NoBoom
{
    class NoBoomViewController : IInitializable
    {

        [UIValue("enabled")]
        public bool Enabled
        {
            get => Configuration.PluginConfig.Instance.Enabled;
            set { 
                
                Configuration.PluginConfig.Instance.Enabled = value;

                // Called manually because BSIPA doesn't do it itself :'(
                Configuration.PluginConfig.Instance.OnReload();
            }
        }

        public void Initialize()
        {
            BeatSaberMarkupLanguage.GameplaySetup.GameplaySetup.instance.AddTab("NoBoom", "NoBoom.Views.ModfierUI.bsml", this);
        }
    }
}