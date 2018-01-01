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
            this.mOpenAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpenFileData = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpenTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSaveMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mSaveAsMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mAESaveMap = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mRZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mAEZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mRZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mPan = new System.Windows.Forms.ToolStripMenuItem();
            this.mFullExtent = new System.Windows.Forms.ToolStripMenuItem();
            this.其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.量测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mMLength = new System.Windows.Forms.ToolStripMenuItem();
            this.mMAera = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).BeginInit();
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.缩放ToolStripMenuItem,
            this.其他ToolStripMenuItem});
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
            this.mOpenRaster,
            this.mOpenAccess,
            this.mOpenFileData,
            this.mOpenTxt});
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
            this.打开mxdToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
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
            this.打开shpToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
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
            this.mOpenRaster.Size = new System.Drawing.Size(160, 22);
            this.mOpenRaster.Text = "打开栅格";
            this.mOpenRaster.Click += new System.EventHandler(this.mOpenRaster_Click);
            // 
            // mOpenAccess
            // 
            this.mOpenAccess.Name = "mOpenAccess";
            this.mOpenAccess.Size = new System.Drawing.Size(160, 22);
            this.mOpenAccess.Text = "打开个人数据库";
            this.mOpenAccess.Click += new System.EventHandler(this.mOpenAccess_Click);
            // 
            // mOpenFileData
            // 
            this.mOpenFileData.Name = "mOpenFileData";
            this.mOpenFileData.Size = new System.Drawing.Size(160, 22);
            this.mOpenFileData.Text = "打开文件数据库";
            this.mOpenFileData.Click += new System.EventHandler(this.mOpenFileData_Click);
            // 
            // mOpenTxt
            // 
            this.mOpenTxt.Name = "mOpenTxt";
            this.mOpenTxt.Size = new System.Drawing.Size(160, 22);
            this.mOpenTxt.Text = "加载txt文件";
            this.mOpenTxt.Click += new System.EventHandler(this.mOpenTxt_Click);
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
            this.mZoomIn,
            this.mZoomOut,
            this.mRZoomIn,
            this.mRZoomOut,
            this.mPan,
            this.mFullExtent});
            this.缩放ToolStripMenuItem.Name = "缩放ToolStripMenuItem";
            this.缩放ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.缩放ToolStripMenuItem.Text = "缩放";
            // 
            // mZoomIn
            // 
            this.mZoomIn.Name = "mZoomIn";
            this.mZoomIn.Size = new System.Drawing.Size(124, 22);
            this.mZoomIn.Text = "放大";
            this.mZoomIn.Click += new System.EventHandler(this.mZoomIn_Click);
            // 
            // mZoomOut
            // 
            this.mZoomOut.Name = "mZoomOut";
            this.mZoomOut.Size = new System.Drawing.Size(124, 22);
            this.mZoomOut.Text = "缩小";
            this.mZoomOut.Click += new System.EventHandler(this.mZoomOut_Click);
            // 
            // mRZoomIn
            // 
            this.mRZoomIn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAEZoomIn});
            this.mRZoomIn.Name = "mRZoomIn";
            this.mRZoomIn.Size = new System.Drawing.Size(124, 22);
            this.mRZoomIn.Text = "拉框放大";
            this.mRZoomIn.Click += new System.EventHandler(this.mRZoomIn_Click);
            // 
            // mAEZoomIn
            // 
            this.mAEZoomIn.Name = "mAEZoomIn";
            this.mAEZoomIn.Size = new System.Drawing.Size(115, 22);
            this.mAEZoomIn.Text = "AE实现";
            this.mAEZoomIn.Click += new System.EventHandler(this.mAEZoomIn_Click);
            // 
            // mRZoomOut
            // 
            this.mRZoomOut.Name = "mRZoomOut";
            this.mRZoomOut.Size = new System.Drawing.Size(124, 22);
            this.mRZoomOut.Text = "拉框缩小";
            this.mRZoomOut.Click += new System.EventHandler(this.mRZoomOut_Click);
            // 
            // mPan
            // 
            this.mPan.Name = "mPan";
            this.mPan.Size = new System.Drawing.Size(124, 22);
            this.mPan.Text = "缩放";
            this.mPan.Click += new System.EventHandler(this.mPan_Click);
            // 
            // mFullExtent
            // 
            this.mFullExtent.Name = "mFullExtent";
            this.mFullExtent.Size = new System.Drawing.Size(124, 22);
            this.mFullExtent.Text = "全图显示";
            this.mFullExtent.Click += new System.EventHandler(this.mFullExtent_Click);
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.量测ToolStripMenuItem});
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.其他ToolStripMenuItem.Text = "其他";
            // 
            // 量测ToolStripMenuItem
            // 
            this.量测ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mMLength,
            this.mMAera});
            this.量测ToolStripMenuItem.Name = "量测ToolStripMenuItem";
            this.量测ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.量测ToolStripMenuItem.Text = "量测";
            // 
            // mMLength
            // 
            this.mMLength.Name = "mMLength";
            this.mMLength.Size = new System.Drawing.Size(152, 22);
            this.mMLength.Text = "长度";
            this.mMLength.Click += new System.EventHandler(this.mMLength_Click);
            // 
            // mMAera
            // 
            this.mMAera.Name = "mMAera";
            this.mMAera.Size = new System.Drawing.Size(152, 22);
            this.mMAera.Text = "面积";
            this.mMAera.Click += new System.EventHandler(this.mMAera_Click);
            // 
            // mainMapControl
            // 
            this.mainMapControl.Location = new System.Drawing.Point(149, 28);
            this.mainMapControl.Name = "mainMapControl";
            this.mainMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainMapControl.OcxState")));
            this.mainMapControl.Size = new System.Drawing.Size(1070, 507);
            this.mainMapControl.TabIndex = 2;
            this.mainMapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.mainMapControl_OnMouseDown);
            this.mainMapControl.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.mainMapControl_OnMouseMove);
            this.mainMapControl.OnDoubleClick += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnDoubleClickEventHandler(this.mainMapControl_OnDoubleClick);
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem mZoomOut;
        private System.Windows.Forms.ToolStripMenuItem mAESaveMap;
        private System.Windows.Forms.ToolStripMenuItem mAddShpByWorkSpace;
        private System.Windows.Forms.ToolStripMenuItem mAddShp;
        private System.Windows.Forms.ToolStripMenuItem mAEOpenMxd;
        private System.Windows.Forms.ToolStripMenuItem mLoadMxd;
        private System.Windows.Forms.ToolStripMenuItem mMapDocu;
        private System.Windows.Forms.ToolStripMenuItem mZoomIn;
        private System.Windows.Forms.ToolStripMenuItem mRZoomIn;
        private System.Windows.Forms.ToolStripMenuItem mRZoomOut;
        private System.Windows.Forms.ToolStripMenuItem mOpenAccess;
        private System.Windows.Forms.ToolStripMenuItem mOpenFileData;
        private System.Windows.Forms.ToolStripMenuItem mOpenTxt;
        private System.Windows.Forms.ToolStripMenuItem mPan;
        private System.Windows.Forms.ToolStripMenuItem mFullExtent;
        private System.Windows.Forms.ToolStripMenuItem mAEZoomIn;
        private System.Windows.Forms.ToolStripMenuItem 其他ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 量测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mMLength;
        private System.Windows.Forms.ToolStripMenuItem mMAera;
    }
}

