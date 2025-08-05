using Game.Coin;

namespace Game.DI
{
    public class CoinCollected
    {
        public int Amount { get; private set; }
        public CoinView CoinView { get; private set; }

        public CoinCollected(int amount, CoinView coinView)
        {
            Amount = amount;
            CoinView = coinView;
        }
    }
}
