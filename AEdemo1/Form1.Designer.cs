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
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开mxdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mAEOpenMxd = new System.Windows.Forms.ToolStripMenuItem();
            this.mLoadMxd = new System.Windows.Forms.ToolStripMenuItem();
            this.mMapDocu = new System.Windows.Forms.ToolStripMenuItem();
            this.打开shpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mAddShpByWorkSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.mAddShp = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpenRaster = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSaveMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mSaveAsMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mAESaveMap = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.缩放ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1231, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "缩放";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开mxdToolStripMenuItem,
            this.打开shpToolStripMenuItem,
            this.mOpenRaster});
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 打开mxdToolStripMenuItem
            // 
            this.打开mxdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAEOpenMxd,
            this.mLoadMxd,
            this.mMapDocu});
            this.打开mxdToolStripMenuItem.Name = "打开mxdToolStripMenuItem";
            this.打开mxdToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.打开mxdToolStripMenuItem.Text = "打开mxd";
            // 
            // mAEOpenMxd
            // 
            this.mAEOpenMxd.Name = "mAEOpenMxd";
            this.mAEOpenMxd.Size = new System.Drawing.Size(184, 22);
            this.mAEOpenMxd.Text = "AE打开";
            this.mAEOpenMxd.Click += new System.EventHandler(this.mAEOpenMxd_Click);
            // 
            // mLoadMxd
            // 
            this.mLoadMxd.Name = "mLoadMxd";
            this.mLoadMxd.Size = new System.Drawing.Size(184, 22);
            this.mLoadMxd.Text = "loadmxd打开";
            this.mLoadMxd.Click += new System.EventHandler(this.mLoadMxd_Click);
            // 
            // mMapDocu
            // 
            this.mMapDocu.Name = "mMapDocu";
            this.mMapDocu.Size = new System.Drawing.Size(184, 22);
            this.mMapDocu.Text = "mapdocument打开";
            this.mMapDocu.Click += new System.EventHandler(this.mMapDocu_Click);
            // 
            // 打开shpToolStripMenuItem
            // 
            this.打开shpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAddShpByWorkSpace,
            this.mAddShp});
            this.打开shpToolStripMenuItem.Name = "打开shpToolStripMenuItem";
            this.打开shpToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.打开shpToolStripMenuItem.Text = "打开shp";
            // 
            // mAddShpByWorkSpace
            // 
            this.mAddShpByWorkSpace.Name = "mAddShpByWorkSpace";
            this.mAddShpByWorkSpace.Size = new System.Drawing.Size(185, 22);
            this.mAddShpByWorkSpace.Text = "通过工作空间打开";
            this.mAddShpByWorkSpace.Click += new System.EventHandler(this.mAddShpByWorkSpace_Click);
            // 
            // mAddShp
            // 
            this.mAddShp.Name = "mAddShp";
            this.mAddShp.Size = new System.Drawing.Size(185, 22);
            this.mAddShp.Text = "通过addshpfile打开";
            this.mAddShp.Click += new System.EventHandler(this.mAddShp_Click);
            // 
            // mOpenRaster
            // 
            this.mOpenRaster.Name = "mOpenRaster";
            this.mOpenRaster.Size = new System.Drawing.Size(125, 22);
            this.mOpenRaster.Text = "打开栅格";
            this.mOpenRaster.Click += new System.EventHandler(this.mOpenRaster_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSaveMap,
            this.mSaveAsMap,
            this.mAESaveMap});
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // mSaveMap
            // 
            this.mSaveMap.Name = "mSaveMap";
            this.mSaveMap.Size = new System.Drawing.Size(115, 22);
            this.mSaveMap.Text = "保存";
            this.mSaveMap.Click += new System.EventHandler(this.mSaveMap_Click);
            // 
            // mSaveAsMap
            // 
            this.mSaveAsMap.Name = "mSaveAsMap";
            this.mSaveAsMap.Size = new System.Drawing.Size(115, 22);
            this.mSaveAsMap.Text = "另存为";
            this.mSaveAsMap.Click += new System.EventHandler(this.mSaveAsMap_Click);
            // 
            // mAESaveMap
            // 
            this.mAESaveMap.Name = "mAESaveMap";
            this.mAESaveMap.Size = new System.Drawing.Size(115, 22);
            this.mAESaveMap.Text = "AE保存";
            this.mAESaveMap.Click += new System.EventHandler(this.mAESaveMap_Click);
            // 
            // 缩放ToolStripMenuItem
            // 
            this.缩放ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放大ToolStripMenuItem,
            this.缩小ToolStripMenuItem});
            this.缩放ToolStripMenuItem.Name = "缩放ToolStripMenuItem";
            this.缩放ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.缩放ToolStripMenuItem.Text = "缩放";
            // 
            // 放大ToolStripMenuItem
            // 
            this.放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            this.放大ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.放大ToolStripMenuItem.Text = "放大";
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.缩小ToolStripMenuItem.Text = "缩小";
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
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开mxdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开shpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mOpenRaster;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSaveMap;
        private System.Windows.Forms.ToolStripMenuItem mSaveAsMap;
        private System.Windows.Forms.ToolStripMenuItem 缩放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mAESaveMap;
        private System.Windows.Forms.ToolStripMenuItem mAddShpByWorkSpace;
        private System.Windows.Forms.ToolStripMenuItem mAddShp;
        private System.Windows.Forms.ToolStripMenuItem mAEOpenMxd;
        private System.Windows.Forms.ToolStripMenuItem mLoadMxd;
        private System.Windows.Forms.ToolStripMenuItem mMapDocu;
    }
}

