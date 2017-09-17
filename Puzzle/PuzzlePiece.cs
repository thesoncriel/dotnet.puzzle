using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PuzzlePiece
{
    struct Position
    {
        public int x;
        public int y;
        public Position(int X, int Y)
        {
            this.x = X;
            this.y = Y;
        }
    }
    class Piece : System.Windows.Forms.PictureBox
    {
        private bool blank = false;
        public string tmp = "";

        public bool isBlank
        {
            get { return blank; }
            set{
                try{
                    blank = value;
                }
                catch{
                    MessageBox.Show("잘못된 인수를 bool형 blank에 집어 넣으려 했네?!", "디질랜드? ^-^)/", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /*
        public bool isPieceNum
        {
        	get { return pieceNum;}
        	set{
        		try{
        			pieceNum = value;
        		}
        		catch{
        			MessageBox.Show("잘못된 인수를 bool형 pieceNum에 집어 넣으려 하셨어요~!", "하악하악~!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        		}
        	}
        }
        */

        public void moveUp()
        {
            this.Top -= this.Height;
        }
        public void moveDown()
        {
            this.Top += this.Height;
        }
        public void moveLeft()
        {
            this.Left -= this.Width;
        }
        public void moveRight()
        {
            this.Left += this.Width;
        }
    }
}