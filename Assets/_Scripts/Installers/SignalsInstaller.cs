using _Scripts.Signals;
using Unity.Burst.Intrinsics;
using Zenject;

namespace _Scripts.Installers
{
    public class SignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.DeclareSignal<BalanceSpendResponseSignal>();
            Container.DeclareSignal<BalanceSpendRequestSignal>();
            Container.DeclareSignal<SelectNewGalleryImageSignal>();
            Container.DeclareSignal<ClickItemGallerySignal>();
        }
    }
}