namespace csharp.ItemPriceMath
{
    public class LegendaryPriceEngine : IItemPriceEngine
    {
        public int GetQuality(Item item)
        {
            return item.Quality;
        }
    }
}
