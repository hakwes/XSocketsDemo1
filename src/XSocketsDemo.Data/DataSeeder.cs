using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XSocketsDemo.Core;

namespace XSocketsDemo.Data
{
    /// <summary>
    /// Insert test data on creation
    /// </summary>
    public class DataSeeder : DropCreateDatabaseIfModelChanges<EfContext>
    {
        private Dictionary<string, int> People = new Dictionary<string, int>() { { "Ben Hur", 23 }, { "Uffe Bjorklund", 35 }, { "Steven Sanderson", 37 }, { "Hakim El Hattab", 25 }, { "Magnus Thor", 31 } };
        private string[] Colors = new string[]{"Yellow","Brown","Blue","Red","Green","Pink","Black"};
        private string[] Fruits = new string[] { "Banana", "Apple", "Grape", "Strawberry", "Pear" };
        protected override void Seed(EfContext context)
        {
            foreach (var color in Colors)
            {
                context.Colors.Add(new Color { Name = color });
            }

            foreach (var fruit in Fruits)
            {
                context.Fruits.Add(new Fruit { Name = fruit });
            }

            context.SaveChanges();

            foreach (var person in People)
            {
                var fruit = context.Fruits.OrderBy(r => Guid.NewGuid()).Take(1).Single();
                var color = context.Colors.OrderBy(r => Guid.NewGuid()).Take(1).Single();
                context.People.Add(new Person
                    {Age = person.Value, Name = person.Key, FavoriteFruit = fruit, FavoriteColor = color, GenderValue = Gender.Male});
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
