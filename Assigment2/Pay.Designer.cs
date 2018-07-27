namespace Assigment2
{
    partial class Pay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pay));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet3 = new Assigment2.DataSet3();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBookingNo = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPaymentMethods = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPaymentOption = new System.Windows.Forms.ComboBox();
            this.gropboxPaymentOption = new System.Windows.Forms.GroupBox();
            this.gropboxPayment = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.labelTotalAmount = new System.Windows.Forms.Label();
            this.lblDepositPaid = new System.Windows.Forms.Label();
            this.labelDepositPaid = new System.Windows.Forms.Label();
            this.lblCharge = new System.Windows.Forms.Label();
            this.labelCharge = new System.Windows.Forms.Label();
            this.lblBookingAmount = new System.Windows.Forms.Label();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblBookingNo = new System.Windows.Forms.Label();
            this.labelBookingAmount = new System.Windows.Forms.Label();
            this.labelDeposit = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1TableAdapter = new Assigment2.DataSet3TableAdapters.DataTable1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet3)).BeginInit();
            this.gropboxPaymentOption.SuspendLayout();
            this.gropboxPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.DataSet3;
            // 
            // DataSet3
            // 
            this.DataSet3.DataSetName = "DataSet3";
            this.DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnCheck
            // 
            this.btnCheck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCheck.BackgroundImage")));
            this.btnCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCheck.Location = new System.Drawing.Point(239, 72);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(1);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(83, 32);
            this.btnCheck.TabIndex = 127;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(119, 39);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 19);
            this.label8.TabIndex = 126;
            this.label8.Text = "Booking No :";
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBookingNo.Location = new System.Drawing.Point(220, 39);
            this.txtBookingNo.Margin = new System.Windows.Forms.Padding(1);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(125, 21);
            this.txtBookingNo.TabIndex = 125;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCancel.Location = new System.Drawing.Point(217, 82);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 32);
            this.btnCancel.TabIndex = 118;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnNext.Location = new System.Drawing.Point(135, 82);
            this.btnNext.Margin = new System.Windows.Forms.Padding(1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 32);
            this.btnNext.TabIndex = 117;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(2, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 19);
            this.label2.TabIndex = 116;
            this.label2.Text = "Payment Method";
            // 
            // cmbPaymentMethods
            // 
            this.cmbPaymentMethods.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbPaymentMethods.FormattingEnabled = true;
            this.cmbPaymentMethods.Items.AddRange(new object[] {
            "Credit Card",
            "Cash",
            "Transfer"});
            this.cmbPaymentMethods.Location = new System.Drawing.Point(135, 50);
            this.cmbPaymentMethods.Margin = new System.Windows.Forms.Padding(1);
            this.cmbPaymentMethods.Name = "cmbPaymentMethods";
            this.cmbPaymentMethods.Size = new System.Drawing.Size(125, 21);
            this.cmbPaymentMethods.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 114;
            this.label1.Text = "Payment Option";
            // 
            // cmbPaymentOption
            // 
            this.cmbPaymentOption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbPaymentOption.FormattingEnabled = true;
            this.cmbPaymentOption.Items.AddRange(new object[] {
            "Deposit",
            "Total"});
            this.cmbPaymentOption.Location = new System.Drawing.Point(135, 20);
            this.cmbPaymentOption.Margin = new System.Windows.Forms.Padding(1);
            this.cmbPaymentOption.Name = "cmbPaymentOption";
            this.cmbPaymentOption.Size = new System.Drawing.Size(125, 21);
            this.cmbPaymentOption.TabIndex = 0;
            // 
            // gropboxPaymentOption
            // 
            this.gropboxPaymentOption.Controls.Add(this.btnCancel);
            this.gropboxPaymentOption.Controls.Add(this.btnNext);
            this.gropboxPaymentOption.Controls.Add(this.label2);
            this.gropboxPaymentOption.Controls.Add(this.cmbPaymentMethods);
            this.gropboxPaymentOption.Controls.Add(this.label1);
            this.gropboxPaymentOption.Controls.Add(this.cmbPaymentOption);
            this.gropboxPaymentOption.Location = new System.Drawing.Point(78, 163);
            this.gropboxPaymentOption.Margin = new System.Windows.Forms.Padding(1);
            this.gropboxPaymentOption.Name = "gropboxPaymentOption";
            this.gropboxPaymentOption.Padding = new System.Windows.Forms.Padding(1);
            this.gropboxPaymentOption.Size = new System.Drawing.Size(381, 139);
            this.gropboxPaymentOption.TabIndex = 128;
            this.gropboxPaymentOption.TabStop = false;
            // 
            // gropboxPayment
            // 
            this.gropboxPayment.Controls.Add(this.lblStatus);
            this.gropboxPayment.Controls.Add(this.labelStatus);
            this.gropboxPayment.Controls.Add(this.lblTotalAmount);
            this.gropboxPayment.Controls.Add(this.labelTotalAmount);
            this.gropboxPayment.Controls.Add(this.lblDepositPaid);
            this.gropboxPayment.Controls.Add(this.labelDepositPaid);
            this.gropboxPayment.Controls.Add(this.lblCharge);
            this.gropboxPayment.Controls.Add(this.labelCharge);
            this.gropboxPayment.Controls.Add(this.lblBookingAmount);
            this.gropboxPayment.Controls.Add(this.lblDeposit);
            this.gropboxPayment.Controls.Add(this.lblDate);
            this.gropboxPayment.Controls.Add(this.lblType);
            this.gropboxPayment.Controls.Add(this.lblCustomerID);
            this.gropboxPayment.Controls.Add(this.lblBookingNo);
            this.gropboxPayment.Controls.Add(this.labelBookingAmount);
            this.gropboxPayment.Controls.Add(this.labelDeposit);
            this.gropboxPayment.Controls.Add(this.label14);
            this.gropboxPayment.Controls.Add(this.label10);
            this.gropboxPayment.Controls.Add(this.label11);
            this.gropboxPayment.Controls.Add(this.label13);
            this.gropboxPayment.Controls.Add(this.btnBack);
            this.gropboxPayment.Controls.Add(this.btnPay);
            this.gropboxPayment.Location = new System.Drawing.Point(56, 114);
            this.gropboxPayment.Margin = new System.Windows.Forms.Padding(1);
            this.gropboxPayment.Name = "gropboxPayment";
            this.gropboxPayment.Padding = new System.Windows.Forms.Padding(1);
            this.gropboxPayment.Size = new System.Drawing.Size(447, 368);
            this.gropboxPayment.TabIndex = 131;
            this.gropboxPayment.TabStop = false;
            this.gropboxPayment.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(175, 214);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(143, 19);
            this.lblStatus.TabIndex = 145;
            this.lblStatus.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelStatus.Location = new System.Drawing.Point(20, 216);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(104, 19);
            this.labelStatus.TabIndex = 144;
            this.labelStatus.Text = "Deposit Status";
            this.labelStatus.Visible = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Location = new System.Drawing.Point(176, 268);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(143, 19);
            this.lblTotalAmount.TabIndex = 143;
            this.lblTotalAmount.Visible = false;
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.AutoSize = true;
            this.labelTotalAmount.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelTotalAmount.Location = new System.Drawing.Point(20, 270);
            this.labelTotalAmount.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Size = new System.Drawing.Size(100, 19);
            this.labelTotalAmount.TabIndex = 142;
            this.labelTotalAmount.Text = "Total Amount";
            this.labelTotalAmount.Visible = false;
            // 
            // lblDepositPaid
            // 
            this.lblDepositPaid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDepositPaid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDepositPaid.Location = new System.Drawing.Point(175, 188);
            this.lblDepositPaid.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblDepositPaid.Name = "lblDepositPaid";
            this.lblDepositPaid.Size = new System.Drawing.Size(143, 19);
            this.lblDepositPaid.TabIndex = 141;
            this.lblDepositPaid.Visible = false;
            // 
            // labelDepositPaid
            // 
            this.labelDepositPaid.AutoSize = true;
            this.labelDepositPaid.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelDepositPaid.Location = new System.Drawing.Point(21, 190);
            this.labelDepositPaid.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelDepositPaid.Name = "labelDepositPaid";
            this.labelDepositPaid.Size = new System.Drawing.Size(94, 19);
            this.labelDepositPaid.TabIndex = 140;
            this.labelDepositPaid.Text = "Deposit Paid";
            this.labelDepositPaid.Visible = false;
            // 
            // lblCharge
            // 
            this.lblCharge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCharge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCharge.Location = new System.Drawing.Point(175, 160);
            this.lblCharge.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(143, 19);
            this.lblCharge.TabIndex = 139;
            // 
            // labelCharge
            // 
            this.labelCharge.AutoSize = true;
            this.labelCharge.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelCharge.Location = new System.Drawing.Point(20, 162);
            this.labelCharge.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelCharge.Name = "labelCharge";
            this.labelCharge.Size = new System.Drawing.Size(57, 19);
            this.labelCharge.TabIndex = 138;
            this.labelCharge.Text = "Charge";
            // 
            // lblBookingAmount
            // 
            this.lblBookingAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBookingAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBookingAmount.Location = new System.Drawing.Point(175, 241);
            this.lblBookingAmount.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblBookingAmount.Name = "lblBookingAmount";
            this.lblBookingAmount.Size = new System.Drawing.Size(143, 19);
            this.lblBookingAmount.TabIndex = 135;
            this.lblBookingAmount.Visible = false;
            // 
            // lblDeposit
            // 
            this.lblDeposit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDeposit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDeposit.Location = new System.Drawing.Point(175, 133);
            this.lblDeposit.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(143, 19);
            this.lblDeposit.TabIndex = 134;
            // 
            // lblDate
            // 
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(175, 105);
            this.lblDate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(143, 19);
            this.lblDate.TabIndex = 131;
            // 
            // lblType
            // 
            this.lblType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblType.Location = new System.Drawing.Point(175, 77);
            this.lblType.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(143, 19);
            this.lblType.TabIndex = 130;
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomerID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCustomerID.Location = new System.Drawing.Point(175, 48);
            this.lblCustomerID.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(143, 19);
            this.lblCustomerID.TabIndex = 129;
            // 
            // lblBookingNo
            // 
            this.lblBookingNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBookingNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBookingNo.Location = new System.Drawing.Point(175, 20);
            this.lblBookingNo.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblBookingNo.Name = "lblBookingNo";
            this.lblBookingNo.Size = new System.Drawing.Size(143, 19);
            this.lblBookingNo.TabIndex = 128;
            // 
            // labelBookingAmount
            // 
            this.labelBookingAmount.AutoSize = true;
            this.labelBookingAmount.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelBookingAmount.Location = new System.Drawing.Point(20, 243);
            this.labelBookingAmount.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelBookingAmount.Name = "labelBookingAmount";
            this.labelBookingAmount.Size = new System.Drawing.Size(122, 19);
            this.labelBookingAmount.TabIndex = 127;
            this.labelBookingAmount.Text = "Booking Amount";
            this.labelBookingAmount.Visible = false;
            // 
            // labelDeposit
            // 
            this.labelDeposit.AutoSize = true;
            this.labelDeposit.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelDeposit.Location = new System.Drawing.Point(20, 135);
            this.labelDeposit.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelDeposit.Name = "labelDeposit";
            this.labelDeposit.Size = new System.Drawing.Size(66, 19);
            this.labelDeposit.TabIndex = 126;
            this.labelDeposit.Text = "Discount";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(21, 22);
            this.label14.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 19);
            this.label14.TabIndex = 125;
            this.label14.Text = "Booking No";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(6, 107);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 19);
            this.label10.TabIndex = 123;
            this.label10.Text = "Tour/Reservation Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(19, 79);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 19);
            this.label11.TabIndex = 122;
            this.label11.Text = "Booking Type";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(20, 50);
            this.label13.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 19);
            this.label13.TabIndex = 120;
            this.label13.Text = "IC / Passport";
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBack.Location = new System.Drawing.Point(277, 316);
            this.btnBack.Margin = new System.Windows.Forms.Padding(1);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(82, 24);
            this.btnBack.TabIndex = 118;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPay
            // 
            this.btnPay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPay.BackgroundImage")));
            this.btnPay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnPay.Location = new System.Drawing.Point(175, 304);
            this.btnPay.Margin = new System.Windows.Forms.Padding(1);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(100, 49);
            this.btnPay.TabIndex = 117;
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reportDataSource9.Name = "DataSet1";
            reportDataSource9.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource9);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Assigment2.Receipt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 60);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(477, 400);
            this.reportViewer1.TabIndex = 132;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // Pay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 480);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.gropboxPayment);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBookingNo);
            this.Controls.Add(this.gropboxPaymentOption);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Pay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Payment";
            this.Activated += new System.EventHandler(this.Pay_Activated);
            this.Deactivate += new System.EventHandler(this.Pay_Deactivate);
            this.Load += new System.EventHandler(this.Pay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet3)).EndInit();
            this.gropboxPaymentOption.ResumeLayout(false);
            this.gropboxPaymentOption.PerformLayout();
            this.gropboxPayment.ResumeLayout(false);
            this.gropboxPayment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBookingNo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPaymentMethods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPaymentOption;
        private System.Windows.Forms.GroupBox gropboxPaymentOption;
        private System.Windows.Forms.GroupBox gropboxPayment;
        private System.Windows.Forms.Label lblDepositPaid;
        private System.Windows.Forms.Label labelDepositPaid;
        private System.Windows.Forms.Label lblCharge;
        private System.Windows.Forms.Label labelCharge;
        private System.Windows.Forms.Label lblBookingAmount;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label lblBookingNo;
        private System.Windows.Forms.Label labelBookingAmount;
        private System.Windows.Forms.Label labelDeposit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label labelTotalAmount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label labelStatus;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private DataSet3 DataSet3;
        private DataSet3TableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
    }
}