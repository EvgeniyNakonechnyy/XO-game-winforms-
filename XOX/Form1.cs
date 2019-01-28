using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOX
{
    public partial class Form1 : Form
    {
        Logic logic = new Logic();

        public Form1()
        {
            InitializeComponent();
            start_game();
        }

        private void start_game()
        {
            logic.Init();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menu_game_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menu_game_start_Click(object sender, EventArgs e)
        {
            start_game();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            make_move((PictureBox)sender);
        }

        private void make_move(PictureBox box)
        {
            int x, y;
            string tag = box.Tag.ToString();

            x = int.Parse(tag.Substring(0, 1));
            y = int.Parse(tag.Substring(1, 1));
            int side = logic.side;

            if (logic.Place(x, y))
            {
                box.Image = (side == 1) ? Properties.Resources.x : Properties.Resources.o;

                if (logic.finish != "play")
                    game_over();
            }
        }

        private void game_over()
        {
            switch(logic.finish)
            {
                case "winx": MessageBox.Show("Крестики победили!", "Конец игры"); return;
                case "wino": MessageBox.Show("Победили Нолики!", "Конец игры"); return;
                case "draw": MessageBox.Show("Ничья!", "Конец игры"); return;
                default: return;
            }
        }
    }
}
