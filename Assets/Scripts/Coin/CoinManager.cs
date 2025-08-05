using UnityEngine;
using TMPro;

namespace Game.Coin
{
    public class CoinManager : MonoBehaviour
    {
        public int CoinCount { get; set; }

        [field: SerializeField] public TextMeshProUGUI CoinText { get; private set; }
    }
}