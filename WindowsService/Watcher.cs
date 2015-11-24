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
        Parser p;
        public FileSystemWatcher watcher;
        TaskFactory tf = new System.Threading.Tasks.TaskFactory();

        public Watcher()
        {
            p = new Parser();
            watcher = new FileSystemWatcher();
            watcher.Path = "c:\\Managers";
            watcher.Filter = "*.csv";

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;


            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        public void run()
        {

        }
        public void OnChanged(object source, FileSystemEventArgs e)
        {
            string t;
            t = e.FullPath;
            tf.StartNew(() => p.ParseData(t));
        }
    }
}
