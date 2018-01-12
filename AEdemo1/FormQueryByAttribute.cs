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
    public partial class FormQueryByAttribute : Form
    {
        public FormQueryByAttribute()
        {
            InitializeComponent();
        }

        private IMap currentMap;//当前mapcontrol控件中的map对象
        private IFeatureLayer currentFeatureLayer;//设置临时类变量来使用ifeaturelayer接口的当前图层对象
        private string currentFieldName;//设置临时类变量来存储字段名称
        public IMap CurrentMap
        {
            set
            {
                currentMap = value;
            }
        }

        private void FormQueryByAttribute_Load(object sender, EventArgs e)
        {
            //将当前图层列表清空
            comboBoxLayerName.Items.Clear();
            string layerName;//设置临时变量存储图层名称
            //对map中的每个图层进行判断并且加载名称
            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                //如果该图层为图层组类型，则分别对所包含的每个图层进行操作
                if (currentMap.get_Layer(i) is GroupLayer)
                {//根据索引获取
                    //使用icompositelayer接口进行遍历操作
                    ICompositeLayer compositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; j < compositeLayer.Count; j++)
                    {
                        //将图层的名称添加到comboboxlayername控件中
                        layerName = compositeLayer.get_Layer(j).Name;
                        comboBoxLayerName.Items.Add(layerName);
                    }
                }
                else
                { //如果图层不是图层组类型，则直接添加名称
                    layerName = currentMap.get_Layer(i).Name;
                    comboBoxLayerName.Items.Add(layerName);
                }
            }
            //将comboboxlayername控件的默认的选项设置为第一个图层的名称
            comboBoxLayerName.SelectedIndex = 0;
            //将comboboxselectmethod控件的默认选项设置为第一种选择方式
            comboBoxSelectMethod.SelectedIndex = 0;

        }

        //当图层的名称下拉框控件中所选择的图层发生改变时触发事件执行本函数
        private void comboBoxLayerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //首先将字段列表和字段值表清空
            listBoxFields.Items.Clear();
            listBoxValues.Items.Clear();
            IField field;//设置临时变量存储使用ifield接口的对象
            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                if (currentMap.get_Layer(i) is GroupLayer)
                {
                    //使用icompositelayer接口进行遍历操作
                    ICompositeLayer compositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; j < compositeLayer.Count; j++)
                    {
                        //判断图层的名称是否与combolayername控件中选择的图层名称相同
                        if (compositeLayer.get_Layer(j).Name == comboBoxLayerName.SelectedItem.ToString())
                        {
                            //如果相同设置为整个窗体所用的ifeaturelayer接口对象
                            currentFeatureLayer = compositeLayer.get_Layer(j) as IFeatureLayer;
                            break;
                        }

                    }
                }
                else { 
                    //判断图层的名称是否与comboboxlayername中选择的图层名称相同
                    if(currentMap.get_Layer(i).Name == comboBoxLayerName.SelectedItem.ToString()){
                        //如果相同则设置为整个窗体所使用的ifeaturelayer接口对象
                        currentFeatureLayer = currentMap.get_Layer(i) as IFeatureLayer;
                        break;
                    }
                }
            }
            //使用ifeatureclass接口对该图层的所有属性字段进行遍历，并填充listboxfields
            for (int i = 0; i < currentFeatureLayer.FeatureClass.Fields.FieldCount; i++)
            {
                //根据索引值获取图层的字段
                field = currentFeatureLayer.FeatureClass.Fields.get_Field(i);
                //排除shape字段，并在其他的字段名称前后添加字符\和字符“
                if (field.Name.ToUpper() != "SHAPE") {
                    listBoxFields.Items.Add("\""+field.Name+"\"");
                }
            }
            //更新labelwhere控件中的图层名称信息
            labelwhere.Text = currentFeatureLayer.Name + " WHERE:";
            //将显示where语句的文本框内容清空
            textBoxWhere.Clear();
        }


        //在字段名称列表控件中所选择的字段发生改变时触发事件执行本函数
        private void listBoxFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            //首先将listboxvalues控件中的字段属性值清空
            listBoxValues.Items.Clear();
            //将buttongetuniquevalue按钮控件置为可用状态
            if (buttonGetUniqeValue.Enabled == false)
            {
                buttonGetUniqeValue.Enabled = true;
            }
            //设置整个窗体可用的字段名称
            string str = listBoxFields.SelectedItem.ToString();
            //使用string类中的方法将字段名称中的两个“字符去掉
            str = str.Substring(1);
            str = str.Substring(0, str.Length - 1);
            currentFieldName = str;
            labelwhere.Text += currentFieldName;
        }


        //在点击“获取唯一属性值”按钮时触发事件执行本函数
        //对图层的某个字段进行唯一值获取操作，并将所有的唯一值显示在listboxvalues控件中
        private void buttonGetUniqeValue_Click(object sender, EventArgs e)
        {
            //使用featureclass对象的idataset接口来获取dataset和workspace控件信息
            IDataset dataset = (IDataset)currentFeatureLayer.FeatureClass;
            //使用iquerydef接口的对象来定义和查询属性信息，通过iworkspace接口的creatquerydef()方法创建该对象
            IQueryDef queryDef = ((IFeatureWorkspace)dataset.Workspace).CreateQueryDef();
            //设置所需查询的表格的名称为dataset的名称
            queryDef.Tables = dataset.Name;
            //设置查询的字段名称，可以联合使用sql语言的关键字，如查询唯一值可以使用distinct关键字
            queryDef.SubFields = currentFieldName;
            //执行查询并返回icursor接口点的对象来访问整个结果的集合
            ICursor cursor = queryDef.Evaluate();//游标
            //使用ifields接口获取当前所需要使用的字段的信息
            IFields fields = currentFeatureLayer.FeatureClass.Fields;
            IField field = fields.get_Field(fields.FindField(currentFieldName));
            //对整个结果集合进行遍历，从而添加所有唯一的值，使用irow接口来操作结果集合
            //首先定位到第一个查询结果
            IRow row = cursor.NextRow();
            //如果查询结果非空，则一直进行添加操作
            while (row != null)
            {
                //对string类型的字段，唯一值的前后添加\和‘，以符合sql语句要求
                if (field.Type == esriFieldType.esriFieldTypeString)
                {
                    //一个列中的可能的值
                    listBoxValues.Items.Add("\'" + row.get_Value(0).ToString() + "\'");
                }
                else
                {
                    listBoxValues.Items.Add(row.get_Value(0).ToString());
                }
                //继续执行下一个结果的添加
                row = cursor.NextRow();
            }
        }

        //点击【确定】按钮时触发
        private void buttonOK_Click(object sender, EventArgs e)
        {
            //执行属性查询操作，并关闭窗体
            SelectFeatureByAttribute();
            this.Close();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            //执行属性查询操作
            //SelectFeatureByAttribute();
            SelectFeatureByAttribute2();
        }


        //关闭窗体
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //在点击“清除”按钮时发生
        private void buttonClear_Click(object sender, EventArgs e)
        {
            //清空textBoxWhere控件中的文本
            textBoxWhere.Clear();
        }

        #region
        //在字段列表中双击属性字段名称时发生
        private void listBoxFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //在where语句中加入字段名称信息
            textBoxWhere.Text += listBoxFields.SelectedItem.ToString();
        }

        //在字段值列表中双击属性唯一值时发生
        private void listBoxValues_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //在where语句中加入字段值信息
            textBoxWhere.Text += listBoxValues.SelectedItem.ToString();
        }

        //在点击“=”运算符时发生
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            //在where语句中加入运算符信息
            textBoxWhere.Text += " " + buttonEqual.Text + " ";
        }
        //在点击“And”运算符时发生
        private void buttonAnd_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonAnd.Text + " ";
        }
        //在点击“<>”运算符时发生
        private void buttonNotEqual_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonNotEqual.Text + " ";
        }
        //在点击“Like”运算符时发生
        private void buttonLike_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonLike.Text + " ";
        }
        //在点击“>”运算符时发生
        private void buttonGreater_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonGreater.Text + " ";
        }
        //在点击“>=”运算符时发生
        private void buttonGeaterEqual_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonGeaterEqual.Text + " ";
        }
        //在点击“<”运算符时发生
        private void buttonLess_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonLess.Text + " ";
        }
        //在点击“<=”运算符时发生
        private void buttonLessEqual_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonLessEqual.Text + " ";
        }
        //在点击“Or”运算符时发生
        private void buttonOr_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonOr.Text + " ";
        }
        //在点击“_”运算符时发生
        private void buttonUnderLine_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonUnderLine.Text + " ";
        }
        //在点击“%”运算符时发生
        private void buttonPercent_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonPercent.Text + " ";
        }
        //在点击“()”运算符时发生
        private void buttonBrackets_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonBrackets.Text + " ";
        }
        //在点击“Not”运算符时发生
        private void buttonNot_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonNot.Text + " ";
        }
        //在点击“Is”运算符时发生
        private void buttonIs_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonIs.Text + " ";
        }
        #endregion

        private void SelectFeatureByAttribute() { 
            //使用featurelayer对象的ifeatureselection接口来执行查询操作，这里有一个接口转换
            IFeatureSelection featureSelection = currentFeatureLayer as IFeatureSelection;//提供对控制图形选择的成员的访问
            //新建iqueryfilter接口的对象来进行where语句的定义
            IQueryFilter queryFilter = new QueryFilterClass();
            //设置where语句内容
            queryFilter.WhereClause = "\"Name\"='长清区'";
            //通过接口转换使用map对象的iactiveview接口来部分刷新地图视图，从而高亮显示查询结果
            IActiveView activeView = currentMap as IActiveView;
            //根据查询选择方式的不同得到不同的选择集
            switch (comboBoxSelectMethod.SelectedIndex)
            {
                case 0://在新建选择集的情况下
                    //首先使用imap接口的clearselection（）方法清空地图选择集
                    currentMap.ClearSelection();
                    //根据定义的where语句使用ifeatureselection接口的selectfeatures方法选择要素，并将其添加到选择集中
                    featureSelection.SelectFeatures(queryFilter,esriSelectionResultEnum.esriSelectionResultNew,false);
                    break;
                case 1://添加到当前选择集的情况
                    featureSelection.SelectFeatures(queryFilter,esriSelectionResultEnum.esriSelectionResultAdd,false);
                    break;
                case 2://从当前选择集中删除的情况
                    featureSelection.SelectFeatures(queryFilter,esriSelectionResultEnum.esriSelectionResultXOR,false);
                    break;
                case  3://从当前选择集中选择的情况
                    featureSelection.SelectFeatures(queryFilter,esriSelectionResultEnum.esriSelectionResultAdd,false);
                    break;
                default://默认为新建选择集的情况
                    currentMap.ClearSelection();
                    featureSelection.SelectFeatures(queryFilter,esriSelectionResultEnum.esriSelectionResultNew,false);
                    break;
            }
            //进行部分刷新操作，只刷新地理选择集的内容
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection,null,activeView.Extent);
        
        }
       
        private void SelectFeatureByAttribute2() {
         
            IFeatureSelection featureSelection = currentFeatureLayer as ESRI.ArcGIS.Carto.IFeatureSelection; // Dynamic Cast
            IActiveView activeView = currentMap as IActiveView;
            featureSelection.Clear();
            // Set up the query
            ESRI.ArcGIS.Geodatabase.IQueryFilter queryFilter = new ESRI.ArcGIS.Geodatabase.QueryFilterClass();
            queryFilter.WhereClause = "\"NAME\" = '长清区'";

            // Perform the selection
            featureSelection.SelectFeatures(queryFilter, ESRI.ArcGIS.Carto.esriSelectionResultEnum.esriSelectionResultAdd, false);

            // Flag the new selection
            activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection, null, activeView.Extent);

        
        }
       
    }
}
