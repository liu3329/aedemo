using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Carto类库支持地图的创建和显示，这些地图可以在一幅地图或由许多地图及其地图元素组成的页面中包含数据。
using ESRI.ArcGIS.Carto;
//SystemUI类库包含用户界面组件接口定义，这些用户界面组件可以在ArcGIS Engine中进行扩展。包含ICommand、ITool和IToolControl接口。
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
namespace AEdemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_LocalMxFile1(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "打开地图文档";
            pOpenFileDialog.Filter = "arcmap文档（*.mxd）|*.mxd";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pFileName = pOpenFileDialog.FileName;
                if (pFileName == "")
                {
                    return;
                }
                if (mainMapControl.CheckMxFile(pFileName)) //检查地图文档的有效性
                {
                    mainMapControl.LoadMxFile(pFileName);//地图空间加载mxd文档.loadMxfile(路径，地图名或索引，密码)

                }
                else
                {
                    MessageBox.Show(pFileName + "是无效文档", "信息提示");
                    return;
                }
            }
        }

        private void bt_mapDocu_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "打开地图文档";
            pOpenFileDialog.Filter = "arcmap文档（*.mxd）|*.mxd";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pFileName = pOpenFileDialog.FileName;
                if (pFileName == "")
                {
                    return;
                }
                if (mainMapControl.CheckMxFile(pFileName)) //检查地图文档的有效性
                {
                    //将数据载入pmapdocument并与map控件关联
                    IMapDocument pMapDocument = new MapDocument();
                    pMapDocument.Open(pFileName);
                    //获取map中激活的地图文档
                    mainMapControl.Map = pMapDocument.ActiveView.FocusMap;
                    mainMapControl.ActiveView.Refresh();
                   

                }
                else
                {
                    MessageBox.Show(pFileName + "是无效文档", "信息提示");
                    return;
                }
            }
        }

        private void bt_controlopen_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_WorkSpaceLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "打开地图文档";
            pOpenFileDialog.Filter = "shp文档（*.shp）|*.shp";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;
            pOpenFileDialog.ShowDialog();
            string pFullPath = pOpenFileDialog.FileName;
            //获取文件路径
            IWorkspaceFactory pWorkspaceFactory;
            IFeatureWorkspace pFeatureWorkspace;
            IFeatureLayer pFeatureLayer;//提供操作图层的属性和方法
           
            if (pFullPath == "")
            {
                return;
            }
            else {
                int pIndex = pFullPath.LastIndexOf("\\");//D:\aelearning\shp\，在17位
                string pFilePath = pFullPath.Substring(0,pIndex); //0-17位是文件路径
                string pFileName = pFullPath.Substring(pIndex+1);//18到最后是文件的名
                //实例化shapefileworkspacefactory（）
                pWorkspaceFactory = new ShapefileWorkspaceFactory();//创建shape文件的工作工厂
                pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(pFilePath,0);
                //创建并实例化要素集
                IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(pFileName);
                pFeatureLayer = new FeatureLayer();
                pFeatureLayer.FeatureClass = pFeatureClass;
                pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                mainMapControl.Map.AddLayer(pFeatureLayer);
                mainMapControl.ActiveView.Refresh();
                MessageBox.Show(pIndex.ToString());
            }
        }

        private void bt_addshpfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "打开地图文档";
            pOpenFileDialog.Filter = "shp文档（*.shp）|*.shp";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;
            pOpenFileDialog.ShowDialog();
            string pFullPath = pOpenFileDialog.FileName;
            int pIndex = pFullPath.LastIndexOf("\\");//D:\aelearning\shp\，在17位
            string pFilePath = pFullPath.Substring(0, pIndex); //0-17位是文件路径
            string pFileName = pFullPath.Substring(pIndex + 1);//18到最后是文件的名
            mainMapControl.AddShapeFile(pFilePath,pFileName);
        }

        private void bt_addRaster_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "打开栅格地图";
            pOpenFileDialog.Filter = "栅格文档（*.jpg）|*.jpg";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;
            pOpenFileDialog.ShowDialog();
            string PRasterFileName = pOpenFileDialog.FileName;
            if (PRasterFileName == "")
            {
                return;
            }
            else {
                string pPath = System.IO.Path.GetDirectoryName(PRasterFileName);
                string pFileName = System.IO.Path.GetFileName(PRasterFileName);
                IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory();
                IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(pPath,0);
                IRasterWorkspace pRasterWorkspace = pWorkspace as IRasterWorkspace;
                IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pFileName);
                //影像金字塔判断与创建
                IRasterPyramid3 pRasPyrmid = pRasterDataset as IRasterPyramid3;
                if (pRasPyrmid != null)
                {
                    if (!(pRasPyrmid.Present)) {
                        pRasPyrmid.Create();//创建金字塔
                    }
                }
                IRaster pRaster;
                pRaster = pRasterDataset.CreateDefaultRaster();
                IRasterLayer pRasterLayer;
                pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromRaster(pRaster);
                ILayer pLayer = pRasterLayer as ILayer;
                mainMapControl.AddLayer(pLayer,0);



            }
        }


    }
}