using Game.DI;

namespace Game.Coin
{
    public class CoinModel 
    {
        public void CalculateCoinCount(CoinCollected signal, CoinManager coinController)
        {
            coinController.CoinCount += signal.Amount;
        }
    }
}