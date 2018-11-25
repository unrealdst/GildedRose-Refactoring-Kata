using csharp.ItemPriceMath;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        private PriceEngineFactory priceEngineFactory;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            priceEngineFactory = new PriceEngineFactory();
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                IItemPriceEngine priceEngine = priceEngineFactory.GetEngine(item.Name);
                item.Quality = priceEngine.GetQuality(item);

                QualityRange(item);
                SellInUpdate(item);
            }
        }

        private void QualityRange(Item item)
        {
            if (item.Name != GlobalMathEngineConfig.Legendary)
            {
                if (item.Quality > GlobalMathEngineConfig.MaxQuality)
                {
                    item.Quality = GlobalMathEngineConfig.MaxQuality;
                }

                if (item.Quality < GlobalMathEngineConfig.MinQuality)
                {
                    item.Quality = GlobalMathEngineConfig.MinQuality;
                }
            }
        }

        private void SellInUpdate(Item item)
        {
            if (item.Name != GlobalMathEngineConfig.Legendary)
            {
                item.SellIn = item.SellIn - 1;
            }
        }
    }
}
