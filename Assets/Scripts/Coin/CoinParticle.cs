using UnityEngine;

namespace Game.Coin
{
    public class CoinParticle
    {
        public void Activate(ParticleSystem particle)
        {
            particle.gameObject.SetActive(true);
        }
    }
}
