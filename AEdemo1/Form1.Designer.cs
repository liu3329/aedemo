namespace AEdemo1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.mainMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��mxdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mAEOpenMxd = new System.Windows.Forms.ToolStripMenuItem();
            this.mLoadMxd = new System.Windows.Forms.ToolStripMenuItem();
            this.mMapDocu = new System.Windows.Forms.ToolStripMenuItem();
            this.��shpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mAddShpByWorkSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.mAddShp = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpenRaster = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSaveMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mSaveAsMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mAESaveMap = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�Ŵ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��СToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(524, 314);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // mainMapControl
            // 
            this.mainMapControl.Location = new System.Drawing.Point(149, 28);
            this.mainMapControl.Name = "mainMapControl";
            this.mainMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainMapControl.OcxState")));
            this.mainMapControl.Size = new System.Drawing.Size(1070, 507);
            this.mainMapControl.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.��ToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.����ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1231, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "����";
            // 
            // ��ToolStripMenuItem
            // 
            this.��ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.��mxdToolStripMenuItem,
            this.��shpToolStripMenuItem,
            this.mOpenRaster});
            this.��ToolStripMenuItem.Name = "��ToolStripMenuItem";
            this.��ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.��ToolStripMenuItem.Text = "��";
            // 
            // ��mxdToolStripMenuItem
            // 
            this.��mxdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAEOpenMxd,
            this.mLoadMxd,
            this.mMapDocu});
            this.��mxdToolStripMenuItem.Name = "��mxdToolStripMenuItem";
            this.��mxdToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.��mxdToolStripMenuItem.Text = "��mxd";
            // 
            // mAEOpenMxd
            // 
            this.mAEOpenMxd.Name = "mAEOpenMxd";
            this.mAEOpenMxd.Size = new System.Drawing.Size(184, 22);
            this.mAEOpenMxd.Text = "AE��";
            this.mAEOpenMxd.Click += new System.EventHandler(this.mAEOpenMxd_Click);
            // 
            // mLoadMxd
            // 
            this.mLoadMxd.Name = "mLoadMxd";
            this.mLoadMxd.Size = new System.Drawing.Size(184, 22);
            this.mLoadMxd.Text = "loadmxd��";
            this.mLoadMxd.Click += new System.EventHandler(this.mLoadMxd_Click);
            // 
            // mMapDocu
            // 
            this.mMapDocu.Name = "mMapDocu";
            this.mMapDocu.Size = new System.Drawing.Size(184, 22);
            this.mMapDocu.Text = "mapdocument��";
            this.mMapDocu.Click += new System.EventHandler(this.mMapDocu_Click);
            // 
            // ��shpToolStripMenuItem
            // 
            this.��shpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAddShpByWorkSpace,
            this.mAddShp});
            this.��shpToolStripMenuItem.Name = "��shpToolStripMenuItem";
            this.��shpToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.��shpToolStripMenuItem.Text = "��shp";
            // 
            // mAddShpByWorkSpace
            // 
            this.mAddShpByWorkSpace.Name = "mAddShpByWorkSpace";
            this.mAddShpByWorkSpace.Size = new System.Drawing.Size(185, 22);
            this.mAddShpByWorkSpace.Text = "ͨ�������ռ��";
            this.mAddShpByWorkSpace.Click += new System.EventHandler(this.mAddShpByWorkSpace_Click);
            // 
            // mAddShp
            // 
            this.mAddShp.Name = "mAddShp";
            this.mAddShp.Size = new System.Drawing.Size(185, 22);
            this.mAddShp.Text = "ͨ��addshpfile��";
            this.mAddShp.Click += new System.EventHandler(this.mAddShp_Click);
            // 
            // mOpenRaster
            // 
            this.mOpenRaster.Name = "mOpenRaster";
            this.mOpenRaster.Size = new System.Drawing.Size(125, 22);
            this.mOpenRaster.Text = "��դ��";
            this.mOpenRaster.Click += new System.EventHandler(this.mOpenRaster_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSaveMap,
            this.mSaveAsMap,
            this.mAESaveMap});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.����ToolStripMenuItem.Text = "����";
            // 
            // mSaveMap
            // 
            this.mSaveMap.Name = "mSaveMap";
            this.mSaveMap.Size = new System.Drawing.Size(115, 22);
            this.mSaveMap.Text = "����";
            this.mSaveMap.Click += new System.EventHandler(this.mSaveMap_Click);
            // 
            // mSaveAsMap
            // 
            this.mSaveAsMap.Name = "mSaveAsMap";
            this.mSaveAsMap.Size = new System.Drawing.Size(115, 22);
            this.mSaveAsMap.Text = "���Ϊ";
            this.mSaveAsMap.Click += new System.EventHandler(this.mSaveAsMap_Click);
            // 
            // mAESaveMap
            // 
            this.mAESaveMap.Name = "mAESaveMap";
            this.mAESaveMap.Size = new System.Drawing.Size(115, 22);
            this.mAESaveMap.Text = "AE����";
            this.mAESaveMap.Click += new System.EventHandler(this.mAESaveMap_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�Ŵ�ToolStripMenuItem,
            this.��СToolStripMenuItem});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.����ToolStripMenuItem.Text = "����";
            // 
            // �Ŵ�ToolStripMenuItem
            // 
            this.�Ŵ�ToolStripMenuItem.Name = "�Ŵ�ToolStripMenuItem";
            this.�Ŵ�ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.�Ŵ�ToolStripMenuItem.Text = "�Ŵ�";
            // 
            // ��СToolStripMenuItem
            // 
            this.��СToolStripMenuItem.Name = "��СToolStripMenuItem";
            this.��СToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.��СToolStripMenuItem.Text = "��С";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 547);
            this.Controls.Add(this.mainMapControl);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl mainMapControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��mxdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��shpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mOpenRaster;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSaveMap;
        private System.Windows.Forms.ToolStripMenuItem mSaveAsMap;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �Ŵ�ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��СToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mAESaveMap;
        private System.Windows.Forms.ToolStripMenuItem mAddShpByWorkSpace;
        private System.Windows.Forms.ToolStripMenuItem mAddShp;
        private System.Windows.Forms.ToolStripMenuItem mAEOpenMxd;
        private System.Windows.Forms.ToolStripMenuItem mLoadMxd;
        private System.Windows.Forms.ToolStripMenuItem mMapDocu;
    }
}

