using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;



[assembly: OwinStartup(typeof(StakeholderManagement.Startup))]

namespace StakeholderManagement
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
