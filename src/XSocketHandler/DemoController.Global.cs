using System;
using System.Collections.Generic;
using System.Linq;
using XSocketHandler.ViewModel;
using XSockets.Core.XSocket.Event.Attributes;
using XSockets.Core.XSocket.Helpers;
using XSocketsDemo.Core;
using XSockets.Core.XSocket.Exceptions;

namespace XSocketHandler
{
    /// <summary>
    /// A partial of our DemoController
    /// This one will handle Global stuff... like collecting data from several entities and send back.
    /// </summary>
	public partial class DemoController
	{
        /// <summary>
        /// Probably called when the demo page is loaded...
        /// Will send back multiple stuff, but it´s smarter to do one DbCOntext
        /// and do multiple send back to the client then to open the context several times.        
        /// </summary>
        [HandlerEvent(Commands.GlobalBinding.Init)]
        public void GlobalInit()
        {
            try
            {
                var Db = this.getContext();
                //Collect data
                var jsonPeople = GetAllPeopleViewModel(Db);
                var jsonFruits = GetAllFruitsViewModel(Db);
                var jsonColors = GetAllColorsViewModel(Db);

                //Send data
                this.Send(jsonPeople, Commands.PersonTrigger.GetAll);
                this.Send(jsonFruits, Commands.FruitTrigger.GetAll);
                this.Send(jsonColors, Commands.ColorTrigger.GetAll);
            }
            catch(Exception ex)
            {
                this.DispatchError(ex, "Exception in GlobalInit");
            }
        }
    }
}
