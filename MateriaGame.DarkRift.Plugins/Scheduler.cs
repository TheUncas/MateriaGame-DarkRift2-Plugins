using DarkRift.Server;
using System;
using System.Threading.Tasks;

namespace MateriaGame.DarkRift.Plugins
{
    /// <summary>
    /// Plugin wich schedule initialization of darkrift plugins
    /// </summary>
    class Scheduler : Plugin
    {
        #region Plugin implementation

        public override bool ThreadSafe => false;
        public override Version Version => new Version(1, 0, 0);

        public Scheduler(PluginLoadData pluginLoadData) : base(pluginLoadData)
        {
            //Initialize some data
            //...
            Console.WriteLine("Initialize some stuff here that is needed in plugins");

            //Initialize plugins async - enable continue execution
            InitPluginsAsync(PluginManager);

            Console.WriteLine("Scheduler instanciated successfully");
        }

        /// <summary>
        /// Initialize plugins
        /// </summary>
        /// <param name="pPluginManager"></param>
        /// <returns></returns>
        private static async Task InitPluginsAsync(IPluginManager pPluginManager)
        {
            //Free execution
            await Task.Yield();

            bool arePluginsLoaded = false;
            while (!arePluginsLoaded)
            {
                try
                {
                    pPluginManager.GetPluginByType<Scheduler>();
                    arePluginsLoaded = true;
                }
                catch (Exception)
                {
                    //Console.WriteLine("Darkrift hasn't finished to load plugins");
                }
            }

            //Initialize plugins
            Console.WriteLine("Scheduler initialization start");
            ((FirstPlugin)pPluginManager.GetPluginByType<FirstPlugin>()).Init();
            ((SecondPlugin)pPluginManager.GetPluginByType<SecondPlugin>()).Init();
            ((ThirdPlugin)pPluginManager.GetPluginByType<ThirdPlugin>()).Init();
            ((FourthPlugin)pPluginManager.GetPluginByType<FourthPlugin>()).Init();
            ((FifthPlugin)pPluginManager.GetPluginByType<FifthPlugin>()).Init();
            Console.WriteLine("Scheduler initialization finished");
        }

        #endregion
    }
}
