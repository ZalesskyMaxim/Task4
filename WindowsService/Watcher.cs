using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public class Watcher
    {
        public Parser Parser;
        public FileSystemWatcher FileWatcher;
        //private TaskFactory _taskFactory = new System.Threading.Tasks.TaskFactory();
        private Task task;

        public Watcher()
        {
            Parser = new Parser();
            FileWatcher = new FileSystemWatcher();
            FileWatcher.Path = "c:\\Managers";
            FileWatcher.Filter = "*.csv";
            FileWatcher.NotifyFilter = NotifyFilters.FileName;
           // watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           //| NotifyFilters.FileName | NotifyFilters.DirectoryName;


            FileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            FileWatcher.Created += new FileSystemEventHandler(OnChanged);
            FileWatcher.EnableRaisingEvents = true;
        }

        public void run()
        {

        }
        public void OnChanged(object source, FileSystemEventArgs e)
        {
            
            //_taskFactory.StartNew(() => Parser.ParseData(t));
            task = new Task(() => CallParse(source, e));
            task.Start();
        }
        public void CallParse(object source, FileSystemEventArgs e)
        { 
            string path;
            path = e.FullPath;
            Parser.ParseData(path);
        }
    }
}
