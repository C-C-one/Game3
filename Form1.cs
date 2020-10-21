using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public int[,] gg = new int[3,3]; //1 = o, 2 = x
        public PictureBox[,] pb = new PictureBox[3, 3];
        public bool game = true;
        public int step = 0;
        public int tmr = 0;
        public int player = 1; //0 = 0, 1 = x
        public Form1()
        {
            InitializeComponent();
            pb[0, 0] = picr1c1;
            pb[0, 1] = picr1c2;
            pb[0, 2] = picr1c3;
            pb[1, 0] = picr2c1;
            pb[1, 1] = picr2c2;
            pb[1, 2] = picr2c3;
            pb[2, 0] = picr3c1;
            pb[2, 1] = picr3c2;
            pb[2, 2] = picr3c3;
            pgbx.Value = 99;
            lbl1.Text = "";
        }

        private bool tl_to_br()
        {
            if (gg[0, 0] == gg[1, 1] && gg[1, 1] == gg[2, 2])
            {
                return true;
            }
            return false;
        }

        private bool bl_to_tr()
        {
            if (gg[0, 2] == gg[1, 1] && gg[1, 1] == gg[2, 0])
            {
                return true;
            }
            return false;
        }

        private bool win(int r, int c)
        {
            
                if (gg[r, 0] == gg[r, 1] && gg[r, 1] == gg[r, 2])
                {
                    return true;
                }
                if (gg[0, c] == gg[1, c] && gg[1, c] == gg[2, c])
                {
                    return true;
                }
                r++;
                c++;
                if (r % 2 != 0 && c % 2 != 0)
                {
                    if (r == 1)
                    {
                        if (c == 1)
                        {
                            if (tl_to_br())
                            {
                                return true;
                            }
                        }
                        if (c == 3)
                        {
                            if (bl_to_tr())
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (c == 1)
                        {
                            if (bl_to_tr())
                            {
                                return true;
                            }
                        }
                        if (c == 3)
                        {
                            if (tl_to_br())
                            {
                                return true;
                            }
                        }
                    }
                }
                else if (r == 2 && c == 2)
                {
                    return (tl_to_br() || bl_to_tr());
                }
            return false;
        }

        private void apply(int r, int c)
        {
            if (game)
            {
                if (gg[r, c] == 0)
                {
                    if (player == 0)
                    {
                        player = 1;
                        pb[r, c].Image = Properties.Resources.o_cb;
                        gg[r, c] = 1;
                        pgbx.Value = 99;
                        pgbo.Value = 0;
                    }
                    else
                    {
                        player = 0;
                        pb[r, c].Image = Properties.Resources.x_cb;
                        gg[r, c] = 2;
                        pgbx.Value = 0;
                        pgbo.Value = 99;
                    }
                    step++;
                    if (step == 9)
                    {
                        lbl1.Text = "Congratulations... Nobody won!";
                    }
                    if (win(r, c))
                    {
                        if (player == 0)
                        {
                            lbl1.Text = "player \"X\" is victorious!!!";
                            game = false;
                        }
                        else
                        {
                            lbl1.Text = "player \"O\" is victorious!!!";
                            game = false;
                        }
                    }
                }
            }
        }

        private void reset()
        {
            for(int i = 0; i < 3; i++)
            {
                for (int y = 0; y < 3; y++)
                {
                    gg[i, y] = 0;
                    pb[i, y].Image = null;
                }
            }
            pgbx.Value = 99;
            pgbo.Value = 0;
            lbl1.Text = "";
            game = true;
            player = 1;
            step = 0;
        }
        private void picr1c1_Click(object sender, EventArgs e)
        {
            apply(0, 0);
        }

        private void picr1c2_Click(object sender, EventArgs e)
        {
            apply(0, 1);
        }

        private void picr1c3_Click(object sender, EventArgs e)
        {
            apply(0, 2);
        }

        private void picr2c1_Click(object sender, EventArgs e)
        {
            apply(1, 0);
        }

        private void picr2c2_Click(object sender, EventArgs e)
        {
            apply(1, 1);
        }

        private void picr2c3_Click(object sender, EventArgs e)
        {
            apply(1, 2);
        }

        private void picr3c1_Click(object sender, EventArgs e)
        {
            apply(2, 0);
        }

        private void picr3c2_Click(object sender, EventArgs e)
        {
            apply(2, 1);
        }

        private void picr3c3_Click(object sender, EventArgs e)
        {
            apply(2, 2);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            reset();
            picbg.Visible = true;
            button1.Visible = true;
            lblname.Visible = true;
            txtttt.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picbg.Visible = false;
            button1.Visible = false;
            lblname.Visible = false;
            txtttt.Visible = false;
            pictran.Visible = true;
            tmr1.Start();
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            if(tmr == 1)
            {
                tmr++;
            }
            else
            {
                tmr = 1;
                pictran.Visible = false;
                tmr1.Stop();
            }
        }
    }
}
