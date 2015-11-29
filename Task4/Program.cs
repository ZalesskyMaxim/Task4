using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Model;
//using DAL;
using System.Configuration;
using DAL.Repository;
using DAL.Models;
using Model;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            //ManagersContext managerContext = new ManagersContext();
            //IModelRepository<DAL.Models.Manager> managerRepository = new ManagerRepository();
            //IModelRepository<DAL.Models.Client> clientRepository = new CilentRepository();
            //IModelRepository<DAL.Models.Product> productRepository = new ProductRepository();
            //IModelRepository<DAL.Models.SaleInfo> saleInfoRepository = new SaleInfoRepository();

            //var newManager = new DAL.Models.Manager { ManagerName = "Bil" };
            //managerRepository.Add(newManager);
            //managerRepository.SaveChanges();
            //var manager = managerContext.Manager.FirstOrDefault(x => x.ManagerName == newManager.ManagerName);

            //var newClient = new DAL.Models.Client { ClientName = "Mick" };
            //clientRepository.Add(newClient);
            //clientRepository.SaveChanges();
            //var client = managerContext.Client.FirstOrDefault(x => x.ClientName == newClient.ClientName);

            //var newProduct = new DAL.Models.Product { ProductName = "Car", ProductCost = "6500" };
            //productRepository.Add(newProduct);
            //productRepository.SaveChanges();
            //var product = managerContext.Product.FirstOrDefault(x => x.ProductName == newProduct.ProductName && x.ProductCost == newProduct.ProductCost);

            //var saleInfo = new DAL.Models.SaleInfo 
            //{ 
            //    SaleDate = "29.11.2015", 
            //    ID_Manager = manager.ID_Manager, 
            //    ID_Client = client.ID_Client,
            //    ID_Product = product.ID_Product
            //};
            //saleInfoRepository.Add(saleInfo);
            //saleInfoRepository.SaveChanges();
            //using (var db = new ManagersContext())
            //{
            //    //var managers = GetManagers();
            //    var managers = from b in db.Manager
            //                   orderby b.Name
            //                   select b;
            //    foreach (var manager in managers)
            //    {
            //        Console.WriteLine(
            //            "Name: {0}\n Client: {1}\n",
            //            manager.Name,
            //            manager.Client);
            //    }

            //    Console.ReadKey();
            //}
        }
        //private static IList<Manager> GetManagers()
        //{
        //    ManagersContext mc = new ManagersContext();
        //    var managers = mc.Manager.ToList();
        //    return managers;
        //}
    }
}
