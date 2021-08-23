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
    public partial class FormAddUser : Form
    {
        string constring = @"Data Source=172.28.10.25\QA;Initial Catalog=PrintLabel;Persist Security Info=True;User ID=sa;PASSWORD=$umcevn123";
        DataTable dttable;
        SqlDataAdapter adapter;
        SqlConnection connect;
        SqlCommand command;
        FormMain frm;

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
            adapter = new SqlDataAdapter("Select * from Nichicon_Users", connect);
            adapter.Fill(dttable);
            dtgv_Add_user.DataSource = dttable;
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
        public FormAddUser(FormMain frm)
        {
            InitializeComponent();
            this.frm = frm;
            Load_data();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (FieldError(txtuser) == false)
                {
                    return;
                }
                else if (FieldError(txtpassword) == false)
                {
                    return;
                }
                else if (FieldError(txtdes) == false)
                {
                    return;
                }
                else
                {
                    SqlDataAdapter dt = new SqlDataAdapter("select USER_NAME from Nichicon_Users where USER_NAME='" + txtuser.Text + "'", connect);
                    DataTable table_check = new DataTable();
                    dt.Fill(table_check);
                    if (table_check.Rows.Count > 0)
                    {
                        MessageBox.Show("Username is exists!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Connect();
                        command = new SqlCommand("insert into Nichicon_Users(USER_NAME,PASSWORD,DES, CREATE_BY,CREATE_DATE) values(@username,@pass,@des,@create_by,@create_date)", connect);
                        command.Parameters.AddWithValue("@username", txtuser.Text);
                        command.Parameters.AddWithValue("@pass", txtpassword.Text);
                        command.Parameters.AddWithValue("@des", txtdes.Text);
                        command.Parameters.AddWithValue("@create_by", "admin");
                        command.Parameters.AddWithValue("@create_date", DateTime.Now.ToString());
                        command.ExecuteNonQuery();
                        Load_data();
                        connect.Close();
                        txtuser.ResetText();
                        txtpassword.ResetText();
                        txtdes.ResetText();
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

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtuser.Text!= null)
                {
                        Connect();
                        command = new SqlCommand("update Nichicon_Users set PASSWORD='" + txtpassword.Text + "', DES='" + txtdes.Text + "' where USER_NAME='" + txtuser.Text + "'", connect);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Record Updated Successfully!");
                        Load_data();
                        connect.Close();
                        txtuser.ResetText();
                        txtpassword.ResetText();
                        txtdes.ResetText();
                        txtuser.Enabled = true;
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

        private void dtgv_Add_model_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {         
            txtuser.Text = dtgv_Add_user.Rows[e.RowIndex].Cells["USER_NAME"].Value.ToString();
            txtpassword.Text = dtgv_Add_user.Rows[e.RowIndex].Cells["PASSWORD"].Value.ToString();
            txtdes.Text = dtgv_Add_user.Rows[e.RowIndex].Cells["DES"].Value.ToString();
            txtuser.Enabled = false;
        }
    }
}
