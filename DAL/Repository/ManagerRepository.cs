using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Repository
{
    public class ManagerRepository : AbstractRepository, IModelRepository<DAL.Models.Manager>
    {
        Model.Manager ToEntity(DAL.Models.Manager source)
        {
            return new Model.Manager() 
            { 
                Name = source.Name, 
                Date = source.Date,
                Client = source.Client,
                Product = source.Product,
                Cost = source.Cost,
                ID_Manager = source.ID_Manager
            };
        }

        DAL.Models.Manager ToObject(Model.Manager source)
        {
            return new DAL.Models.Manager() 
            {
                Name = source.Name,
                Date = source.Date,
                Client = source.Client,
                Product = source.Product,
                Cost = source.Cost,
                ID_Manager = source.ID_Manager
            };
        }

        public void Add(DAL.Models.Manager item)
        {
            var entity = this.ToEntity(item);
            managersContext.Manager.Add(entity);
        }

        public void Remove(DAL.Models.Manager item)
        {
            var user = this.managersContext.Manager.FirstOrDefault(x => x.ID_Manager == item.ID_Manager);
            if (user != null)
            {
                managersContext.Manager.Remove(user);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(DAL.Models.Manager item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DAL.Models.Manager> Items
        {
            get
            {
                return this.managersContext.Manager.Select(x => this.ToObject(x));
            }
        }

        public void SaveChanges()
        {
            managersContext.SaveChanges();
        }
    }
}
