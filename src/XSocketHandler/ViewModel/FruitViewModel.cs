using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XSocketsDemo.Core;

namespace XSocketHandler.ViewModel
{
    public class FruitViewModel : ViewModelBase
    {
        public string Name { get; set; }

        /// <summary>
        /// Ctor, will transform a EF entity to a viewmodel
        /// </summary>
        /// <param name="p"></param>
        public FruitViewModel(Fruit f):base(f)
        {            
            this.Name = f.Name;
        }

    }
}
