using System;
using System.Linq;
using XSockets.Core.Globals;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Event.Attributes;
using XSockets.Core.XSocket.Interface;
using XSockets.Plugin.Framework.Attributes;
using XSocketsDemo.Core;
using XSocketsDemo.Data;

namespace XSocketHandler
{
    /// <summary>
    /// This is a Controller (plugin) in XSockets.
    /// You can look at it as an MVC Controller, with the difference that the communication here is full duplex, NOT HTTP!
    /// </summary>
    [Export(typeof(IXBaseSocket))]
    [XBaseSocketMetadata("DemoController", Constants.GenericTextBufferSize)]
    public partial class DemoController : XBaseSocket
    {        
        /// <summary>
        /// Returns a new instance på EF context for CRUD operations
        /// </summary>
        /// <returns></returns>
        public EfContext getContext()
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