using Game.Interfaces.Coin;
using System;
using Zenject;
using UnityEngine;

namespace Game.Coin
{
    public class CoinPresenter : ICoinPresenter, IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        private readonly ICoinModel _coinModel;

        private readonly CoinManager _coinManager;

        private readonly CoinUI _coinUI;

        private readonly CoinParticle _coinParticle;

        private readonly CoinObject _coinObject;

        public CoinPresenter(SignalBus signalBus, ICoinModel coinModel, CoinManager сoinManager, CoinUI coinUI,
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

        public void CollectCoin(CoinCollected signal)
        {
            _coinModel.CalculateCoinCount(signal, _coinManager);

            _coinUI.UpdateCoinUI(_coinManager);

            _coinParticle.Activate(signal.CoinView.DeathParticle);

            _coinObject.Deactivate(signal.CoinView.CoinObject);
        }
    }
}
