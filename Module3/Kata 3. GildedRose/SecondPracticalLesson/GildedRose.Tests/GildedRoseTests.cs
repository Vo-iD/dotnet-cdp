using System.Linq;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class GildedRoseTests
    {
        private GildedRose _gildedRose;

        [Test]
        public void Should_Keep_Quality_In_Range_Zero_To_Fifty()
        {
            var items = TestDataContainer.GetDefaultItemList();
            _gildedRose = new GildedRose(items);

            UpdateQuality(_gildedRose);

            foreach (var item in items)
            {
                Assert.IsTrue(item.Quality >= 0 && item.Quality <= 50);
            }
        }

        [Test]
        public void Should_Degrade_Qulatity_Twice_As_Fast_After_Passed_Sell_By_Date_For_Aged_Brie()
        {
            var items = TestDataContainer.GetListWithAgedBrieOnly();
            _gildedRose = new GildedRose(items);

            UpdateQuality(_gildedRose, 4);

            Assert.AreEqual(15, items.First().Quality);
        }

        [Test]
        public void Should_Increase_Quality_For_Aged_Brie_The_Older_It_Gets()
        {
            var items = TestDataContainer.GetListWithAgedBrieOnly();
            _gildedRose = new GildedRose(items);

            _gildedRose.UpdateQuality();
            var firstDayQuality = items.First().Quality;

            _gildedRose.UpdateQuality();
            var secondDayQuality = items.First().Quality;

            Assert.IsTrue(secondDayQuality > firstDayQuality);
        }

        [Test]
        public void Should_Increase_Quality_For_Backstage_Passes_The_Older_It_Gets()
        {
            var items = TestDataContainer.GetListWithAgedBackstagePasses();
            _gildedRose = new GildedRose(items);

            _gildedRose.UpdateQuality();
            var firstDayQuality = items.First().Quality;

            _gildedRose.UpdateQuality();
            var secondDayQuality = items.First().Quality;

            Assert.IsTrue(secondDayQuality > firstDayQuality);
        }

        [Test]
        public void Should_Increase_Quality_For_Backstage_By_Two_If_Days_Are_In_Range_Five_To_Ten()
        {
            var items = TestDataContainer.GetListWithAgedBackstagePasses();
            _gildedRose = new GildedRose(items);

            UpdateQuality(_gildedRose, 12);

            Assert.AreEqual(24, items.First().Quality);
        }

        [Test]
        public void Should_Increase_Quality_For_Backstage_By_Three_If_Days_Are_In_Range_Zero_To_Five()
        {
            var items = TestDataContainer.GetListWithAgedBackstagePasses();
            _gildedRose = new GildedRose(items);

            UpdateQuality(_gildedRose, 16);

            Assert.AreEqual(33, items.First().Quality);
        }

        [Test]
        public void Should_Dropt_Quality_To_Zero_For_Backstage_After_The_Concert()
        {
            var items = TestDataContainer.GetListWithAgedBackstagePasses();
            _gildedRose = new GildedRose(items);

            UpdateQuality(_gildedRose, 21);

            Assert.AreEqual(0, items.First().Quality);
        }

        [Test]
        public void Should_Not_Change_Quality_For_Sulfuras()
        {
            var items = TestDataContainer.GetListWithSulfurasOnly();
            var startedQuality = items.First().Quality;
            _gildedRose = new GildedRose(items);

            UpdateQuality(_gildedRose);

            Assert.AreEqual(startedQuality, items.First().Quality);
        }

        [Test]
        public void Should_Decrease_Days_For_Not_Specified_Item()
        {
            var items = TestDataContainer.GetListWithoutSpecifiedItems();
            var startedSellIn = items.First().SellIn;
            _gildedRose = new GildedRose(items);

            UpdateQuality(_gildedRose, 1);

            Assert.AreEqual(startedSellIn - 1, items.First().SellIn);
        }

        [Test]
        public void Should_Decrease_Quality_For_Not_Specified_Item()
        {
            var items = TestDataContainer.GetListWithoutSpecifiedItems();
            var startedQuality = items.First().Quality;
            _gildedRose = new GildedRose(items);

            UpdateQuality(_gildedRose, 1);

            Assert.AreEqual(startedQuality - 1, items.First().Quality);
        }

        [Test]
        public void Should_Decrease_Quality_For_Not_Specified_Item_If_SellIn_Less_Than_Zero()
        {
            var items = TestDataContainer.GetListWithoutSpecifiedItemsWithZeroSellIn();
            _gildedRose = new GildedRose(items);
            var expectedQuality = items.First().Quality - 2;

            UpdateQuality(_gildedRose, 1);

            Assert.AreEqual(expectedQuality, items.First().Quality);
        }

        [Test]
        public void Should_Decrease_Quality_By_Two_Each_Day_If_Sell_In_More_Than_Zero()
        {
            var items = TestDataContainer.GetListWithConjuredOnly();
            var expectedQuality = items.First().Quality - 2;
            _gildedRose = new GildedRose(items);

            UpdateQuality(_gildedRose, 1);

            Assert.AreEqual(expectedQuality, items.First().Quality);
        }

        [Test]
        public void Should_Decrease_Quality_By_Four_Each_Day_If_Sell_In_Less_Than_Zero()
        {
            var items = TestDataContainer.GetListWithConjuredOnlyWithZeroSellIn();
            var expectedQuality = items.First().Quality - 4;
            _gildedRose = new GildedRose(items);

            UpdateQuality(_gildedRose, 1);

            Assert.AreEqual(expectedQuality, items.First().Quality);
        }

        private void UpdateQuality(GildedRose gildedRose, int times = 50)
        {
            for (var t = 0; t < times; t++)
            {
                gildedRose.UpdateQuality();
            }
        }
    }
}
