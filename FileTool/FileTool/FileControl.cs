using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IWshRuntimeLibrary;

namespace FileTool
{
    public class FileControl
    {
        /// <summary>
        /// 拷贝文件夹下面的全部东西到另外一个里面
        /// </summary>
        /// <param name="srcdir"></param>
        /// <param name="desdir"></param>
        public void CopyDirectory(string srcdir, string desdir, string exceptdir)
        {
            DirectoryInfo di = new DirectoryInfo(srcdir);

            DirectoryInfo[] dis = di.GetDirectories();
            FileInfo[] fis = di.GetFiles();
            //如果是文件夹  就看 是不是 要创建的  要是有的 就不创建要是没有的 就创建
            foreach (var dir in dis)
            {
                //假如排除的文件夹名称不等于空就排除对应的文件夹
                if (exceptdir != "" && dir.Name == exceptdir)
                {
                    continue;
                }
                string tempDirName = desdir + "\\" + dir.Name;
                if (!Directory.Exists(tempDirName))
                {
                    Directory.CreateDirectory(tempDirName);
                }
                else
                {
                    CopyDirectory(dir.FullName, tempDirName, "");
                }
            }
            //如果已经存在文件就把文件覆盖掉
            foreach (var file in fis)
            {
                string tempFileName = desdir + "\\" + file.Name;
                System.IO.File.Copy(file.FullName, tempFileName, true);
            }
        }//function end





        /// <summary>
        /// win7开机启动位置
        /// </summary>
        const string win7startupPath = @"C:\Users\Administrator\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup";
        /// <summary>
        /// 在dirpath文件夹里面 查找包含
        /// </summary>
        /// <param name="dirPath">要查找的位置</param>
        /// <param name="ContainFiles">包含的文件</param>
        /// <returns></returns>
        public Hashtable FindDirPath(string dirPath,string[] ContainFiles)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            Hashtable ht = new Hashtable();
            FileInfo[] fis = di.GetFiles();
            foreach (var item in fis)
            {
                if (item.Name.Contains(".lnk"))
                {
                    //发现是 快捷键的 就进来
                    //判断是不是对的地址
                    string temp_dirPath;
                    foreach (var fileName in ContainFiles)
                    {
                        if (IsDirPathByLnkFullName(item.FullName, fileName, out temp_dirPath))
                        {
                            ht.Add(fileName, temp_dirPath);
                        }
                    }
                }
            }
            return ht;
        }
        /// <summary>
        /// 快捷键文件是否指向   特定的文件 并给出指向文件夹位置
        /// </summary>
        /// <param name="fileFullPath">快捷键全路径</param>
        /// <param name="isContainFile">特定的文件名</param>
        /// <param name="DirPath">给出指向的文件夹</param>
        /// <returns>是否指向 特定的文件</returns>
        private bool IsDirPathByLnkFullName(string fileFullPath,string isContainFile, out string DirPath)
        {
            DirPath = null;
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(fileFullPath);
            if (shortcut.TargetPath.Contains(isContainFile))
            {
                DirPath = shortcut.TargetPath.Substring(0, shortcut.TargetPath.Length - isContainFile.Length);
                return true;
            }
            return false;
        }
    }
}
