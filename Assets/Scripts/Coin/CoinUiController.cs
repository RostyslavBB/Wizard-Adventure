using Game.DI;
using UnityEngine;
using Zenject;

namespace Game.Coin
{
    public class CoinUiController : IInitializable
    {
        private readonly SignalBus _signalBus;

        private int _coinCount = 0;

        public CoinUiController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<CoinCollectedSignal>(CollectCoin);
        }

        private void CollectCoin(CoinCollectedSignal signal)
        {
            _coinCount += signal.Amount;

            Debug.Log(_coinCount);
        }
    }
}
