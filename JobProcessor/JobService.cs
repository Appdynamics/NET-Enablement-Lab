using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace JobProcessor
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        private static JobCore core = new JobCore();

        protected override void OnStart(string[] args)
        {
            core.Start();
        }

        protected override void OnStop()
        {
            core.Stop();
        }
    }
}
