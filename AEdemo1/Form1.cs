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
namespace AEdemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
    }
}