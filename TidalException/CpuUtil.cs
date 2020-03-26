using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace TidalException
{
    class CpuUtil
    {
        public static int GetCpuCores()
        {

            ManagementClass c = new ManagementClass(new ManagementPath("Win32_Processor"));
            // Get the properties in the class
            ManagementObjectCollection moc = c.GetInstances();

            //return properties["NumberOfCores"].Value;
            string str = "";
            foreach (ManagementObject mo in moc)
            {
                PropertyDataCollection properties = mo.Properties;
                //获取内核数代码
                //str += "物理内核数:" + properties["NumberOfCores"].Value + "\r";
                //str += "逻辑内核数:" + properties["NumberOfLogicalProcessors"].Value + "\r";
                //其他属性获取代码
                //foreach (PropertyData property in properties)
                //{
                //    str += property.Name + ":" + property.Value + "\r";
                //}

                return int.Parse(properties["NumberOfCores"].Value.ToString());
            }
            //return str;

            return 0;

        }

    }
}
