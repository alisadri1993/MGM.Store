using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.console.Model
{
    public sealed class ApplicationSetting
    {
        //        public string Name { get; set; } = "sadri";
        private static readonly object lockObject = new object();
        private ApplicationSetting() { }
        private static ApplicationSetting instance = null;
        public static ApplicationSetting Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ApplicationSetting();
                    }
                }
                return instance;
            }
        }
    }




}
