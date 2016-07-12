using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                    {
                        UpdateBrieQuality(item);
                        break;
                    }
                    case "Backstage passes to a TAFKAL80ETC concert":
                    {
                        UpdateBackstagePassesQuality(item);
                        break;
                    }
                    case "Conjured Mana Cake":
                    {
                        UpdateConjuredQuality(item);
                        break;
                    }
                    case "Sulfuras, Hand of Ragnaros":
                    {
                        UpdateSulfurasQuality();
                        break;
                    }
                    default:
                    {
                        UpdateUnknownItem(item);
                        break;
                    }
                }
            }
        }

        private void UpdateBrieQuality(Item brie)
        {
            brie.SellIn--;

            if (brie.Quality < 50)
            {
                brie.Quality++;
                if (brie.SellIn < 0 && brie.Quality < 50)
                {
                    brie.Quality++;
                }
            }
        }

        private void UpdateSulfurasQuality()
        {
        }

        private void UpdateBackstagePassesQuality(Item backstage)
        {
            backstage.SellIn--;

            if (backstage.Quality < 50)
            {
                backstage.Quality++;

                if (backstage.SellIn < 10 && backstage.Quality < 50)
                {
                    backstage.Quality++;
                }

                if (backstage.SellIn < 5 && backstage.Quality < 50)
                {
                    backstage.Quality++;
                }

                if (backstage.SellIn < 0)
                {
                    backstage.Quality = 0;
                }
            }
        }

        private void UpdateConjuredQuality(Item conjured)
        {
            conjured.SellIn--;

            if (conjured.SellIn >= 0)
            {
                if (conjured.Quality >= 2)
                {
                    conjured.Quality -= 2;
                }
            }
            else
            {
                if (conjured.Quality >= 4)
                {
                    conjured.Quality -= 4;
                }
            }
        }

        private void UpdateUnknownItem(Item unknown)
        {
            unknown.SellIn--;

            if (unknown.Quality > 0)
            {
                unknown.Quality--;
            }

            if (unknown.SellIn < 0 && unknown.Quality > 0)
            {
                unknown.Quality--;
            }
        }
    }
}
