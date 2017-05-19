using System.Windows.Forms;
using TerraExplorerX;

namespace UAVApp
{
    public class SGTools {

        static SGWorld65 sgworld = new SGWorld65();

        public static void ZoomIn() {
            sgworld.Navigate.ZoomIn();
        }

        public static void ZoomOut() {
            sgworld.Navigate.ZoomOut();
        }

        public static void FaceNorth() {
            sgworld.Command.Execute(1056, 0);
        }

        public static void Rotate() {
            sgworld.Command.Execute(1057, 0);
        }
        //设置拖动模式
        public static void SetDragMode() {
            sgworld.Command.Execute(1049, 0);
        }

        public static void SetSlideMode() {
            sgworld.Command.Execute(1050, 0);
        }

        public static void SetTurnAndTiltMode() {
            sgworld.Command.Execute(1051, 0);
        }
        //坐标查询
        public static void QueryInfo() {
            sgworld.Command.Execute(1023, 0);
        }
        //快照
        public static string GetSnapshot(int width, int height) {
            return sgworld.Window.GetSnapShot(true, width, height, "JPeg75", 0);
        }

        public static void SetUndergroundMode() {
            sgworld.Navigate.UndergroundMode = !sgworld.Navigate.UndergroundMode;
        }

        public static void HideTerrain() {
            sgworld.Terrain.Opacity = sgworld.Terrain.Opacity > 0 ? 0 : 1;
        }    

        public static void MeasureHorizontal() {
            sgworld.Command.Execute(1034, 0);
        }

        public static void MeasureAerial() {
            sgworld.Command.Execute(1035, 0);
        }

        public static void MeasureVertical() {
            sgworld.Command.Execute(1036, 0);
        }

        public static void MeasureArea() {
            sgworld.Command.Execute(1165, 0);
        }

        public static void ShowShadow() {

            sgworld.Command.Execute(2118, 0);
            sgworld.Command.Execute(1065, 4);
           
        }

        public static void ModifyTerrain() {
            sgworld.Command.Execute(1012, 15);
        }

        //public static void GetTerrainProfile() {
        //    sgworld.Command.Execute(1043, 0);
        //}

        public static void Snapshot(int width,int height) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "系统截图";
            saveFileDialog.DefaultExt = "jpg";
            saveFileDialog.Filter = "JPEG文件|*.jpg";

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string filePath = saveFileDialog.FileName;
                string snapshotFilePath = SGTools.GetSnapshot(width, height);
                System.IO.File.Copy(snapshotFilePath, filePath, true);
            }
        }
    }
}
