﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchFolderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WatcherStrat(@"D:\Route", "*.txt");
            Console.ReadKey();
        }
        private static void WatcherStrat(string path, string filter)
        {

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.Filter = filter;
            watcher.Changed += new FileSystemEventHandler(OnProcess);
            watcher.Created += new FileSystemEventHandler(OnProcess);
            watcher.Deleted += new FileSystemEventHandler(OnProcess);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess
                                   | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
            watcher.IncludeSubdirectories = true;
        }

        private static void OnProcess(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                OnCreated(source, e);
            }
            else if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                OnChanged(source, e);
            }
            else if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                OnDeleted(source, e);
            }
        }
        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("文件新建事件处理逻辑 {0}  {1}  {2}", e.ChangeType, e.FullPath, e.Name);
            //读取文件名称，自动入库
            string[] n = e.Name.Split('_');
            if (n[1] == "f.txt")
            {
                string taskName = e.Name.Split('_')[0];
                ReadFlyText(e.FullPath, taskName);
            }
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("文件改变事件处理逻辑{0}  {1}  {2}", e.ChangeType, e.FullPath, e.Name);
        }

        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("文件删除事件处理逻辑{0}  {1}   {2}", e.ChangeType, e.FullPath, e.Name);
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("文件重命名事件处理逻辑{0}  {1}  {2}", e.ChangeType, e.FullPath, e.Name);
        }

        private static void ReadFlyText(string path,string _taskName)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string taskID= sr.ReadLine();
            string taskName = _taskName;
            sr.ReadLine();
            string trdStr = sr.ReadLine();
            string[] val = System.Text.RegularExpressions.Regex.Split(trdStr, @"\s");
            string month = val[0];
            string year = val[1];
            string day = val[2];

            string taskTime = year + "-" + month + "-" + day;
            //DateTime dt = Convert.ToDateTime(taskTime);
            Utils.SQLiteManager.InsertData("'"+taskID + "','" + taskName + "','"+" ','"+ taskTime + "'");
        }
    }
}
