using Game.DI;
using Game.Interfaces;
using Game.Player;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Game.Coin
{
    public class CoinView : MonoBehaviour, ILifecycle
    {
        [SerializeField] private int _coinsPerOne;

        [SerializeField] private SphereCollider _sphereColider;

        private SignalBus _signalBus;

        [field: SerializeField] public Transform CoinObject {  get; private set; }
        [field: SerializeField] public ParticleSystem DeathParticle { get; private set; }

        public bool IsEnable { get; private set; }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerView _))
            {
                _signalBus.Fire(new CoinCollected(_coinsPerOne, this));

                _sphereColider.enabled = false;

                StartCoroutine(WaitToDestroy());
            }
        }

        private IEnumerator WaitToDestroy()
        {
            yield return new WaitForSeconds(DeathParticle.main.duration);

            Destroy(gameObject);
        }
    }
}