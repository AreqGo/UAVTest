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
        }

        public void DrawH()
        {
            plotter.RemoveUserElements();

            var yDataSource = new EnumerableDataSource<PolylinePoint>(lDesignPoint);
            yDataSource.SetYMapping(y => y.Z);
            var xDataSource = new EnumerableDataSource<PolylinePoint>(lDesignPoint);
            xDataSource.SetXMapping(lx => lx.X);
            CompositeDataSource compositeDataSource = new CompositeDataSource(xDataSource, yDataSource);

            var y1DataSource = new EnumerableDataSource<PolylinePoint>(LFlyPoint);
            y1DataSource.SetYMapping(y => y.Z);
            var x1DataSource = new EnumerableDataSource<PolylinePoint>(LFlyPoint);
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


        public void DrawV()
        {
            plotter.RemoveUserElements();

            var yDataSource = new EnumerableDataSource<PolylinePoint>(lDesignPoint);
            yDataSource.SetYMapping(y => y.Y);
            var xDataSource = new EnumerableDataSource<PolylinePoint>(lDesignPoint);
            xDataSource.SetXMapping(lx => lx.X);
            CompositeDataSource compositeDataSource = new CompositeDataSource(xDataSource, yDataSource);

            var y1DataSource = new EnumerableDataSource<PolylinePoint>(LFlyPoint);
            y1DataSource.SetYMapping(y => y.Y);
            var x1DataSource = new EnumerableDataSource<PolylinePoint>(LFlyPoint);
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
