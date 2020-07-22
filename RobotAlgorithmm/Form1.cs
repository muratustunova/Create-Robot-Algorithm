using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false; // Form uygulamasının boyutunu kilitleyerek istediğim boyutta kalmasını sağladım

        }
        private void button1_Click(object sender, EventArgs e)
        {

            #region Hesaplama işlemleri
            int head, body, arm, leg, saglamRobot = 0, kuvvetsizRobot = 0, artanparca;
            int toplamparça;

            head = Convert.ToInt32(textBox1.Text);
            body = Convert.ToInt32(textBox2.Text);
            arm = Convert.ToInt32(textBox3.Text);
            leg = Convert.ToInt32(textBox4.Text);

            toplamparça = head + body + arm + leg;

            int kalanoncelik;
            int oncelikHB = head < body ? head : body; //oncelikHB =30;
                                                       // int UnOncelikHB = head < body ? body : head;
            for (int i = 0; i < oncelikHB; i++) //Sağlam Robot Sayısını belirleyen dögü
            {
                if (head <= 0 || body <= 0 || arm < 2 || leg < 2)
                { break; }
                else
                {
                    head -= 1; body -= 1; arm -= 2; leg -= 2;
                    saglamRobot += 1;
                }
            }
            oncelikHB = oncelikHB - saglamRobot;
            kalanoncelik = oncelikHB;
            int oncelikAL = arm < leg ? leg : arm; //oncelikAL=20;

            // int UnOncelik = arm < leg ? arm : leg;
            for (int i = 0; i < kalanoncelik;) //Kuvvetsiz Robot Sayısını belirleyen döngü
            {
                if (oncelikAL < 4)
                {
                    break;
                }
                else
                {
                    head -= 1; body -= 1; kuvvetsizRobot += 1; oncelikAL -= 4;
                }
                i++;
            }
            artanparca = toplamparça - (saglamRobot * 6 + kuvvetsizRobot * 6);

            textBox6.Text = "" + saglamRobot;
            textBox7.Text = "" + kuvvetsizRobot;
            textBox5.Text = "" + artanparca;
            #endregion
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            #region Başlangıç Mesajı
            MessageBox.Show("\t\t---Robot Oluşturma Parça Hesap Programı---\n\nBİLGİLENDİRME MESAJI:\nHer bir robot için bir kafa, bir gövde, iki adet kol ve iki adet\n" +
            "bacak parçası kullanılmaktadır. Bu robotlar 'Sağlam robot' olarak adlandırılır. Ancak kol veya bacak sayısı '0' olduğunda,\n" +
            "bacak yerine kol veya kol yerine bacak kullanabilebilen bir tesiste bu robotlara ise 'Kuvvetsiz robot' denilmektedir.\n\n\n" +
            "ÖRNEK:\n\nSAĞLAM ROBOT: 1 ADET KAFA, 1  ADET GÖVDE, 2 ADET KOL, 2 ADET BACAK" +
            "\n\nKUVVETSİZ ROBOT VARYASYON(1) : 1 ADET KAFA, 1 ADET GÖVDE , 4 ADET BACAK " +
            "\n\nKUVVETSİZ ROBOT VARYASYON(2) : 1 ADET KAFA, 1 ADET GÖVDE , 4 ADET KOL");


            button1.BackColor = Color.Red;
            button2.BackColor = Color.Red;
            #endregion
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.Gray;
        }
        #region TextBox'a sadece sayı girme kısmı
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.Gray;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        #endregion // sadece sayı girilebilecek.
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
        }

        #region Enter ile TexBox Atlama (Events)
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox2;
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox3;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox4;
            }
        }
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.ActiveControl = textBox1;
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = button1;
            }
        }
        #endregion 
    }
}
