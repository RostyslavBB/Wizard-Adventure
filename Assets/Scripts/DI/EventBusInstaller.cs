using Zenject;

namespace Game.DI
{
    public class EventBusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<CoinCollectedSignal>();
        }
    }
}