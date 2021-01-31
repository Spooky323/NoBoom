using System;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;

namespace NoBoom
{
    class NoBoomViewController : BSMLResourceViewController
    {
        public override string ResourceName => "NoBoom.Views.settings.bsml";

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
    }
}