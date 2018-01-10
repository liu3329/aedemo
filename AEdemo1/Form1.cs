using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Carto���֧�ֵ�ͼ�Ĵ�������ʾ����Щ��ͼ������һ����ͼ��������ͼ�����ͼԪ����ɵ�ҳ���а������ݡ�
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
//SystemUI�������û���������ӿڶ��壬��Щ�û��������������ArcGIS Engine�н�����չ������ICommand��ITool��IToolControl�ӿڡ�
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesGDB;
using System.IO;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;

namespace AEdemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //�����ڼ���ʱ����ͼ��ؼ��󶨵�ͼ�ؼ�
            axTOCControl.SetBuddyControl(mainMapControl);
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
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string pFullPath = dlg.SelectedPath;
            if (pFullPath == "")
            {
                return;
            }
            IWorkspaceFactory pFileGDBFactory = new FileGDBWorkspaceFactoryClass();
            IWorkspace pWorkspace = pFileGDBFactory.OpenFromFile(pFullPath, 0);
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
            else
            {
                double dWidth = pActiveView.Extent.Width * pActiveView.Extent.Width / pEnvelope.Width;
                double dHeight = pActiveView.Extent.Height * pActiveView.Extent.Height / pEnvelope.Height;
                double dXmin = pActiveView.Extent.XMin - ((pEnvelope.XMin - pActiveView.Extent.XMin) * pActiveView.Extent.Width / pEnvelope.Width);
                double dYmin = pActiveView.Extent.YMin - ((pEnvelope.YMin - pActiveView.Extent.YMin) * pActiveView.Extent.Height / pEnvelope.Height);
                double dXmax = dXmin + dWidth;
                double dYmax = dYmin + dHeight;
                pEnvelope.PutCoords(dXmin, dYmin, dXmax, dYmax);
            }
            pActiveView.Extent = pEnvelope;
            pActiveView.Refresh();

        }


        private void mPan_Click(object sender, EventArgs e)
        {
            mainMapControl.Pan();
        }

        private void mFullExtent_Click(object sender, EventArgs e)
        {
            mainMapControl.Extent = mainMapControl.FullExtent;
        }

        private void mAEZoomIn_Click(object sender, EventArgs e)
        {
            mainMapControl.CurrentTool = null;
            ICommand pCommand = new ControlsMapZoomInToolClass();
            ITool pTool = pCommand as ITool;//��icommandת����itool����
            pCommand.OnCreate(mainMapControl.Object);
            mainMapControl.CurrentTool = pTool as ITool;
        }
        #endregion


        #region ����txt


        private void mOpenTxt_Click(object sender, EventArgs e)
        {

        }





        #endregion


        #region ����
        private IPoint pPointPt = null;//�������
        private IPoint pMovePT = null;//����ƶ�ʱ�ĵ�ǰ��
        private INewLineFeedback pNewLineFeedback;//׷���߶���
        private INewPolygonFeedback pNewPolygonFeedback;//׷�������
        private double dToltalLength = 0;//�����ܳ���
        private double dSegmentLength = 0;//Ƭ�ξ���
        private string pMouseOperate;//����������
        private string sMapUnits;//������λ�洢
        double area;
        private object missing = Type.Missing;

        private IPointCollection pAreaPointCol = new MultipointClass();//���������ʱ���ĵ���д洢������ļ��ϴ洢
        private void mMLength_Click(object sender, EventArgs e)
        {
            mainMapControl.CurrentTool = null;
            pMouseOperate = "MeasureLength";
            mainMapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;//���ָ����ʾ��MapControl�ϡ�          

        }

        private void mMAera_Click(object sender, EventArgs e)
        {
            mainMapControl.CurrentTool = null;
            pMouseOperate = "MeasureArea";
            mainMapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;//��ͼ��ȡָ��
        }

        /// <summary>
        /// ��ȡ��ͼ��λ
        /// </summary>
        /// <param name="_esriMapUnit"></param>
        /// <returns></returns>
        private string GetMapUnit(esriUnits _esriMapUnit)
        {
            string sMapUnits = string.Empty;
            switch (_esriMapUnit)
            {
                case esriUnits.esriCentimeters:
                    sMapUnits = "����";
                    break;
                case esriUnits.esriDecimalDegrees:
                    sMapUnits = "ʮ����";
                    break;
                case esriUnits.esriDecimeters:
                    sMapUnits = "����";
                    break;
                case esriUnits.esriFeet:
                    sMapUnits = "��";
                    break;
                case esriUnits.esriInches:
                    sMapUnits = "Ӣ��";
                    break;
                case esriUnits.esriKilometers:
                    sMapUnits = "ǧ��";
                    break;
                case esriUnits.esriMeters:
                    sMapUnits = "��";
                    break;
                case esriUnits.esriMiles:
                    sMapUnits = "Ӣ��";
                    break;
                case esriUnits.esriMillimeters:
                    sMapUnits = "����";
                    break;
                case esriUnits.esriNauticalMiles:
                    sMapUnits = "����";
                    break;
                case esriUnits.esriPoints:
                    sMapUnits = "��";
                    break;
                case esriUnits.esriUnitsLast:
                    sMapUnits = "UnitsLast";
                    break;
                case esriUnits.esriUnknownUnits:
                    sMapUnits = "δ֪��λ";
                    break;
                case esriUnits.esriYards:
                    sMapUnits = "��";
                    break;
                default:
                    break;
            }
            return sMapUnits;
        }




        /// <summary>
        /// ������ƶ�ʱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainMapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            //���ƶ������Ļ�����ת��Ϊ��ͼ�����
            pMovePT = (mainMapControl.Map as IActiveView).ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);

            if (pMouseOperate == "MeasureLength")
            {
                if (pNewLineFeedback != null) //����е�
                {
                    pNewLineFeedback.MoveTo(pMovePT);//�ƶ����µĵ�
                }
                double deltaX = 0;//����֮���x��ֵ
                double deltaY = 0; //����֮���y��ֵ
                if ((pPointPt != null) && (pNewLineFeedback != null))
                {
                    deltaX = pMovePT.X - pPointPt.X; //��ȡ�µĵ�ֵ----ǰһ�����xֵ
                    deltaY = pMovePT.Y - pPointPt.Y;
                    //������ľ��볤��
                    dSegmentLength = Math.Round(Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY)), 3);
                    dToltalLength = dToltalLength + dSegmentLength;
                    //MessageBox.Show(dToltalLength.ToString());
                }
            }

            else if (pMouseOperate == "MeasureArea")
            {
                if (pNewPolygonFeedback != null)
                {
                    pNewPolygonFeedback.MoveTo(pMovePT);
                }
                for (int i = 0; i < pAreaPointCol.PointCount - 1; i++)
                {
                    pPointCol.AddPoint(pAreaPointCol.get_Point(i), ref missing, ref missing);//���㼯����ӵ�����μ�����
                }
                pPointCol.AddPoint(pMovePT, ref missing, ref missing);//��������ƶ����ĵ� 

            }
        }
        /// <summary>
        /// ��˫�����ʱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainMapControl_OnDoubleClick(object sender, IMapControlEvents2_OnDoubleClickEvent e)
        {
            switch (pMouseOperate)
            {
                case "MeasureLength":
                    if (pNewLineFeedback != null)
                    {
                        sMapUnits = GetMapUnit(mainMapControl.MapUnits);
                        MessageBox.Show(dToltalLength.ToString() + sMapUnits);
                        pNewLineFeedback.Stop();
                        pNewLineFeedback = null;
                        //����������߶���
                        (mainMapControl.Map as IActiveView).PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);//����ָ������ͼ�׶Ρ���һ����İ�����������������λ��

                    }
                    dToltalLength = 0;
                    dSegmentLength = 0;
                    break;
                case "MeasureArea":
                    if (pNewPolygonFeedback != null)
                    {
                        IPolygon pPolygon = new PolygonClass();//Ϊʶ��һ������εĳ�Ա�ṩ����Ȩ�ޣ�����������ڲ����ⲿ�������ܿط��ʡ�
                        IGeometry pGeo = null;//�ṩ�����м��ζ�������Ժ���Ϊ�ķ���
                        ITopologicalOperator pTopo = null;//�����еļ���ͼ��֮�佨���µļ���ͼ��

                        //����㼯���е�ĸ����� 3�������ɶ����
                        if (pPointCol.PointCount < 3)
                        {
                            //MessageBox.Show(pPointCol.PointCount.ToString());
                            return;
                        }
                        //����ļ���ת���ɶ����
                        pPolygon = pPointCol as IPolygon;
                        if ((pPolygon != null))
                        {
                            pPolygon.Close();
                            pGeo = pPolygon as IGeometry;//�������ת���ʸ��ͼ��
                            pTopo = pGeo as ITopologicalOperator;//�����еļ���ͼ��֮�佨���µļ���ͼ��
                            //ʹ����ͼ��������ȷ
                            pTopo.Simplify();
                            pGeo.Project(mainMapControl.Map.SpatialReference);
                            IArea pArea = pGeo as IArea;//���ػ������ε����ԡ�
                            area = pArea.Area;
                            sMapUnits = GetMapUnit(mainMapControl.MapUnits);
                            MessageBox.Show(area + sMapUnits);
                            pPolygon = null;
                        }
                        pNewPolygonFeedback.Stop();
                        pNewPolygonFeedback = null;
                        //����������� 
                        (mainMapControl.Map as IActiveView).PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);//����ָ������ͼ�׶Ρ���һ����İ�����������������λ��

                    }
                    //��յ㼯���е����е�
                    pAreaPointCol.RemovePoints(0, pAreaPointCol.PointCount);
                    break;
            }
        }

        #endregion

        /// <summary>
        /// �����ͼ�´���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //����Ļ�����ת��Ϊ��ͼ�����
            pPointPt = (mainMapControl.Map as IActiveView).ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
            mainMapControl.CurrentTool = null;
            #region ��������
            if (e.button == 1 && pMouseOperate == "MeasureLength")
            {
                //�ж�׷���߶����Ƿ�Ϊ�գ�������ʵ���������õ�ǰ����Ϊ��ʼ��
                if (pNewLineFeedback == null)
                {
                    pNewLineFeedback = new NewLineFeedback();
                    pNewLineFeedback.Display = (mainMapControl.Map as IActiveView).ScreenDisplay;
                    //������㣬��ʼ��̬�߻���
                    pNewLineFeedback.Start(pPointPt);
                    dToltalLength = 0;
                }
                else//���׷���߶���Ϊ�գ�����ӵ�ǰ����
                {
                    pNewLineFeedback.AddPoint(pPointPt);
                }
                if (dSegmentLength != 0)
                {
                    dToltalLength = dToltalLength + dSegmentLength;
                    //MessageBox.Show(dToltalLength.ToString());
                }

            }
            #endregion
            #region �������
            if (e.button == 1 && pMouseOperate == "MeasureArea")
            {
                if (pNewPolygonFeedback == null)
                {
                    //ʵ���������
                    pNewPolygonFeedback = new NewPolygonFeedback();
                    pNewPolygonFeedback.Display = (mainMapControl.Map as IActiveView).ScreenDisplay;
                    pAreaPointCol.RemovePoints(0, pAreaPointCol.PointCount);
                    //��ʼ����ͼ��
                    pNewPolygonFeedback.Start(pPointPt);
                    pAreaPointCol.AddPoint(pPointPt);
                }
                else
                {
                    pNewPolygonFeedback.AddPoint(pPointPt);
                    pAreaPointCol.AddPoint(pPointPt, ref missing, ref missing);
                }
            }
            #endregion
            #region ѡ��Ҫ��
            if (pMouseOperate == "Select")
            {
                //��ȡ�������ΰ�����
                IEnvelope pEnv = mainMapControl.TrackRectangle();
                //��������ת����ʸ��ͼ��
                IGeometry pGeo = pEnv as IGeometry;
                //���ο���Ϊ�գ���Ϊ��ѡ���Ե㷶Χ������չ
                if (pEnv.IsEmpty == true)
                {
                    tagRECT r;//�ṹ����������ϽǺ����½ǵ����ꡣ
                    r.left = e.x - 5;
                    r.top = e.y - 5;
                    r.right = e.x + 5;
                    r.bottom = e.y + 5;
                    IActiveView pActiveView = mainMapControl.ActiveView;
                    pActiveView.ScreenDisplay.DisplayTransformation.TransformRect(pEnv, ref r, 4);//�����δ��豸ת��Ϊ����ռ䣬��֮��Ȼ��ʹ��esriDisplayTransformEnumָ�������ġ�
                    pEnv.SpatialReference = pActiveView.FocusMap.SpatialReference;
                }
                pGeo = pEnv as IGeometry;//��������ת���ɼ���ͼ��
                mainMapControl.Map.SelectByShape(pGeo, null, false);//�ڵ�ͼ��ѡ��һ����״��һ��ѡ�񻷾�(��ѡ)��
                mainMapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }
            #endregion


        }
        IPointCollection pPointCol = new Polygon();//�ṩ�Զ�㡢·�����������ߡ�����Ρ����Ƿ��������߻���ĵ�ķ���Ȩ


        #region Ҫ��ѡ��
        private void mSelect_Click(object sender, EventArgs e)
        {
            pMouseOperate = "Select";
        }



        private void mZoomSelect_Click(object sender, EventArgs e)
        {
            //��ȡ��ǰѡ��Ҫ�صĸ���
            int nSelection = mainMapControl.Map.SelectionCount;
            if (nSelection == 0)
            {
                MessageBox.Show("��ѡ��Ҫ��", "��ʾ");
            }
            else
            {
                //��ȡ��ǰѡ��ͼ�Σ�����һ���ѡ��Ķ���
                ISelection selection = mainMapControl.Map.FeatureSelection;
                //��ѡ��Ķ���ת����ö�ٵ�ͼ��
                IEnumFeature enumFeature = (IEnumFeature)selection;
                enumFeature.Reset();//��ö������Ϊ��ʼ
                IEnvelope pEnvelope = new EnvelopeClass();
                IFeature pFeature = enumFeature.Next();
                while (pFeature != null)
                {
                    pEnvelope.Union(pFeature.Extent);//��ȡ����ѡ��Ҫ�ص������Χ����ʹ��ͼ��ͼ�������÷�Χ
                    pFeature = enumFeature.Next();
                }
                pEnvelope.Expand(1.1, 1.1, true);//�����ߵ�X��Y�����ƶ�����Զ��Է�,����Ϊtrueʱ��Ϊ�˷����ţ�x.y������1.1����
                mainMapControl.ActiveView.Extent = pEnvelope;
                mainMapControl.ActiveView.Refresh();
            }
        }

        private void mClearSelect_Click(object sender, EventArgs e)
        {
            IActiveView pActiveView = mainMapControl.ActiveView;
            pActiveView.FocusMap.ClearSelection();
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, pActiveView.Extent);

        }
        #endregion


        #region toc�ؼ�

        private ILayer pMoveLayer;//��Ҫ������ʾ˳���ͼ��
        private int toIndex;//����϶�ͼ���ƶ�����ͼ��������
        private ESRI.ArcGIS.Geometry.Point pMoveLayerPoint = new ESRI.ArcGIS.Geometry.Point();  //�����TOC���������ʱ���λ��

        IFeatureLayer pTocFeatureLayer = null;//�����Ҫ��ͼ��
        private FormAttribute frmAttribute = null;//ͼ�����Դ���

        private IFeatureLayer _curFeatureLayer;
        public IFeatureLayer curFeatureLayer
        {
            get { return _curFeatureLayer; }
            set { _curFeatureLayer = value; }
        }


        /// <param name="X">�������toc�ؼ��а���ʱ������toc�ؼ����Ͻ�Ϊԭ�㣬������Ϊ��λ����������x����</param>
        /// <param name="Y">���������toc�ؼ��е�y����</param>
        /// <param name="ItemType">esritoccontrolitemö�ٳ���</param>
        /// <param name="BasicMap">��mapcontrol�Ķ��󡣡����ƻ�����ͼ�Ľӿ�</param>
        /// <param name="Layer">�������ͼ����󡣡��ṩ����ͼ��Ľӿ�</param>
        /// <param name="Unk">ͼ�������</param>
        /// <param name="Data">ͼ������ͼ���������������������ͼ���ɻ���ض���ͼ����</param>
        public void HitTest(int X, int Y, ref esriTOCControlItem ItemType, ref IBasicMap BasicMap, ref ILayer Layer, ref object Unk, ref object Data)
        {

        }

        //��toc�ؼ���������¼�
        private void axTOCControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            //�������
            if (e.button == 1)
            {
                //��ʼ��
                esriTOCControlItem pItem = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap pMap = null;
                object unk = null;
                object data = null;
                ILayer pLayer = null;
                //hittest��������toc�е������㴦�Ķ�������
                axTOCControl.HitTest(e.x, e.y, ref pItem, ref pMap, ref pLayer, ref unk, ref data);
                pMoveLayerPoint.PutCoords(e.x, e.y);
                //�����һ��ͼ��
                if (pItem == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    if (pLayer is IAnnotationSublayer)//�����һ��ע��ͼ��
                    {
                        return;
                    }
                    else
                    {
                        pMoveLayer = pLayer;//��Ҫ�ƶ���ͼ��
                    }
                }
            }
            //�������Ҽ�
            if (e.button == 2)
            {
                esriTOCControlItem pItem = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap pMap = null;
                object unk = null;
                object data = null;
                ILayer pLayer = null;
                //hittest��������toc�е������㴦�Ķ�������
                axTOCControl.HitTest(e.x, e.y, ref pItem, ref pMap, ref pLayer, ref unk, ref data);
                pTocFeatureLayer = pLayer as IFeatureLayer;
                if (pItem == esriTOCControlItem.esriTOCControlItemLayer && pTocFeatureLayer != null)
                {
                    btnLayerSel.Enabled = !pTocFeatureLayer.Selectable;
                    btnLayerUnSel.Enabled = pTocFeatureLayer.Selectable;
                    contextMenuStrip.Show(Control.MousePosition);//�Ҽ������˵�������λ����ʾ
                }
            }
        }


        //��toc�ؼ�����굯���¼�
        private void axTOCControl_OnMouseUp(object sender, ITOCControlEvents_OnMouseUpEvent e)
        {
            if (e.button == 1 && pMoveLayer != null && pMoveLayerPoint.Y != e.y)
            {
                esriTOCControlItem pItem = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap pBasicMap = null;
                object unk = null;
                object data = null;
                ILayer pLayer = null;
                //hittest��������toc�е������㴦�Ķ�������
                axTOCControl.HitTest(e.x, e.y, ref pItem, ref pBasicMap, ref pLayer, ref unk, ref data);
                IMap pMap = mainMapControl.ActiveView.FocusMap;
                if (pItem == esriTOCControlItem.esriTOCControlItemLayer || pLayer != null)
                {
                    if (pMoveLayer != null)
                    {
                        ILayer pTempLayer;
                        //��ȡ��굯��ʱ���ڵ�ͼ��������
                        for (int i = 0; i < pMap.LayerCount; i++)
                        {
                            pTempLayer = pMap.get_Layer(i);
                            if (pTempLayer == pLayer)
                            {
                                toIndex = i;
                            }
                        }
                    }
                }
                //�ƶ�����ǰ��
                else if (pItem == esriTOCControlItem.esriTOCControlItemMap)
                {
                    toIndex = 0;
                }
                else if (pItem == esriTOCControlItem.esriTOCControlItemNone)
                {
                    toIndex = pMap.LayerCount - 1;
                }
                MessageBox.Show(toIndex.ToString());
                pMap.MoveLayer(pMoveLayer, toIndex);
                mainMapControl.ActiveView.Refresh();
                axTOCControl.Update();
            }
        }







        #endregion



        private void bt_showAttri_Click(object sender, EventArgs e)
        {
            if (frmAttribute == null || frmAttribute.IsDisposed)
            {
                frmAttribute = new FormAttribute();
            }
            frmAttribute.curFeatureLayer = pTocFeatureLayer;
            frmAttribute.InitUI();
            frmAttribute.ShowDialog();
        }

        private void bt_deleteLayer_Click(object sender, EventArgs e)
        {
            if (pTocFeatureLayer == null) { return; }
            DialogResult result = MessageBox.Show("�Ƿ�ɾ����"+pTocFeatureLayer.Name+"��ͼ��","��ʾ",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            if (result == DialogResult.OK) {
                mainMapControl.Map.DeleteLayer(pTocFeatureLayer);
            }
            mainMapControl.ActiveView.Refresh();


        }


    }
}