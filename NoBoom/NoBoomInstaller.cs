using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace NoBoom
{
    class NoBoomInstaller : Installer
    {

        public override void InstallBindings()
        {
            Container.Bind<NoBoomViewController>().AsSingle();
        }
    }
}
