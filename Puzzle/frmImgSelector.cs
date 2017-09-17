using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using PuzzleBoard;
using WaitingProgress;
using ImageConverter;
using PuzzlePiece;

namespace PuzzleMain
{

    public partial class frmImgSelector : Form
    {
        private const int maxPuzzleImage = 20;
        private PuzzleImage[] puzzleImage = new PuzzleImage[maxPuzzleImage];
        private BoardOption boardOption;

        private int indexNum = 0;
        //private bool userImage = false;

        public frmImgSelector()
        {
            InitializeComponent();
        }

        public BoardOption Option
        {
            get
            {
                return boardOption;
            }
            set
            {
                try
                {
                    boardOption = value;
                }
                catch
                {
                    MessageBox.Show("잘못된 인수를 BoardOption에 대입하려 하였습니다", "뭥미 에러 났어 -ㅁ-;;", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmImgSelector_Load(object sender, EventArgs e)
        {
            cmbCategory_init();
            initUIdata();
        }
        private void initUIdata()
        {
            int len = 0;
            TypeChanger tc = new TypeChanger();
            DrawNumType dnType = DrawNumType.Alphabet;

            len = tc.tcColor.Length;
            for (int i = 0; i < len; i++)
            {
                this.cmbColor.Items.Add(tc.tcColor[i]);
            }
            this.cmbColor.Text = tc.ColorChange(this.Option.fontColor);

            len = tc.DrawNumTypeLength;
            for (int j = 0; j < len; j++)
            {
                this.cmbType.Items.Add((dnType + j).ToString());
            }
            this.cmbType.Text = this.Option.drawNumType.ToString();

            picPreview.Image = this.Option.puzzleImage.image;
            txtDesc_Draw(Option.puzzleImage.name, Option.puzzleImage.boardType, Option.puzzleImage.desc);
            chkNumEnable.Checked = Option.drawNum;
            chkNumEnable_Check();
            cmbType.SelectedIndex = (int)Option.drawNumType;
            cmbColor.Text = tc.ColorChange(Option.fontColor);
            
            chkImageHint.Checked = Option.previewHint;
            chkTypeIgnore_Change();
            
        }
        private void cmbCategory_init()
        {
            bool userYes = (Option.puzzleImage.file.Substring(4, 4) == "user") ? true : false;
            cmbCategory.SelectedIndex = (userYes) ? 1 : 0;
        }
        private int cmbCategory_Change()
        {
            try
            {
                panel_ImgSelector.Controls.Clear();
            }
            catch { }

            return (cmbCategory.SelectedIndex == 0)? 1 : 0;
        }
        private void chkTypeIgnore_Change()
        {
        	if(Option.puzzleImage.boardType == BoardType.TypeAny) 
            {
            	chkTypeIgnore.Checked = true;
            	chkTypeIgnore.Enabled = false;
            }
			else
			{
				chkTypeIgnore.Checked = Option.ignoreBoardType;
				chkTypeIgnore.Enabled = true;
			}
        }
        private void initImgPanel(int selectedIndex)
        {
            string sDir = (selectedIndex == 0)? "Default" : "user";
            frmWaiting Wait = new frmWaiting();
            //string cDir = Environment.CurrentDirectory;
            string[] Files = Directory.GetFiles(@"img\" + sDir, "*.jpg", SearchOption.TopDirectoryOnly);
            int len = Files.Length;
            Panel[] ImgPanel = new Panel[len];
            PictureBox[] ImgPreview = new PictureBox[len];
            StreamReader sr = null;
            string str = "";
            string[] tmp = new string[3];
            int num = 0;
            TypeChanger tc = new TypeChanger();

            Wait.Show();
            //MessageBox.Show(sDir);
            if (sDir == "Default")
            {
                sr = new StreamReader(@"img\Default\Desc.txt", Encoding.UTF8);
                while (true)
                {
                    num++;
                    str += sr.ReadLine() + "\t";
                    if (sr.EndOfStream) break;
                }
                sr.Close();

                Wait.Progress(10);

                tmp = str.Split('\t');

                for (int i = 0; i < num; i++)
                {
                    puzzleImage[i].boardType = tc.ExtractToBoardType(tmp[0 + 3 * i]);
                    puzzleImage[i].image = Image.FromFile(Files[i]);
                    puzzleImage[i].name = tmp[1 + 3 * i];
                    puzzleImage[i].desc = tmp[2 + 3 * i];
                    puzzleImage[i].file = @"img\Default\" + tmp[0 + 3 * i];
                }
            }
            else
            {
                string rootDir = Environment.CurrentDirectory + @"\img\user\";
                len = rootDir.Length;
                num = Files.Length;
                for (int i = 0; i < num; i++)
                {
                    string[] tmpName = Files[i].Split('\\');
                    puzzleImage[i].boardType = BoardType.TypeAny;
                    puzzleImage[i].image = Image.FromFile(Files[i]);
                    puzzleImage[i].name = tmpName[tmpName.Length - 1];
                    puzzleImage[i].desc = "사용자 정의";
                    puzzleImage[i].file = @"img\user\" + puzzleImage[i].name;
                }
            }
            Wait.Progress(20);


            len = Files.Length;
            for (int i = 0; i < len; i++)
            {
                ImgPanel[i] = new Panel();
                ImgPreview[i] = new PictureBox();
                ImgPreview[i].Image = puzzleImage[i].image;
                ImgPreview[i].Location = new System.Drawing.Point(3, 3);
                ImgPreview[i].Name = "ImgPreview" + i;
                ImgPreview[i].Size = new System.Drawing.Size(64, 64);
                ImgPreview[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                ImgPreview[i].TabIndex = 0;
                ImgPreview[i].TabStop = false;
                ImgPanel[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                ImgPanel[i].Location = new System.Drawing.Point(3, 3 + 70 * i);
                ImgPanel[i].Name = "imgPanel" + i;
                ImgPanel[i].Size = new System.Drawing.Size(230, 70);
                ImgPanel[i].TabIndex = 2 + i;
                ImgPanel[i].Paint += new PaintEventHandler(ImgPanel_Paint);
                ImgPanel[i].MouseMove += new MouseEventHandler(ImgPanel_MouseMove);
                ImgPanel[i].MouseLeave += new EventHandler(ImgPanel_MouseLeave);
                ImgPanel[i].Click += new EventHandler(ImgPanel_Click);
                ImgPanel[i].Controls.Add(ImgPreview[i]);
                panel_ImgSelector.Controls.Add(ImgPanel[i]);
                Wait.Progress(20 + i);
            }
            Wait.Progress(100);
            Wait.Close();
        }
        /// <summary>
        /// 이미지 선택창에서 사용자가 선택 및 옵션 결정을 하고 누르는 확인 버튼의 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComplete_Click(object sender, EventArgs e)
        {
            frmWaiting Wait = new frmWaiting();
            Wait.Progress(5);
            Wait.Show();
            TypeChanger tc = new TypeChanger();
            BoardType boardType = this.Option.puzzleImage.boardType;
            int pieceNum = 0;
            int len = tc.BoardTypeLength + 2;
            
            if (boardType == BoardType.TypeAny || boardOption.ignoreBoardType)
            {
                for (int i = 3; i < len; i++)
                {
                    ImgCrop(i, 600 / i);
                    Wait.Progress(i*10);
                }
                boardOption.puzzleImage.boardType = BoardType.Type5x5;
            }
            else
            {
                pieceNum = (int)boardType + 2;
                ImgCrop(pieceNum, 600 / pieceNum);
                Wait.Progress(80);
            }
            Wait.Progress(100);
            btnComplete.DialogResult = DialogResult.OK;
            this.Close();
            Wait.Close();
        }
        public DialogResult btnComplete_DialogResult
        {
            get
            {
                return btnComplete.DialogResult;
            }
        }
        private void ImgCrop(int pieceNum, int pieceWidth)
        {
            ImageConverter.ImageConverter ImgConv = new ImageConverter.ImageConverter();
            int n = 0;
            string subDir = "";
            pieceWidth = (int)(600 / pieceNum);
            n = 0;

            subDir = "img/Type" + pieceNum + "x" + pieceNum + "/";
            for (int i = 0; i < pieceNum; i++)
            {
                for (int j = 0; j < pieceNum; j++)
                {
                    n++;
                    ImgConv.Save(ImgConv.CropImage(this.Option.puzzleImage.image, j * pieceWidth, i * pieceWidth, pieceWidth, pieceWidth), subDir + n + ".png");
                }
            }
        }

        private void ImgPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            int imageCount = Convert.ToInt32(panel.Name.Substring(8,panel.Name.Length-8));
            TypeChanger btChanger = new TypeChanger();
            Font font = new Font("Gulim", 10);
            string str = "::: " + puzzleImage[imageCount].name + " :::\n[ " + btChanger.BoardTypeToDesc(puzzleImage[imageCount].boardType) + " ]\n" + puzzleImage[imageCount].desc;
            Rectangle rec = new Rectangle(new Point(80, 7), new Size(155, 64));
            e.Graphics.DrawString(str, font, Brushes.Black, rec);
        }
        private void ImgPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }
        private void ImgPanel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = System.Drawing.SystemColors.Control;
        }
        private void ImgPanel_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            this.indexNum = Convert.ToInt32(panel.Name.Substring(8, panel.Name.Length - 8));
            this.picPreview.Image = this.puzzleImage[indexNum].image;
            txtDesc_Draw(puzzleImage[indexNum].name, puzzleImage[indexNum].boardType, puzzleImage[indexNum].desc);

            this.boardOption.puzzleImage = puzzleImage[indexNum];
            chkTypeIgnore_Change();
        }
        private void txtDesc_Draw(string name, BoardType boardType, string desc)
        {
            TypeChanger btc = new TypeChanger();
            this.txtDesc.Text = ":::" + name + ":::\r\n[ " + btc.BoardTypeToDesc(boardType) + " ]\r\n" + desc;
        }

        private void ChkNumEnable_CheckedChanged(object sender, EventArgs e)
        {
            this.chkNumEnable_Check();
        }
        private void chkNumEnable_Check()
        {
            if (!this.chkNumEnable.Checked)
            {
                cmbType.Enabled = false;
                cmbColor.Enabled = false;
                this.boardOption.drawNum = false;
            }
            else
            {
                cmbType.Enabled = true;
                cmbColor.Enabled = true;
                this.boardOption.drawNum = true;
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.boardOption.drawNumType = (DrawNumType)cmbType.SelectedIndex;
        }
        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeChanger tc = new TypeChanger();
            this.boardOption.fontColor = tc.tcColor[cmbColor.SelectedIndex];
        }
        private void chkImageHint_CheckedChanged(object sender, EventArgs e)
        {
            this.boardOption.previewHint = chkImageHint.Checked;
        }
        private void chkTypeIgnore_CheckedChanged(object sender, EventArgs e)
        {
            this.boardOption.ignoreBoardType = chkTypeIgnore.Checked;
        }

        private void btnFileSearch_Click(object sender, EventArgs e)
        {
            ImageConverter.ImageConverter ImgConv = new ImageConverter.ImageConverter();
            string subPath = Environment.CurrentDirectory;
            openFileDialog.ShowDialog();
            FileStream fs = null;
            int num = openFileDialog.FileNames.Length;
            string[] path = openFileDialog.FileNames;
            string fileName = "";

            try
            {
                for (int i = 0; i < num; i++)
                {
                    string[] tmp = path[i].Split('\\');
                    fs = new FileStream(path[i], FileMode.Open);
                    fileName = tmp[tmp.Length - 1];
                    ImgConv.Save(ImgConv.ResizeImage(Image.FromStream(fs), 600, 600), subPath + @"\img\user\" + fileName);
                    fs.Close();
                }
                Environment.CurrentDirectory = subPath;

                boardOption.puzzleImage.boardType = BoardType.TypeAny;
                boardOption.puzzleImage.desc = "사용자 정의";
                boardOption.puzzleImage.name = fileName;
                boardOption.puzzleImage.file = @"img\user\" + fileName;
                boardOption.puzzleImage.image = Image.FromFile(boardOption.puzzleImage.file);
                chkTypeIgnore.Enabled = false;
                cmbCategory_Change();
                initImgPanel(1);
            }
            catch { return; }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCategory_Change();
            initImgPanel(cmbCategory.SelectedIndex);
        }
    }
}
