using Game.Coin;

namespace Game.Interfaces.Coin
{
    public interface ICoinPresenter
    {
        public void CollectCoin(CoinCollected signal);
    }
}