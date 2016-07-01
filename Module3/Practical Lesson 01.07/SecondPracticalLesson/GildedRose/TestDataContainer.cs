using System.Collections.Generic;

namespace GildedRose
{
    public static class TestDataContainer
    {
        public static IList<Item> GetDefaultItemList()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 50},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            return items;
        }

        public static IList<Item> GetListWithAgedBrieOnly()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 3, Quality = 10}
            };

            return items;
        }

        public static IList<Item> GetListWithSulfurasOnly()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 3, Quality = 10}
            };

            return items;
        }

        public static IList<Item> GetListWithConjuredOnly()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            return items;
        }

        public static IList<Item> GetListWithConjuredOnlyWithZeroSellIn()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 6}
            };

            return items;
        }

        public static IList<Item> GetListWithAgedBackstagePasses()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10}
            };

            return items;
        }

        public static IList<Item> GetListWithoutSpecifiedItems()
        {
            return new List<Item>
            {
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            };
        }

        public static IList<Item> GetListWithoutSpecifiedItemsWithZeroSellIn()
        {
            return new List<Item>
            {
                new Item {Name = "Elixir of the Mongoose", SellIn = 0, Quality = 7},
            };
        }
    }
}
