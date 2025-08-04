using Game.DI;
using UnityEngine;
using Zenject;

namespace Game.Coin
{
    public class Coin : MonoBehaviour
    {
        private readonly SignalBus _signalBus;

        [Inject]
        public Coin(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _signalBus.Fire(new CoinCollectedSignal(1));

                Destroy(gameObject);
            }
        }
    }
}