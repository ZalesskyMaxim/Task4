using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public partial class ManagerService : ServiceBase
    {
        private Watcher _watcher;
        public ManagerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _watcher = new Watcher();
        }

        protected override void OnStop()
        {
            _watcher.Dispose();
        }
    }
}
