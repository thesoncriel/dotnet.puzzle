using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using PuzzlePiece;
using WaitingProgress;

namespace PuzzleBoard
{
    public class Board : TypeChanger
    {
        private const int MaxWidth = 600;
        private const int marginTop = 36;
        private const int marginLeft = 12;
        private BoardOption boardOption;
        private int pieceNum;
        private int pieceSize;
        private int blankLocationX;
        private int blankLocationY;
        private Piece[,] piece = new Piece[10,10];
        private int score = 0;
        
		/// <summary>
		/// 생성자: 보드타입을 Type4x4를 기본으로 잡고 세팅합니다.
		/// </summary>
        public Board()
        {
            this.boardOption = initBoard();
            //this.Type = BoardType.Type4x4;
            this.setPieceWidth();
        }
        
        /// <summary>
        /// 생성자: 보드타입을 사용자가 정의하고 세팅합니다.
        /// </summary>
        /// <param name="type">BoardType 형태의 열거형</param>
        public Board(BoardType type)
        {
            this.boardOption = initBoard();
            this.boardOption.puzzleImage.boardType = type;
            this.setPieceWidth();
        }
        public Board(BoardOption option)
        {
            this.boardOption = option;
            this.setPieceWidth();
        }
        /// <summary>
        /// 현재 퍼즐 보드의 점수를 리턴 합니다.
        /// </summary>
        public int Score
        {
            get { return score; }
        }

        private BoardOption initBoard()
        {
            StreamReader sr = null;
            string tmp = "";
            BoardOption boardOption = new BoardOption();

            try
            {
                sr = new StreamReader("option.ini");
            }
            catch
            {
                OptionSaver();
                sr = new StreamReader("option.ini");
            }

            while(true)
            {
                tmp = sr.ReadLine();
                if (tmp.Length > 7)
                {
                    switch (tmp.Substring(3, 4))
                    {
                        //PuzzleImage//
                        case "name":
                            boardOption.puzzleImage.name = tmp.Substring(8, tmp.Length - 8);
                            break;
                        case "desc":
                            boardOption.puzzleImage.desc = tmp.Substring(8, tmp.Length - 8);
                            break;
                        case "Type":
                            boardOption.puzzleImage.boardType = this.ExtractToBoardType(tmp.Substring(8, tmp.Length - 8));
                            break;
                        case "file":
                            boardOption.puzzleImage.file = tmp.Substring(8, tmp.Length - 8);
                            break;
                        //BoardOption//
                        case "prev":
                            boardOption.previewHint = (tmp.Substring(8, tmp.Length - 8) == "True") ? true : false;
                            break;
                        case "draw":
                            boardOption.drawNum = (tmp.Substring(8, tmp.Length - 8) == "True") ? true : false;
                            break;
                        case "dTyp":
                            boardOption.drawNumType = this.DrawNumTypeChange(tmp.Substring(8, tmp.Length - 8));
                            break;
                        case "font":
                            boardOption.fontColor = this.ColorChange(tmp.Substring(8, tmp.Length - 8));
                            break;
                        case "igno":
                            boardOption.ignoreBoardType = (tmp.Substring(8, tmp.Length - 8) == "True") ? true : false;
                            break;
                    }
                }
                if (sr.EndOfStream) break;
            }
            sr.Close();
            boardOption.puzzleImage.image = Image.FromFile(boardOption.puzzleImage.file);

            return boardOption;
        }

        /// <summary>
        /// 현재 퍼즐 보드의 옵션을 저장합니다.
        /// </summary>
        public void OptionSaver()
        {
            option_ini_Creator("프로젝트 이미지", "한 껨 하셔야죠? ^-^)/", BoardType.TypeAny, @"img\Default\#ProjectTitle#.jpg", true, true, DrawNumType.Numeric, "Black", false);
        }
        /// <summary>
        /// 현재 퍼즐 보드의 옵션을 저장합니다.
        /// </summary>
        /// <param name="option">사용자 임의의 BoardOption 형태의 구조체</param>
        public void OptionSaver(BoardOption option)
        {
            option_ini_Creator( option.puzzleImage.name, option.puzzleImage.desc, option.puzzleImage.boardType,
                                option.puzzleImage.file, option.previewHint, option.drawNum,
                                option.drawNumType, this.ColorChange(option.fontColor), option.ignoreBoardType);
        }
        private void option_ini_Creator(string name, string desc, BoardType type,
                                        string file, bool prev, bool draw,
                                        DrawNumType dnTy, string font, bool ibTy)
        {
            StreamWriter sw = new StreamWriter("option.ini");
            string str ="//////////////////////////////////////////////////////////////////////////////////\r\n" +
                        "//                               오호라~! Puzzle -_-?                           //\r\n" +
                        "//                                    설정 파일                                 //\r\n" +
                        "//////////////////////////////////////////////////////////////////////////////////\r\n" +
                        "//                                                                              //\r\n" +
                        "//          :::: 경고 ::::                                                      //\r\n" +
                        "//   ※함부로 수정하면 에러날 가능성 99.999999.. (하악)% 씩이나 된답니다 ^-^)b  //\r\n" +
                        "//     잘 못 건드려서 맛이가면 새로 설치해 주시는 Sense~!!                      //\r\n" +
                        "//                                                                              //\r\n" +
                        "//////////////////////////////////////////////////////////////////////////////////\r\n" +
                        "//\r\n" +
                        "//\r\n" +
                        "PuzzleImage\r\n" +
                        "{\r\n" +
                        "   name=" + name + "\r\n" +
                        "   desc=" + desc + "\r\n" +
                        "   Type=" + type + "\r\n" +
                        "   file=" + file + "\r\n" +
                        "}\r\n" +
                        "BoardOption\r\n" +
                        "{\r\n" +
                        "   prev=" + prev + "\r\n" +
                        "   draw=" + draw + "\r\n" +
                        "   dTyp=" + dnTy + "\r\n" +
                        "   font=" + font + "\r\n" +
                        "   igno=" + ibTy + "\r\n" +
                        "}";
            sw.Write(str);
            sw.Close();
        }
        
        /// <summary>
        /// Board.Type : 보드에 설정된 보드타입을 설정하거나 내보냅니다.
        /// </summary>
        public BoardType Type
        {
            get { return this.boardOption.puzzleImage.boardType; }
            set
            {
                try
                {
                    this.boardOption.puzzleImage.boardType = value;
                }
                catch
                {
                    MessageBox.Show("잘못된 BoardType 인수를 지정하려 하였습니다.", "이보게~ 뭔가 잘못됐어 -.-;;", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public bool DrawNumEnable
        {
            get { return this.boardOption.drawNum; }
            set
            {
                try
                {
                    this.boardOption.drawNum = value;
                }
                catch
                {
                    MessageBox.Show("잘못된 bool형 인수를 지정하려 하였습니다.", "이보게~ 뭔가 잘못됐어 -.-;;", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public BoardOption Option
        {
            get { return this.boardOption; }
            set
            {
                try
                {
                    this.boardOption = value;
                }
                catch
                {
                    MessageBox.Show("잘못된 BoardOption 인수를 지정하려 하였당께!", "어이~ 또 잘못됐어 ㅡ.ㅡ;;");
                }
            }
        }
		
        /// <summary>
        /// 보드에 설정된 Board.Type 속성을 이용하여 퍼즐에 쓰일 조각의 개수와 최종 크기를 설정합니다.
        /// </summary>
        public void setPieceWidth()
        {
        	setPieceWidth_common();
        }
        /// <summary>
        /// 보드에 설정된 Board.Type 속성을 이용하여 퍼즐에 쓰일 조각의 개수와 최종 크기를 설정합니다.
        /// </summary>
        /// <param name="type">BoardType 형태의 열거형. 사용자가 직접 보드 타입을 설정 합니다.</param>
        public void setPieceWidth(BoardType type)
        {
        	this.Type = type;
        	setPieceWidth_common();
        }
        private void setPieceWidth_common()
        {
            pieceNum = ((int)Type) + 2;
            pieceSize = (int)(MaxWidth / pieceNum);
        }

        public void DrawNum()
        {
            try
            {
                if (this.boardOption.drawNum)
                {
                    for (int i = 0; i < pieceNum; i++)
                    {
                        for (int j = 0; j < pieceNum; j++)
                        {
                            this.piece[i, j].Paint += new System.Windows.Forms.PaintEventHandler(this.Piece_DrawNumber);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < pieceNum; i++)
                    {
                        for (int j = 0; j < pieceNum; j++)
                        {
                            this.piece[i, j].Paint -= new System.Windows.Forms.PaintEventHandler(this.Piece_DrawNumber);
                        }
                    }
                }
            }
            catch { MessageBox.Show("뭔일임?"); }
        }
        
        /// <summary>
        /// 설정된 보드 속성들을 이용하여 퍼즐 조각들을 생성하고 그 조각들을 Control 배열로 반환합니다. 퍼즐 조각에 문자를 새기지 않습니다.
        /// </summary>
		/// <param name="type">BoardType 형식의 열거형</param>
        /// <returns>Control 배열</returns>
		public Control[] MakePiece(BoardType type)
        {
			int n = 0;
			FileStream fs = null;
			string path = "";

            if (type == BoardType.TypeAny) this.Type = BoardType.Type5x5;
			else this.Type = type;

			setPieceWidth();
			Control[] controls = new Control[pieceNum*pieceNum];

            

            for(int i = 0; i < pieceNum; i++)
            {
                for (int j = 0; j < pieceNum; j++)
                {
                    path = "img/" + Type.ToString() + "/" + (n + 1) + ".png";
                    try
                    {
                        fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    }
                    catch
                    {
                        MessageBox.Show(path + " 파일을 찾을 수 없습니다.\n프로그램을 종료 합니다.. ㅠ_ㅠ", "파일이 없어 ㅇㅂㅇ;; 찾아줘~!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                    this.piece[i,j] = new Piece();
                    this.piece[i,j].Location = new Point(marginLeft + (j * pieceSize), marginTop + (i * pieceSize));
                    this.piece[i,j].Size = new Size(pieceSize, pieceSize);
                    this.piece[i,j].TabIndex = 5 + n;
                    this.piece[i,j].TabStop = false;
                    this.piece[i,j].Name = "pic" + (n+1);
                    this.piece[i, j].tmp = path;
                    this.piece[i, j].Image = Image.FromStream(fs);
                    fs.Close();
                    this.piece[i, j].Click += new System.EventHandler(this.BlankPiece_Click);
                    this.piece[i, j].MouseMove += new System.Windows.Forms.MouseEventHandler(this.BlankPiece_MouseMove);
                    this.piece[i, j].MouseLeave += new System.EventHandler(this.BlankPiece_MouseLeave);
                    controls[n] = this.piece[i,j];
                    n++;
                }
                
            }
            DrawNum();
            return controls;
        }
        private void Piece_DrawNumber(object sender, PaintEventArgs e)
        {
            Piece piece = (Piece)sender;
            Han han = Han.가;
            Eng eng = Eng.A;
            int num = Convert.ToInt32(piece.Name.Substring(3, piece.Name.Length-3)) - 1;
            Font font = new Font("Arial Black",10f);
            string str = "";
            switch (this.boardOption.drawNumType)
            {
                case DrawNumType.Alphabet:
                    str = (eng + num).ToString();
                    break;
                case DrawNumType.AlphabetDouble:
                    str = (eng + (int)(num/26)) + "" + (eng + num%26);
                    break;
                case DrawNumType.AlphabetLocation:
                    str = (eng + (int)(num / pieceNum)) + "" + (eng + num % pieceNum);
                    break;
                case DrawNumType.ExcelLocation:
                    str = (eng + ((num % pieceNum))) + "" + (int)(num / pieceNum + 1);
                    break;
                case DrawNumType.HangulLocation:
                    str = (han + (int)(num / 14)) + "" + (han + num % 14);
                    break;
                case DrawNumType.Numeric:
                default:
                    str = (num+1).ToString();
                    break;
            }
            e.Graphics.DrawString(str, font, new SolidBrush(this.boardOption.fontColor), 10, 10);
        }

        private void Piece_Click(object sender, EventArgs e)
        {
            Piece piece = (Piece)sender;
            int row = (piece.Top - 12) / pieceSize;
            int col = (piece.Left - 12) / pieceSize;

            //MessageBox.Show(piece.Name + "\n" + row + "\n" + col + "\n" + this.pieceNum + "\n" + this.boardType);

            if (row > 0)            //조각의 세로 좌표가 윗쪽 끄트머리에 있지 않을 때
                moveEvent(0, row, col, piece);
            if (row < pieceNum - 1) //조각의 세로 좌표가 아래쪽 끄트머리에 있지 않을 때
                moveEvent(1, row, col, piece);
            if (col > 0)            //조각의 가로 좌표가 왼쪽 끄트머리에 있지 않을 때
                moveEvent(2, row, col, piece);
            if (col < pieceNum - 1) //조각의 가로 좌표가 오른쪽 끄트머리에 있지 않을 때
                moveEvent(3, row, col, piece);
            
            return;
        }
        private void BlankPiece_MouseMove(object sender, EventArgs e)
        {

            Piece piece = (Piece)sender;
            //MessageBox.Show(piece.Image.ToString());
            //piece.Tag = piece.Image.
            //Image.FromFile("img/selectPiece.png");
            piece.Image = null;
        }
        private void BlankPiece_MouseLeave(object sender, EventArgs e)
        {
            Piece piece = (Piece)sender;
            FileStream fs = new FileStream(piece.tmp, FileMode.Open, FileAccess.Read);
            piece.Image = Image.FromStream(fs);
            fs.Close();
        }
        private void BlankPiece_Click(object sender, EventArgs e)
        {
            Piece piece = (Piece)sender;
            if (MessageBox.Show("정말 이곳을 빈 조각으로 설정 하시겠습니까?", "Really? ^0^", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                piece.isBlank = true;
                piece.Image = null;
                this.blankLocationY = (piece.Top - marginTop) / piece.Width;
                this.blankLocationX = (piece.Left - marginLeft) / piece.Width;
                piece.Paint -= new System.Windows.Forms.PaintEventHandler(this.Piece_DrawNumber);
                for (int i = 0; i < this.pieceNum; i++)
                {
                    for (int j = 0; j < this.pieceNum; j++)
                    {
                        this.piece[i, j].Click -= new System.EventHandler(this.BlankPiece_Click);
                        this.piece[i, j].MouseMove -= new System.Windows.Forms.MouseEventHandler(this.BlankPiece_MouseMove);
                        this.piece[i, j].MouseLeave -= new System.EventHandler(this.BlankPiece_MouseLeave);
                        this.piece[i, j].Click += new System.EventHandler(this.Piece_Click);
                    }
                }
                PuzzleMix((int)Option.puzzleImage.boardType * 250);

            }
            
        }
		
        /// <summary>
        /// 만들어진 조각들을 섞습니다.
        /// </summary>
        /// <param name="num">빈 조각의 이동 횟수(섞일 횟수)</param>
        public void PuzzleMix(int num)
        {
            Random ran = new Random();
            int row = this.blankLocationY;
            int col = this.blankLocationX;
            Piece piece = null;
            int direction = 0;
            int walk = 0;

            for (int i = 0; i < num;)
            {
                direction = ran.Next(0,4);
                walk = ran.Next(1, pieceNum);
                for (int j = 0; j < walk; j++)
                {
                    switch (direction)
                    {
                        case 0:     //위로
                            if (row - 1 < 0)
                            {
                                direction++;
                            }
                            break;
                        case 1:     //아래로
                            if (row + 1 >= pieceNum)
                            {
                                direction--;
                            }
                            break;
                        case 2:     //좌로
                            if (col - 1 < 0)
                            {
                                direction++;
                            }
                            break;
                        case 3:     //우로
                            if (col + 1 >= pieceNum)
                            {
                                direction--;
                            }
                            break;
                    }

                    piece = this.piece[row, col];
                    switch (direction)
                    {
                        case 0:
                            this.piece[row, col].moveUp();
                            this.piece[row - 1, col].moveDown();
                            this.piece[row, col] = this.piece[row - 1, col];
                            this.piece[row - 1, col] = piece;
                            row--;
                            break;
                        case 1:
                            this.piece[row, col].moveDown();
                            this.piece[row + 1, col].moveUp();
                            this.piece[row, col] = this.piece[row + 1, col];
                            this.piece[row + 1, col] = piece;
                            row++;
                            break;
                        case 2:
                            this.piece[row, col].moveLeft();
                            this.piece[row, col - 1].moveRight();
                            this.piece[row, col] = this.piece[row, col - 1];
                            this.piece[row, col - 1] = piece;
                            col--;
                            break;
                        case 3:
                            this.piece[row, col].moveRight();
                            this.piece[row, col + 1].moveLeft();
                            this.piece[row, col] = this.piece[row, col + 1];
                            this.piece[row, col + 1] = piece;
                            col++;
                            break;
                    }
                    i++;
                }
            }
            this.blankLocationX = col;
            this.blankLocationY = row;
            this.setScore();
        }
        /*public void PuzzleMix(int num, bool progress)
        {
            frmWaiting Wait = new frmWaiting();
            Wait.Show();
            Random ran = new Random();
            int row = this.blankLocationY;
            int col = this.blankLocationX;
            Piece piece = null;
            int direction = 0;
            int walk = 0;

            for (int i = 0; i < num; )
            {
                Wait.Progress((i+1)/num*100);
                direction = ran.Next(0, 4);
                walk = ran.Next(1, pieceNum);
                for (int j = 0; j < walk; j++)
                {
                    switch (direction)
                    {
                        case 0:     //위로
                            if (row - 1 < 0)
                            {
                                direction++;
                            }
                            break;
                        case 1:     //아래로
                            if (row + 1 >= pieceNum)
                            {
                                direction--;
                            }
                            break;
                        case 2:     //좌로
                            if (col - 1 < 0)
                            {
                                direction++;
                            }
                            break;
                        case 3:     //우로
                            if (col + 1 >= pieceNum)
                            {
                                direction--;
                            }
                            break;
                    }

                    piece = this.piece[row, col];
                    switch (direction)
                    {
                        case 0:
                            this.piece[row, col].moveUp();
                            this.piece[row - 1, col].moveDown();
                            this.piece[row, col] = this.piece[row - 1, col];
                            this.piece[row - 1, col] = piece;
                            row--;
                            break;
                        case 1:
                            this.piece[row, col].moveDown();
                            this.piece[row + 1, col].moveUp();
                            this.piece[row, col] = this.piece[row + 1, col];
                            this.piece[row + 1, col] = piece;
                            row++;
                            break;
                        case 2:
                            this.piece[row, col].moveLeft();
                            this.piece[row, col - 1].moveRight();
                            this.piece[row, col] = this.piece[row, col - 1];
                            this.piece[row, col - 1] = piece;
                            col--;
                            break;
                        case 3:
                            this.piece[row, col].moveRight();
                            this.piece[row, col + 1].moveLeft();
                            this.piece[row, col] = this.piece[row, col + 1];
                            this.piece[row, col + 1] = piece;
                            col++;
                            break;
                    }
                    i++;
                }
            }
            this.blankLocationX = col;
            this.blankLocationY = row;
            Wait.Close();
        }
        */
        private void moveEvent(int num, int row, int col, Piece piece)
        {
            switch (num) // 0=상 1=하 2=좌 3=우
            {
                case 0:
                    if (this.piece[row - 1, col].isBlank)
                    {
                        this.piece[row, col].moveUp();
                        this.piece[row - 1, col].moveDown();
                        this.piece[row, col] = this.piece[row - 1, col];
                        this.piece[row - 1, col] = piece;

                        ScoreAccumulation(this.piece[row-1, col].Name, row - 1, col, row, col);
                        return;
                    }
                    break;
                case 1:
                    if (this.piece[row + 1, col].isBlank)
                    {
                        this.piece[row, col].moveDown();
                        this.piece[row + 1, col].moveUp();
                        this.piece[row, col] = this.piece[row + 1, col];
                        this.piece[row + 1, col] = piece;

                        ScoreAccumulation(this.piece[row+1, col].Name, row + 1, col, row, col);
                        return;
                    }
                    break;
                case 2:
                    if (this.piece[row, col - 1].isBlank)
                    {
                        this.piece[row, col].moveLeft();
                        this.piece[row, col - 1].moveRight();
                        this.piece[row, col] = this.piece[row, col - 1];
                        this.piece[row, col - 1] = piece;

                        ScoreAccumulation(this.piece[row, col-1].Name, row, col - 1, row, col);
                        return;
                    }
                    break;
                case 3:
                    if (this.piece[row, col + 1].isBlank)
                    {
                        this.piece[row, col].moveRight();
                        this.piece[row, col + 1].moveLeft();
                        this.piece[row, col] = this.piece[row, col + 1];
                        this.piece[row, col + 1] = piece;

                        ScoreAccumulation(this.piece[row, col+1].Name, row, col + 1, row, col);
                        return;
                    }
                    break;
            }
        }

        /// <summary>
        /// 퍼즐 조각을 삭제 합니다.
        /// </summary>
        /// <param name="controls">삭제할 컨트롤의 모임</param>
        public void RemovePiece(Control.ControlCollection controls)
        {
            int n = 0;
            for (int i = 0; i < pieceNum; i++)
            {
                for (int j = 0; j < pieceNum; j++)
                {
                    n++;
                    
                    controls.Remove(this.piece[i, j]);
                }
            }
        }

        private void ScoreAccumulation(string ClickedPiece, int row1, int col1, int row2, int col2)
        {
            //MessageBox.Show(ClickedPiece);
            if (ClickedPiece == ("pic" + ((row2 * pieceNum) + (col2 + 1))) )
            {
                score--;
            }
            else if (ClickedPiece == ("pic" + ((row1 * pieceNum) + (col1 + 1))) )
            {
                score++;
            }

            if (score == (pieceNum * pieceNum - 1))
            {
                MessageBox.Show("축하합니다~ 완성되었습니다 ^^)/","오~ 쫌 하시는데?",MessageBoxButtons.OK,MessageBoxIcon.Information);
                initScore();
            }
            return;
        }
        public void initScore()
        {
            score = 0;
        }
        public void setScore()
        {
            for (int i = 0; i < pieceNum; i++)
            {
                for (int j = 0; j < pieceNum; j++)
                {
                    if (this.piece[i, j].Name == ("pic" + ((i * pieceNum) + (j + 1))))
                    {
                        score++;
                        //MessageBox.Show(score + "\n" + "pic" + ((i * pieceNum) + (j + 1)));
                    }
                }
            }
        }
    }
}