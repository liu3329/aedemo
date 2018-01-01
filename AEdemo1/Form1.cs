using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Carto���֧�ֵ�ͼ�Ĵ�������ʾ����Щ��ͼ������һ����ͼ��������ͼ�����ͼԪ����ɵ�ҳ���а������ݡ�
using ESRI.ArcGIS.Carto;
//SystemUI�������û���������ӿڶ��壬��Щ�û��������������ArcGIS Engine�н�����չ������ICommand��ITool��IToolControl�ӿڡ�
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

        #region �򿪲˵�
        #region ��mxd
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
            pOpenFileDialog.Title = "�򿪵�ͼ�ĵ�";
            pOpenFileDialog.Filter = "arcmap�ĵ���*.mxd��|*.mxd";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pFileName = pOpenFileDialog.FileName;
                if (pFileName == "")
                {
                    return;
                }
                if (mainMapControl.CheckMxFile(pFileName)) //����ͼ�ĵ�����Ч��
                {
                    mainMapControl.LoadMxFile(pFileName);//��ͼ�ռ����mxd�ĵ�.loadMxfile(·������ͼ��������������)

                }
                else
                {
                    MessageBox.Show(pFileName + "����Ч�ĵ�", "��Ϣ��ʾ");
                    return;
                }
            }
        }

        private void mMapDocu_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "�򿪵�ͼ�ĵ�";
            pOpenFileDialog.Filter = "arcmap�ĵ���*.mxd��|*.mxd";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pFileName = pOpenFileDialog.FileName;
                if (pFileName == "")
                {
                    return;
                }
                if (mainMapControl.CheckMxFile(pFileName)) //����ͼ�ĵ�����Ч��
                {
                    //����������pmapdocument����map�ؼ�����
                    IMapDocument pMapDocument = new MapDocument();
                    pMapDocument.Open(pFileName);
                    //��ȡmap�м���ĵ�ͼ�ĵ�
                    mainMapControl.Map = pMapDocument.ActiveView.FocusMap;
                    mainMapControl.ActiveView.Refresh();


                }
                else
                {
                    MessageBox.Show(pFileName + "����Ч�ĵ�", "��Ϣ��ʾ");
                    return;
                }
            }
        }
        #endregion



        #region ��դ��
        private void mOpenRaster_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "��դ���ͼ";
            pOpenFileDialog.Filter = "դ���ĵ���*.jpg��|*.jpg";
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
                IRasterWorkspace pRasterWorkspace = (IRasterWorkspace)pWorkspace; //�������ռ���ת����դ��ռ�
                IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pFileName);//��դ��ռ��դ�����ݼ��ṩ�Կ��ƹ�դ���ݼ��ĳ�Ա�ķ���
                //Ӱ��������ж��봴��
                IRasterPyramid3 pRasPyrmid = pRasterDataset as IRasterPyramid3;
                if (pRasPyrmid != null)
                {
                    if (!(pRasPyrmid.Present))
                    {
                        pRasPyrmid.Create();//����������
                    }
                }
                IRaster pRaster = pRasterDataset.CreateDefaultRaster();//����һ�����и����ݼ���Ĭ�����ԵĹ�դ����
                IRasterLayer pRasterLayer = new RasterLayerClass();//��դ��Դ����ʾѡ�
                pRasterLayer.CreateFromRaster(pRaster);//�����е�դ����󴴽�ͼ��
                ILayer pLayer = pRasterLayer as ILayer;//��դ��ͼ��ת����ͼ��
                mainMapControl.AddLayer(pLayer, 0);
            }
        }
        #endregion

        #region ��shp
        private void mAddShp_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "�򿪵�ͼ�ĵ�";
            pOpenFileDialog.Filter = "shp�ĵ���*.shp��|*.shp";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;
            pOpenFileDialog.ShowDialog();
            string pFullPath = pOpenFileDialog.FileName;
            int pIndex = pFullPath.LastIndexOf("\\");//D:\aelearning\shp\����17λ
            string pFilePath = pFullPath.Substring(0, pIndex); //0-17λ���ļ�·��
            string pFileName = pFullPath.Substring(pIndex + 1);//18��������ļ�����
            mainMapControl.AddShapeFile(pFilePath, pFileName);
        }

        private void mAddShpByWorkSpace_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "�򿪵�ͼ�ĵ�";
            pOpenFileDialog.Filter = "shp�ĵ���*.shp��|*.shp";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;
            pOpenFileDialog.ShowDialog();
            string pFullPath = pOpenFileDialog.FileName;
            //��ȡ�ļ�·��
            IWorkspaceFactory pWorkspaceFactory;
            IFeatureWorkspace pFeatureWorkspace;
            IFeatureLayer pFeatureLayer;//�ṩ����ͼ������Ժͷ���

            if (pFullPath == "")
            {
                return;
            }
            else
            {
                int pIndex = pFullPath.LastIndexOf("\\");//D:\aelearning\shp\����17λ
                string pFilePath = pFullPath.Substring(0, pIndex); //0-17λ���ļ�·��
                string pFileName = pFullPath.Substring(pIndex + 1);//18��������ļ�����
                //ʵ����shapefileworkspacefactory����
                pWorkspaceFactory = new ShapefileWorkspaceFactory();//����shape�ļ��Ĺ�������
                pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(pFilePath, 0);
                //������ʵ����Ҫ�ؼ�
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
            pOpenFileDialog.Filter = "�������ݿ⣨*.mdb��|*.mdb";
            pOpenFileDialog.Title = "�򿪸��˵������ݿ�";
            pOpenFileDialog.ShowDialog();
            string pFullPath = pOpenFileDialog.FileName;
            if (pFullPath == "")
            {
                return;
            }
            else
            {
                IWorkspaceFactory pAccessWorkspaceFactory = new AccessWorkspaceFactory();
                //��ȡ�����ռ�
                IWorkspace pWorkspace = pAccessWorkspaceFactory.OpenFromFile(pFullPath, 0);
                //���ع����ռ��������
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
        /// ���ع����ռ��е����ݷ���,�ԣ��ļ��������ݿ⣬arcsde�ռ����ݿ⣩����ʱֱ�ӵ���
        /// </summary>
        /// 
        private void AddAllDataset(IWorkspace pWorkspace, AxMapControl mapControl)
        {
            //�ṩ��ͨ�����ݼ�����ö�ٵĳ�Ա�ķ��ʡ�
            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);//��������Ϊ�κ����ݼ�
            pEnumDataset.Reset();//��ö��������������Ϊ��ʼ
            IDataset pDataset = pEnumDataset.Next();//��ö�������м�����һ�����ݼ�����enum���ݼ��е�����һ��һ���ض���dataset��
            while (pDataset != null)
            {
                //�����Ҫ�����ݼ�
                if (pDataset is IFeatureDataset)
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    //��Ҫ�ؿռ��д�Ҫ�����ݼ�
                    IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset(pDataset.Name);
                    //������ݼ��а��������ݼ�
                    IEnumDataset pEnumDataset1 = pFeatureDataset.Subsets;
                    pEnumDataset1.Reset();
                    IGroupLayer pGroupLayer = new GroupLayerClass();//�ṩ�Գ�Ա�ķ��ʣ���Щ��Ա������һ��㣬��Щ�����Ϊ������һ���㡣
                    pGroupLayer.Name = pFeatureDataset.Name;
                    IDataset pDataset1 = pEnumDataset1.Next();
                    while (pDataset1 != null)
                    {
                        if (pDataset1 is IFeatureClass)//Ҫ����
                        {
                            //�ṩ�Ի��������������ݵĲ�����Ժͷ����ķ��ʣ���ͨ����һ���������ݿ⡢shapefile�򸲸��������ࡣ
                            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                            pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset1.Name);
                            if (pFeatureLayer.FeatureClass != null)
                            {
                                pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;//Ҫ���������
                                pGroupLayer.Add(pFeatureLayer);
                                mapControl.Map.AddLayer(pFeatureLayer);
                            }
                        }
                        pDataset1 = pEnumDataset1.Next();//ָ��ָ����һ�����ݼ�
                    }
                }
                //�����Ҫ����
                else if (pDataset is IFeatureClass)
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                    pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset.Name);
                    pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                    mapControl.Map.AddLayer(pFeatureLayer);
                }
                //�����դ�����ݼ�
                else if (pDataset is IRasterDataset)
                {
                    IRasterWorkspace pRasterWorkspace = (IRasterWorkspace)pWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDataset.Name);
                    //Ӱ����������ж��봴��
                    IRasterPyramid pRasterPyramid = pRasterDataset as IRasterPyramid3;
                    if (pRasterPyramid != null && !(pRasterPyramid.Present))
                    {
                        pRasterPyramid.Create();
                    }
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromDataset(pRasterDataset);//դ��ͼ���դ�����ݼ��д���
                    mapControl.AddLayer(pRasterLayer, 0);
                }
                pDataset = pEnumDataset.Next();
            }
            mapControl.ActiveView.Refresh();



        }

 #endregion
     

       


        #region ����
        private void mSaveAsMap_Click(object sender, EventArgs e)
        {
            SaveFileDialog pSaveFileDialog = new SaveFileDialog();//�����
            pSaveFileDialog.Title = "��ѡ�񱣴�·��";
            pSaveFileDialog.OverwritePrompt = true;
            pSaveFileDialog.Filter = "arcmap�ĵ���*.mxd��|*.mxd";
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
            IMapDocument pMapDocument = new MapDocumentClass(); //�ṩ�Կ��Ƶ�ͼ�ĵ��ļ��Ķ�ȡ��д��ĳ�Ա�ķ��ʡ�
            if (sMxdFileName != null && mainMapControl.CheckMxFile(sMxdFileName))//checkmxfile���ָ�����ļ����������ǲ���һ������װ�ص�MapControl��ӳ���ĵ���
            {
                if (pMapDocument.get_IsReadOnly(sMxdFileName))
                {
                    MessageBox.Show("����ͼ�ĵ���ֻ���ģ����ܱ���");
                    pMapDocument.Close();
                    return;
                }
            }
            else
            {
                SaveFileDialog pSaveFileDialog = new SaveFileDialog();//�����
                pSaveFileDialog.Title = "��ѡ�񱣴�·��";
                pSaveFileDialog.OverwritePrompt = true;
                pSaveFileDialog.Filter = "arcmap�ĵ���*.mxd��|*.mxd";
                pSaveFileDialog.RestoreDirectory = true;
                if (pSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    sMxdFileName = pSaveFileDialog.FileName;//��ȡ����ѡ�ļ�������
                    pMapDocument.New(sMxdFileName);//��������һ���µ�ӳ���ĵ�(�ļ���)��
                    //����ͼ�ؼ���ĵ�ͼӳ��Ϊimxdcontents���ݣ���mapdocument�е�������imxdcontentsȡ��
                    pMapDocument.ReplaceContents(mainMapControl.Map as IMxdContents);//�滻ӳ���ĵ�������|�ṩ�Գ�Ա�ķ��ʣ��Ա㽫���ݴ�MXDӳ���ĵ��ļ��д��ݳ�ȥ��ʵ�ָýӿڵ�co���������Ҫ������½�ʵ������Ϊһ�����ԡ�
                    pMapDocument.Save(pMapDocument.UsesRelativePaths, true);//save��ӳ���ĵ������ݱ��浽���ļ��С�||UsesRelativePaths()��ʾӳ���ĵ��е�������ʹ�����·������
                    pMapDocument.Close();
                    MessageBox.Show("�����ĵ��ɹ�");
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


        #region ����
        private void mZoomIn_Click(object sender, EventArgs e)
        {
            //�����߽ӿڣ���ȡͼ�ε���С��Ӿ���
            IEnvelope pEnvelope = mainMapControl.Extent;//��ͼ��λ��ǰ�ĵ�ͼ��Χ��
            pEnvelope.Expand(0.5, 0.5, true);//�Ŵ�2��
            mainMapControl.Extent = pEnvelope;//����ͼ�ķ�Χ�޸�Ϊ �����ķ�Χ
            mainMapControl.ActiveView.Refresh();//���»��Ƶ�ͼ
            double max = pEnvelope.XMax;
            MessageBox.Show(max.ToString());
        }

        private void mZoomOut_Click(object sender, EventArgs e)
        {
            //�����߽ӿڣ���ȡͼ�ε���С��Ӿ���
            IEnvelope pEnvelope = mainMapControl.Extent;//��ͼ��λ��ǰ�ĵ�ͼ��Χ��
            pEnvelope.Expand(1.5, 1.5, true);//�Ŵ�2��
            mainMapControl.Extent = pEnvelope;//����ͼ�ķ�Χ�޸�Ϊ �����ķ�Χ
            mainMapControl.ActiveView.Refresh();//���»��Ƶ�ͼ
        }


        private void mRZoomIn_Click(object sender, EventArgs e)
        {
            IActiveView pActiveView = mainMapControl.ActiveView;
            IEnvelope pEnvelope = mainMapControl.TrackRectangle();//�÷�����MapControl�ϴ���������¼���Ȼ�����ɹ켣����
            //���������û��
            if (pEnvelope == null || pEnvelope.IsEmpty || pEnvelope.Height == 0 || pEnvelope.Width == 0)
            {
                return;
            }
            else//����а����߷�Χ
            {
                pActiveView.Extent = pEnvelope;
                pActiveView.Refresh();
            }
        }

        private void mRZoomOut_Click(object sender, EventArgs e)
        {
            IActiveView pActiveView = mainMapControl.ActiveView;//�ýӿڹ���ArcMap�е���Ӧ�ó��򴰿ں����л�ͼ������
            IEnvelope pEnvelope = mainMapControl.TrackRectangle();//�÷�����MapControl�ϴ���������¼���Ȼ�����ɹ켣����
            //���������û��
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

        #region ����txt

        
      




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
            ITool pTool = pCommand as ITool;//��icommandת����itool����
            pCommand.OnCreate(mainMapControl.Object);
            mainMapControl.CurrentTool = pTool as ITool;
        }

      



    }
}