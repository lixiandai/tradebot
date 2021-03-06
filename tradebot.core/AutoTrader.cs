using System;
using System.Threading.Tasks;

namespace tradebot.core
{
    public class AutoTrader
    {
        public ITradeAccount BuyAccount { get; set; }
        public ITradeAccount SellAccount { get; set; }
        public TradeInfo TradeInfo { get; set; }
        public AutoTrader(
            ITradeAccount buyAccount,
            ITradeAccount sellAccount,
            TradeInfo tradeInfo)
        {
            this.BuyAccount = buyAccount;
            this.BuyAccount = sellAccount;
            this.TradeInfo = tradeInfo;
        }
        public async Task Trade()
        {
            var plusPointToWin = 0.00000003M;
            await Task.WhenAll(
                this.BuyAccount.Buy(
                    TradeInfo.CoinQuantityAtBuy,
                    BuyAccount.TradeCoin.CoinPrice.AskPrice + plusPointToWin),
                this.SellAccount.Sell(
                    TradeInfo.CoinQuantityAtSell,
                    SellAccount.TradeCoin.CoinPrice.BidPrice - plusPointToWin)
            );
        }

        public void PrintDashboard(){
            Console.WriteLine(@"+--------------------------------------+
                                | SELL              | BUY              |
                                |-------------------|------------------|
                                | 0.00002608 BTC    | 0.00002508 BTC   |
                                | 18,000 ADA        | 17,000 ADA       |
                                |-------------------|------------------|
                                | Profit:                              |
                                +--------------------------------------+
            ");
        }
    }
}