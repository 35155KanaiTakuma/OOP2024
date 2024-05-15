using System.Reflection;

namespace BallApp {
    public partial class Form1 : Form {
        //Obj ball;
        //PictureBox pb;

        // List�R���N�V����
        private List<Obj> balls = new List<Obj>();      // �{�[���C���X�^���X�i�[�p
        private List<PictureBox> pbs = new List<PictureBox>();  // �\���p

        // �R���X�g���N�^
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
        }

        // �t�H�[�����ŏ��Ƀ��[�h�����Ƃ���x�������s�����
        private void Form1_Load(object sender, EventArgs e) {
        }

        private void timer1_Tick(object sender, EventArgs e) {
            //ball.Move();
            //pb.Location = new Point((int)ball.PosX, (int)ball.PosY);

            for(int i = 0; i < balls.Count; i++) {
                balls[i].Move();
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);

            }
        
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            PictureBox pb = new PictureBox();   // �摜��\������R���g���[��
            Obj ball = null;

            // �T�b�J�[�{�[������
            if (e.Button == MouseButtons.Left) {
                ball = new SoccerBall(e.X, e.Y);
                pb.Size = new Size(50, 50);
            }
            
            // �e�j�X�{�[������
            else if (e.Button == MouseButtons.Right){
                ball = new TennisBall(e.X - 12, e.Y - 12);
                pb.Size = new Size(25, 25);
            }
            pb.Image = ball.Image;
            pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Parent = this;
            timer1.Start();

            balls.Add(ball);
            pbs.Add(pb);
        }
    }
}
