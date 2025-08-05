using UnityEngine;

namespace Game.Interfaces.Coin
{
    public interface ICoinView 
    {
        public Transform CoinObject { get; }
        public ParticleSystem DeathParticle { get; }
    }
}
