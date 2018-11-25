namespace csharp.ItemPriceMath
{
    public class DefaultPriceEnigne : IItemPriceEngine
    {
        private const int config_sellInDeadline = 0;
        private const int config_fastQualityDropRatio = 2;

        public int GetQuality(Item item)
        {
            int result = 0;
            if (item.SellIn <= config_sellInDeadline)
            {
                result = item.Quality - (config_fastQualityDropRatio * GlobalMathEngineConfig.QualityChangeStep);
            }
            else
            {
                result = item.Quality - GlobalMathEngineConfig.QualityChangeStep;
            }

            return result;
        }

        public int GetSellIn(Item item)
        {
            return item.SellIn - 1;
        }
    }
}
