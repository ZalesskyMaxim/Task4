using Model;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagersForm
{
    public partial class Form1 : Form
    {
        IModelRepository<DAL.Models.Manager, Model.Manager> managerRepository;
        IModelRepository<DAL.Models.Client, Model.Client> clientRepository;
        IModelRepository<DAL.Models.Product, Model.Product> productRepository;
        IModelRepository<DAL.Models.SaleInfo, Model.SaleInfo> saleInfoRepository;
        public Form1()
        {
            managerRepository = new ManagerRepository();
            clientRepository = new CilentRepository();
            productRepository = new ProductRepository();
            saleInfoRepository = new SaleInfoRepository();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            var manager = managerRepository.GetEntity(new DAL.Models.Manager(){ManagerName = comboBox1.Text});
            if (manager != null)
            {
                var dataM = saleInfoRepository.Items.Where(x => x.ID_Manager == manager.ID_Manager);
                dataGridView1.Rows.Clear();
                foreach(var saleInfo in dataM)
                {
                    var date = saleInfo.SaleDate;
                    var managerName = managerRepository.GetEntityNameById(saleInfo.ID_Manager.Value);
                    var clientName = clientRepository.GetEntityNameById(saleInfo.ID_Client.Value);
                    var product = productRepository.GetEntityNameById(saleInfo.ID_Product.Value);
                    dataGridView1.Rows.Add(date, clientName.ClientName, product.ProductName, product.ProductCost);
                }

            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (var d in managerRepository.Items)
            {
                if (!comboBox1.Items.Contains(d.ManagerName))
                {
                    comboBox1.Items.Add(d.ManagerName);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Date", "Date");
            dataGridView1.Columns.Add("Client", "Client");
            dataGridView1.Columns.Add("Product", "Product");
            dataGridView1.Columns.Add("Cost", "Cost");
        }
    }
}
