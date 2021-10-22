using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessApp
{
    class Piece
    {
        public string Type { get; set; }
        public string Owner { get; set; }
        public bool Is_white { get; set; }
        public bool Disabled { get; set; }
        public PictureBox Box { get; set; }
        public Piece( bool Is_white, PictureBox Box)
        {
           
            this.Is_white = Is_white;
            Disabled = true;
            this.Box = Box;
        }
      
    }
}
