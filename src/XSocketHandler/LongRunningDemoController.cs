using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using XSocketHandler.ViewModel;
using XSockets.Core.Globals;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Interface;
using XSockets.Plugin.Framework;
using XSockets.Plugin.Framework.Attributes;
using XSocketsDemo.Data;
using XSockets.Core.XSocket.Helpers;

namespace XSocketHandler
{
    /// <summary>
    /// This is an internal plugin for long running tasks... 
    /// Users/CLients cant create an instance of this... Its a singleton in the server.
    /// 
    /// However, it can perform tasks and delegate information to clients.
    /// 
    /// This one will just update stuff randomly and tell the clients that stuff happend.
    /// </summary>
    [Export(typeof(IXBaseSocket))]
    [XBaseSocketMetadata("LongRunningDemoController", Constants.GenericTextBufferSize, PluginRange.Internal)]
    public class LongRunningDemoController : XBaseSocket
    {
        private static Timer timer;
        private static Random _r = new Random();
        private static int Rnd()
        {
            return _r.Next(10,100);
        }

        private static DemoController demoController;

        static LongRunningDemoController()
        {
            demoController = new DemoController();
            timer = new Timer(8000);

            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var ctx = getContext();
                var randomPerson = ctx.People.OrderBy(r => Guid.NewGuid()).Take(1).Single();
                randomPerson.FavoriteColorId = ctx.Colors.OrderBy(r => Guid.NewGuid()).Take(1).Single().Id;
                randomPerson.FavoriteFruitId = ctx.Fruits.OrderBy(r => Guid.NewGuid()).Take(1).Single().Id;
                randomPerson.Age = Rnd();

                ctx.SaveChanges();
                var json = new PersonViewModel(randomPerson);
                demoController.RouteTo(demoController.Alias, json, Commands.PersonTrigger.Updated);
            }
            catch
            {
                
            }

        }


        /// <summary>
        /// Returns a new instance på EF context for CRUD operations
        /// </summary>
        /// <returns></returns>
        private static EfContext getContext()
        {
            return new EfContext();
        }

        /// <summary>
        /// Mandatory method that will save time creating instances, avoiding reflection in server.
        /// </summary>
        /// <returns></returns>
        public override IXBaseSocket NewInstance()
        {
            return new DemoController();
        }
    }
}
