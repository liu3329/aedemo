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
            this.bt_LocalMxFile = new System.Windows.Forms.Button();
            this.mainMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.bt_mapDocu = new System.Windows.Forms.Button();
            this.bt_controlopen = new System.Windows.Forms.Button();
            this.bt_WorkSpaceLoad = new System.Windows.Forms.Button();
            this.bt_addshpfile = new System.Windows.Forms.Button();
            this.bt_addRaster = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
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
            // bt_LocalMxFile
            // 
            this.bt_LocalMxFile.Location = new System.Drawing.Point(12, 34);
            this.bt_LocalMxFile.Name = "bt_LocalMxFile";
            this.bt_LocalMxFile.Size = new System.Drawing.Size(113, 23);
            this.bt_LocalMxFile.TabIndex = 1;
            this.bt_LocalMxFile.Text = "loadmxf打开地图文档";
            this.bt_LocalMxFile.UseVisualStyleBackColor = true;
            this.bt_LocalMxFile.Click += new System.EventHandler(this.bt_LocalMxFile1);
            // 
            // mainMapControl
            // 
            this.mainMapControl.Location = new System.Drawing.Point(276, 12);
            this.mainMapControl.Name = "mainMapControl";
            this.mainMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainMapControl.OcxState")));
            this.mainMapControl.Size = new System.Drawing.Size(943, 395);
            this.mainMapControl.TabIndex = 2;
            // 
            // bt_mapDocu
            // 
            this.bt_mapDocu.Location = new System.Drawing.Point(146, 34);
            this.bt_mapDocu.Name = "bt_mapDocu";
            this.bt_mapDocu.Size = new System.Drawing.Size(113, 23);
            this.bt_mapDocu.TabIndex = 3;
            this.bt_mapDocu.Text = "mapdocu打开地图";
            this.bt_mapDocu.UseVisualStyleBackColor = true;
            this.bt_mapDocu.Click += new System.EventHandler(this.bt_mapDocu_Click);
            // 
            // bt_controlopen
            // 
            this.bt_controlopen.Location = new System.Drawing.Point(12, 83);
            this.bt_controlopen.Name = "bt_controlopen";
            this.bt_controlopen.Size = new System.Drawing.Size(113, 23);
            this.bt_controlopen.TabIndex = 4;
            this.bt_controlopen.Text = "controlopen打开地图";
            this.bt_controlopen.UseVisualStyleBackColor = true;
            this.bt_controlopen.Click += new System.EventHandler(this.bt_controlopen_Click);
            // 
            // bt_WorkSpaceLoad
            // 
            this.bt_WorkSpaceLoad.Location = new System.Drawing.Point(146, 83);
            this.bt_WorkSpaceLoad.Name = "bt_WorkSpaceLoad";
            this.bt_WorkSpaceLoad.Size = new System.Drawing.Size(113, 23);
            this.bt_WorkSpaceLoad.TabIndex = 5;
            this.bt_WorkSpaceLoad.Text = "通过工作空间加载shp";
            this.bt_WorkSpaceLoad.UseVisualStyleBackColor = true;
            this.bt_WorkSpaceLoad.Click += new System.EventHandler(this.bt_WorkSpaceLoad_Click);
            // 
            // bt_addshpfile
            // 
            this.bt_addshpfile.Location = new System.Drawing.Point(13, 126);
            this.bt_addshpfile.Name = "bt_addshpfile";
            this.bt_addshpfile.Size = new System.Drawing.Size(112, 23);
            this.bt_addshpfile.TabIndex = 6;
            this.bt_addshpfile.Text = "addshpfile加载";
            this.bt_addshpfile.UseVisualStyleBackColor = true;
            this.bt_addshpfile.Click += new System.EventHandler(this.bt_addshpfile_Click);
            // 
            // bt_addRaster
            // 
            this.bt_addRaster.Location = new System.Drawing.Point(146, 126);
            this.bt_addRaster.Name = "bt_addRaster";
            this.bt_addRaster.Size = new System.Drawing.Size(113, 23);
            this.bt_addRaster.TabIndex = 7;
            this.bt_addRaster.Text = "添加栅格图";
            this.bt_addRaster.UseVisualStyleBackColor = true;
            this.bt_addRaster.Click += new System.EventHandler(this.bt_addRaster_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 419);
            this.Controls.Add(this.bt_addRaster);
            this.Controls.Add(this.bt_addshpfile);
            this.Controls.Add(this.bt_WorkSpaceLoad);
            this.Controls.Add(this.bt_controlopen);
            this.Controls.Add(this.bt_mapDocu);
            this.Controls.Add(this.mainMapControl);
            this.Controls.Add(this.bt_LocalMxFile);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Button bt_LocalMxFile;
        private ESRI.ArcGIS.Controls.AxMapControl mainMapControl;
        private System.Windows.Forms.Button bt_mapDocu;
        private System.Windows.Forms.Button bt_controlopen;
        private System.Windows.Forms.Button bt_WorkSpaceLoad;
        private System.Windows.Forms.Button bt_addshpfile;
        private System.Windows.Forms.Button bt_addRaster;
    }
}

