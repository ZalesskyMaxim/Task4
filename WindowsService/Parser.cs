using DAL.Models;
using DAL.Repository;
using Model;
//using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public class Parser
    {
        private DatabaseHandler _dbHandler;

        public Parser()
        {
            _dbHandler = new DatabaseHandler();
        }

        public void ParseData(string path)
        {
            string managerName;
            string[] param;
            managerName = Path.GetFileName(path).Split('_').First();

            using(StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    param = sr.ReadLine().Split(',');
                    _dbHandler.AddToDatabase(managerName, param[0], param[1], param[2], param[3]);
                }
            }
        }
    }
}
