using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public class RecordsHandler
    {
        private DatabaseHandler _dbHandler;
        private Parser _parser;
        public RecordsHandler()
        {
            _dbHandler = new DatabaseHandler();
            _parser = new Parser();
        }
        public void SaveRecords(string path)
        {
                var records = _parser.ParseData(path);
                foreach (var record in records)
                {
                    _dbHandler.AddToDatabase(record);
                }
        }
    }
}
