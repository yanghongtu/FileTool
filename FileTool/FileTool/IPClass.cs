using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace ToolHelper
{
    /// <summary>
    /// 对IP地址和适配器进行修改的类
    /// </summary>
    public class IPClass:IDisposable
    {
        /// <summary>
        /// 指定适配器名称   修改IP地址
        /// </summary>
        /// <param name="name">适配器名称</param>
        /// <param name="ip">ip地址</param>
        /// <param name="netsub">子网掩码</param>
        /// <param name="gateway">网关</param>
        /// <returns>返回 是否修改成功</returns>
        public bool ModifyIPAddress(string name,string ip, string netsub, string gateway)
        {
            bool result=false;
            ManagementObject mo = null;
            ManagementObjectCollection moc = this.mc_Win32_NetworkAdapter.GetInstances();
            foreach (ManagementObject item in moc)
            {
                if (item["NetConnectionID"] != null && item["NetConnectionID"].ToString().Trim() == name)
                {
                    mo = item;
                    break;
                }
            }
            string Description = mo["Name"].ToString().Trim();
            ManagementObjectCollection moc_config = this.mc_Win32_NetworkAdapterConfiguration.GetInstances();
            foreach (ManagementObject item in moc_config)
            {
                if (item["Description"] != null && item["Description"].ToString().Trim() == Description)
                {
                    string[] temp_ip = new string[] {ip};
                    string[] temp_netsub = new string[] { netsub};

                    item.InvokeMethod("EnableStatic", new object[] { temp_ip, temp_netsub });
                    string[] temp_gateway = new string[] { gateway};
                    item.InvokeMethod("SetGateways", new object[] { temp_gateway });
                }
            }



            result = true;
            return result;
        }
        /// <summary>
        /// 开启或者禁止指定的 网络适配器
        /// </summary>
        /// <param name="name">网络适配器名称</param>
        /// <param name="isEnable">是否允许开启</param>
        /// <returns>是否执行成功</returns>
        public bool EnableOrDisableAdapter(string name,bool isEnable)
        {
            ManagementObject mo = null;
            ManagementObjectCollection moc = this.mc_Win32_NetworkAdapter.GetInstances();
            foreach (ManagementObject item in moc)
            {
                if (item["NetConnectionID"] != null && item["NetConnectionID"].ToString().Trim() == name)
                {
                    mo = item;
                    break;
                }
            }
            if (mo == null)
            {
                return false;
            }
            else
            {
                if (isEnable)
                {
                    mo.InvokeMethod("Enable", new object[] { });
                }
                else
                {
                    mo.InvokeMethod("Disable", new object[] { });
                }
                return true;
            }
        }
        /// <summary>
        /// 网络是否可用  包括适配器被禁用 和网络没有连接
        /// </summary>
        /// <param name="name">适配器名称</param>
        /// <returns>返回网络是否可用</returns>
        public bool IsEnableAdapter(string name)
        {
            ManagementObject mo = null;
            ManagementObjectCollection moc = this.mc_Win32_NetworkAdapter.GetInstances();
            foreach (ManagementObject item in moc)
            {
                if (item["NetConnectionID"] != null && item["NetConnectionID"].ToString().Trim() == name)
                {
                    mo = item;
                    break;
                }
            }
            if (mo == null)
            {
                return false;
            }
            else
            {
                return (bool)mo["NetEnabled"];
            }
        }
        private volatile ManagementClass mc_Win32_NetworkAdapterConfiguration = null;
        private ManagementClass GetWin32_NetworkAdapterConfiguration()
        {
            if (mc_Win32_NetworkAdapterConfiguration == null)
            {
                mc_Win32_NetworkAdapterConfiguration = new ManagementClass("Win32_NetworkAdapterConfiguration");
            }
            return this.mc_Win32_NetworkAdapterConfiguration;
        }
        private volatile ManagementClass mc_Win32_NetworkAdapter = null;
        private ManagementClass GetWin32_NetworkAdapter()
        {
            if (mc_Win32_NetworkAdapter == null)
            {
                mc_Win32_NetworkAdapter = new ManagementClass("Win32_NetworkAdapter");
            }
            return this.mc_Win32_NetworkAdapter;
        }

        #region IDisposable 成员
        /// <summary>
        /// 释放wmi资源
        /// </summary>
        public void Dispose()
        {
            this.mc_Win32_NetworkAdapter.Dispose();
            this.mc_Win32_NetworkAdapter = null;
            this.mc_Win32_NetworkAdapterConfiguration.Dispose();
            this.mc_Win32_NetworkAdapterConfiguration = null;

        }

        #endregion
    }
}
