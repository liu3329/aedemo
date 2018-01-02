namespace AEdemo1
{
    partial class FormExportMap
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tExportWidth = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tExportHeight = new DevExpress.XtraEditors.TextEdit();
            this.dropDownButton1 = new DevExpress.XtraEditors.DropDownButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.bSave = new System.Windows.Forms.Button();
            this.bExport = new System.Windows.Forms.Button();
            this.bConcal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tExportWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tExportHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "输出宽度";
            // 
            // tExportWidth
            // 
            this.tExportWidth.Location = new System.Drawing.Point(88, 9);
            this.tExportWidth.Name = "tExportWidth";
            this.tExportWidth.Size = new System.Drawing.Size(100, 20);
            this.tExportWidth.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(258, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "输出高度";
            // 
            // tExportHeight
            // 
            this.tExportHeight.Location = new System.Drawing.Point(332, 15);
            this.tExportHeight.Name = "tExportHeight";
            this.tExportHeight.Size = new System.Drawing.Size(100, 20);
            this.tExportHeight.TabIndex = 3;
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.Location = new System.Drawing.Point(88, 55);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(135, 23);
            this.dropDownButton1.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 59);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "输出分辨率:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 117);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "请选择";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(88, 111);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(326, 20);
            this.textEdit1.TabIndex = 7;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(433, 107);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 8;
            this.bSave.Text = "保存";
            this.bSave.UseVisualStyleBackColor = true;
            // 
            // bExport
            // 
            this.bExport.Location = new System.Drawing.Point(341, 167);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(75, 23);
            this.bExport.TabIndex = 9;
            this.bExport.Text = "导出";
            this.bExport.UseVisualStyleBackColor = true;
            // 
            // bConcal
            // 
            this.bConcal.Location = new System.Drawing.Point(433, 167);
            this.bConcal.Name = "bConcal";
            this.bConcal.Size = new System.Drawing.Size(75, 23);
            this.bConcal.TabIndex = 10;
            this.bConcal.Text = "取消";
            this.bConcal.UseVisualStyleBackColor = true;
            // 
            // FormExportMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 209);
            this.Controls.Add(this.bConcal);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dropDownButton1);
            this.Controls.Add(this.tExportHeight);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.tExportWidth);
            this.Controls.Add(this.labelControl1);
            this.Name = "FormExportMap";
            this.Text = "FormExportMap";
            ((System.ComponentModel.ISupportInitialize)(this.tExportWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tExportHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit tExportWidth;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit tExportHeight;
        private DevExpress.XtraEditors.DropDownButton dropDownButton1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bExport;
        private System.Windows.Forms.Button bConcal;
    }
}