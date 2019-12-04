namespace P09_ADO.NET_form {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.appointmentSet1 = new P09_ADO.NET_form.AppointmentSet();
            this.loadMDBButton = new System.Windows.Forms.Button();
            this.storeMDBButton = new System.Windows.Forms.Button();
            this.loadXMLButton = new System.Windows.Forms.Button();
            this.storeXMLButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.filterButton = new System.Windows.Forms.Button();
            this.resetFilterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1366, 633);
            this.dataGridView1.TabIndex = 0;
            // 
            // appointmentSet1
            // 
            this.appointmentSet1.DataSetName = "AppointmentSet";
            this.appointmentSet1.Locale = new System.Globalization.CultureInfo("de-CH");
            this.appointmentSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // loadMDBButton
            // 
            this.loadMDBButton.Location = new System.Drawing.Point(12, 12);
            this.loadMDBButton.Name = "loadMDBButton";
            this.loadMDBButton.Size = new System.Drawing.Size(121, 47);
            this.loadMDBButton.TabIndex = 1;
            this.loadMDBButton.Text = "load mdb";
            this.loadMDBButton.UseVisualStyleBackColor = true;
            this.loadMDBButton.Click += new System.EventHandler(this.loadMDBButton_Click);
            // 
            // storeMDBButton
            // 
            this.storeMDBButton.Location = new System.Drawing.Point(139, 12);
            this.storeMDBButton.Name = "storeMDBButton";
            this.storeMDBButton.Size = new System.Drawing.Size(121, 47);
            this.storeMDBButton.TabIndex = 2;
            this.storeMDBButton.Text = "store mbd";
            this.storeMDBButton.UseVisualStyleBackColor = true;
            this.storeMDBButton.Click += new System.EventHandler(this.storeMDBButton_Click);
            // 
            // loadXMLButton
            // 
            this.loadXMLButton.Location = new System.Drawing.Point(290, 13);
            this.loadXMLButton.Name = "loadXMLButton";
            this.loadXMLButton.Size = new System.Drawing.Size(121, 46);
            this.loadXMLButton.TabIndex = 3;
            this.loadXMLButton.Text = "load XML";
            this.loadXMLButton.UseVisualStyleBackColor = true;
            this.loadXMLButton.Click += new System.EventHandler(this.loadXMLButton_Click);
            // 
            // storeXMLButton
            // 
            this.storeXMLButton.Location = new System.Drawing.Point(417, 14);
            this.storeXMLButton.Name = "storeXMLButton";
            this.storeXMLButton.Size = new System.Drawing.Size(121, 45);
            this.storeXMLButton.TabIndex = 4;
            this.storeXMLButton.Text = "store XML";
            this.storeXMLButton.UseVisualStyleBackColor = true;
            this.storeXMLButton.Click += new System.EventHandler(this.storeXMLButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(902, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(317, 26);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(1225, 12);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(51, 45);
            this.filterButton.TabIndex = 6;
            this.filterButton.Text = "filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // resetFilterButton
            // 
            this.resetFilterButton.Location = new System.Drawing.Point(1282, 12);
            this.resetFilterButton.Name = "resetFilterButton";
            this.resetFilterButton.Size = new System.Drawing.Size(96, 45);
            this.resetFilterButton.TabIndex = 7;
            this.resetFilterButton.Text = "reset filter";
            this.resetFilterButton.UseVisualStyleBackColor = true;
            this.resetFilterButton.Click += new System.EventHandler(this.resetFilterButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 710);
            this.Controls.Add(this.resetFilterButton);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.storeXMLButton);
            this.Controls.Add(this.loadXMLButton);
            this.Controls.Add(this.storeMDBButton);
            this.Controls.Add(this.loadMDBButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private AppointmentSet appointmentSet1;
        private System.Windows.Forms.Button loadMDBButton;
        private System.Windows.Forms.Button storeMDBButton;
        private System.Windows.Forms.Button loadXMLButton;
        private System.Windows.Forms.Button storeXMLButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button resetFilterButton;
    }
}

