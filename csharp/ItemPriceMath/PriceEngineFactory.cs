namespace csharp.ItemPriceMath
{
    public class PriceEngineFactory
    {
        public IItemPriceEngine GetEngine(string itemName)
        {
            switch (itemName)
            {
                case GlobalMathEngineConfig.Increasing:
                    return new IncreasingPriceEngine();
                case GlobalMathEngineConfig.Legendary:
                    return new LegendaryPriceEngine();
                case GlobalMathEngineConfig.Ticket:
                    return new TicketpriceEngine();
                default:
                    return new DefaultPriceEnigne();
            }
        }
    }
}
