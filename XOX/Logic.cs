using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX
{
    class Logic
    {
        int[,] map = new int[3, 3]; // 0 - пустая, 1 - крестик, 2 - нолик
        public int side { get; private set; } // 1 - крестик, 2 - нолик
        bool play;
        int step;
        public string finish { get; private set; }


        public Logic()
        {
            Init();
        }

        public void Init()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    map[i, j] = 0;
            side = 1;
            play = true;
            step = 0;
        }

        public bool Place(int x, int y)
        {
            if (!play) return false;

            if (x < 0 || x > 2) return false;
            if (y < 0 || y > 2) return false;

            if (map[x, y] > 0) return false;

            map[x, y] = side;
            
            step++;
            finish = Finish(x, y);

            if (side == 1)
                side = 2;
            else
                side = 1;

            return true;
        }

        private string Finish(int x, int y)
        {
            bool win = false;

            if (map[x, 0] == side && map[x, 1] == side && map[x, 2] == side)
                win = true;
            if (map[0, y] == side && map[1, y] == side && map[2, y] == side)
                win = true;
            if (map[0, 0] == side && map[1, 1] == side && map[2, 2] == side)
                win = true;
            if (map[2, 0] == side && map[1, 1] == side && map[0, 2] == side)
                win = true;

            if (win)
            {
                if (side == 1)
                {
                    play = false;
                    return "winx";
                }
                else
                {
                    play = false;
                    return "wino";
                }
            }
            else
            {
                if (step == 9)
                {
                    play = false;
                    return "draw";
                }
                else
                    return "play";
            }
        }
    }
}
