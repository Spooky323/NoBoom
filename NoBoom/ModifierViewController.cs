using System;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using Zenject;

namespace NoBoom
{
    class ModifierViewController : IInitializable, IDisposable
    {
        [UIValue("enabled")]
        public bool Enabled
        {
            get => Configuration.PluginConfig.Instance.Enabled;
            set => Configuration.PluginConfig.Instance.Enabled = value;
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