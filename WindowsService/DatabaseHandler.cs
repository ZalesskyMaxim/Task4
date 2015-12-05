using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public class DatabaseHandler
    {
        private IModelRepository<DAL.Models.Manager, Model.Manager> _managerRepository;
        private IModelRepository<DAL.Models.Client, Model.Client> _clientRepository;
        private IModelRepository<DAL.Models.Product, Model.Product> _productRepository;
        private IModelRepository<DAL.Models.SaleInfo, Model.SaleInfo> _saleInfoRepository;

        public DatabaseHandler()
        {
            _managerRepository = new ManagerRepository();
            _clientRepository = new CilentRepository();
            _productRepository = new ProductRepository();
            _saleInfoRepository = new SaleInfoRepository();
        }

        public void AddToDatabase(Journal journal)
        {
            lock (this)
            {
                var newManager = new DAL.Models.Manager { ManagerName = journal.ManagerName };
                var manager = _managerRepository.GetEntity(newManager);
                if (manager == null)
                {
                    _managerRepository.Add(newManager);
                    _managerRepository.SaveChanges();
                    manager = _managerRepository.GetEntity(newManager);
                }

                var newClient = new DAL.Models.Client { ClientName = journal.ClientName };
                _clientRepository.Add(newClient);
                _clientRepository.SaveChanges();
                var client = _clientRepository.GetEntity(newClient);

                var newProduct = new DAL.Models.Product { ProductName = journal.ProductName, ProductCost = journal.ProductCost };
                _productRepository.Add(newProduct);
                _productRepository.SaveChanges();
                var product = _productRepository.GetEntity(newProduct);

                var saleInfo = new DAL.Models.SaleInfo
                {
                    SaleDate = journal.SaleDate,
                    ID_Manager = manager.ID_Manager,
                    ID_Client = client.ID_Client,
                    ID_Product = product.ID_Product
                };
                _saleInfoRepository.Add(saleInfo);
                _saleInfoRepository.SaveChanges();
            }
        }
    }
}
