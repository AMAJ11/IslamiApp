using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.Design;
using System.Threading;
using System.Resources;
using System.Text.RegularExpressions;
using System.Globalization;
using islami;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.InteropServices;
using Microsoft.CSharp.RuntimeBinder;
using PrayTimes;








namespace islami
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        int x = 0, y = 0;
        bool down;
        double zkah;
        double nsab;
        double zh = 85;
        double pric;
        double lon;
        double lat; 
        int dayn = int.Parse(DateTime.Now.ToString("dd", new System.Globalization.CultureInfo("ar-sa")));
        string date = DateTime.Now.ToString("yyyy,MM,dd", new System.Globalization.CultureInfo("ar-eg"));
        string dateh=DateTime.Now.ToString("yyyy,MMMM,dd",new System.Globalization.CultureInfo("ar"));
        string day = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("ar-sa"));
        int mounth =int.Parse(DateTime.Now.ToString("MM", new System.Globalization.CultureInfo("ar-eg")));
        string[] ahades = { "من صلى علي صلاة واحدة صلى الله عليه عشراً",
            "من أطاعني دخل الجنة، ومن عصاني فقد أبى" ,
        "من رغب عن سنتي فليس مني",
        "لا يؤمن أحدكم حتى أكون أحب إليه من والده وولده والناس أجمعين",
        "إن لله تسعة وتسعين اسما مائة إلا واحدا، من أحصاها دخل الجنة",
        "(قال الله عز وجل: (سبقت رحمتي غضبي",
        "إن الله يغار, وغيرة الله أن يأتي المؤمنُ ما حرم عليه",
        "إن الله يرفع بهذا الكتاب أقواما، ويضع به آخرين",
        "من حفظ عشر آيات من أول سورة الكهف عُصم من الدجال",
        "من يرد الله به خيرا يفقهه في الدين",
        "من سلك طريقاً يلتمس فيه علماً سهَّل الله له به طريقاً إلى الجنة",
        "إنّ الملائكة لتضع أجنحتها رضاً لطالب العلم",
        "أكبر الكبائر: الإشراك بالله، وعقوق الوالدين، وشهادة الزور",
        "إن بين الرجل و بين الشرك و الكفر تركُ الصلاة",
        "كلُّ المسلم على المسلم حرام, دمه و ماله و عرضه",
        "أوّل ما يقضى بين الناس يوم القيامة في الدماء",
        "من غشّنا فليس منّا",
        "آية النفاق ثلاث, إذا حدّث كذب, و إذا اؤتمن خان, وإذا وعد أخلف",
        "لاتسبّوا أصحابي, فلو أن أحدكم أنفق مثل أحد ذهباً ما بلغ مدَّ أحدهم و لا نصيفه",
        "لا يدخل الجنّة نمّام",
        "ما زال جبريل يوصيني بالجار حتى ظننت انه سيورثه",
        "أشدّ الناس عذاباً يوم القيامة المصوّرون",
        "من أتى عرّافاً فسأله عن شيء, لم تقبل صلاته أربعين ليلة",
        "الدينُ النّصيحة",
        "إن الله لا ينظر الى صوركم و اموالكم, و لكن ينظر الى قلوبكم و أعمالكم",
        "المسلم من سلمَ المسلمون من لسانه و يده",
        "ليس الشديد بالصرعة, إنّما الشديدُ الذي يملك نفسه عند الغضب",
        "نعمتان مغبونٌ فيهما كثير من الناس, الصحةُ و الفراغ",
        "إنّ امتي يُدعون يوم القيامة غراً محجلين من اثار الوضوء",
        "ويل للاعقاب من النار",
         "لا يؤمن أحدكم حتى يحبَّ لأخيه ما يحبُّ لنفسه",
        "لا صلاة لجار المسجد إلا في المسجد",
          "كلكم راعٍ و كلّكم مسؤول عن رعيّته"

        };
        string[] ahades1 = {
  "لا يؤمن أحدكم حتى يحبَّ لأخيه ما يحبُّ لنفسه",
"لا صلاة لجار المسجد إلا في المسجد",
  "كلكم راعٍ و كلّكم مسؤول عن رعيّته"
 ,"من كذب علّي نتعمدا فليتبوّأ مقعده من النار",
 "أنا و كافل اليتيم في الجنة كهاتين [وأشار بالسبابة و الوسطى]",
 "أفطر الحاجم و المحجوم",
 "امسحو على الخفين",
 "اهتزّ عرش الرحمن لموت سعد بن معاذ",
 "الايمان يمان",
 "الحرب خدعة",
 "الحسن و الحسين سيِّدا شباب أهل الجنّة",
  "الحياءُ من الإيمان",
  "دباغ الأديم طهوره",
  "قل هو الله أحد تعدل ثلُثَ القرآن",
  "كلُّ مسكرٍ حرام",
  "من رآني في المنام فقد رآني فإنّ الشيطان لا يتمثّل بي",
  "من لا يَرحَم لا يُرحم",
"المؤذّنون أطولُ النّاس أعناقاً يومَ القيامة",
 "اتّقوا النار و لو بشقِّ تمرة",
 "أُمرت أن أقاتلَ النّاس حتّى يشهدوا أن لا إله إلّا الله",
 "أيام التشريقِ أيام أكلٍ و شربٍ و ذكرِ الله تعالى",
 "بُعثت انا و الساعة كهاتين",
 "الخير معقودٌ بنواصي الخيل إلى يوم القيامة",
 "إنّما الأعمال بالنّيات",
 "خيركم من تعلّم القرآن و علّمه",
 "إنَّ اللهَ تعالى يحبُّ إذا عملَ أحدُكمْ عملًا أنْ يتقنَهُ",
 "أقربكم منّي مجلساً يوم القيامة أحاسنكم أخلاقا",
 "اقرؤوا القرآن فإنه يأتي يوم القيامة شفيعاً لأصحابه",
 "إنّ الذي ليس في جوفه شيءٌ من القرآن كالبيت الخرب",
 "مثل الذي يذكر و الذي لايذكر كمثل الحيّ و الميّت",
 "كلمتان خفيفتان على اللسان ثقيلتان في الميزان حبيبتان إلى الرحمن, سبخان الله و بحمده سبحان الله العظيم" ,
 };
        
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            down = true;
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (down) { this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y); }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
            
        }

          

        private void tintro_Tick_1(object sender, EventArgs e)
        {
           
      
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            if (mounth == 1 || mounth == 3 || mounth == 5 || mounth == 7 || mounth == 9 || mounth == 11)
                label9.Text = ahades1[dayn];
            else if(mounth==2|| mounth == 4 || mounth == 6 || mounth == 8 || mounth == 10 || mounth == 12 )
                label9.Text = ahades[dayn];
            guna2ComboBox1.SelectedIndex=0;
            label1.Text = date;
            label3.Text = dateh;
            label4.Text = day;
            phades.BringToFront();
            var tz = DateTime.Now;
            lat = 33.5102;
            lon = 36.2913;
            PrayTimesCalculator pt = new PrayTimesCalculator(lat,lon );
            pt.CalculationMethod = CalculationMethods.Makkah;
            label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Fajr);
            label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Sunrise);
            label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Dhuhr);
            label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Asr);
            label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Maghrib);
            label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Isha); 
    }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("hh:mm:ss,tt");
            label2.Text = time;
        }

        private void bexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void zekr_Click(object sender, EventArgs e)
        {
            pzekr.BringToFront();
        }

        private void pzekr_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bczekr.Visible == false)
            {
                bczekr.BringToFront();
                bczekr.Visible = true;
            }
            else { bczekr.Visible = false; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bczekr.Visible = false;
            label5.Text = "سبحان الله";
            label6.Text="« قال رسول الله صلّى الله عليه و سلم :الطُّهُورُ شَطْرُ الإيمانِ، والْحَمْدُ لِلَّهِ تَمْلأُ المِيزانَ، وسُبْحانَ اللهِ والْحَمْدُ لِلَّهِ تَمْلَآنِ -أَوْ تَمْلأُ- ما بيْنَ السَّمَواتِ والأرْضِ، والصَّلاةُ نُورٌ، والصَّدَقَةُ بُرْهانٌ، والصَّبْرُ ضِياءٌ، والْقُرْآنُ حُجَّةٌ لَكَ، أوْ عَلَيْكَ، كُلُّ النَّاسِ يَغْدُو فَبايِعٌ نَفْسَهُ فَمُعْتِقُها، أوْ مُوبِقُها . » ";
            label6.Visible = true;
            button12.Text = label5.Text;
            button12.Enabled = true;
            label12.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bczekr.Visible = false;
            label5.Text = "الحمد لله";
            label6.Text = "« قال رسول الله صلّى الله عليه و سلم :الطُّهُورُ شَطْرُ الإيمانِ، والْحَمْدُ لِلَّهِ تَمْلأُ المِيزانَ، وسُبْحانَ اللهِ والْحَمْدُ لِلَّهِ تَمْلَآنِ -أَوْ تَمْلأُ- ما بيْنَ السَّمَواتِ والأرْضِ، والصَّلاةُ نُورٌ، والصَّدَقَةُ بُرْهانٌ، والصَّبْرُ ضِياءٌ، والْقُرْآنُ حُجَّةٌ لَكَ، أوْ عَلَيْكَ، كُلُّ النَّاسِ يَغْدُو فَبايِعٌ نَفْسَهُ فَمُعْتِقُها، أوْ مُوبِقُها . » ";
            label6.Visible = true;
            button12.Text = label5.Text;
            button12.Enabled = true;
            label12.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bczekr.Visible = false;
            label5.Text = "لا إله إلّا الله";
            label6.Visible = true;
            label6.Text = "« قال رسول الله صلّى الله عليه:وسلم أفضل الذكر لا إله إلا الله وأفضل الدعاء الحمد لله»";
            button12.Text = label5.Text;
            button12.Enabled = true;
            label12.Text = "0";
        }

        private void bczekr_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            bczekr.Visible = false;
            label5.Text = "الله أكبر";
            label6.Visible = true;
            label6.Text = "قَالَ عُمَرُ بْنُ الْخَطَّابِ: قَوْلُ الْعَبْدِ: اللَّهُ أَكْبَرُ، خير من الدنيا وما فيها";
            button12.Text = label5.Text;
            button12.Enabled = true;
            label12.Text = "0";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bczekr.Visible = false;
            label5.Text = "اللهم صلِّ على سيدنا محمد";
            label6.Visible = true;
            label6.Text = "قال أبي بن كعب : فقلت يا رسول الله إني أكثر الصلاة عليك فما أجعل لك من صلاتي ؟ قال : ما شئت قلت : الربع ؟ قال : ما شئت وإن زدت فهو خير . قلت : النصف ؟ قال : ما شئت وإن زدت فهو خير لك . قلت : الثلثين ؟ قال : ما شئت وإن زدت فهو خير . قلت : أجعل لك صلاتي كلها قال : إذا يكفي همك ويغفر ذنبك";
            button12.Text = label5.Text;
            button12.Enabled = true;
            label12.Text = "0";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bczekr.Visible = false;
            label5.Text = " سبحان الله وبحمده سبحان الله العظيم";
            label6.Visible = true;
            label6.Text = " قال رسول الله صلّى الله عليه و سلم : كلمتان خفيفتان على اللسان ثقيلتان في الميزان حبيبتان إلى الرحمن, سبحان الله و بحمده سبحان الله العظيم ";
            button12.Text = label5.Text;
            button12.Enabled = true;
            label12.Text = "0";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bczekr.Visible = false;
            label5.Text = "أستغفر الله";
            label6.Visible = true;
            label6.Text="قال الله عزّوجلَّ :ولو أنهم إذ ظلموا أنفسهم جاؤوك فاستغفروا الله واستغفر لهم الرسول لوجدوا الله توابا رحيما ";
            button12.Text = label5.Text;
            button12.Enabled = true;
            label12.Text = "0";
        }
       

        private void button10_Click(object sender, EventArgs e)
        {
            bczekr.Visible = false;
            label5.Text = "حسبيّ الله و نعم الوكيل";
            label6.Visible = true;
            label6.Text = "قال اله تعالى:فإن تولو فقل حسبيَ الله لاإله إلا أنت";
            button12.Text = label5.Text;
            button12.Enabled = true;
            label12.Text = "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bczekr.Visible = false;
            label5.Text = "اللهم إنك عفوٌّ تحبّ العفو فاعف عنا";
            label6.Visible = true;
            label6.Text = "«سألَتْهُ صلى اللهُ عليهِ وسلَّمَ عائشةُ رضي الله عنها إنْ وافقتُها فبِمَ أدعو ؟[أي عن ليلة القدر] قال قولي اللهمَّ إنك عفوٌ تحبُّ العفوَ فاعفُ عني »";
            button12.Text = label5.Text;
            button12.Enabled = true;
            label12.Text = "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label12.Text =Convert.ToString(int.Parse(label12.Text) + 1);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pshazel.BringToFront();
            label13.Text = Resource2.shazel;
            label13.Height = 1200;
            
        }

        private void doaa_Click(object sender, EventArgs e)
        {
            pdoaa.BringToFront();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pshazel.BringToFront();
            label13.Text = Resource2.nawawi;
            label13.Height = 3500;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            phades.BringToFront();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            lblzahab.Text = lblzahab.Text + "1";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            lblzahab.Text = lblzahab.Text + "2";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            lblzahab.Text = lblzahab.Text + "3";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            lblzahab.Text = lblzahab.Text + "4";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            lblzahab.Text = lblzahab.Text + "5";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            lblzahab.Text = lblzahab.Text + "6";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            lblzahab.Text = lblzahab.Text + "7";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            lblzahab.Text = lblzahab.Text + "8";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            lblzahab.Text = lblzahab.Text + "9";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            lblzahab.Text = lblzahab.Text + "0";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            lblzahab.Text = lblzahab.Text + ".";
        }

        private void zakah_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
            guna2ComboBox2.SelectedIndex = 0;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            zkah = double.Parse(lblzahab.Text);
            lblzahab.Text = "";
            nsab = zkah * zh;
            label17.Text =Convert.ToString(nsab);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            lblzahab.Text = "";
        }

        private void button40_Click(object sender, EventArgs e)
        {
            label20.Text = label20.Text + "1";
        }

        private void button39_Click(object sender, EventArgs e)
        {
            label20.Text = label20.Text + "2";
        }

        private void button38_Click(object sender, EventArgs e)
        {
            label20.Text = label20.Text + "3";
        }

        private void button37_Click(object sender, EventArgs e)
        {
            label20.Text = label20.Text + "4";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            label20.Text = label20.Text + "5";
        }

        private void button35_Click(object sender, EventArgs e)
        {
            label20.Text = label20.Text + "6";
        }

        private void button34_Click(object sender, EventArgs e)
        {
            label20.Text = label20.Text + "7";
        }

        private void button33_Click(object sender, EventArgs e)
        {
            label20.Text = label20.Text + "8";
        }

        private void button32_Click(object sender, EventArgs e)
        {
            label20.Text = label20.Text + "9";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            label20.Text = label20.Text + ".";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            label20.Text = label20.Text + "0";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            label20.Text = "";
        }

        private void button30_Click(object sender, EventArgs e)
        {

            pric = double.Parse(label20.Text);
            if (pric < nsab) { MessageBox.Show("نقودك التي تمتلكها لم تبلغ حدّ النصاب "); } else if (pric > nsab || pric == nsab) { label21.Text = Convert.ToString(pric * 2.5 / 100); }
        }

        private void phades_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hades_Click(object sender, EventArgs e)
        {
           Form2 frm = new Form2();
            frm.Show();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (guna2ComboBox1.SelectedIndex == 0)
            {
                var tz = DateTime.Now;
                lat = 33.5102;
                lon = 36.2913;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 1) {
                var tz = DateTime.Now;
                lat = 31.963158;
                lon = 35.930359;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Isha);
            }
            else  if (guna2ComboBox1.SelectedIndex == 2) {
                var tz = DateTime.Now;
                lat = 33.312805;
                lon = 44.361488;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 3) {
                var tz = DateTime.Now;
                lat =   29.95375640 ;
                lon =  31.53700030;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 4) {
                var tz = DateTime.Now;
                lat = 24.774265;
                lon = 46.738586;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 5) {
                var tz = DateTime.Now;
                lat = 25.2048;
                lon = 55.2708;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +4).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +4).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +4).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +4).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +4).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +4).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 6) {
                var tz = DateTime.Now;
                lat = 33.8938;
                lon = 35.5018;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 7) {
                var tz = DateTime.Now;
                lat = 31.7683;
                lon = 35.2137;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 8) {
                var tz = DateTime.Now;
                lat = 34.0084;
                lon = 6.8539;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 9) {
                var tz = DateTime.Now;
                lat = 25.2854;
                lon = 51.5310;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 10) {
                var tz = DateTime.Now;
                lat = 18.0735;
                lon = 15.9582;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +0).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +0).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +0).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +0).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +0).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +0).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 11) {
                var tz = DateTime.Now;
                lat = 11.5886;
                lon = 43.1454;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 12) {
                var tz = DateTime.Now;
                lat = 11.7061;
                lon = 43.2517;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 13) {
                var tz = DateTime.Now;
                lat = 32.8877;
                lon = 13.1872;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 14) {
                var tz = DateTime.Now;
                lat = 29.378586;
                lon = 47.990341;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 15) {
                var tz = DateTime.Now;
                lat = 26.2235;
                lon = 50.5876;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 16) {
                var tz = DateTime.Now;
                lat = 15.5974;
                lon = 32.5356;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 17) {
                var tz = DateTime.Now;
                lat = 4.8539;
                lon = 31.5825;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +2).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 18) {
                var tz = DateTime.Now;
                lat = 2.0371;
                lon = 45.3379;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 19) {
                var tz = DateTime.Now;
                lat = 36.8065;
                lon = 10.1815;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 20) {
                var tz = DateTime.Now;
                lat = 15.298819;
                lon = 44.181877;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +3).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 21) {
                var tz = DateTime.Now;
                lat = 23.5880;
                lon = 58.3829;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +4).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +4).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +4).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +4).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +4).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +4).Isha);
            }
            else if (guna2ComboBox1.SelectedIndex == 22)
            {
                var tz = DateTime.Now;
                lat = 36.7538;
                lon = 3.0588;
                PrayTimesCalculator pt = new PrayTimesCalculator(lat, lon);
                pt.CalculationMethod = CalculationMethods.Makkah;
                label29.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Fajr);
                label28.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Sunrise);
                label30.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Dhuhr);
                label31.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Asr);
                label32.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Maghrib);
                label33.Text = Convert.ToString(pt.GetPrayerTimes(tz.Date, +1).Isha);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedIndex == 0)
                zh = 85;
            else if (guna2ComboBox2.SelectedIndex == 1)
                zh = 97.14;
            else if (guna2ComboBox2.SelectedIndex == 2)
                zh = 113.3;
        }

        private void button43_Click(object sender, EventArgs e)
        {
           MessageBox.Show("Name:عمّار أبو جيب,\nNational:syria/Damascus,\nGmail: apo.zouher11@gmail.com,\nphone:+963937379312");
        }

        private void button41_Click(object sender, EventArgs e)
        {
            pshazel.BringToFront();
            label13.Text = Resource2.nasr;
            label13.Height = 2300;
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }
        
        





    }
}
