using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UAVApp.SubForms
{
    public partial class PicForm : DevExpress.XtraEditors.XtraForm
    {
        public PicForm()
        {
            InitializeComponent();
            Pipeline.Client.Forms.wpfTerrainProfile wpf = new Pipeline.Client.Forms.wpfTerrainProfile();
            this.elementHost1.Child = wpf;
        }
    }
}