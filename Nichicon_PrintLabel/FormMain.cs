using Nichicon_PrintLabel.Business;
using Nichicon_PrintLabel.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Nichicon_PrintLabel
{
    public partial class FormMain : Form
    {
        private Timer t = null;
        // PrintLabelEntities db = new PrintLabelEntities();
        string constring = @"Data Source=172.28.10.25\QA;Initial Catalog=PrintLabel;Persist Security Info=True;User ID=sa;Password=$umcevn123";
        private string pathLog = @"C:\Logs\LibraModel";
        DataTable dttable;
        SqlDataAdapter adapter;
        SqlConnection connect;
        SqlCommand command;
        SqlDataAdapter adapter_model;
        DataTable dttable_model;
        List<string> months = new List<string>();
        PvsService.PVSWebServiceSoapClient _pvs_service = new PvsService.PVSWebServiceSoapClient();
        List<Nichicon_HistoriesSerial1> histories = new List<Nichicon_HistoriesSerial1>();
        List<Nichicon_HistoriesSerial2> histories2 = new List<Nichicon_HistoriesSerial2>();
        public Dictionary<string, int> _dic = new Dictionary<string, int>()
        {
            {"A",10 },
            {"B",11 },
            {"C",12 },
            {"D",13 },
            {"E",14 },
            {"F",15 },
            {"G",16 },
            {"H",17 },
            {"J",18 },
            {"K",19 },
            {"L",20 },
            {"M",21 },
            {"N",22 },
            {"P",23 },
            {"Q",24 },
            {"R",25 },
            {"S",26 },
            {"T",27 },
            {"U",28 },
            {"V",29 },
            {"W",30 },
            {"X",31 },
            {"Y",32 },
            {"Z",33 },
        };
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
        bool FieldError(Control control)
        {
            if (control.Text == "" || control.Text == null)
            {

                control.Focus();
                return false;
            }
            return true;
        }
        public FormMain()
        {
            InitializeComponent();
            StartTimer();
            lblVersion.Text = Ultils.GetRunningVersion();
            GetMonths();
            dtgvResult.VirtualMode = true;
            this.dtgvResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        }
        void Check_user_admin()
        {
            if (Program.CurrentUser.Desception == "IT")
            {
                btnAddUser.Visible = true;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Program.CurrentUser.Username == null)
            {
                new FormLogin().ShowDialog();
            }
            else
            {
                Program.CurrentUser = new Users();
            }

        }

        private void lblAddModel_Click(object sender, EventArgs e)
        {
            new FormAddModel(this).ShowDialog();
        }

        private void StartTimer()
        {
            t = new Timer();
            t.Interval = 100;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString();
            if (Program.CurrentUser.Username != null)
            {
                lblName.Visible = true;
                lblName.Text = Program.CurrentUser.Username;
                lblAddModel.Enabled = true;
                btnExportToCSV.Enabled = true;
                lblPathLog.Enabled = true;
                if (Program.CurrentUser.Desception == "IT")
                {
                    btnAddUser.Visible = true;
                }
                else
                {
                    btnAddUser.Visible = false;
                }
            }
            else
            {
                lblName.Visible = false;
                lblAddModel.Enabled = false;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Connect();
            adapter = new SqlDataAdapter("Select * from Nichicon_model where Status='True'", connect);
            dttable.Rows.Add();
            dttable.AcceptChanges();
            adapter.Fill(dttable);
            cboModels.DataSource = dttable;
            cboModels.DisplayMember = "Model_Name";
            cboModels.ValueMember = "ID";
            cboYear.Text = DateTime.Now.Year.ToString();
        }

        private void cboModels_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectcbb = null;
            selectcbb = cboModels.SelectedIndex.ToString();
            if (cboModels.SelectedIndex > 0)
            {
                selectcbb = cboModels.SelectedValue.ToString();
                Connect();
                command = new SqlCommand("Select * from Nichicon_model where ID='" + selectcbb + "'", connect);
                adapter_model = new SqlDataAdapter(command);
                dttable_model = new DataTable();
                adapter_model.Fill(dttable_model);
                txtProduct.Text = dttable_model.Rows[0]["Product_Name"].ToString();
                txtProductmanager.Text = dttable_model.Rows[0]["Product_ManagerName"].ToString();
                txtcodecustomer.Text= dttable_model.Rows[0]["Code_productcustomer"].ToString();
                txtQuantity.Focus();
                dtgvResult.DataSource = null;
            }
            else
            {
                txtProduct.ResetText();
                txtProductmanager.ResetText();
            }

        }
        private void GetMonths()
        {
            DateTime now = _pvs_service.GetDateTime();
            for (int i = 1; i <= 9; i++)
            {
                months.Add(i.ToString());
            }
            string[] array = { "X", "Y", "Z" };
            foreach (var item in array)
            {
                months.Add(item);
            }
            cboMonth.DataSource = months;
            cboMonth.SelectedItem = now.Month.ToString();
        }

        private void txtQuantity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtQuantity.Text != "")
            {
                if (FieldError(txtQuantity) == true)
                {
                    double qty = double.Parse(txtQuantity.Text);
                    if (qty > 2600001)
                    {
                        label9.Visible = true;
                        label9.Text = "Value max of quantity is 260000";
                    }
                }
            }
            else
            {
                label9.Visible = true;
                label9.Text = "Value cannot be empty!";
            }
        }

         bool Check_value()
        {
          bool ok = false;
            int qty = 0;
            if (cboModels.SelectedIndex < 1 && !int.TryParse(txtQuantity.Text, out qty))
            {
                MessageBox.Show($"Model và số lượng không được để trống", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ok = true;
            }
            else if (cboModels.SelectedIndex < 1)
            {
                MessageBox.Show($"Model chưa được chọn", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ok = true;
            }
            else if (!int.TryParse(txtQuantity.Text, out qty))
            {
                MessageBox.Show($"Số lượng không hợp lệ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ok = true;
            }
            return ok;
        }
        private void btnGenerateSerial_Click(object sender, EventArgs e)
        {
            if (Check_value() == false)
            {
                string startNo;
                string month = cboMonth.Text;
                string model = cboModels.Text;

                Nichicon_model model_item = (NichiconRepository.GetModel(model));
                Nichicon_ItemSeiral1 nichiconItem = NichiconRepository.GetLastSerial1(model);
                startNo = nichiconItem == null ? "A0000" : nichiconItem.BarCode_Last.Substring(nichiconItem.BarCode_Last.Length - 6, 5);
                histories = Ultils.GenericSerial1(model_item, startNo, int.Parse(txtQuantity.Text), _dic, month);
                dtgvResult.DataSource = histories.ToList();
                dtgvResult.Columns["ID"].Visible = false;
                dtgvResult.Columns["Country"].Visible = false;
            }            
           
        }

        private void btnExportToCSV_Click(object sender, EventArgs e)
        {
            try
            {
                bool exists = Directory.Exists(pathLog);
                if (!exists)
                {
                    Directory.CreateDirectory(pathLog);
                }
                // Log Print system
                string logPrint = txtPathLog.Text;
                if (!Directory.Exists(logPrint))
                {
                    Directory.CreateDirectory(logPrint);
                }

                string folderModel = $@"{pathLog}\{cboModels.Text}";
                if (!Directory.Exists(folderModel))
                {
                    Directory.CreateDirectory(folderModel);
                }
                string year = DateTime.Now.Year.ToString().Substring((DateTime.Now.Year.ToString()).Length - 1);
                string month = cboMonth.Text;
                string fileName = $@"{folderModel}\{year + month}.csv";
                //string fileName = $@"{pathLog}\{_model.Name + year + month}.csv";
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Dispose();
                }
                // Logs 
                try
                {
                    dtgvResult.Columns.Remove("ID");
                    DateTime now = _pvs_service.GetDateTime();
                    string fileLogserial = "";
                    if (histories != null)
                    {
                         fileLogserial = "LogSerial1.csv";
                        var lastHis1 = histories.OrderByDescending(r => r.QR_Code).FirstOrDefault();
                        var item_serial1 = new Nichicon_ItemSeiral1()
                        {
                            BarCode_Last = lastHis1.QR_Code,
                            Create_Date = now,
                            Model_Name = cboModels.Text,
                            Product = txtProduct.Text,
                            Product_manager = lastHis1.Product_Customer,
                            Code_productcustomer = txtcodecustomer.Text
                        };
                        NichiconRepository.SaveHistoryOfSerial1(item_serial1, histories);
                    }
                    else
                    {
                        dtgvResult.Columns.Remove("Model");
                        dtgvResult.Columns.Remove("Product_Name");
                        dtgvResult.Columns.Remove("Code_productcustomer");
                        fileLogserial = "LogSerial2.csv";
                        var lastHis2 = histories2.OrderByDescending(r => r.QR_Code).FirstOrDefault();
                        if (lastHis2 != null)
                        {
                            var item_serial2 = new Nichicon_ItemSerial2()
                            {
                                BarCode_Last = lastHis2.QR_Code,
                                Create_Date = now,
                                Model_Name = cboModels.Text,
                                Product = txtProduct.Text,
                                Product_manager = lastHis2.Product_Customer,
                                Code_productcustomer = txtcodecustomer.Text
                            };
                            NichiconRepository.SaveHistoryOfSerial2(item_serial2, histories2);
                        }
                    }
                    string newLog = logPrint + @"\" +fileLogserial+ "";
                    if (!File.Exists(newLog))
                    {
                        File.Create(newLog).Dispose();
                    }
                    Ultils.WriteCSV(dtgvResult, fileName);
                    Ultils.WriteAppendCSV(dtgvResult, true, newLog);
                    MessageBox.Show("Export file to .csv success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtProductmanager.ResetText();
                    txtQuantity.ResetText();
                    cboModels.ResetText();
                    txtProduct.ResetText();
                    txtcodecustomer.ResetText();
                    dtgvResult.DataSource = null;
                    dtgvResult.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error:\nPlease close file Log.csv!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.Message}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ckChangeDate_CheckedChanged(object sender, EventArgs e)
        {
            //var check = ckChangeDate.Checked;
            //if (check == true)
            //{
            //    cboYear.Enabled = true;
            //    cboMonth.Enabled = true;
            //}
            //else
            //{
            //    cboYear.Enabled = false;
            //    cboMonth.Enabled = false;
            //}
        }

        private void PathLog()
        {
            var path = Ultils.GetValueRegistryKey("Libra Model", "PathLog");
            if (path != null)
            {
                txtPathLog.Text = path;
            }
        }

        private void lblPathLog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog outputLog = new FolderBrowserDialog();
            DialogResult open = outputLog.ShowDialog();
            if (open == DialogResult.OK)
            {
                txtPathLog.Text = outputLog.SelectedPath;
                Ultils.WriteRegistry("Libra Model", "PathLog", outputLog.SelectedPath);
                PathLog();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            new FormAddUser(this).ShowDialog();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void btnGenerateSerial2_Click(object sender, EventArgs e)
        {
            if (Check_value() == false)
            {
                dtgvResult.DataSource = null;
                dtgvResult.Refresh();
                histories = null;
                string startNo;
                string month = cboMonth.Text;
                string model = cboModels.Text;
                if (cboModels.SelectedIndex < 1)
                {
                    MessageBox.Show($"Model chưa được chọn", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                int qty = 0;
                if (!int.TryParse(txtQuantity.Text, out qty))
                {
                    MessageBox.Show($"Số lượng không hợp lệ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Nichicon_model model_item = (NichiconRepository.GetModel(model));
                Nichicon_ItemSerial2 nichiconItem = NichiconRepository.GetLastSerial2(model);
                startNo = nichiconItem == null ? "A0000" : nichiconItem.BarCode_Last.Substring(nichiconItem.BarCode_Last.Length - 5, 5);
                histories2 = Ultils.GenericSerial2(model_item, startNo, int.Parse(txtQuantity.Text), _dic, month);
                dtgvResult.DataSource = histories2.ToList();
                dtgvResult.Columns["ID"].Visible = false;
                dtgvResult.Columns["Model"].Visible = false;
                dtgvResult.Columns["Product_Name"].Visible = false;
                dtgvResult.Columns["Code_productcustomer"].Visible = false;
            }
        }
    }
}
