namespace Nichicon_PrintLabel
{
    partial class FormAddModel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddModel));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtproductmanager = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtproduct = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtmodel = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.dtgv_Add_model = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Productmanager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtcodecustomer = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Add_model)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtcodecustomer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtproductmanager);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtproduct);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtmodel);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 159);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic from";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên quản lý sản phẩm: ";
            // 
            // txtproductmanager
            // 
            this.txtproductmanager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtproductmanager.Location = new System.Drawing.Point(144, 93);
            this.txtproductmanager.Name = "txtproductmanager";
            this.txtproductmanager.Size = new System.Drawing.Size(161, 20);
            this.txtproductmanager.TabIndex = 8;
            // 
            // btnDel
            // 
            this.btnDel.Image = global::Nichicon_PrintLabel.Properties.Resources._23231_delete_icon;
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(462, 19);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(69, 29);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "      Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tên sản phẩm: ";
            // 
            // txtproduct
            // 
            this.txtproduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtproduct.Location = new System.Drawing.Point(144, 57);
            this.txtproduct.Name = "txtproduct";
            this.txtproduct.Size = new System.Drawing.Size(161, 20);
            this.txtproduct.TabIndex = 5;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Nichicon_PrintLabel.Properties.Resources._3841801_disk_download_guardar_interface_multimedia_icon;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(462, 82);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(58, 31);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "      Save";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Nichicon_PrintLabel.Properties.Resources._32378_add_plus_icon1;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(357, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "     Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtmodel
            // 
            this.txtmodel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtmodel.Location = new System.Drawing.Point(144, 19);
            this.txtmodel.Name = "txtmodel";
            this.txtmodel.Size = new System.Drawing.Size(161, 20);
            this.txtmodel.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(65, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên model: ";
            // 
            // dtgv_Add_model
            // 
            this.dtgv_Add_model.AllowUserToAddRows = false;
            this.dtgv_Add_model.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_Add_model.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_Add_model.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_Add_model.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Product,
            this.Model,
            this.Productmanager});
            this.dtgv_Add_model.Location = new System.Drawing.Point(5, 165);
            this.dtgv_Add_model.Name = "dtgv_Add_model";
            this.dtgv_Add_model.RowHeadersVisible = false;
            this.dtgv_Add_model.Size = new System.Drawing.Size(551, 262);
            this.dtgv_Add_model.TabIndex = 6;
            this.dtgv_Add_model.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_Add_model_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Product
            // 
            this.Product.DataPropertyName = "Product_Name";
            this.Product.HeaderText = "Sản phẩm";
            this.Product.Name = "Product";
            // 
            // Model
            // 
            this.Model.DataPropertyName = "Model_Name";
            this.Model.HeaderText = "Tên Model";
            this.Model.Name = "Model";
            // 
            // Productmanager
            // 
            this.Productmanager.DataPropertyName = "Product_ManagerName";
            this.Productmanager.HeaderText = "Tên quản lý sản phẩm";
            this.Productmanager.Name = "Productmanager";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mã quản lý sản phẩm:";
            // 
            // txtcodecustomer
            // 
            this.txtcodecustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcodecustomer.Location = new System.Drawing.Point(144, 133);
            this.txtcodecustomer.Name = "txtcodecustomer";
            this.txtcodecustomer.Size = new System.Drawing.Size(161, 20);
            this.txtcodecustomer.TabIndex = 10;
            // 
            // FormAddModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 439);
            this.Controls.Add(this.dtgv_Add_model);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddModel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Add_model)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtproduct;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtmodel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dtgv_Add_model;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtproductmanager;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Productmanager;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcodecustomer;
    }
}