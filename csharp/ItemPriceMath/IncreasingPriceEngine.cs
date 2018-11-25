namespace csharp.ItemPriceMath
{
    public class IncreasingPriceEngine : IItemPriceEngine
    {

        private const int config_finallPriceDropDeadline = 0;
        private const int config_agedBrieMultiRatio = 2;

        public int GetQuality(Item item)
        {
            int result = 0;
            if (item.SellIn > config_finallPriceDropDeadline)
            {
                result = item.Quality + GlobalMathEngineConfig.QualityChangeStep;
            }
            else
            {
                result = item.Quality + (config_agedBrieMultiRatio * GlobalMathEngineConfig.QualityChangeStep);
            }

            return result;
        }
    }
}
