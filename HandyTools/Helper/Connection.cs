using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using System.Runtime.InteropServices;

namespace HandyTools.Helper
{
    class Connection
    {
        public Application InventorApplication { get; set; }

        public Application GetApp
        {

            get
            {
                try
                {
                    return (Application)Marshal.GetActiveObject("Inventor.Application");
                }
                catch { return null; }
            }
        }

        public void SetApp()
        {
            InventorApplication = GetApp;
        }

    }

}
