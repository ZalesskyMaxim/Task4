using Model;
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
        ManagersContext managersContext;
        public Form1()
        {
            managersContext = new ManagersContext();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dataM = from getData in managersContext.Manager
                        where (getData as Manager).Name == comboBox1.Text
                        select getData;
            dataGridView1.DataSource = dataM;
            dataGridView1.Columns.RemoveAt(0);
            dataGridView1.Columns.RemoveAt(4);
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            var dataManagers = from getManager in managersContext.Manager
                               select getManager.Name;
            foreach (var d in dataManagers)
            {
                if (!comboBox1.Items.Contains(d))
                {
                    comboBox1.Items.Add(d);
                }
            }
        }
    }
}
