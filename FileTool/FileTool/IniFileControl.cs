using System;
using System.Collections.Generic;
using System.Text;

namespace FileTool
{
    public class IniFileControl
    {
        private string _filePath = null;
        public IniFileControl(string filePath)
        {
            this._filePath = filePath;
        }
        /// <summary>
        /// 读取ini键值
        /// </summary>
        /// <param name="valOne">键主标题</param>
        /// <param name="valTwo">键名称</param>
        /// <returns>键值</returns>
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        public string ReadIniField(string valOne,string valTwo)
        {
            StringBuilder str = new StringBuilder();
            str.Capacity = 250;
            WinAPI.WinAPI.GetPrivateProfileString(valOne, valTwo, "", str, 300, this._filePath);
            return str.ToString();
        }
        /// <summary>
        /// 写入ini文件
        /// </summary>
        /// <param name="valOne">appName</param>
        /// <param name="valTwo">键名称</param>
        /// <param name="value">键值</param>
        /// <returns>是否执行成功</returns>
        public bool WriteIniField(string valOne, string valTwo, string value)
        {
            return WinAPI.WinAPI.WritePrivateProfileString(valOne, valTwo, value, this._filePath);
        }
    }
}
