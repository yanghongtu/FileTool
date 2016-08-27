using System;
using System.Collections.Generic;
using System.Text;

namespace FileTool
{
    public class IniFileClass
    {
        /// <summary>
        /// 实用单实例模式
        /// </summary>
        private static readonly IniFileClass _iniFileClass = new IniFileClass();
        /// <summary>
        /// 利用属性快速获取实例
        /// </summary>
        public static IniFileClass IniFileClassInstance
        {
            //get { return IniFileClass._iniFileClass; }
            get { return new IniFileClass(); }
        }

        private List<ThreadGradeData> _list = new List<ThreadGradeData>();
        /// <summary>
        /// 构造函数 私有化
        /// </summary>
        private IniFileClass()
        {
            //获取配置信息里面的数据
            Array ar_inifilefield = Enum.GetValues(typeof(IniFileFields));
            Array ar_inifilekey = Enum.GetValues(typeof(IniFileKeys));
            foreach (IniFileFields f in ar_inifilefield)
            {
                foreach (IniFileKeys k in ar_inifilekey)
                {
                    //_list.Add( new ThreadGradeData(f.ToString(),k.ToString(),  SetFileControl.GetIniFileInfo(f.ToString(), k.ToString())));
                }
            }
        }

        public string GetValue(IniFileFields field, IniFileKeys key)
        {
            string result="";
            foreach (ThreadGradeData tgd in _list)
            {
                if (tgd.OneGradeData==field.ToString()&&tgd.TwoGradeData==key.ToString())
                {
                    result = tgd.ThreeGradeData;
                }
            }
            return result;
        }
    }
    public class ThreadGradeData
    {
        private string _oneGradeData;

        public string OneGradeData
        {
            get { return _oneGradeData; }
            set { _oneGradeData = value; }
        }
        private string _twoGradeData;

        public string TwoGradeData
        {
            get { return _twoGradeData; }
            set { _twoGradeData = value; }
        }
        private string _threeGradeData;

        public string ThreeGradeData
        {
            get { return _threeGradeData; }
            set { _threeGradeData = value; }
        }
        public ThreadGradeData(string s1,string s2,string s3)
        {
            this._oneGradeData = s1;
            this._twoGradeData = s2;
            this._threeGradeData = s3;
        }
    }
    public enum IniFileFields
    {
        填单机参数
    }
    public enum IniFileKeys
    {
        管理密码,
        自动关机时间,
        调试模式,
        是否屏蔽ctrlaltdel,
        默认地区,
        指示灯控制器端口,
        操作系统,
        刷卡间隔时间毫秒,
        编码,
        开户行是否到支行,
        银行名称,
        打印机名称,
        系统退出密码,
        市或县,
        读卡器类型,
        身份证阅读器名称,
        芯片卡阅读器名称,
        联网模式,
        网点机构代码,
        设备编号,
        银行代码,
        WebServiceUrl,
        身份证读取间隔,
        联想字库容量,
        开启数字联想,
        接口数据保存天数,
        默认市,
        默认县,
        操作系统位数,
        是否在填单前弹出单据图片,
        是否要填单前必须要放纸进去,
        打印机界面退出时间,
        是否客户定制,
        填单前弹出单据图片提示,
        是否直辖市打印到省,
        激光打印机名称,
        无接口联网模式,
        身份证验证URL,
        数据服务启动命令,
        复印身份证件,
        无接口连接地址,
        无接口连接端口,
        是否监视打印机,
        邮政编码
    }
    }
