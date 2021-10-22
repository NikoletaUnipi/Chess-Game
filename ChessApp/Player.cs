using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp
{


    class Player
    {
        private bool isPlaying;
        private string name;
        private int secindsLeft;
        public Player(bool isPlaying, string name, int secindsLeft) {
            this.isPlaying = isPlaying;
            this.name = name;
            this.secindsLeft = secindsLeft;
        }

        public bool IsPlaying{
            get { return isPlaying; }
            set { isPlaying = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int SecindsLeft

        {
            get { return secindsLeft; }
            set { secindsLeft = value; }
        }
       
    }
}
