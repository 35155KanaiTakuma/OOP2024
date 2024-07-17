using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class fmVersion : Form {
        public fmVersion() {
            InitializeComponent();
        }

        private void btVersionOk_Click(object sender, EventArgs e) {
            Close();
            //DialogResult = DialogResult.OK;
        }

        private void fmVersion_Load(object sender, EventArgs e) {
            var asm = Assembly.GetExecutingAssembly();
            var varsion = asm.GetName().Version;

            VersionNow.Text = "Ver" + varsion.Major.ToString() + "." + varsion.Minor.ToString() + "." +
                varsion.Build.ToString() + "." + varsion.Revision.ToString();
            var name = asm.GetName();

        }


    }
}
