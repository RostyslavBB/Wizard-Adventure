using UnityEngine;

namespace Game.Coin
{
    public class CoinObject 
    {
        public void Deactivate(Transform objectToDeactivate)
        {
            objectToDeactivate.gameObject.SetActive(false);
        }
    }
}