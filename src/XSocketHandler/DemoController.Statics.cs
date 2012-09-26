using System;
using System.Collections.Generic;
using System.Linq;
using XSocketHandler.ViewModel;
using XSockets.Core.XSocket.Event.Attributes;
using XSockets.Core.XSocket.Helpers;
using XSocketsDemo.Core;

namespace XSocketHandler
{
	public partial class DemoController
	{
        #region "private static methods"
        private static List<PersonViewModel> GetAllPeopleViewModel(XSocketsDemo.Data.EfContext Db)
        {
            var json = new List<PersonViewModel>();

            foreach (var person in Db.People.ToList().OrderBy(p => p.Name))
            {
                json.Add(new PersonViewModel(person));
            }
            return json;
        }

        private static List<FruitViewModel> GetAllFruitsViewModel(XSocketsDemo.Data.EfContext Db)
        {
            var json = new List<FruitViewModel>();

            foreach (var fruit in Db.Fruits.ToList().OrderBy(p => p.Name))
            {
                json.Add(new FruitViewModel(fruit));
            }
            return json;
        }

        private static List<ColorViewModel> GetAllColorsViewModel(XSocketsDemo.Data.EfContext Db)
        {
            var json = new List<ColorViewModel>();

            foreach (var color in Db.Colors.ToList().OrderBy(p => p.Name))
            {
                json.Add(new ColorViewModel(color));
            }
            return json;
        }
        #endregion
    }
}
