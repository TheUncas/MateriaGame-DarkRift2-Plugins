using System;
using DarkRift.Server;

namespace MateriaGame.DarkRift.Plugins
{
    public class FourthPlugin : Plugin
    {
        #region Plugin implementation
        public override bool ThreadSafe => false;

        public override Version Version => new Version(1, 0, 0);

        public FourthPlugin(PluginLoadData pluginLoadData) : base(pluginLoadData)
        {
            //Do nothing here
            //Eventually, store pluginLoadData data if needed
        }
        #endregion

        #region Implementation

        public void Init()
        {
            Console.WriteLine("FourthPlugin plugin initialization");
        }

        #endregion
    }
}
