using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChestionareAuto
{
    public partial class ChestionarWindow : Form
    {
        private Dictionary<string, int> nrQuestions = new Dictionary<string, int>();
        private Dictionary<string, int> maxWrongAllowed = new Dictionary<string, int>();
        private Dictionary<string, int> minCorrectNeeded = new Dictionary<string, int>();
        private Dictionary<string, int> maxTimeMinutes = new Dictionary<string, int>();
        private int totalQuestions = 0;
        private string letter;
        private bool[] viz = new bool[1200];
        private Queue<QuestionClass> Q = new Queue<QuestionClass>();
        private char letterch = 'a';
        private DatabaseQuestions dbq;
        private Random R;
        private int countwrong = 0;
        private int countcorrect = 0;
        private int countremaining = 0;
        private bool isClosed;
        private bool checkA, checkB, checkC;
        private int timeleft;
        private bool closeApp = false;
        QuestionClass now;
        Color OrangeColor = new Color();

        private CategorieWindow categWindow;
        public ChestionarWindow(CategorieWindow cw, string categorie)
        {
            InitializeComponent();
            Initializare();
            closeApp = false;
            OrangeColor = Color.FromArgb(255, 228, 181);
            this.categWindow = cw;
            dbq = new DatabaseQuestions();
            letter = categorie;
            letterch = letter.ToCharArray()[0];
            timeleft = maxTimeMinutes[letter] * 60;
            LoadingWindow lw = new LoadingWindow();
            CreareCoada();
            lw.ShowDialog(); 
            GoChestionar();
        }
        ~ChestionarWindow()
        {
            dbq = null;
            Q = null;
            System.GC.Collect();
        }

        public bool IsClosed
        {
            get { return isClosed; }
            set { isClosed = value; }
        }
        public bool CloseApp
        {
            get { return closeApp; }
            set { closeApp = value; }
        }

        private void Initializare()
        {
            StreamReader fin = new StreamReader("appFiles\\legea.txt");
            string nowcateg;
            while((nowcateg = fin.ReadLine()) != null)
            {
                string[] listnr = fin.ReadLine().Split(' ');
                nrQuestions[nowcateg] = Convert.ToInt32(listnr[0]);
                maxWrongAllowed[nowcateg] = Convert.ToInt32(listnr[1]);
                minCorrectNeeded[nowcateg] = nrQuestions[nowcateg] - maxWrongAllowed[nowcateg];
                maxTimeMinutes[nowcateg] = Convert.ToInt32(fin.ReadLine());    
            }
            fin.Close();
        }
        private void CreareCoada()
        {
            Q.Clear();
            R = new Random();
            StreamReader fin = new StreamReader("appFiles\\" + letter + "\\nrq.txt");
            totalQuestions = Convert.ToInt32(fin.ReadLine());
            fin.Close();
            int uptonow = 0;
            while (uptonow < nrQuestions[letter])
            {
                int cand = R.Next(1, totalQuestions + 1);
                if (!viz[cand])
                {
                    viz[cand] = true;
                    Q.Enqueue(dbq[letterch, cand]);
                    ++uptonow;
                }
            }
        }

        private void UpdateLabels()
        {
            qremlabel.Text = countremaining.ToString();
            qexactlabel.Text = countcorrect.ToString();
            qwronglabel.Text = countwrong.ToString();
        }

        private void ShowNextQuestion()
        {
            UpdateLabels();
            now = Q.Dequeue();
            ansAlabel.Text = now.AnsA;
            ansBlabel.Text = now.AnsB;
            ansClabel.Text = now.AnsC;
            if (!now.ExistsImage)
            {
                Qlabel.Size = new Size (776, 138);
                photoimg.Visible = false;
                Qlabel.Text = now.Question;
            }
            else
            {
                Qlabel.Size = new Size(620, 138);
                photoimg.Visible = true;
               
                Qlabel.Text = now.Question;
                photoimg.BackgroundImage = Image.FromFile(now.PhotoPath);
            }
        }
        private void GoChestionar()
        {
            timeleft = maxTimeMinutes[letter] * 60;
            timelabel.Text = TimeToString(timeleft);
            timer1.Start();
            countcorrect = countwrong = 0;
            countremaining = nrQuestions[letter];
            ShowNextQuestion();
        }

        private void ChestionarWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbq.Dispose();
            dbq = null;
            categWindow.Show();
            IsClosed = true;
        }

        private void imgA_Click(object sender, EventArgs e)
        {
            checkA = true;
            imgA.Image = Image.FromFile("appFiles\\A_pressed.jpg");
            ansAlabel.BackColor = OrangeColor;
        }
        private void imgB_Click(object sender, EventArgs e)
        {
            checkB = true;
            imgB.Image = Image.FromFile("appFiles\\B_pressed.jpg");
            ansBlabel.BackColor = OrangeColor;
        }
        private void imgC_Click(object sender, EventArgs e)
        {
            checkC = true;
            imgC.Image = Image.FromFile("appFiles\\C_pressed.jpg");
            ansClabel.BackColor = OrangeColor;
        }


        private void delanswerButton_Click(object sender, EventArgs e)
        {
            checkA = checkB = checkC = false;
            imgA.Image = Image.FromFile("appFiles\\A_released.jpg");
            imgB.Image = Image.FromFile("appFiles\\B_released.jpg");
            imgC.Image = Image.FromFile("appFiles\\C_released.jpg");
            ansAlabel.BackColor = ansBlabel.BackColor = ansClabel.BackColor = Color.Transparent;
        }
        private void anslaterButton_Click(object sender, EventArgs e)
        {
            checkA = checkB = checkC = false;
            imgA.Image = Image.FromFile("appFiles\\A_released.jpg");
            imgB.Image = Image.FromFile("appFiles\\B_released.jpg");
            imgC.Image = Image.FromFile("appFiles\\C_released.jpg");
            ansAlabel.BackColor = ansBlabel.BackColor = ansClabel.BackColor = Color.Transparent;
            Q.Enqueue(now);
            ShowNextQuestion();
        }
        private void sendanswerButton_Click(object sender, EventArgs e)
        {
            if (checkA || checkB || checkC)
            {
                string ansnow = "";
                if (checkA) ansnow += "A";
                if (checkB) ansnow += "B";
                if (checkC) ansnow += "C";
                --countremaining;
                if (ansnow == now.AnsCorrect)
                    ++countcorrect;
                else
                    ++countwrong;
                if (countwrong > maxWrongAllowed[letter])
                {
                    ShowResultForm("RESPINS.jpg");
                    this.Close();
                }
                else if (countremaining == 0 && countcorrect >= minCorrectNeeded[letter])
                {
                    ShowResultForm("ADMIS.jpg");
                    this.Close();
                }
                checkA = checkB = checkC = false;
                imgA.Image = Image.FromFile("appFiles\\A_released.jpg");
                imgB.Image = Image.FromFile("appFiles\\B_released.jpg");
                imgC.Image = Image.FromFile("appFiles\\C_released.jpg");
                ansAlabel.BackColor = ansBlabel.BackColor = ansClabel.BackColor = Color.Transparent;
                if (countremaining != 0)
                    ShowNextQuestion();
            }
        }

        private void ShowResultForm(string nameimg)
        {
            Form f = new Form();
            f.Size = new Size(512, 276);
            f.BackgroundImage = Image.FromFile("appFiles\\" + nameimg);
            f.BackgroundImageLayout = ImageLayout.Stretch;
            f.FormBorderStyle = FormBorderStyle.None;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowInTaskbar = false;
            f.Click += resultform_click;
            f.ShowDialog();
        }
        private void resultform_click(object sender, EventArgs e)
        {
            (sender as Form).Close();
            (sender as Form).Dispose();
        }

        private void photoimg_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.Size = new Size(800, 600);
            f.BackgroundImage = photoimg.BackgroundImage;
            f.BackgroundImageLayout = ImageLayout.Stretch;
            f.FormBorderStyle = FormBorderStyle.None;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowInTaskbar = false;
            f.Click += f_Click;
            f.ShowDialog();
        }
        private void f_Click(object sender, EventArgs e)
        {
            (sender as Form).Close();
            (sender as Form).Dispose();
        }

        private String TimeToString(int time)
        {
            string min = (time / 60).ToString(), sec = (time % 60).ToString();
            if (min.Length == 1)
                min = "0" + min;
            if (sec.Length == 1)
                sec = "0" + sec;
            return min + ":" + sec;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            --timeleft;
            if (timeleft == 0)
            {
                ShowResultForm("RESPINS.jpg");
                this.Close();
            }
            if (timeleft < 0)
                timeleft = 0;
            timelabel.Text = TimeToString(timeleft);
        }

        private void iesireAplicatieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeApp = true;
            this.Close();
        }

        private void inchidereChestionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChestionarWindow_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White, 10);
            Rectangle rectangle = new Rectangle(-5, 24, this.Size.Width - 1, this.Size.Height - 25);
            LinearGradientBrush LGB = new LinearGradientBrush
            (
                rectangle,
                Color.White,
                Color.Gray,
                LinearGradientMode.Vertical
            );
            e.Graphics.FillRectangle(LGB, rectangle);
            e.Graphics.DrawRectangle(pen, rectangle);
        }
        
    }
}
