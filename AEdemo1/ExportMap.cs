using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AEdemo1
{
    public class ExportMap
    {
        //静态函数 直接点出来
        public static void ExportView(IActiveView view, IGeometry pGeo, int OutputResolution, int Width, int Height, string ExpPath, bool bRegion)
        {
            IExport pExport = null;//新建一个导出
            tagRECT exportRect = new tagRECT();
            IEnvelope pEnvelope = pGeo.Envelope;//获取导出图形的包络线
            string sType = System.IO.Path.GetExtension(ExpPath);
            switch (sType)
            {
                case ".jpg":
                    pExport = new ExportJPEGClass();
                    break;
                case ".bmp":
                    pExport = new ExportBMPClass();
                    break;
                case ".gif":
                    pExport = new ExportGIFClass();
                    break;
                case ".tif":
                    pExport = new ExportTIFFClass();
                    break;
                case ".png":
                    pExport = new ExportPNGClass();
                    break;
                case ".pdf":
                    pExport = new ExportPDFClass();
                    break;
                default:
                    MessageBox.Show("没有输出格式，默认为JPEG格式");
                    pExport = new ExportJPEGClass();
                    break;
            }
            pExport.ExportFileName = ExpPath;//导出文件的路径
            exportRect.left = 0;
            exportRect.top = 0;
            exportRect.right = Width;
            exportRect.bottom = Height;
            if (bRegion)
            {
                view.GraphicsContainer.DeleteAllElements();
                view.Refresh();
            }
            IEnvelope envelope = new EnvelopeClass();
            envelope.PutCoords((double)exportRect.left, (double)exportRect.top, (double)exportRect.right, (double)exportRect.bottom);
            pExport.PixelBounds = envelope;
            view.Output(pExport.StartExporting(), OutputResolution, ref exportRect, pEnvelope, null);
            pExport.FinishExporting();
            pExport.Cleanup();
        }


        /// <summary>
        /// 获取rgb颜色
        /// </summary>
        /// <param name="intR"></param>
        /// <param name="intG"></param>
        /// <param name="intB"></param>
        /// <returns></returns>
        public static IRgbColor  GetRgbColor(int intR, int intG, int intB)
        {
            IRgbColor pRgbColor = null;
            if (intR < 0 || intR > 255 || intG < 0 || intG > 255 || intB < 0 || intB > 255)
            {
                return pRgbColor;
            }
            pRgbColor = new RgbColorClass();
            pRgbColor.Red = intR;
            pRgbColor.Green = intG;
            pRgbColor.Blue = intB;
            return pRgbColor;
        }

        /// <summary>
        /// 创建图形元素
        /// </summary>
        /// <returns></returns>
        public static IElement CreatElement(IGeometry pGeometry, IRgbColor lineColor, IRgbColor fillColor)
        {
            if (pGeometry == null || lineColor == null || fillColor == null)
            {
                return null;
            }
            IElement pElem = null;
            if (pGeometry is IEnvelope)
            {
                pElem = new RectangleElementClass();
            }
            else if (pGeometry is IPolygon)
            {
                pElem = new PolygonElementClass();
            }
            else if (pGeometry is ICircularArc)
            {
                ISegment pSegCircle = pGeometry as ISegment;//实例化一个 片段
                ISegmentCollection pSegColl = new PolygonClass();//操作路径、环、多线或多边形的段
                object o = Type.Missing;
                pSegColl.AddSegment(pSegCircle, ref o, ref o);
                IPolygon pPolygon = pSegColl as IPolygon;
                pGeometry = pPolygon as IGeometry;
                pElem = new CircleElementClass();
            }
            else if (pGeometry is IPolyline)
            {
                pElem = new LineElementClass();
            }
            if (pElem == null)
            {
                return null;
            }
            pElem.Geometry = pGeometry;
            IFillShapeElement pFElem = pElem as IFillShapeElement;
            ISimpleFillSymbol pSymbol = new SimpleFillSymbolClass();
            pSymbol.Color = fillColor;
            pSymbol.Outline.Color = lineColor;
            pSymbol.Style = esriSimpleFillStyle.esriSFSCross;
            if (pSymbol == null)
            {
                return null;
            }
            pFElem.Symbol = pSymbol;
            return pElem;
        }
        //视图窗口绘制几何图形元素
        public static void AddElement(IGeometry pGeometry, IActiveView activeView)
        {
            IRgbColor fillColor = GetRgbColor(204,175,235);
            IRgbColor lineColor = GetRgbColor(0,0,0);
            IElement pEle = CreatElement(pGeometry,lineColor,fillColor);
            IGraphicsContainer pGC = activeView.GraphicsContainer;
            if (pGC == null) 
            {
                pGC.AddElement(pEle,0);
                activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics,pEle,null);
            }
        }


      
    }
}
