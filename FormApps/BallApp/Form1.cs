namespace BallApp {
    public partial class Form1 : Form {
        private double posX;    // X���W
        private double posY;    // Y���W
        private double moveX;   // �ړ��ʁiX�����j
        private double moveY;   // �ړ��ʁiY�����j



        // �R���X�g���N�^
        public Form1() {
            InitializeComponent();

            moveX = moveY = 4; 
        }

        private void button1_Click(object sender, EventArgs e) {

        }

        // �t�H�[�����ŏ��Ƀ��[�h�����Ƃ���x�������s�����
        private void Form1_Load(object sender, EventArgs e) {
            this.BackColor = Color.GreenYellow;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            // ���݈ʒu��\��
            this.Text = pbBall.Location.ToString();


            if(pbBall.Location.X > 750 || pbBall.Location.X < 0) {
                // �ړ��ʂ̕����𔽓]
                moveX = -moveX;
            }

            if (pbBall.Location.Y > 500 || pbBall.Location.Y < 0) {
                // �ړ��ʂ̕����𔽓]
                moveY = -moveY;
            }

            posX += moveX;
            posY += moveY;

            pbBall.Location = new Point((int)posX, (int)posY);
        }
    }
}
