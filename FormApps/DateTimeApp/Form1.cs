namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            //tbDisp.Text = "››“ú–Ú";
            var today = DateTime.Today;
            TimeSpan diff = today - dtpDate.Value;

            tbDisp.Text = (diff.Days + 1) + "“ú–Ú";
        }

        private void btDayBefore_Click(object sender, EventArgs e) {
            var past = dtpDate.Value.AddDays(-(double)nudDay.Value);
            tbDisp.Text = past.ToString("D");

        }

        private void btDayAfter_Click(object sender, EventArgs e) {
            var future = dtpDate.Value.AddDays((double)nudDay.Value);
            tbDisp.Text = future.ToString("D");
        }

        private void btAge_Click(object sender, EventArgs e) {
            var birthday = dtpDate.Value;
            var today = DateTime.Today;
            var age = GetAge(birthday,today);
            tbDisp.Text = age.ToString("D");
        }

        public static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if(targetDay < birthday.AddYears(age).AddDays(-1)) {
                age--;
            }
            return age;
        }
    }
}
