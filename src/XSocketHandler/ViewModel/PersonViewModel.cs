using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XSocketsDemo.Core;

namespace XSocketHandler.ViewModel
{
    /// <summary>
    /// We need viewmodel for our EF entities since we will get circular references passing an EF object to JSON
    /// </summary>
    public class PersonViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public string GenderString {
            get { return Enum.GetName(typeof (Gender), this.Gender); }
        }

        public int FavoriteColorId { get; set; }
        public ColorViewModel FavoriteColor { get; set; }

        public int FavoriteFruitId { get; set; }
        public FruitViewModel FavoriteFruit { get; set; }

        /// <summary>
        /// Ctor, will transform a EF entity to a viewmodel
        /// </summary>
        /// <param name="p"></param>
        public PersonViewModel(Person p):base(p)
        {
            this.Age = p.Age;
            this.Name = p.Name;
            this.Gender = p.GenderValue;
            this.FavoriteColorId = p.FavoriteColorId;
            this.FavoriteFruitId = p.FavoriteFruitId;
            if(p.FavoriteColor != null)
                this.FavoriteColor = new ColorViewModel(p.FavoriteColor);
            if (p.FavoriteFruit != null) 
                this.FavoriteFruit = new FruitViewModel(p.FavoriteFruit);
        }
    }
}
