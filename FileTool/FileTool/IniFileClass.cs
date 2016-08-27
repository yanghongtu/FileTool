using System;
using System.Collections.Generic;
using System.Text;

namespace FileTool
{
    ///// <summary>
    ///// 测试操作ini文件类
    ///// </summary>
    //public class IniFileClass
    //{
    //    /// <summary>
    //    /// 实用单实例模式
    //    /// </summary>
    //    private static readonly IniFileClass _iniFileClass = new IniFileClass();
    //    /// <summary>
    //    /// 利用属性快速获取实例
    //    /// </summary>
    //    public static IniFileClass IniFileClassInstance
    //    {
    //        //get { return IniFileClass._iniFileClass; }
    //        get { return new IniFileClass(); }
    //    }

    //    private List<ThreadGradeData> _list = new List<ThreadGradeData>();
    //    /// <summary>
    //    /// 构造函数 私有化
    //    /// </summary>
    //    private IniFileClass()
    //    {
    //        //获取配置信息里面的数据
    //        Array ar_inifilefield = Enum.GetValues(typeof(IniFileFields));
    //        Array ar_inifilekey = Enum.GetValues(typeof(IniFileKeys));
    //        foreach (IniFileFields f in ar_inifilefield)
    //        {
    //            foreach (IniFileKeys k in ar_inifilekey)
    //            {
    //                //_list.Add( new ThreadGradeData(f.ToString(),k.ToString(),  SetFileControl.GetIniFileInfo(f.ToString(), k.ToString())));
    //            }
    //        }
    //    }

    //    public string GetValue(IniFileFields field, IniFileKeys key)
    //    {
    //        string result="";
    //        foreach (ThreadGradeData tgd in _list)
    //        {
    //            if (tgd.OneGradeData==field.ToString()&&tgd.TwoGradeData==key.ToString())
    //            {
    //                result = tgd.ThreeGradeData;
    //            }
    //        }
    //        return result;
    //    }
    //}
    //public class ThreadGradeData
    //{
    //    private string _oneGradeData;

    //    public string OneGradeData
    //    {
    //        get { return _oneGradeData; }
    //        set { _oneGradeData = value; }
    //    }
    //    private string _twoGradeData;

    //    public string TwoGradeData
    //    {
    //        get { return _twoGradeData; }
    //        set { _twoGradeData = value; }
    //    }
    //    private string _threeGradeData;

    //    public string ThreeGradeData
    //    {
    //        get { return _threeGradeData; }
    //        set { _threeGradeData = value; }
    //    }
    //    public ThreadGradeData(string s1,string s2,string s3)
    //    {
    //        this._oneGradeData = s1;
    //        this._twoGradeData = s2;
    //        this._threeGradeData = s3;
    //    }
    //}
    ///// <summary>
    ///// 主键名称
    ///// </summary>
    //public enum IniFileFields
    //{
    //    /// <summary>
    //    /// 填单机参数
    //    /// </summary>
    //    填单机参数
    //}
    ///// <summary>
    ///// 
    ///// </summary>
    //public enum IniFileKeys
    //{
    //    管理密码,
    //    邮政编码
    //}
    }
