using Game.DI;
using System;
using System.Collections;
using Zenject;

namespace Game.Coin
{
    public class CoinPresenter : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        private readonly CoinModel _coinModel;

        private readonly CoinManager _coinManager;

        private readonly CoinUI _coinUI;

        private readonly CoinParticle _coinParticle;

        private readonly CoinObject _coinObject;

        public CoinPresenter(SignalBus signalBus, CoinModel coinModel, CoinManager сoinManager, CoinUI coinUI,
            CoinParticle coinParticle, CoinObject coinObject)
        {
            _signalBus = signalBus;
            _coinModel = coinModel;
            _coinManager = сoinManager;
            _coinUI = coinUI;
            _coinParticle = coinParticle;
            _coinObject = coinObject;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<CoinCollected>(CollectCoin);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<CoinCollected>(CollectCoin);
        }

        private void CollectCoin(CoinCollected signal)
        {
            _coinModel.CalculateCoinCount(signal, _coinManager);

            _coinUI.UpdateCoinUI(_coinManager);

            _coinParticle.Activate(signal.CoinView.DeathParticle);

            _coinObject.Deactivate(signal.CoinView.CoinObject);
        }
    }
}
