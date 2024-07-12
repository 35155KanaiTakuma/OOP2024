using CarReportSystem.Properties;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        // 設定クラスのインスタンス作成
        Settings settings = new Settings();

        //コンストラクタ
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        // 追加
        private void btAddReport_Click(object sender, EventArgs e) {

            /*if(cbAuthor.Text == "" || cbCarName.Text == "") {
                btAddReport.Enabled = false;
                return;
            } else {
                btAddReport.Enabled = true;
                return;
            }*/

            //エラーメッセージ
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };

            listCarReports.Add(carReport);

            setCbAuthor(cbAuthor.Text);

            setCbCarName(cbCarName.Text);

            dgvCarReport.ClearSelection(); // セレクションを外す

            inputitemsAllClear(); // 入力項目をすべてクリア

            MessageClear(); // エラーメッセージのクリア
        }

        // 入力項目をすべてクリア
        private void inputitemsAllClear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = "";
            setRadioButtonMaker(CarReport.MakerGroup.なし);
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;
        }

        // 社名のチェックをすべて外す
        private void rbAllClear() {
            rbToyota.Checked = false;
            rbNissan.Checked = false;
            rbHonda.Checked = false;
            rbSubaru.Checked = false;
            rbImport.Checked = false;
            rbOther.Checked = false;
        }

        // エラーメッセージのクリア
        private void MessageClear() {
            if (!string.IsNullOrEmpty(tslbMessage.Text))
                tslbMessage.Text = "";
        }

        // 記録者の履歴をコンボボックスへ登録（重複なし）
        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }

        // 車名の履歴をコンボボックスへ登録（重複なし）
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }

        // 選択されているメーカー名を列挙型で返す
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return CarReport.MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return CarReport.MakerGroup.日産;
            if (rbHonda.Checked)
                return CarReport.MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return CarReport.MakerGroup.スバル;
            if (rbImport.Checked)
                return CarReport.MakerGroup.輸入車;
            if (rbOther.Checked)
                return CarReport.MakerGroup.その他;

            return CarReport.MakerGroup.その他;
        }

        // 指定したメーカーのラジオボタンをセット
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {

            switch (targetMaker) {
                case CarReport.MakerGroup.なし:
                    rbAllClear();
                    break;
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
            }
        }

        // 画像選択
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }

        // 画像削除
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }


        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;  //画像表示しない

            // 交互に色を設定する（データグリッドビュー）
            dgvCarReport.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCarReport.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            if (File.Exists("settings.xml")) {
                // 設定ファイルを逆シリアル化して背景を設定
                try {
                    using (var reader = XmlReader.Create("settings.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        /*settings = serializer.Deserialize(reader) as Settings;
                        BackColor = Color.FromArgb(settings.MainFormColor);*/
                        var settings = serializer.Deserialize(reader) as Settings;
                        BackColor = Color.FromArgb(settings.MainFormColor);
                        settings.MainFormColor = BackColor.ToArgb();
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "色情報ファイルエラー";
                }
            } else {
                tslbMessage.Text = "色情報ファイルがありません";
            }
        }

        //　CarRePortリストに入力内容を保存
        private void dgvCarReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.Rows.Count == 0) || (!dgvCarReport.CurrentRow.Selected)) return; ;

            dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvCarReport.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvCarReport.CurrentRow.Cells["picture"].Value;

        }

        // 削除
        private void btDeleteReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;
            /*if (listCarReports.Count == 0) {
                tslbMessage.Text = "リストに何も登録されていません";
                return;
            }*/
            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            dgvCarReport.ClearSelection(); // セレクションを外す
        }

        // 修正
        private void btModifyReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;

            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }
            /*if (listCarReports.Count == 0) {
                tslbMessage.Text = "リストに何も登録されていません";
                return;
            }

            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }*/


            listCarReports[dgvCarReport.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvCarReport.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvCarReport.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Picture = pbPicture.Image;
            /*     こっちでも修正出来る    
            var modifyData = listCarReports.[dgvCarReport.CurrentRow.Index];

            modifyData = new CarReport {
            Date = dtpDate.Value,
            Author = cbAuthor.Text,
            Maker = GetRadioButtonMaker(),
            Report = tbReport.Text,
            Picture = pbPicture.Image,
            }; */

            dgvCarReport.Refresh(); // データグリッドビューの更新

        }

        // 記録者のテキストが編集されたら
        private void cbAuthor_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }

        // 車名のテキストが編集されたら
        private void cbCarName_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }

        // 保存
        private void ReportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    // バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(
                        sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "書き込みエラー";
                    return;
                }
            }
        }

        // ファイルを開く
        private void ReportOpenFile() {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    // 逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs
                        = File.Open(ofdPicFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCarReport.DataSource = listCarReports;

                        foreach (var carReport in listCarReports) {
                            setCbAuthor(carReport.Author);
                            setCbCarName(carReport.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "ファイル形式が違います";
                    return;
                    //MessageBox.Show(ex.Message);
                }
                dgvCarReport.ClearSelection();
            }
        }

        // クリアボタンが押されたら中身をすべて消す
        private void CheckClear_Click(object sender, EventArgs e) {
            inputitemsAllClear();
            dgvCarReport.ClearSelection();
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportOpenFile();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportSaveFile();
        }

        private void 色の設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;  // 背景色設定
                settings.MainFormColor = cdColor.Color.ToArgb(); // 背景色保存
                MessageBox.Show(settings.MainFormColor.ToString());
            }
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {

            if (MessageBox.Show("終了しますか？", "確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            // 設定ファイルのシリアル化
            try {
                using (var writer = XmlWriter.Create("settings.xml")) {
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception) {
                MessageBox.Show("設定ファイルの書き込みエラー");
            }

        }
    }
}
