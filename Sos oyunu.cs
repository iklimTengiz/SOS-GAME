using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sos_oyunu
{
    public partial class Sos : Form
    {
        bool turn = true; //true = x turn; false = Y turn
        int turn_count = 0;


        public Sos()
        {
            InitializeComponent();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("S-O-S harflerini yan yana getirerek SOS yaparak oyunu kazanın. ", "Hakkında");
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "S";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            Kazanankontrol();


        }

        private void Kazanankontrol()

        {
            bool Kazanan = false;

            // Yatay kontrol
            if ((A1.Text != A2.Text ) && (A2.Text != A3.Text)&&(!A1.Enabled) && (!A2.Enabled) && (!A3.Enabled))
            { Kazanan = true; }
            else if ((B1.Text != B2.Text) && (B2.Text != B3.Text) && (!B1.Enabled) && (!B2.Enabled) && (!B3.Enabled))
            { Kazanan = true; }
            else if ((C1.Text != C2.Text) && (C2.Text != C3.Text)  && (!C1.Enabled) && (!C2.Enabled) && (!C3.Enabled))
            { Kazanan = true; }


            // Dikey kontrol
            else if ((A1.Text != B1.Text) && (B1.Text != C1.Text) && (!A1.Enabled) && (!B1.Enabled) && (!C1.Enabled))
            { Kazanan = true; }
            else if ((A2.Text != B2.Text) && (B2.Text != C2.Text) && (!A2.Enabled) && (!B2.Enabled) && (!C2.Enabled))
            { Kazanan = true; }
            else if ((A3.Text != B3.Text) && (B3.Text != C3.Text) && (!A3.Enabled) && (!B3.Enabled) && (!C3.Enabled))
            { Kazanan = true; }

            // Çapraz kontrol
            else if ((A1.Text != B2.Text) && (B2.Text != C3.Text) && (!A1.Enabled) && (!B2.Enabled) && (!C3.Enabled))
            { Kazanan = true; }
            else if ((A3.Text != B2.Text) && (B2.Text != C1.Text) && (!A3.Enabled) && (!B2.Enabled) && (!C1.Enabled))
            { Kazanan = true; }
          




            if (Kazanan)
                {
                disablebutton();
                    String Winner = "";
                    if (turn)
                        Winner = "O";
                    else
                        Winner = "S";
                    MessageBox.Show(Winner + "  Kazandı !", "Kazanan");

                }//if bitiş
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("   Kaybettinz!", "Kazanan");
            }
            }//Kazanan

        private void disablebutton()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;

                }
            }

            catch { }
        }

        private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }

            catch { }
        }
    } 
}

