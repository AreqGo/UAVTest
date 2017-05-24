using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TerraExplorerX;

namespace Pipeline.Client.Forms
{
    /// <summary>
    /// wpfTerrainProfile.xaml 的交互逻辑
    /// </summary>
    public partial class wpfTerrainProfile : UserControl
    {
        SGWorld66 sgworld;
        IPoint IntersectionPoint = null;
        double z = 0;
        private List<PolylinePoint> lDesignPoint=null;

        public List<PolylinePoint> LDesignPoint
        {
            get
            {
                return lDesignPoint;
            }

            set
            {
                lDesignPoint = value;
            }
        }

        public List<PolylinePoint> LFlyPoint
        {
            get
            {
                return lFlyPoint;
            }

            set
            {
                lFlyPoint = value;
            }
        }

        private List<PolylinePoint> lFlyPoint = null;

        public wpfTerrainProfile()
        {
            InitializeComponent();
            sgworld = new SGWorld66();
        }
        /// <summary>
        /// 侧视图
        /// </summary>
        public void DrawH()
        {
            var ds = getDisList(LDesignPoint);
            var fs = getDisList(LFlyPoint);
            plotter.RemoveUserElements();

            var yDataSource = new EnumerableDataSource<PolylinePoint>(ds);
            yDataSource.SetYMapping(y => y.Z);
            var xDataSource = new EnumerableDataSource<PolylinePoint>(ds);
            xDataSource.SetXMapping(lx => lx.X);
            CompositeDataSource compositeDataSource = new CompositeDataSource(xDataSource, yDataSource);

            var y1DataSource = new EnumerableDataSource<PolylinePoint>(fs);
            y1DataSource.SetYMapping(y => y.Z);
            var x1DataSource = new EnumerableDataSource<PolylinePoint>(fs);
            y1DataSource.SetXMapping(lx => lx.X);
            CompositeDataSource compositeDataSource1 = new CompositeDataSource(x1DataSource, y1DataSource);

            plotter.AddLineGraph(compositeDataSource,
                new Pen(Brushes.OrangeRed, 2),
                new PenDescription("设计航线"));
            plotter.AddLineGraph(compositeDataSource1,
                new Pen(Brushes.GreenYellow, 2),
                new PenDescription("实际航线"));
            plotter.FitToView();
        }

        /// <summary>
        /// 俯视图
        /// </summary>
        public void DrawV()
        {
            var ds = getDisList(LDesignPoint);
            var fs = getDisList(LFlyPoint);
            plotter.RemoveUserElements();

            var yDataSource = new EnumerableDataSource<PolylinePoint>(ds);
            yDataSource.SetYMapping(y => y.Y);
            var xDataSource = new EnumerableDataSource<PolylinePoint>(ds);
            xDataSource.SetXMapping(lx => lx.X);
            CompositeDataSource compositeDataSource = new CompositeDataSource(xDataSource, yDataSource);

            var y1DataSource = new EnumerableDataSource<PolylinePoint>(fs);
            y1DataSource.SetYMapping(y => y.Y);
            var x1DataSource = new EnumerableDataSource<PolylinePoint>(fs);
            y1DataSource.SetXMapping(lx => lx.X);

            CompositeDataSource compositeDataSource1 = new CompositeDataSource(x1DataSource, y1DataSource);

            plotter.AddLineGraph(compositeDataSource,
                new Pen(Brushes.OrangeRed, 2),
                new PenDescription("设计航线"));
            plotter.AddLineGraph(compositeDataSource1,
                new Pen(Brushes.GreenYellow, 2),
                new PenDescription("实际航线"));
            plotter.FitToView();
        }

        void _vEllipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //string strMsg = "X坐标：" + Math.Round(pWorldPointInfo65.Position.X, 2) + "\r\n";
            //strMsg += "Y坐标：" + Math.Round(pWorldPointInfo65.Position.Y, 2) + "\r\n";
            //strMsg += "地面高程：" + Math.Round(groundInfo.Position.Altitude, 2);
            //MessageBox.Show(strMsg, "查询结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private double[] getDistance(double lon1,double lat1,double lon2,double lat2)
        {
            var HDis = sgworld.CoordServices.GetDistance(lon1, (lat1+lat2)/2, lon2, (lat1 + lat2) / 2);
            if(lon2 < lon1)
            {
                HDis = -HDis;
            }
            var VDis = sgworld.CoordServices.GetDistance((lon1+lon2)/2, lat1, (lon1 + lon2) / 2, lat2);
            if(lat2 < lat1)
            {
                VDis = -VDis;
            }
            return new double[] {HDis,VDis};
        }

        private List<PolylinePoint> getDisList(List<PolylinePoint> ls)
        {
            var lsNew = new List<PolylinePoint>();
            PolylinePoint pFirst = ls[0];
            foreach (PolylinePoint pp in ls)
            {
                var arrayDis = getDistance(pFirst.X, pFirst.Y, pp.X, pp.Y);
                var p = new PolylinePoint();
                p.X = arrayDis[0];
                p.Y = arrayDis[1];
                p.Z = pp.Z-pFirst.Z;
                lsNew.Add(p);
            }
            return lsNew;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.tbName.Text == "侧视图")
            {
                this.tbName.Text = "俯视图";
                DrawV();

            }
            else if(this.tbName.Text== "俯视图")
            {
                this.tbName.Text = "侧视图";
                DrawH();
            }
        }
    }
    public class LinePoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Distance { get; set; }

    }
    public class PolylinePoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
