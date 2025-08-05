using Game.Coin;

namespace Game.Interfaces.Coin
{
    public interface ICoinModel
    {
        public void CalculateCoinCount(CoinCollected signal, CoinManager coinController);
    }
}
