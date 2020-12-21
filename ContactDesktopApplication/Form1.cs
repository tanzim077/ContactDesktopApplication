using ContactDesktopApplication.ContactClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactDesktopApplication
{
    public partial class Contact : Form
    {
        ContactClass c = new ContactClass(); 

        public Contact()
        {
            InitializeComponent();
        }

       
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbxGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            c.Name = textBoxName.Text;
            c.Email = textBoxEmail.Text;
            c.City = textBoxCity.Text;
            c.ContactNo = textBoxContact.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = cbxGender.Text;

            bool success = c.Insert(c);
            if (success == true)
            {
                MessageBox.Show("Data inserted successfully");

                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;

                Clear();
            }
            else
            {
                MessageBox.Show("Failed to inserted Data");
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            c.ID = Convert.ToInt32(textBoxID.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                MessageBox.Show("Data Deleted successfully");
                Clear();
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to inserted Data");
            }
        }

        private void pbxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvContactList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void Contact_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void Clear()
        {
            textBoxID.Text = null;
            textBoxName.Text = "";
            textBoxEmail.Text = "";
            textBoxCity.Text = "";
            textBoxContact.Text = "";
            textBoxAddress.Text = "";
            cbxGender.Text = "";
        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            //int rowIndex = 3;
            textBoxID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxEmail.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxCity.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxContact.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            textBoxAddress.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
            cbxGender.Text = dgvContactList.Rows[rowIndex].Cells[6].Value.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            c.ID = int.Parse(textBoxID.Text);
            c.Name = textBoxName.Text;
            c.Email = textBoxEmail.Text;
            c.City = textBoxCity.Text;
            c.ContactNo = textBoxContact.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = cbxGender.Text;

            bool success = c.Update(c);

            if (success==true)
            {
                MessageBox.Show("Data Updated Successfully");
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to Updated Data");
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
