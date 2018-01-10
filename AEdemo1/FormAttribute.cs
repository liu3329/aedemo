using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AEdemo1
{
    public partial class FormAttribute : Form
    {
        public FormAttribute()
        {
            InitializeComponent();
        }


        private IFeatureLayer _curFeatureLayer;//提供访问功能层的成员的访问权限
        public IFeatureLayer curFeatureLayer
        {
            get { return _curFeatureLayer; }
            set { _curFeatureLayer = value; }
        }


        public void InitUI()
        {
            if(_curFeatureLayer == null){
                return;
            }
            IFeature pFeature = null;//提供对返回并设置特性属性的成员的访问
            DataTable pFeatDT = new DataTable();//创建数据表
            DataRow pDataRow = null;//数据表行变量
            DataColumn pDataCol = null;//数据表列变量
            IField pField = null;
            for (int i = 0; i < _curFeatureLayer.FeatureClass.Fields.FieldCount; i++)
            {
                pDataCol = new DataColumn();
                pField = _curFeatureLayer.FeatureClass.Fields.get_Field(i);
                pDataCol.ColumnName = pField.AliasName;//获取字段名作为列标题
                pDataCol.DataType = Type.GetType("System.Object");//定义列字段的类型
                pFeatDT.Columns.Add(pDataCol);//在数据表中添加字段信息
            }
            //search(IQueryFilter ,bool) 根据搜索条件创建一个游标(提供对基于属性值和关系的数据进行过滤的成员的访问,是否再回收)。
            IFeatureCursor pFeatureCursor = _curFeatureLayer.Search(null, true);//提供对那些分发枚举特性、字段集合并允许更新、删除和插入特性的成员的访问。
            pFeature = pFeatureCursor.NextFeature();//将光标的位置向前移动，并返回该位置的特性对象
            while(pFeature != null){
                pDataRow = pFeatDT.NewRow();
                for (int i = 0; i < pFeatDT.Columns.Count; i++)
                {
                    pDataRow[i] = pFeature.get_Value(i); 
                }
                pFeatDT.Rows.Add(pDataRow);//再数据表中添加字段属性信息
                pFeature = pFeatureCursor.NextFeature();
            }
            //释放指针
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatureCursor);
            dataGridAttribute.DataSource = pFeatDT;
        }
    }
}
