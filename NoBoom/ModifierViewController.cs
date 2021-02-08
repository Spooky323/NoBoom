using System;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using NoBoom.Configuration;
using Zenject;

namespace NoBoom
{
    class ModifierViewController : IInitializable, IDisposable
    {
        [UIValue("enabled")]
        public bool Enabled
        {
            get => PluginConfig.Instance.Enabled;
            set
            {
                PluginConfig.Instance.Enabled = value;
                PluginConfig.Instance.Changed();
            }
        }

        public void Initialize()
        {
            GameplaySetup.instance.AddTab("NoBoom", "NoBoom.Views.ModifierView.bsml", this);
        }

        public void Dispose()
        {
            GameplaySetup.instance.RemoveTab("NoBoom");
        }
    }
}