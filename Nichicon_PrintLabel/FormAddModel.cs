using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nichicon_PrintLabel
{
    public partial class FormAddModel : Form
    {
        string constring = @"Data Source=172.28.10.25\QA;Initial Catalog=PrintLabel;Persist Security Info=True;User ID=sa;PASSWORD=$umcevn123";
        DataTable dttable;
        SqlDataAdapter adapter;
        SqlConnection connect;
        SqlCommand command;
        string ID_;
        FormMain frm;
        DataTable reload_table;
        SqlDataAdapter reload_adapter;
        void Connect()
        {
            try
            {
                connect = new SqlConnection();
                connect.ConnectionString = constring;
                connect.Open();
                dttable = new DataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Load_data()
        {
            Connect();
            adapter = new SqlDataAdapter("Select * from Nichicon_model where Status='True'", connect);
            adapter.Fill(dttable);
            dtgv_Add_model.DataSource = dttable;
            dtgv_Add_model.Columns["ID"].Visible = false;
            dtgv_Add_model.Columns["Status"].Visible = false;
            dtgv_Add_model.Columns["Users"].Visible = false;
        }

        public FormAddModel(FormMain frm)
        {
            this.frm = frm;
            InitializeComponent();
            Load_data();
        }
        bool FieldError(Control control)
        {
            if (control.Text == "" || control.Text == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(control, "Required field!");
                control.Focus();
                return false;
            }
            return true;
        }
        public void Reload_combobox_model()
        {
            Connect();
            reload_adapter = new SqlDataAdapter("Select * from Nichicon_model where Status='True'", connect);
            reload_table = new DataTable();
            reload_table.Rows.Add();
            reload_table.AcceptChanges();
            reload_adapter.Fill(reload_table);
            frm.cboModels.DataSource = reload_table;
            frm.cboModels.DisplayMember = "Model_Name";
            frm.cboModels.ValueMember = "ID";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (FieldError(txtmodel) == false)
                {
                    return;
                }
                else if (FieldError(txtproduct) == false)
                {
                    return;
                }
                else if (FieldError(txtproductmanager) == false)
                {
                    return;
                }
                else
                {
                    SqlDataAdapter dt = new SqlDataAdapter("select Model_Name from Nichicon_model where Model_Name='" + txtmodel.Text + "' and Status= 'True'", connect);
                    DataTable table_check = new DataTable();
                    dt.Fill(table_check);
                    if (table_check.Rows.Count > 0)
                    {
                        MessageBox.Show("Model name is exists!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Connect();
                        command = new SqlCommand("insert into Nichicon_model(ID,Model_Name,Product_Name,Product_ManagerName,Code_productcustomer,Users,Status) values(@ID,@modelname,@productname,@productmanager,@code_customer,@users,@status)", connect);
                        command.Parameters.AddWithValue("@ID", Guid.NewGuid().ToString());
                        command.Parameters.AddWithValue("@modelname", txtmodel.Text);
                        command.Parameters.AddWithValue("@productname", txtproduct.Text);
                        command.Parameters.AddWithValue("@productmanager", txtproductmanager.Text);
                        command.Parameters.AddWithValue("@code_customer", txtcodecustomer.Text);
                        command.Parameters.AddWithValue("@users", Program.CurrentUser.Username);
                        command.Parameters.AddWithValue("@status", "True");
                        command.ExecuteNonQuery();
                        Load_data();
                        Reload_combobox_model();
                        connect.Close();
                        txtmodel.ResetText();
                        txtproduct.ResetText();
                        txtproductmanager.ResetText();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID_ != null)
                {
                    Connect();
                    command = new SqlCommand("update Nichicon_Model set Status='" + "False" + "' where ID='" + ID_ + "'", connect);
                    command.ExecuteNonQuery();          
                    Load_data();
                    MessageBox.Show("Record Delete Successfully!");
                    Reload_combobox_model();
                    connect.Close();
                    txtmodel.ResetText();
                    txtproduct.ResetText();
                    txtproductmanager.ResetText();
                }
                else
                {
                    MessageBox.Show("Don't have choose value to delete!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID_ != null)
                {              
                        Connect();
                        command = new SqlCommand("update Nichicon_Model set Product_Name='" + txtproduct.Text + "',Product_ManagerName='" + txtproductmanager.Text + "',Code_productcustomer='" + txtcodecustomer.Text + "' where ID='" + ID_ + "'", connect);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Record Updated Successfully!");
                        Load_data();
                        Reload_combobox_model();
                        connect.Close();
                        txtmodel.ResetText();
                        txtproduct.ResetText();
                        txtproductmanager.ResetText();
                }
                else
                {
                    MessageBox.Show("Don't have choose value to edit!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgv_Add_model_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_ = dtgv_Add_model.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            txtmodel.Text = dtgv_Add_model.Rows[e.RowIndex].Cells["Model"].Value.ToString();
            txtproduct.Text = dtgv_Add_model.Rows[e.RowIndex].Cells["Product"].Value.ToString();
            txtproductmanager.Text= dtgv_Add_model.Rows[e.RowIndex].Cells["Productmanager"].Value.ToString();
            txtcodecustomer.Text = dtgv_Add_model.Rows[e.RowIndex].Cells["Code_productcustomer"].Value.ToString();
            txtmodel.Enabled = false;
        }
    }
}
