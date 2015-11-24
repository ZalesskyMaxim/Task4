using DAL.Models;
using DAL.Repository;
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
        public void ParseData(string path)
        {
            string p = path;
            string[] n;
            string[] s;
            n = p.Split('\\', '_', '.');
            using(StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine().Split(',');
                    IModelRepository<Manager> mr = new ManagerRepository();
                    mr.Add(new Manager { Name = n[2], Date = s[0], Client = s[1], Product = s[2], Cost = s[3] });
                    mr.SaveChanges();
                }
            }

        }
    }
}
