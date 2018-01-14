using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
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
    public partial class FormQueryBySpatial : Form
    {
        public FormQueryBySpatial()
        {
            InitializeComponent();
        }


        private IMap currentMap;//当前mapcontrol控件中的map对象
    
        public IMap CurrentMap
        {
            set
            {
                currentMap = value;
            }
        }

        private void FormQueryBySpatial_Load(object sender, EventArgs e)
        {
            //清空目标图层列表
            checkedListBoxTargetLayers.Items.Clear();
            string layerName;//设置临时变量存储图层名称
            //对map中的每个图层进行判断并添加图层名称
            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                //如果是图层组类型，分别对所包含的每个图层进行操作
                if (currentMap.get_Layer(i) is GroupLayer)
                {
                    //使用icompositelayer接口进行遍历操作
                    ICompositeLayer compositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; j < compositeLayer.Count; j++)
                    {
                        //将图层的名称添加到checklistboxtargetlayers控件和comboboxmethods控件中
                        layerName = compositeLayer.get_Layer(j).Name;
                        checkedListBoxTargetLayers.Items.Add(layerName);
                        comboBoxSourceLayer.Items.Add(layerName);
                    }
                }
                else//如果不是图层组类型，则直接添加名称
                {
                    layerName = currentMap.get_Layer(i).Name;
                    checkedListBoxTargetLayers.Items.Add(layerName);
                    comboBoxSourceLayer.Items.Add(layerName);
                }
            }
            //将comboboxsourcelayer控件的默认选项设置为第一图层的名称
            comboBoxSourceLayer.SelectedIndex = 0;
            //将comboBoxmethods控件的默认选项设置为第一种空间选择方法
            comboBoxMethods.SelectedIndex = 0;
        }



        private IFeatureLayer GetFeatureLayerByName(IMap map, string layerName)
        {
            //对地图的图层尽心遍历
            for (int i = 0; i < map.LayerCount; i++)
            {
                //如果是图层组类型，分别对所包含的每个图层进行操作
                if (map.get_Layer(i) is GroupLayer)
                {
                    //使用icompositelayer接口进行遍历操作
                    ICompositeLayer compositeLayer = map.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; j < compositeLayer.Count; j++)
                    {
                        //如果图层名称为所要查询的图层名称，则返回ifeaturelayer接口的矢量图层对象
                        if (compositeLayer.get_Layer(i).Name == layerName)
                        {
                            return (IFeatureLayer)compositeLayer.get_Layer(j);
                        }
                    }
                }
                else//如果不是图层组类型，则直接判断
                {
                    if (map.get_Layer(i).Name == layerName)
                    {
                        return (IFeatureLayer)map.get_Layer(i);
                    }
                }
            }
            return null;
        }

        private IGeometry GetFeatureLayerGeometryUnion(IFeatureLayer featureLayer) {
            //定义igeometry接口对象，存储每一步拓扑操作后得到的几何体
            IGeometry geometry = null;
            //使用itopologicaloperator接口进行几何体的拓扑操作
            ITopologicalOperator topologicalOpreator;
            //使用null作为查询过滤器得到图层中所有要素的游标
            IFeatureCursor featureCursor = featureLayer.Search(null,false);
            //获取ifeature接口游标的第一个元素
            IFeature feature = featureCursor.NextFeature();
            //当游标不为空时
            while (feature != null)
            {
                //若果几何体不为空
                if (geometry != null)
                {
                    //进行接口转换，使用当前几何体的itopologicaloperator接口进行拓扑操作
                    topologicalOpreator = geometry as ITopologicalOperator;//提供对成员的访问，基于现有的几何图形之间的拓扑关系来构造新的几何图形
                    //执行拓扑合并操作，将当前要素的几何体与已有几何体进行union，返回新的合并后的几何体
                    geometry = topologicalOpreator.Union(feature.Shape);//构造几何图形，它是输入几何图形的集合理论的结合

                }
                else {
                    geometry = feature.Shape;
                    feature = featureCursor.NextFeature();
                }
            }
            return geometry;//返回最新合并后的几何体
        }


        private void SelectFeatureBySpatial() { 
            //定义和创建用于空间查询的ispatialfilter接口对象
            ISpatialFilter spatialFilter = new SpatialFilter();
            //默认设定用于查询的空间几何体为当前地图源层中所有要素几何体的集合
            spatialFilter.Geometry = GetFeatureLayerGeometryUnion(GetFeatureLayerByName(currentMap,comboBoxSourceLayer.SelectedItem.ToString()));
            //根据空间选择方法的选择采用相应的空间选择方法
            switch (comboBoxMethods.SelectedIndex)
            {
                case 0:
                    spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
                case 1:
                    spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                    break;
                case 2:
                    spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    break;
                case 3:
                    spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                    break;
                case 4:
                    spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelTouches;
                    break;
                case 5:
                    spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                    break;
                default:
                    spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
            }
            //对所选择的目标图层进行遍历，并对每一个图层进行空间查询操作，查询结果将放在选择集中
            IFeatureLayer featureLayer;
            //对所有的被选择的目标图层进行遍历
            for (int i = 0; i < checkedListBoxTargetLayers.CheckedItems.Count; i++)
			{
			    //根据选择的目标图层名称获得对应的矢量图层
                featureLayer = GetFeatureLayerByName(currentMap,checkedListBoxTargetLayers.CheckedItems[i].ToString());
                //进行接口转换，使用ifeatureselection接口选择要素
                IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
                //使用ifeatureselection接口的selectfeature方法，根据空间查询过滤器选择要素，并将其放在新的选择集中
                featureSelection.SelectFeatures((IQueryFilter)spatialFilter,esriSelectionResultEnum.esriSelectionResultAdd,false);

			}
            //进行接口转换，使用iactiveView接口进行视图操作
            IActiveView activeView = currentMap as IActiveView;
            //进行部分刷新，只刷新地理选择集的内容
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection,null,activeView.Extent);
        
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SelectFeatureBySpatial();
            this.Close();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            SelectFeatureBySpatial();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
