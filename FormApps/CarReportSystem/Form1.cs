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

        //�J�[���|�[�g�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        // �ݒ�N���X�̃C���X�^���X�쐬
        Settings settings = new Settings();

        //�R���X�g���N�^
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        // �ǉ�
        private void btAddReport_Click(object sender, EventArgs e) {

            /*if(cbAuthor.Text == "" || cbCarName.Text == "") {
                btAddReport.Enabled = false;
                return;
            } else {
                btAddReport.Enabled = true;
                return;
            }*/

            //�G���[���b�Z�[�W
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ��������͂ł�";
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

            dgvCarReport.ClearSelection(); // �Z���N�V�������O��

            inputitemsAllClear(); // ���͍��ڂ����ׂăN���A

            MessageClear(); // �G���[���b�Z�[�W�̃N���A
        }

        // ���͍��ڂ����ׂăN���A
        private void inputitemsAllClear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = "";
            setRadioButtonMaker(CarReport.MakerGroup.�Ȃ�);
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;
        }

        // �Ж��̃`�F�b�N�����ׂĊO��
        private void rbAllClear() {
            rbToyota.Checked = false;
            rbNissan.Checked = false;
            rbHonda.Checked = false;
            rbSubaru.Checked = false;
            rbImport.Checked = false;
            rbOther.Checked = false;
        }

        // �G���[���b�Z�[�W�̃N���A
        private void MessageClear() {
            if (!string.IsNullOrEmpty(tslbMessage.Text))
                tslbMessage.Text = "";
        }

        // �L�^�҂̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }

        // �Ԗ��̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }

        // �I������Ă��郁�[�J�[����񋓌^�ŕԂ�
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return CarReport.MakerGroup.�g���^;
            if (rbNissan.Checked)
                return CarReport.MakerGroup.���Y;
            if (rbHonda.Checked)
                return CarReport.MakerGroup.�z���_;
            if (rbSubaru.Checked)
                return CarReport.MakerGroup.�X�o��;
            if (rbImport.Checked)
                return CarReport.MakerGroup.�A����;
            if (rbOther.Checked)
                return CarReport.MakerGroup.���̑�;

            return CarReport.MakerGroup.���̑�;
        }

        // �w�肵�����[�J�[�̃��W�I�{�^�����Z�b�g
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {

            switch (targetMaker) {
                case CarReport.MakerGroup.�Ȃ�:
                    rbAllClear();
                    break;
                case CarReport.MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.�z���_:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.���̑�:
                    rbOther.Checked = true;
                    break;
            }
        }

        // �摜�I��
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }

        // �摜�폜
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }


        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;  //�摜�\�����Ȃ�

            // ���݂ɐF��ݒ肷��i�f�[�^�O���b�h�r���[�j
            dgvCarReport.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCarReport.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            if (File.Exists("settings.xml")) {
                // �ݒ�t�@�C�����t�V���A�������Ĕw�i��ݒ�
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
                    tslbMessage.Text = "�F���t�@�C���G���[";
                }
            } else {
                tslbMessage.Text = "�F���t�@�C��������܂���";
            }
        }

        //�@CarRePort���X�g�ɓ��͓��e��ۑ�
        private void dgvCarReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.Rows.Count == 0) || (!dgvCarReport.CurrentRow.Selected)) return; ;

            dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvCarReport.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvCarReport.CurrentRow.Cells["picture"].Value;

        }

        // �폜
        private void btDeleteReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;
            /*if (listCarReports.Count == 0) {
                tslbMessage.Text = "���X�g�ɉ����o�^����Ă��܂���";
                return;
            }*/
            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            dgvCarReport.ClearSelection(); // �Z���N�V�������O��
        }

        // �C��
        private void btModifyReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;

            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ��������͂ł�";
                return;
            }
            /*if (listCarReports.Count == 0) {
                tslbMessage.Text = "���X�g�ɉ����o�^����Ă��܂���";
                return;
            }

            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ��������͂ł�";
                return;
            }*/


            listCarReports[dgvCarReport.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvCarReport.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvCarReport.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Picture = pbPicture.Image;
            /*     �������ł��C���o����    
            var modifyData = listCarReports.[dgvCarReport.CurrentRow.Index];

            modifyData = new CarReport {
            Date = dtpDate.Value,
            Author = cbAuthor.Text,
            Maker = GetRadioButtonMaker(),
            Report = tbReport.Text,
            Picture = pbPicture.Image,
            }; */

            dgvCarReport.Refresh(); // �f�[�^�O���b�h�r���[�̍X�V

        }

        // �L�^�҂̃e�L�X�g���ҏW���ꂽ��
        private void cbAuthor_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }

        // �Ԗ��̃e�L�X�g���ҏW���ꂽ��
        private void cbCarName_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }

        // �ۑ�
        private void ReportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    // �o�C�i���`���ŃV���A����
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    using (FileStream fs = File.Open(
                        sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "�������݃G���[";
                    return;
                }
            }
        }

        // �t�@�C�����J��
        private void ReportOpenFile() {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    // �t�V���A�����Ńo�C�i���`������荞��
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
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
                    tslbMessage.Text = "�t�@�C���`�����Ⴂ�܂�";
                    return;
                    //MessageBox.Show(ex.Message);
                }
                dgvCarReport.ClearSelection();
            }
        }

        // �N���A�{�^���������ꂽ�璆�g�����ׂď���
        private void CheckClear_Click(object sender, EventArgs e) {
            inputitemsAllClear();
            dgvCarReport.ClearSelection();
        }

        private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportOpenFile();
        }

        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportSaveFile();
        }

        private void �F�̐ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;  // �w�i�F�ݒ�
                settings.MainFormColor = cdColor.Color.ToArgb(); // �w�i�F�ۑ�
                MessageBox.Show(settings.MainFormColor.ToString());
            }
        }

        private void �I��ToolStripMenuItem_Click(object sender, EventArgs e) {

            if (MessageBox.Show("�I�����܂����H", "�m�F",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            // �ݒ�t�@�C���̃V���A����
            try {
                using (var writer = XmlWriter.Create("settings.xml")) {
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception) {
                MessageBox.Show("�ݒ�t�@�C���̏������݃G���[");
            }

        }
    }
}
