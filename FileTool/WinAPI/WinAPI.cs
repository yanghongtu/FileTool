using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinAPI
{
    public class WinAPI
    {
        public const int WM_MOUSEFIRST = 0x0200;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_RBUTTONDBLCLK = 0x0206;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;
        public const int WM_MBUTTONDBLCLK = 0x0209;
        public const int WM_MOUSELAST = 0x0209;
        public const int WM_PAINT = 0x000F;
        public const int WM_HSCROLL = 0x0114;
        public const int WM_VSCROLL = 0x0115;
        public const int EM_POSFROMCHAR = 0x00D6;

        //控件切圆角
        [DllImport("gdi32.dll")]
        public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);

        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, Boolean bRedraw);

        public static void CutRound(Control c, int num)
        {
            int Rgn = CreateRoundRectRgn(0, 0, c.Width + 1, c.Height + 1, num, num);
            SetWindowRgn(c.Handle, Rgn, true);
        }

        /// <summary>
        /// 读ini配置文件
        /// </summary>
        /// <param name="lpApplicationName">键的主标题</param>
        /// <param name="lpKeyName">键名称</param>
        /// <param name="lpDefault"></param>
        /// <param name="lpReturnedString"></param>
        /// <param name="nSize">写入的缓存大小</param>
        /// <param name="lpFileName">绝对路径</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);
        /// <summary>
        /// 写ini配置文件
        /// </summary>
        /// <param name="lpApplicationName">键的主标题</param>
        /// <param name="lpKeyName">键名称</param>
        /// <param name="lpString">要写入的值</param>
        /// <param name="lpFileName">绝对路径</param>
        /// <returns>返回布尔类型</returns>
        [DllImport("kernel32.dll")]
        public static extern bool WritePrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpString,
            string lpFileName);
        //发送键值
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        //获得按键状态
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetKeyState")]
        public static extern int GetKeyState(
            int nVirtKey // Long，欲测试的虚拟键键码。对字母、数字字符（A-Z、a-z、0-9），用它们实际的ASCII值  
        );

        //判断插入符光标的闪烁频率
        [DllImport("user32.dll")]
        public static extern int GetCaretBlinkTime();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        //       Declare Function ShowWindow Lib "user32" Alias "ShowWindow" (ByVal hwnd As Long, ByVal nCmdShow As Long) As Long
        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        //*********************************************************************
        #region 国腾R100-01读卡函数

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int InitComm(int iPort);//打开端口

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int CloseComm();   //关闭端口

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int Authenticate();    //卡认证

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int Read_Content(int iActive); //读卡

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        static extern int GetPeopleName(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        static extern int GetPeopleSex(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        static extern int GetPeopleNation(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        static extern int GetPeopleBirthday(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        static extern int GetPeopleAddress(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        static extern int GetStartDate(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        static extern int GetEndDate(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        static extern int GetPeopleIDCode(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        static extern int GetDepartment(Byte[] buf, int iLen);

        public static string GetName()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetPeopleName(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }

        public static string GetSex()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetPeopleSex(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }

        public static string GetNation()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetPeopleNation(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }
        public static string GetBirthday()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetPeopleBirthday(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }
        public static string GetAddress()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetPeopleAddress(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }
        public static string GetStartDate()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetStartDate(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }
        public static string GetEndDate()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetEndDate(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }

        public static string GetIDCode()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetPeopleIDCode(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }

        public static string GetDepartment()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetDepartment(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }
        #endregion
        //**************************************************************************

        //*******************
        //BP8902刷卡器停止刷卡函数
        [DllImport("NTDeviceAPI.dll")]
        public static extern int AbortReader();
        //*************************

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr PostMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);


        //*************************************************************************************
        /// <summary>
        /// 发送arp数据包
        /// </summary>
        /// <param name="dest">目的地地址</param>
        /// <param name="host">发送给别人 可以不填</param>
        /// <param name="mac">返回的mac地址</param>
        /// <param name="length">返回的长度</param>
        /// <returns></returns>
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        /// <summary>
        /// 把字符串形式的ip地址转换为整数形式的网络字节序
        /// </summary>
        /// <param name="ip">字符串形式的ip地址</param>
        /// <returns></returns>
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip); 

    }
}
