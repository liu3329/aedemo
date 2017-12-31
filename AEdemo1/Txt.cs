using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AEdemo1
{
   public class Txt
    {

        //定义点的结构体
        struct CPoint
        {
            public string name;
            public double x;
            public double y;
        }
        List<string> pColumns = new List<string>();
        /// <summary>
        /// 获取文件中的点坐标
        /// </summary>
        /// <param name="surveyDataFullName">文件的路径名称</param>
        /// <returns></returns>
        private List<CPoint> GetPoints(string surveyDataFullName)
        {
            List<CPoint> pList = new List<CPoint>();
            // 常用的分隔符来分割内容(逗号，空格 制位符)
            char[] charArray = new char[] { ',', ' ', '\t' };
            //文本读取
            FileStream fs = new FileStream(surveyDataFullName, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            string strLine = sr.ReadLine();
            if (strLine != null)
            {
                string[] strArray = strLine.Split(charArray);
                if (strArray.Length > 0)
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        pColumns.Add(strArray[i]);
                    }
                }
                while ((strLine = sr.ReadLine()) != null)
                {
                    //点信息读取
                    strArray = strLine.Split(charArray);
                    CPoint pCPoint = new CPoint();
                    pCPoint.name = strArray[0].Trim();
                    pCPoint.x = Convert.ToDouble(strArray[1]);
                    pCPoint.y = Convert.ToDouble(strArray[2]);
                    pList.Add(pCPoint);
                }
            }
            else
            {
                return null;
            }
            sr.Close();
            return pList;
        }

       /// <summary>
       /// 根据点坐标创建shp
       /// </summary>
       /// <param name="cPointList"></param>
       /// <param name="filePath"></param>
       /// <returns></returns>
        public IFeatureLayer CreatShpFromPoints(List<CPoint> cPointList, string filePath)
        {
            int index = filePath.LastIndexOf('\\');
            string folder = filePath.Substring(0,index);
            string shapename = filePath.Substring(index + 1);
            IWorkspaceFactory pWSF = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace pFWS = (IFeatureWorkspace)pWSF.OpenFromFile(folder,0);
            IFields pFields = new FieldsClass();//field对象表示表中的一列。
            IFieldEdit pFieldsEdit = (IFieldEdit)pFields;





        
        }
    }
}
