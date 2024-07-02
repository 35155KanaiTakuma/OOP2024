using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }



        private void btEx8_1_Click(object sender, EventArgs e) {

            var dateTime = DateTime.Now;
            var str1 = string.Format("{0:yyyy/M/d HH:mm}", dateTime);
            tbDisp.Text = str1;

            var str2 = dateTime.ToString("yyyy�NMM��dd�� HH��mm��ss�b");
            tbDisp.Text = str2;

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var datestr = dateTime.ToString("ggyy",culture);
            var day0fweek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);

            var str3 = string.Format("{0}�N{1,2}��{2,2}��{3}", datestr, dateTime.Month, dateTime.Day, day0fweek);
            tbDisp.Text = str3;
            /*var date = new DateTime(2019, 1, 15, 19, 48, 32);
            var s1 = date.ToString("yyyy/MM/dd f");
            tbDisp.Text = "ssssss\r\n";

            var s2 = date.ToString("yyyy�NMM��dd���@HH��mm��ss�b");
            tbDisp.Text = "ssssss\r\n";

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var day0fweek = culture.DateTimeFormat.GetDayName(date.DayOfWeek);
            var str = date.ToString("ggyy�� MM��dd��", culture);
            tbDisp.Text = "ssssss\r\n";
            tbDisp.Text += "ssssss";*/
        }

        private void btEx8_2_Click(object sender, EventArgs e) {
            
        }

        public static DateTime NextDay(DateTime date,DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
        }
    }
}
