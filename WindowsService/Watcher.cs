using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WindowsService
{
    public class Watcher
    {
        private Parser _parser;
        private FileSystemWatcher _fileWatcher;
        //private TaskFactory _taskFactory = new System.Threading.Tasks.TaskFactory();
        private Task task;

        public Watcher()
        {
            _parser = new Parser();
            _fileWatcher = new FileSystemWatcher();
            _fileWatcher.Path = ConfigurationManager.AppSettings["Path"];
            _fileWatcher.Filter = "*.csv";
            _fileWatcher.NotifyFilter = NotifyFilters.FileName;
           // watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           //| NotifyFilters.FileName | NotifyFilters.DirectoryName;


            _fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            _fileWatcher.Created += new FileSystemEventHandler(OnChanged);
            _fileWatcher.EnableRaisingEvents = true;
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
            _parser.ParseData(path);
        }
        public void Dispose()
        {
            _fileWatcher.Dispose();
        }
    }
}
