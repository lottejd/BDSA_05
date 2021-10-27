using System.Collections.Generic;

namespace GildedRose.Console {
    public class Program {
        IList<Item> Items;
        static void Main(string[] args) {
            System.Console.WriteLine("OMGHAI!");

            UpdateQuality(insertDefaultItems());

            System.Console.ReadKey();

        }

        public static void UpdateQuality(IList<Item> items) {
            foreach (Item item in items) {

                item.SellIn--; // A day goes by.
                switch (item.Name) {
                    case "Aged Brie":
                        if (item.Quality <= 49) {
                            item.Quality++;
                        }
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        switch (item.SellIn) {
                            case <= 0: item.Quality = 0; break;
                            case < 6: item.Quality += 3; break;
                            case < 11: item.Quality += 2; break;
                            default: item.Quality += 1; break;
                        }
                        if (item.Quality > 50) {
                            item.Quality = 50;
                        }
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    case string a when a.Contains("Conjured"):
                        switch (item.SellIn) {
                            case < 0: item.Quality -= 4; break;
                            case > 0: item.Quality -= 2; break;
                        }
                        switch (item.Quality) {
                            case < 0: item.Quality = 0; break;
                        }
                        break;
                    default:
                        if (item.SellIn <= 0) {
                            item.Quality -= 2;
                        } else {
                            item.Quality--;
                        }

                        if (item.Quality <= 0) {
                            item.Quality = 0;
                        }
                        break;
                }
            }
        }

        public static IList<Item> insertDefaultItems() {
            return new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

        }
    }

    public class Item {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}