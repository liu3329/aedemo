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
            this.��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��mxdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mAEOpenMxd = new System.Windows.Forms.ToolStripMenuItem();
            this.mLoadMxd = new System.Windows.Forms.ToolStripMenuItem();
            this.mMapDocu = new System.Windows.Forms.ToolStripMenuItem();
            this.��shpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mAddShpByWorkSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.mAddShp = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpenRaster = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpenAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpenFileData = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpenTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSaveMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mSaveAsMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mAESaveMap = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mRZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mAEZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mRZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mPan = new System.Windows.Forms.ToolStripMenuItem();
            this.mFullExtent = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.��ToolStripMenuItem,
            this.����ToolStripMenuItem,
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
            this.mOpenRaster,
            this.mOpenAccess,
            this.mOpenFileData,
            this.mOpenTxt});
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
            this.��mxdToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
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
            this.��shpToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
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
            this.mOpenRaster.Size = new System.Drawing.Size(160, 22);
            this.mOpenRaster.Text = "��դ��";
            this.mOpenRaster.Click += new System.EventHandler(this.mOpenRaster_Click);
            // 
            // mOpenAccess
            // 
            this.mOpenAccess.Name = "mOpenAccess";
            this.mOpenAccess.Size = new System.Drawing.Size(160, 22);
            this.mOpenAccess.Text = "�򿪸������ݿ�";
            this.mOpenAccess.Click += new System.EventHandler(this.mOpenAccess_Click);
            // 
            // mOpenFileData
            // 
            this.mOpenFileData.Name = "mOpenFileData";
            this.mOpenFileData.Size = new System.Drawing.Size(160, 22);
            this.mOpenFileData.Text = "���ļ����ݿ�";
            this.mOpenFileData.Click += new System.EventHandler(this.mOpenFileData_Click);
            // 
            // mOpenTxt
            // 
            this.mOpenTxt.Name = "mOpenTxt";
            this.mOpenTxt.Size = new System.Drawing.Size(160, 22);
            this.mOpenTxt.Text = "����txt�ļ�";
            this.mOpenTxt.Click += new System.EventHandler(this.mOpenTxt_Click);
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
            this.mZoomIn,
            this.mZoomOut,
            this.mRZoomIn,
            this.mRZoomOut,
            this.mPan,
            this.mFullExtent});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.����ToolStripMenuItem.Text = "����";
            // 
            // mZoomIn
            // 
            this.mZoomIn.Name = "mZoomIn";
            this.mZoomIn.Size = new System.Drawing.Size(124, 22);
            this.mZoomIn.Text = "�Ŵ�";
            this.mZoomIn.Click += new System.EventHandler(this.mZoomIn_Click);
            // 
            // mZoomOut
            // 
            this.mZoomOut.Name = "mZoomOut";
            this.mZoomOut.Size = new System.Drawing.Size(124, 22);
            this.mZoomOut.Text = "��С";
            this.mZoomOut.Click += new System.EventHandler(this.mZoomOut_Click);
            // 
            // mRZoomIn
            // 
            this.mRZoomIn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAEZoomIn});
            this.mRZoomIn.Name = "mRZoomIn";
            this.mRZoomIn.Size = new System.Drawing.Size(124, 22);
            this.mRZoomIn.Text = "����Ŵ�";
            this.mRZoomIn.Click += new System.EventHandler(this.mRZoomIn_Click);
            // 
            // mAEZoomIn
            // 
            this.mAEZoomIn.Name = "mAEZoomIn";
            this.mAEZoomIn.Size = new System.Drawing.Size(115, 22);
            this.mAEZoomIn.Text = "AEʵ��";
            this.mAEZoomIn.Click += new System.EventHandler(this.mAEZoomIn_Click);
            // 
            // mRZoomOut
            // 
            this.mRZoomOut.Name = "mRZoomOut";
            this.mRZoomOut.Size = new System.Drawing.Size(124, 22);
            this.mRZoomOut.Text = "������С";
            this.mRZoomOut.Click += new System.EventHandler(this.mRZoomOut_Click);
            // 
            // mPan
            // 
            this.mPan.Name = "mPan";
            this.mPan.Size = new System.Drawing.Size(124, 22);
            this.mPan.Text = "����";
            this.mPan.Click += new System.EventHandler(this.mPan_Click);
            // 
            // mFullExtent
            // 
            this.mFullExtent.Name = "mFullExtent";
            this.mFullExtent.Size = new System.Drawing.Size(124, 22);
            this.mFullExtent.Text = "ȫͼ��ʾ";
            this.mFullExtent.Click += new System.EventHandler(this.mFullExtent_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����ToolStripMenuItem});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.����ToolStripMenuItem.Text = "����";
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mMLength,
            this.mMAera});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.����ToolStripMenuItem.Text = "����";
            // 
            // mMLength
            // 
            this.mMLength.Name = "mMLength";
            this.mMLength.Size = new System.Drawing.Size(152, 22);
            this.mMLength.Text = "����";
            this.mMLength.Click += new System.EventHandler(this.mMLength_Click);
            // 
            // mMAera
            // 
            this.mMAera.Name = "mMAera";
            this.mMAera.Size = new System.Drawing.Size(152, 22);
            this.mMAera.Text = "���";
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
        private System.Windows.Forms.ToolStripMenuItem ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��mxdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��shpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mOpenRaster;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSaveMap;
        private System.Windows.Forms.ToolStripMenuItem mSaveAsMap;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mMLength;
        private System.Windows.Forms.ToolStripMenuItem mMAera;
    }
}

