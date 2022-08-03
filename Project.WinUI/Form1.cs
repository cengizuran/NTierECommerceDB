using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinUI
{
    //A basic E-Commerce database is created (Code First). N-Tier and Singleton patterns are used through the process. All the custom methods can be seen in Project.BLL, some of them are not used on the UI.
    public partial class Form1 : Form
    {
        CategoryRepository _cRep;
        public Form1()
        {
            InitializeComponent();
            _cRep = new CategoryRepository();
        }

        

        private void btnListAll_Click(object sender, EventArgs e)
        {
            lstCategories.DataSource = _cRep.GetAll();
            ClearTextBoxes();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            _cRep.Add(new Category
            {
                CategoryName = txtCategory.Text,
                Description = txtDescription.Text
            });

            ListActiveData();
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (c!=null)
            {
                c.CategoryName = txtCategory.Text;
                c.Description = txtDescription.Text;
                _cRep.Update(c);
                ListActiveData();
                c = null;
            }
            else MessageBox.Show("Please select a category first.");
        } 

        private void btnListActive_Click(object sender, EventArgs e)
        {
            ListActiveData();
        }

        private void ListActiveData()
        {
            lstCategories.DataSource = _cRep.GetActive();
            ClearTextBoxes();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (c!=null)
            {
                _cRep.Delete(c);
                ListActiveData();
                c = null;
            }
            else MessageBox.Show("Please select a category first.");
        }

        Category c;
        private void lstCategories_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedIndex>-1)
            {
                c = lstCategories.SelectedItem as Category;
                txtCategory.Text = c.CategoryName;
                txtDescription.Text=c.Description;
            }
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            if (c!=null)
            {
                _cRep.Destroy(c);
                ListActiveData();
                c = null;
            }
        }

        private void btnListModified_Click(object sender, EventArgs e)
        {
            lstCategories.DataSource = _cRep.GetModified();
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            lstCategories.SelectedIndex = -1;
            txtCategory.Text=txtDescription.Text=string.Empty;
        }

        private void btnListPassive_Click(object sender, EventArgs e)
        {
            lstCategories.DataSource= _cRep.GetDeleted();
            ClearTextBoxes();
        }
    }
}
