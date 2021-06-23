namespace MrCy
{
    partial class frmStorage
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
            this.label1 = new System.Windows.Forms.Label();
            this.materialNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.materialName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.materialSup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.materialCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.materialPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.totalPrice = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.inStorage = new System.Windows.Forms.Button();
            this.storageCheck = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.storageCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "材料序号";
            // 
            // materialNum
            // 
            this.materialNum.Location = new System.Drawing.Point(117, 22);
            this.materialNum.Name = "materialNum";
            this.materialNum.Size = new System.Drawing.Size(139, 25);
            this.materialNum.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "材料名称";
            // 
            // materialName
            // 
            this.materialName.Enabled = false;
            this.materialName.Location = new System.Drawing.Point(391, 22);
            this.materialName.Name = "materialName";
            this.materialName.Size = new System.Drawing.Size(148, 25);
            this.materialName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(603, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "材料供应商";
            // 
            // materialSup
            // 
            this.materialSup.Enabled = false;
            this.materialSup.Location = new System.Drawing.Point(691, 22);
            this.materialSup.Name = "materialSup";
            this.materialSup.Size = new System.Drawing.Size(135, 25);
            this.materialSup.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "入库数量";
            // 
            // materialCount
            // 
            this.materialCount.Location = new System.Drawing.Point(117, 93);
            this.materialCount.Name = "materialCount";
            this.materialCount.Size = new System.Drawing.Size(139, 25);
            this.materialCount.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "材料单价";
            // 
            // materialPrice
            // 
            this.materialPrice.Enabled = false;
            this.materialPrice.Location = new System.Drawing.Point(391, 89);
            this.materialPrice.Name = "materialPrice";
            this.materialPrice.Size = new System.Drawing.Size(148, 25);
            this.materialPrice.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(603, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "进货总金额";
            // 
            // totalPrice
            // 
            this.totalPrice.Enabled = false;
            this.totalPrice.Location = new System.Drawing.Point(691, 89);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(135, 25);
            this.totalPrice.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 41);
            this.button1.TabIndex = 12;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inStorage
            // 
            this.inStorage.Location = new System.Drawing.Point(537, 147);
            this.inStorage.Name = "inStorage";
            this.inStorage.Size = new System.Drawing.Size(105, 40);
            this.inStorage.TabIndex = 13;
            this.inStorage.Text = "入库";
            this.inStorage.UseVisualStyleBackColor = true;
            this.inStorage.Click += new System.EventHandler(this.inStorage_Click);
            // 
            // storageCheck
            // 
            this.storageCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storageCheck.Location = new System.Drawing.Point(2, 208);
            this.storageCheck.Name = "storageCheck";
            this.storageCheck.RowTemplate.Height = 27;
            this.storageCheck.Size = new System.Drawing.Size(872, 222);
            this.storageCheck.TabIndex = 14;
            // 
            // frmStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(877, 430);
            this.Controls.Add(this.storageCheck);
            this.Controls.Add(this.inStorage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.totalPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.materialPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.materialCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.materialSup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.materialName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.materialNum);
            this.Controls.Add(this.label1);
            this.Name = "frmStorage";
            this.Text = "材料仓库";
            ((System.ComponentModel.ISupportInitialize)(this.storageCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox materialNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox materialName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox materialSup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox materialCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox materialPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox totalPrice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button inStorage;
        private System.Windows.Forms.DataGridView storageCheck;
    }
}