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
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesGDB;
using System.IO;
namespace AEdemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 打开菜单
        #region 打开mxd
        private void mAEOpenMxd_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(mainMapControl.Object);
            command.OnClick();
        }

        private void mLoadMxd_Click(object sender, EventArgs e)
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

        private void mMapDocu_Click(object sender, EventArgs e)
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
        #endregion



        #region 打开栅格
        private void mOpenRaster_Click(object sender, EventArgs e)
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
            else
            {
                string pPath = System.IO.Path.GetDirectoryName(PRasterFileName);
                string pFileName = System.IO.Path.GetFileName(PRasterFileName);
                IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory();
                IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(pPath, 0);
                IRasterWorkspace pRasterWorkspace = (IRasterWorkspace)pWorkspace; //将工作空间类转换成栅格空间
                IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pFileName);//从栅格空间打开栅格数据集提供对控制光栅数据集的成员的访问
                //影像金字塔判断与创建
                IRasterPyramid3 pRasPyrmid = pRasterDataset as IRasterPyramid3;
                if (pRasPyrmid != null)
                {
                    if (!(pRasPyrmid.Present))
                    {
                        pRasPyrmid.Create();//创建金字塔
                    }
                }
                IRaster pRaster = pRasterDataset.CreateDefaultRaster();//创建一个带有该数据集的默认属性的光栅对象
                IRasterLayer pRasterLayer = new RasterLayerClass();//光栅层源和显示选项。
                pRasterLayer.CreateFromRaster(pRaster);//从已有的栅格对象创建图层
                ILayer pLayer = pRasterLayer as ILayer;//将栅格图层转换成图层
                mainMapControl.AddLayer(pLayer, 0);
            }
        }
        #endregion

        #region 打开shp
        private void mAddShp_Click(object sender, EventArgs e)
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
            mainMapControl.AddShapeFile(pFilePath, pFileName);
        }

        private void mAddShpByWorkSpace_Click(object sender, EventArgs e)
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
            else
            {
                int pIndex = pFullPath.LastIndexOf("\\");//D:\aelearning\shp\，在17位
                string pFilePath = pFullPath.Substring(0, pIndex); //0-17位是文件路径
                string pFileName = pFullPath.Substring(pIndex + 1);//18到最后是文件的名
                //实例化shapefileworkspacefactory（）
                pWorkspaceFactory = new ShapefileWorkspaceFactory();//创建shape文件的工作工厂
                pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(pFilePath, 0);
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
        #endregion


        private void mOpenAccess_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.Filter = "个人数据库（*.mdb）|*.mdb";
            pOpenFileDialog.Title = "打开个人地理数据库";
            pOpenFileDialog.ShowDialog();
            string pFullPath = pOpenFileDialog.FileName;
            if (pFullPath == "")
            {
                return;
            }
            else
            {
                IWorkspaceFactory pAccessWorkspaceFactory = new AccessWorkspaceFactory();
                //获取工作空间
                IWorkspace pWorkspace = pAccessWorkspaceFactory.OpenFromFile(pFullPath, 0);
                //加载工作空间里的数据
                AddAllDataset(pWorkspace, mainMapControl);
            }
        }

        private void mOpenFileData_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() != DialogResult.OK) {
                return;
            }
            string pFullPath = dlg.SelectedPath;
            if (pFullPath == "") {
                return;
            }
            IWorkspaceFactory pFileGDBFactory = new FileGDBWorkspaceFactoryClass();
            IWorkspace pWorkspace = pFileGDBFactory.OpenFromFile(pFullPath,0);
            AddAllDataset(pWorkspace, mainMapControl);
        }

        /// <summary>
        /// 加载工作空间中的数据方法,对（文件地理数据库，arcsde空间数据库）加载时直接调用
        /// </summary>
        /// 
        private void AddAllDataset(IWorkspace pWorkspace, AxMapControl mapControl)
        {
            //提供对通过数据集进行枚举的成员的访问。
            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);//数据类型为任何数据集
            pEnumDataset.Reset();//将枚举序列重新设置为开始
            IDataset pDataset = pEnumDataset.Next();//在枚举序列中检索下一个数据集。将enum数据集中的数据一个一个地读到dataset中
            while (pDataset != null)
            {
                //如果是要素数据集
                if (pDataset is IFeatureDataset)
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    //从要素空间中打开要素数据集
                    IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset(pDataset.Name);
                    //这个数据集中包含的数据集
                    IEnumDataset pEnumDataset1 = pFeatureDataset.Subsets;
                    pEnumDataset1.Reset();
                    IGroupLayer pGroupLayer = new GroupLayerClass();//提供对成员的访问，这些成员控制着一组层，这些层的行为类似于一个层。
                    pGroupLayer.Name = pFeatureDataset.Name;
                    IDataset pDataset1 = pEnumDataset1.Next();
                    while (pDataset1 != null)
                    {
                        if (pDataset1 is IFeatureClass)//要素类
                        {
                            //提供对基于向量地理数据的层的属性和方法的访问，这通常是一个地理数据库、shapefile或覆盖率特性类。
                            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                            pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset1.Name);
                            if (pFeatureLayer.FeatureClass != null)
                            {
                                pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;//要素类的名称
                                pGroupLayer.Add(pFeatureLayer);
                                mapControl.Map.AddLayer(pFeatureLayer);
                            }
                        }
                        pDataset1 = pEnumDataset1.Next();//指针指向下一个数据集
                    }
                }
                //如果是要素类
                else if (pDataset is IFeatureClass)
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                    pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset.Name);
                    pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                    mapControl.Map.AddLayer(pFeatureLayer);
                }
                //如果是栅格数据集
                else if (pDataset is IRasterDataset)
                {
                    IRasterWorkspace pRasterWorkspace = (IRasterWorkspace)pWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDataset.Name);
                    //影像金子塔的判断与创立
                    IRasterPyramid pRasterPyramid = pRasterDataset as IRasterPyramid3;
                    if (pRasterPyramid != null && !(pRasterPyramid.Present))
                    {
                        pRasterPyramid.Create();
                    }
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromDataset(pRasterDataset);//栅格图层从栅格数据集中创建
                    mapControl.AddLayer(pRasterLayer, 0);
                }
                pDataset = pEnumDataset.Next();
            }
            mapControl.ActiveView.Refresh();



        }

 #endregion
     

       


        #region 保存
        private void mSaveAsMap_Click(object sender, EventArgs e)
        {
            SaveFileDialog pSaveFileDialog = new SaveFileDialog();//保存框
            pSaveFileDialog.Title = "请选择保存路径";
            pSaveFileDialog.OverwritePrompt = true;
            pSaveFileDialog.Filter = "arcmap文档（*.mxd）|*.mxd";
            pSaveFileDialog.RestoreDirectory = true;
            if (pSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sFilePath = pSaveFileDialog.FileName;
                IMapDocument pMapDocument = new MapDocumentClass();
                pMapDocument.New(sFilePath);
                pMapDocument.ReplaceContents(mainMapControl.Map as IMxdContents);
                pMapDocument.Save(true, true);
                pMapDocument.Close();
            }
            else
            {

            }
        }

        private void mSaveMap_Click(object sender, EventArgs e)
        {
            string sMxdFileName = mainMapControl.DocumentFilename;
            IMapDocument pMapDocument = new MapDocumentClass(); //提供对控制地图文档文件的读取和写入的成员的访问。
            if (sMxdFileName != null && mainMapControl.CheckMxFile(sMxdFileName))//checkmxfile检查指定的文件名，看它是不是一个可以装载到MapControl的映射文档。
            {
                if (pMapDocument.get_IsReadOnly(sMxdFileName))
                {
                    MessageBox.Show("本地图文档是只读的，不能保存");
                    pMapDocument.Close();
                    return;
                }
            }
            else
            {
                SaveFileDialog pSaveFileDialog = new SaveFileDialog();//保存框
                pSaveFileDialog.Title = "请选择保存路径";
                pSaveFileDialog.OverwritePrompt = true;
                pSaveFileDialog.Filter = "arcmap文档（*.mxd）|*.mxd";
                pSaveFileDialog.RestoreDirectory = true;
                if (pSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    sMxdFileName = pSaveFileDialog.FileName;//获取到所选文件的名称
                    pMapDocument.New(sMxdFileName);//创建并打开一个新的映射文档(文件名)。
                    //将地图控件里的地图映射为imxdcontents内容，将mapdocument中的内容用imxdcontents取代
                    pMapDocument.ReplaceContents(mainMapControl.Map as IMxdContents);//替换映射文档的内容|提供对成员的访问，以便将数据从MXD映射文档文件中传递出去。实现该接口的co类可以在需要的情况下将实现限制为一个属性。
                    pMapDocument.Save(pMapDocument.UsesRelativePaths, true);//save将映射文档的内容保存到绑定文件中。||UsesRelativePaths()表示映射文档中的数据是使用相对路径引用
                    pMapDocument.Close();
                    MessageBox.Show("保存文档成功");
                }
                else
                {
                    return;
                }
            }
        }

        private void mAESaveMap_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(mainMapControl.Object);
            command.OnClick();
            MessageBox.Show("ok");
        }
        #endregion


        #region 缩放
        private void mZoomIn_Click(object sender, EventArgs e)
        {
            //包络线接口，获取图形的最小外接矩形
            IEnvelope pEnvelope = mainMapControl.Extent;//地图单位当前的地图范围。
            pEnvelope.Expand(0.5, 0.5, true);//放大2倍
            mainMapControl.Extent = pEnvelope;//将地图的范围修改为 扩大后的范围
            mainMapControl.ActiveView.Refresh();//重新绘制地图
            double max = pEnvelope.XMax;
            MessageBox.Show(max.ToString());
        }

        private void mZoomOut_Click(object sender, EventArgs e)
        {
            //包络线接口，获取图形的最小外接矩形
            IEnvelope pEnvelope = mainMapControl.Extent;//地图单位当前的地图范围。
            pEnvelope.Expand(1.5, 1.5, true);//放大2倍
            mainMapControl.Extent = pEnvelope;//将地图的范围修改为 扩大后的范围
            mainMapControl.ActiveView.Refresh();//重新绘制地图
        }


        private void mRZoomIn_Click(object sender, EventArgs e)
        {
            IActiveView pActiveView = mainMapControl.ActiveView;
            IEnvelope pEnvelope = mainMapControl.TrackRectangle();//该方法在MapControl上触发鼠标点击事件，然后生成轨迹矩形
            //如果包络线没有
            if (pEnvelope == null || pEnvelope.IsEmpty || pEnvelope.Height == 0 || pEnvelope.Width == 0)
            {
                return;
            }
            else//如果有包络线范围
            {
                pActiveView.Extent = pEnvelope;
                pActiveView.Refresh();
            }
        }

        private void mRZoomOut_Click(object sender, EventArgs e)
        {
            IActiveView pActiveView = mainMapControl.ActiveView;//该接口管理ArcMap中的主应用程序窗口和所有绘图操作。
            IEnvelope pEnvelope = mainMapControl.TrackRectangle();//该方法在MapControl上触发鼠标点击事件，然后生成轨迹矩形
            //如果包络线没有
            if (pEnvelope == null || pEnvelope.IsEmpty || pEnvelope.Height == 0 || pEnvelope.Width == 0)
            {
                return;
            }
            else {
                double dWidth = pActiveView.Extent.Width * pActiveView.Extent.Width / pEnvelope.Width;
                double dHeight = pActiveView.Extent.Height * pActiveView.Extent.Height / pEnvelope.Height;
                double dXmin = pActiveView.Extent.XMin - ((pEnvelope.XMin - pActiveView.Extent.XMin) * pActiveView.Extent.Width / pEnvelope.Width);
                double dYmin = pActiveView.Extent.YMin - ((pEnvelope.YMin - pActiveView.Extent.YMin) * pActiveView.Extent.Height / pEnvelope.Height);
                double dXmax = dXmin + dWidth;
                double dYmax = dYmin + dHeight;
                pEnvelope.PutCoords(dXmin,dYmin,dXmax,dYmax);
            }
            pActiveView.Extent = pEnvelope;
            pActiveView.Refresh();

        }
        #endregion

        #region 加载txt

        
      




        #endregion










        private void mOpenTxt_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void mPan_Click(object sender, EventArgs e)
        {
            mainMapControl.Pan();
        }

        private void mFullExtent_Click(object sender, EventArgs e)
        {
            mainMapControl.Extent = mainMapControl.FullExtent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mAEZoomIn_Click(object sender, EventArgs e)
        {
            mainMapControl.CurrentTool = null;
            ICommand pCommand =  new ControlsMapZoomInToolClass();
            ITool pTool = pCommand as ITool;//将icommand转换成itool类型
            pCommand.OnCreate(mainMapControl.Object);
            mainMapControl.CurrentTool = pTool as ITool;
        }

      



    }
}