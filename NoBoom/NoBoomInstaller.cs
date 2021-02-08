using Zenject;

namespace NoBoom.Installers
{
    class NoBoomInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ModifierViewController>().AsSingle();
        }
    }
}
