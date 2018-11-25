namespace csharp.ItemPriceMath
{
    public class TicketpriceEngine : IItemPriceEngine
    {
        private const int config_slowValueIncrease = 2;
        private const int config_fastValueIncrease = 3;
        private const int config_slowIncreasDeadline = 10;
        private const int config_fastIncreasDeadline = 5;
        private const int config_afterFinallDeadline = 0;
        private const int config_finallPriceDropDeadline = 0;

        public int GetQuality(Item item)
        {
            var result = 0;
            if (item.SellIn <= config_fastIncreasDeadline)
            {
                result = item.Quality + (config_fastValueIncrease * GlobalMathEngineConfig.QualityChangeStep);
            }
            else if (item.SellIn <= config_slowIncreasDeadline)
            {
                result = item.Quality + (config_slowValueIncrease * GlobalMathEngineConfig.QualityChangeStep);
            }
            else
            {
                result = item.Quality + GlobalMathEngineConfig.QualityChangeStep;
            }

            if (item.SellIn <= config_finallPriceDropDeadline)
            {
                result = config_afterFinallDeadline;
            }

            return result;
        }
    }
}
