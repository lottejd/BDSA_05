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
            var brieQuality = defaultItems.Where(e => e.Name == "Aged Brie").First().Quality;
            Program.UpdateQuality(defaultItems);
            var actual = defaultItems.Where(e => e.Name == "Aged Brie").First().Quality;


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


    }
}