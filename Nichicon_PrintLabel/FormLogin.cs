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
    public partial class FormLogin : Form
    {
        string constring = @"Data Source=172.28.10.25\QA;Initial Catalog=PrintLabel;Persist Security Info=True;User ID=sa;Password=$umcevn123";
        SqlConnection connect;
        SqlCommand command;
        List<Users> list_user = new List<Users>();
        public FormLogin()
        {
            InitializeComponent();
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (FieldError(txtusername) == false)
            {
                return;
            }
            else if (FieldError(txtpassword) == false)
            {
                return;
            }
            else
            {
                connect = new SqlConnection();
                connect.ConnectionString = constring;
                connect.Open();
                command = new SqlCommand("select * from Nichicon_Users where USER_NAME= @username and PASSWORD= @password", connect);
                command.Parameters.AddWithValue("@username", txtusername.Text);
                command.Parameters.AddWithValue("@password", txtpassword.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable ds = new DataTable();
                adapter.Fill(ds);
                connect.Close();
                int count = ds.Rows.Count;
                if (count == 1)
                {
                    var data = new Users {
                        Username = txtusername.Text,
                        Password = txtpassword.Text,
                        Desception = ds.Rows[0]["DES"].ToString()
                    };
                    Program.CurrentUser = data;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("User not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtpassword_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
