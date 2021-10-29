using Xunit;
using GildedRose.Console;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Tests {
    public class TestAssemblyTests {
        [Fact]
        public void TestTheTruth() {
            Assert.True(true);
        }


        [Fact]
        public void TestAgedBrie() {
            var defaultItems = Program.insertDefaultItems();
            var brieQuality = defaultItems.First(e => e.Name == "Aged Brie").Quality;
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.First(e => e.Name == "Aged Brie").Quality;


            Assert.Equal(brieQuality + 1, actual);

        }

        [Fact]
        public void TestSulfuras() {
            var defaultItems = Program.insertDefaultItems();
            var sulfurasQuality = defaultItems.Where(e => e.Name == "Sulfuras, Hand of Ragnaros").First().Quality;
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "Sulfuras, Hand of Ragnaros").First().Quality;


            Assert.Equal(sulfurasQuality, actual);

        }

        [Fact]
        public void TestBackStagePasses15Days() {
            var defaultItems = Program.insertDefaultItems();
            var backStagePasses = defaultItems.Where(e => e.Name == "Backstage passes to a TAFKAL80ETC concert").First().Quality;
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "Backstage passes to a TAFKAL80ETC concert").First().Quality;


            Assert.Equal(backStagePasses + 1, actual);

        }

        [Fact]
        public void TestBackStagePasses9Days() {
            var defaultItems = Program.insertDefaultItems();
            defaultItems.Add(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 20, SellIn = 9 });
            var backStagePasses = defaultItems.Where(e => e.Name == "Backstage passes to a TAFKAL80ETC concert").Last().Quality;
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "Backstage passes to a TAFKAL80ETC concert").Last().Quality;


            Assert.Equal(backStagePasses + 2, actual);

        }

        [Fact]
        public void TestBackStagePasses4Days() {
            var defaultItems = Program.insertDefaultItems();
            defaultItems.Add(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 20, SellIn = 4 });
            var backStagePasses = defaultItems.Where(e => e.Name == "Backstage passes to a TAFKAL80ETC concert").Last().Quality;
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "Backstage passes to a TAFKAL80ETC concert").Last().Quality;


            Assert.Equal(backStagePasses + 3, actual);

        }

        [Fact]
        public void TestBackStagePasses50Quality() {
            var defaultItems = Program.insertDefaultItems();
            defaultItems.Add(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 50, SellIn = 4 });
            var expected = defaultItems.Where(e => e.Name == "Backstage passes to a TAFKAL80ETC concert").Last().Quality;
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "Backstage passes to a TAFKAL80ETC concert").Last().Quality;


            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestElixirGoesBad() {
            var defaultItems = Program.insertDefaultItems();
            var expected = defaultItems.Where(e => e.Name == "Elixir of the Mongoose").First().Quality;
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "Elixir of the Mongoose").First().Quality;


            Assert.Equal(expected - 1, actual);

        }

        [Fact]
        public void TestSellInGoesDay() {
            var defaultItems = Program.insertDefaultItems();
            var expected = defaultItems.Where(e => e.Name == "+5 Dexterity Vest").First().SellIn;
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "+5 Dexterity Vest").First().SellIn;


            Assert.Equal(expected - 1, actual);

        }

        [Fact]
        public void TestConjuredQualityBeforeSellIn0() {
            var defaultItems = Program.insertDefaultItems();
            var expected = defaultItems.Where(e => e.Name == "Conjured Mana Cake").First().Quality;
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "Conjured Mana Cake").First().Quality;

            Assert.Equal(expected - 2, actual);
        }

        [Fact]
        public void TestConjuredQualitySellIn0() {
            var defaultItems = Program.insertDefaultItems();
            defaultItems.Add(new Item() { Name = "Conjured Rotten Cake", SellIn = 0, Quality = 6 });
            var expected = defaultItems.Where(e => e.Name == "Conjured Rotten Cake").First().Quality;
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "Conjured Rotten Cake").First().Quality;

            Assert.Equal(expected - 4, actual);
        }

        [Fact]
        public void TestConjuredQualityNotNegative() {
            var defaultItems = Program.insertDefaultItems();
            defaultItems.Add(new Item() { Name = "Conjured Milk Cake", SellIn = 0, Quality = 3 });
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "Conjured Milk Cake").First().Quality;

            Assert.Equal(0, actual);
        }

        [Fact]
        public void TestDefaultQualityNotNegative() {
            var defaultItems = Program.insertDefaultItems();
            defaultItems.Add(new Item() { Name = "+6 Dexterity Vest", SellIn = 0, Quality = 0 });
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "+6 Dexterity Vest").First().Quality;

            Assert.Equal(0, actual);
        }

        [Fact]
        public void TestQualityOfConcertThing() {
            var defaultItems = Program.insertDefaultItems();
            defaultItems.Add(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 2 });
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "Backstage passes to a TAFKAL80ETC concert").Last().Quality;

            Assert.Equal(0, actual);
        }


    }
}