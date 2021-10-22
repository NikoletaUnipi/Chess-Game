using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessApp
{
    public partial class Form1 : Form
    {
        Point p;
        Player player1 = new Player(false, "white", 60 * 5);
        Player player2 = new Player(false, "black", 60 * 5);
        bool endgame = false;
        List<Piece> pieces = new List<Piece>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            List<PictureBox> pictures = GetPictureBoxes();
            foreach (PictureBox p in pictures) {

                Piece piece = new Piece(isWhite(p),p); //is_white, type,PictureBox
                piece.Box.Click += pictureBox2_Click;
                piece.Box.MouseMove += onMouseMove;
                piece.Box.MouseUp += onMouseUp;
                piece.Box.MouseDown += onMouseDown;
                pieces.Add(piece);
            }
        }
        private List<PictureBox> GetPictureBoxes()
        {
            List<PictureBox> pictureBoxes = new List<PictureBox>();

            foreach (Control c in this.Controls)
            {

                if (c as PictureBox != null)
                {
                    if ((c as PictureBox).Name != "pictureBox1")//αν το pictureBox δεν είναι αυτό με την σκακιέρα
                    {
                        pictureBoxes.Add(c as PictureBox);

                    }   
                }
            }

            return pictureBoxes;
        }
        bool isWhite(PictureBox pictureBox) {
            bool isWhite = true;
            if (pictureBox.Location.Y<200)
            {
                isWhite = false;
            }
            return isWhite;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            foreach(Piece piece in pieces)
            {
                if (piece.Box == (PictureBox)sender)
                {
                    
                    
                        if (piece.Is_white)
                        {
                            player2.IsPlaying = false;
                            player1.IsPlaying = true;
                           
                        }
                        else
                        {
                            player2.IsPlaying = true;
                            player1.IsPlaying = false;
                           
                        }
                    
                }
            }
        }

        private void onMouseDown(object sender, MouseEventArgs e)
        {
            if (!endgame) { foreach (Piece piece in pieces)
                {
                    if (piece.Box == (PictureBox)sender)
                    {

                        piece.Disabled = false;
                    }
                } 
            }
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            foreach (Piece piece in pieces)
            {
                if (piece.Box == (PictureBox)sender)
                {
                    if (!piece.Disabled)
                    {
                       ((PictureBox)sender).Left += e.X - p.X;
                       ((PictureBox)sender).Top += e.Y - p.Y;


                    }
                }
            }
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            foreach (Piece piece in pieces)
            {
                if (piece.Box == (PictureBox)sender)
                {
                    piece.Disabled = true;
                }
            }
        }

        private void onTick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString();
            if (player2.SecindsLeft > 0 && player2.SecindsLeft > 0)
            {
                if (player1.IsPlaying)
                {
                    label3.Text = player1.SecindsLeft.ToString();
                    player1.SecindsLeft--;
                }
                else if (player2.IsPlaying)
                {
                    label4.Text = player2.SecindsLeft.ToString();
                    player2.SecindsLeft--;
                }
            }
            else {
                MessageBox.Show("End Game");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            endgame = true;
            DatabaseConnection databaseConnection = new DatabaseConnection();
            databaseConnection.saveToDatabase(player1.Name,player2.Name, DateTime.Now.ToString());
        }
    }
}
