namespace Game.Coin
{
    public class CoinUI 
    {
        public void UpdateCoinUI(CoinManager coinController)
        {
            coinController.CoinText.text = coinController.CoinCount.ToString();
        }
    }
}