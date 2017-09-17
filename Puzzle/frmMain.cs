using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PuzzlePiece;
using PuzzleBoard;

namespace PuzzleMain
{
    public partial class frmMain : Form
    {
        private Board gameBoard;
        ToolStripMenuItem[] strp = new ToolStripMenuItem[10];
        
        public frmMain()
        {
            InitializeComponent();
        }

        public void frmMain_Load(object sender, EventArgs e)
        {
        	gameBoard = new Board();

            NewGame();
            addDropDownItem_BoardType();

            this.strpNum.Checked = gameBoard.Option.drawNum;
            if (gameBoard.Option.previewHint) picPreview.Image = gameBoard.Option.puzzleImage.image;

        }
        private void addDropDownItem_BoardType()
        {
            int num = gameBoard.BoardTypeLength - 1;

            for (var i = 0; i < num; i++)
            {
                this.strp[i] = new ToolStripMenuItem();
                this.strp[i].Name = "strpBoard" + ((BoardType)(i + 1)).ToString();
                this.strp[i].Size = new System.Drawing.Size(152, 22);
                this.strp[i].Text = (i + 3) + " x " + (i + 3);
                this.strp[i].Click += new System.EventHandler(this.strpBoardType_Click);
                this.strpBoardType.DropDownItems.Add(this.strp[i]);
            }
            strpBoardType_Change();
        }
        public void setBoard(BoardOption option)
        {
            gameBoard.Option = option;
        }

        private void strpMix_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem strp = (ToolStripMenuItem)sender;
            switch (strp.Name)
            {
                case "strpMix_sub100":
                    gameBoard.PuzzleMix(100);
                    break;
                case "strpMix_sub200":
                    gameBoard.PuzzleMix(200);
                    break;
                case "strpMix_sub300":
                    gameBoard.PuzzleMix(300);
                    break;
                case "strpMix_sub400":
                    gameBoard.PuzzleMix(400);
                    break;
                case "strpMix_sub500":
                    gameBoard.PuzzleMix(500);
                    break;
                default:
                    gameBoard.PuzzleMix(4444);
                    break;
            }
        }
        private void strpBoardType_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem strp = (ToolStripMenuItem)sender;
            if (strp.Checked) return;
            try
            {
                gameBoard.RemovePiece(this.Controls);
            }
            catch { }
            
            BoardOption option = gameBoard.Option;
            gameBoard = new Board(option);
			string str = strp.Name;
			str = str.Substring(13, (str.Length == 16) ? 1 : 2);
			int num = Convert.ToInt32(str);
			gameBoard.Type = (BoardType)(num-2);
			
			strpBoardType_Change();
            this.strpNew_Click(sender, e);
        }
        private void strpBoardType_Change()
        {
        	bool ignoreBoardType = false;
        	if((gameBoard.Option.puzzleImage.boardType == BoardType.TypeAny) || gameBoard.Option.ignoreBoardType)
        	{
        		ignoreBoardType = true;
        	}
        	else
        	{
        		ignoreBoardType = false;
        	}
        	
        	for(int i = 0; i < gameBoard.BoardTypeLength-1; i++)
			{
	            this.strp[i].Checked = false;
	            this.strp[i].Enabled = ignoreBoardType;
			}
            this.strp[(int)(gameBoard.Type-1)].Checked = true;
            this.strp[(int)(gameBoard.Type-1)].Enabled = true;
        }

        private void strpNew_Click(object sender, EventArgs e)
        {
        	NewGame();
        }
        private void NewGame()
        {
        	try
            {
                gameBoard.RemovePiece(this.Controls);
            }
            catch { }
            Control[] controls = gameBoard.MakePiece(gameBoard.Type);
            if (controls == null)
            {
                this.Close();
                return;
            }
            foreach (Control cc in controls)
            {
                this.Controls.Add(cc);
            }
            gameBoard.initScore();
            //gameBoard.setScore();
        }

        

        private void ImgSelectorOpen_Click(object sender, EventArgs e)
        {
            frmImgSelector form = new frmImgSelector();
            //gameBoard.RemovePiece(this.Controls);
            //gameBoard = new Board();
            form.Show();
        }

        private void strpEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("헐.. 니 진짜 끝낼거임? -ㅂ-;;", "아항~ 지겨웠군화 - _-)a", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void strpNum_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("가지고 놀던 퍼즐이 초기화 됩니다.\n계속 하시겠습니깡? 'ㅁ')/", "그렇다는 겨~~", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            ToolStripMenuItem strp = (ToolStripMenuItem)sender;
            if (strp.Checked)
            {
                strp.Checked = false;
                gameBoard.DrawNumEnable = false;
                this.strpNew_Click(sender, e);
            }
            else
            {
                strp.Checked = true;
                gameBoard.DrawNumEnable = true;
                this.strpNew_Click(sender, e);
            }
        }

        private void strpSave_Click(object sender, EventArgs e)
        {
            gameBoard.OptionSaver(gameBoard.Option);
        }

        private void strpImgSelector_Click(object sender, EventArgs e)
        {
            frmImgSelector form = new frmImgSelector();
            form.Option = gameBoard.Option;
            form.ShowDialog();
            if (form.btnComplete_DialogResult == DialogResult.Cancel) return;
            
            gameBoard.Option = form.Option;

            NewGame();
            strpBoardType_Change();
            
            if(gameBoard.Option.previewHint)
            	this.picPreview.Image = gameBoard.Option.puzzleImage.image;
            else
            	this.picPreview.Image = Image.FromFile("img/noimage.png");
            
            strpNum.Checked = gameBoard.Option.drawNum;

            gameBoard.OptionSaver(gameBoard.Option);
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            MessageBox.Show(gameBoard.Score + "");
        }
    }
}