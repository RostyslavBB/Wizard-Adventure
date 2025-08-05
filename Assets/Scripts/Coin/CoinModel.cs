using Game.Interfaces.Coin;

namespace Game.Coin
{
    public class CoinModel : ICoinModel
    {
        public void CalculateCoinCount(CoinCollected signal, CoinManager coinController)
        {
            coinController.CoinCount += signal.Amount;
        }
    }
}