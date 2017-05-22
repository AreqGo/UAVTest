using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using TerraExplorerX;
using System.IO;
using Pipeline.Client.Forms;

namespace UAVApp
{
    public partial class AppForm : RibbonForm
    {
        SGWorld66 sgworld;
        public AppForm()
        {
            InitializeComponent();
            InitSkinGallery();
            RibbonButtonsInitialize();

        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            Utils.DevExpressLocalizerHelper.SetSimpleChinese();

            sgworld = new SGWorld66();

            string tAppRoot = Path.GetDirectoryName(Application.ExecutablePath);

            string flyPath = Path.Combine(tAppRoot, @"data\default.fly");
            sgworld.Open(flyPath);

            //sgworld.OnFrame += Sgworld_OnFrame;
        }

        IRouteWaypoint66 currentWaypoint = null;
        private void Sgworld_OnFrame()
        {
            if(_route != null)
            {
                int waypointIndex = _route.Waypoints.Current;
                var waypoint = _route.Waypoints.GetWaypoint(waypointIndex);
                if(waypoint != currentWaypoint)
                {
                    var lon = waypoint.X;
                    var lat = waypoint.Y;
                    var alt = waypoint.Altitude;
                    var speed = waypoint.Speed;
                    var cVerticesArray = new double[] {
                        lon,lat,alt,
                        lon,lat,0,
                    };

                    string tempID = sgworld.ProjectTree.FindItem("Temp");
                    var lineToGround = sgworld.Creator.CreatePolylineFromArray(cVerticesArray, 0xFF808080, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, getGroupID("Temp"),"line");
                    //var pLabel = sgworld.Creator.CreatePosition(lon, lat, alt / 2, AltitudeTypeCode.ATC_TERRAIN_RELATIVE);
                    //SGLabelStyle eLabelStyle = SGLabelStyle.LS_DEFAULT;
                    //// C2. Create label style
                    //ILabelStyle66 cLabelStyle = sgworld.Creator.CreateLabelStyle(eLabelStyle);
                    //// C3. Change label style settings
                    //{
                    //    double dAlpha = 0.5;        // 50% opacity
                    //    var cBackgroundColor = cLabelStyle.BackgroundColor; // Get label style background color
                    //    cBackgroundColor.FromBGRColor(0x0000FF);               // Set background to blue
                    //    cBackgroundColor.SetAlpha(dAlpha);                      // Set transparency to 50%
                    //    cLabelStyle.BackgroundColor = cBackgroundColor;         // Set label style background color
                    //    cLabelStyle.FontName = "Arial";                         // Set font name to Arial
                    //    cLabelStyle.Italic = true;                              // Set label style font to italic
                    //    cLabelStyle.Scale = 3;                                  // Set label style scale
                    //}
                    //sgworld.Creator.CreateLabel(pLabel, alt.ToString("0.00"), null, cLabelStyle, getGroupID("Temp"), "LABEL");
                }
            }
        }

        /// <summary>
        /// 初始化RibbonButtons
        /// </summary>
        private void RibbonButtonsInitialize()
        {
            //basetools
            InitBarButtonItem(bbiZoomIn, TagResources.ZoomIn);
            InitBarButtonItem(bbiZoomOut, TagResources.ZoomOut);
            InitBarButtonItem(bbiFaceNorth, TagResources.FaceNorth);
            InitBarButtonItem(bbiRotate, TagResources.Rotate);
            InitBarButtonItem(bbiDragMode, TagResources.DragMode);
            InitBarButtonItem(bbiSlideMode, TagResources.SlideMode);
            InitBarButtonItem(bbiTurnAndTiltMode, TagResources.TurnAndTiltMode);
            //measuretools
            InitBarButtonItem(bbiHorizontal, TagResources.Horizontal);
            InitBarButtonItem(bbiAerial, TagResources.Aerial);
            InitBarButtonItem(bbiVertical, TagResources.Vertical);
            InitBarButtonItem(bbiTerrainArea, TagResources.TerrainArea);
            //air line
            InitBarButtonItem(bbiDesignRoute, TagResources.DesignRoute);
            InitBarButtonItem(bbiRouteQuery, TagResources.RouteQuery);
            InitBarButtonItem(bbiAnalysis, TagResources.Analysis);
        }

        /// <summary>
        /// 初始化BarButtonItem
        /// </summary>
        /// <param name="buttonItem"></param>
        /// <param name="tag"></param>
        void InitBarButtonItem(DevExpress.XtraBars.BarButtonItem buttonItem, object tag)
        {
            InitBarButtonItem(buttonItem, tag, string.Empty);
        }

        /// <summary>
        /// 初始化BarButtonItem
        /// </summary>
        /// <param name="buttonItem"></param>
        /// <param name="tag"></param>
        /// <param name="description"></param>
        void InitBarButtonItem(DevExpress.XtraBars.BarButtonItem buttonItem, object tag, string description)
        {
            buttonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(bbi_ItemClick);
            buttonItem.Hint = description;
            buttonItem.Tag = tag;
        }

        private void bbi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ButtonClick(string.Format("{0}", e.Item.Tag));
        }

        /// <summary>
        /// BarButton Click事件
        /// </summary>
        /// <param name="tag"></param>
        private void ButtonClick(string tag)
        {
            switch (tag)
            {
                case TagResources.ZoomIn:
                    SGTools.ZoomIn();
                    break;
                case TagResources.ZoomOut:
                    SGTools.ZoomOut();
                    break;
                case TagResources.FaceNorth:
                    SGTools.FaceNorth();
                    break;
                case TagResources.Rotate:
                    SGTools.Rotate();
                    break;
                case TagResources.DragMode:
                    SGTools.SetDragMode();
                    break;
                case TagResources.SlideMode:
                    SGTools.SetSlideMode();
                    break;
                case TagResources.TurnAndTiltMode:
                    SGTools.SetTurnAndTiltMode();
                    break;
                case TagResources.Horizontal:
                    SGTools.MeasureHorizontal();
                    break;
                case TagResources.Aerial:
                    SGTools.MeasureAerial();
                    break;
                case TagResources.Vertical:
                    SGTools.MeasureVertical();
                    break;
                case TagResources.TerrainArea:
                    SGTools.MeasureArea();
                    break;
                case TagResources.DesignRoute:
                    if (fpDesignRoute.Visible == true)
                    {
                        fpDesignRoute.HidePopup();
                    }
                    else
                    {
                        fpDesignRoute.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Manual;
                        fpDesignRoute.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
                        int XCoord = dockPanel3.Width / 2 - fpDesignRoute.Width / 2;
                        int YCoord = dockPanel3.Height / 2 - fpDesignRoute.Height / 2;
                        fpDesignRoute.Options.Location = new Point(XCoord, YCoord);
                        fpDesignRoute.ShowPopup();
                    }
                    break;
                case TagResources.RouteQuery:
                    if (fpRouteHistory.Visible == true)
                    {
                        fpRouteHistory.HidePopup();
                    }
                    else
                    {
                        routeGridControl.DataSource = Utils.SQLiteManager.GetNWindData("T_Design");
                        fpRouteHistory.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Manual;
                        fpRouteHistory.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
                        fpRouteHistory.Options.Location = new Point(0, 0);
                        fpRouteHistory.ShowPopup();
                    }
                    break;
                case TagResources.Analysis:
                    if(pps.Count>0 && ppf.Count > 0)
                    {
                        SubForms.PicForm pf = new SubForms.PicForm();
                        var frm1 = pf.elementHost1.Child as wpfTerrainProfile;
                        frm1.LDesignPoint = pps;
                        frm1.LFlyPoint = ppf;
                        frm1.DrawV();
                        pf.ShowDialog(this);
                    }
                    break;
            }
        }

        private void sbTaskClose_Click(object sender, EventArgs e)
        {
            fpDesignRoute.HidePopup();
        }

        private void sbTaskRouteFile_Click(object sender, EventArgs e)
        {

        }

        private void sbTaskOK_Click(object sender, EventArgs e)
        {

        }

        private void sbHistoryRouteExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                routeGridControl.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sbHistoryRouteClose_Click(object sender, EventArgs e)
        {
            fpRouteHistory.HidePopup();
        }
        string flyGroupID = "";
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                string _taskID = gridView1.GetDataRow(e.RowHandle)["TaskID"].ToString();
                if (!isGroupExist(_taskID))
                {
                    flyGroupID = getGroupID(_taskID);
                    //design route
                    string _designFileName = "D:\\Route\\" + _taskID + "_d.txt";
                    ReadDesignText(_designFileName);
                    //fly route
                    string _flyFileName = "D:\\Route\\" + _taskID + "_f.txt";
                    ReadFlyText(_flyFileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        List<PolylinePoint> pps = new List<PolylinePoint>();
        private void ReadDesignText(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            List<double> lineArray = new List<double>();
            sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line.ToString());
                string[] val = System.Text.RegularExpressions.Regex.Split(line, @"\s{4,}");
                double _lat = Double.Parse(val[1]);
                double _lon = Double.Parse(val[2]);
                double _alt = Double.Parse(val[3])-37.15;
                lineArray.Add(_lon);
                lineArray.Add(_lat);
                lineArray.Add(_alt);

                PolylinePoint pp = new PolylinePoint();
                pp.X = _lon;
                pp.Y = _lat;
                pp.Z = _alt;
                pps.Add(pp);
            }
            var _routeLine = sgworld.Creator.CreatePolylineFromArray(lineArray.ToArray(), -16711936, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, flyGroupID,"设计航线");
        }

        List<PolylinePoint> ppf = new List<PolylinePoint>();
        private void ReadFlyText(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            List<IRouteWaypoint66> lr = new List<IRouteWaypoint66>();
            List<double> lineArray = new List<double>();
            sr.ReadLine();
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(line.ToString());
                    string[] val = System.Text.RegularExpressions.Regex.Split(line, @"\s");
                    double _lat = Double.Parse(val[1]);
                    double _lon = Double.Parse(val[2]);
                    double _alt = Double.Parse(val[3])-37.15;

                    if(i%4 == 0)
                    {
                        lineArray.Add(_lon);
                        lineArray.Add(_lat);
                        lineArray.Add(_alt);
                        IRouteWaypoint66 iRWP = sgworld.Creator.CreateRouteWaypoint(_lon, _lat, _alt, 1);
                        lr.Add(iRWP);
                    }

                    PolylinePoint pp = new PolylinePoint();
                    pp.X = _lon;
                    pp.Y = _lat;
                    pp.Z = _alt;
                    ppf.Add(pp);
                }
                i++;
            }
            CreateDynamicFly(lr, lineArray);
        }
        ITerrainDynamicObject66 _route = null;
        private void CreateDynamicFly(List<IRouteWaypoint66> _lr, List<double> _lineArray)
        {
            string tAppRoot = Path.GetDirectoryName(Application.ExecutablePath);
            string _modelFile = Path.Combine(tAppRoot, @"XPL\111.xpl2");
            var _routeLine = sgworld.Creator.CreatePolylineFromArray(_lineArray.ToArray(), -1000000, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, flyGroupID, "实际航线");
            _route = sgworld.Creator.CreateDynamicObject(_lr.ToArray(), DynamicMotionStyle.MOTION_MANUAL, DynamicObjectType.DYNAMIC_3D_MODEL, _modelFile,0.05,AltitudeTypeCode.ATC_TERRAIN_RELATIVE, flyGroupID,"模拟飞行");
            _route.CircularRoute = false;
            _route.TurnSpeed = 0;
            _route.Acceleration = 0;
            _route.Position.Distance = 5;
            _route.RestartRoute();
            sgworld.Navigate.FlyTo(_route);
            fpCurrent.ShowPopup();
        }

        private bool isGroupExist(string gName)
        {
            var gID = sgworld.ProjectTree.FindItem(gName);
            if(gID=="0" || gID == "" || gID == "-1")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private string getGroupID(string gName)
        {
            var gID = sgworld.ProjectTree.FindItem(gName);
            if (gID == "0" || gID == "" || gID == "-1")
            {
                gID = sgworld.ProjectTree.CreateGroup(gName);
            }
            return gID;
        }

        private void bbiRouteFast_ItemClick(object sender, ItemClickEventArgs e)
        {
            _route.Acceleration = 5;
        }

        private void bbiRouteRestart_ItemClick(object sender, ItemClickEventArgs e)
        {
            _route.RestartRoute();
        }

        private void bbiRouteSlow_ItemClick(object sender, ItemClickEventArgs e)
        {
            _route.Acceleration = 1;
        }
    }
}