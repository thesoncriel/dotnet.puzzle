using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using PuzzlePiece;

namespace PuzzleBoard
{
    /// <summary>
    /// 퍼즐에 쓰이는 각 조각들의 겉보기 형태를 관리하기 위한 열거형
    /// </summary>
    public enum BoardType { TypeAny, Type3x3, Type4x4, Type5x5, Type6x6, Type7x7, Type8x8, Type9x9, Type10x10 }

    public enum DrawNumType { Alphabet, AlphabetDouble, AlphabetLocation, ExcelLocation, HangulLocation, Numeric }
    public enum Han { 가, 나, 다, 라, 마, 바, 사, 아, 자, 차, 카, 타, 파, 하 }
    public enum Eng { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z};

    /// <summary>
    /// 이미지 선택기로 퍼즐에 쓰일 이미지를 관리하기 위한 구조체
    /// </summary>
    public struct PuzzleImage
    {
        public string name;
        public Image image;
        public BoardType boardType;
        public string desc;
        public string file;
    }

    /// <summary>
    /// 퍼즐 보드 옵션 설정용 구조체
    /// </summary>
    public struct BoardOption
    {
        public PuzzleImage puzzleImage;
        public bool previewHint;
        public bool drawNum;
        public DrawNumType drawNumType;
        public Color fontColor;
        public bool ignoreBoardType;
        /*
        public BoardOption()
        {
            this.puzzleImage.boardType = BoardType.Type5x5;
            this.puzzleImage.file = "img/Default/#PuzzleTitle#.jpg";
            this.puzzleImage.image = Image.FromFile(this.puzzleImage.file);
            this.puzzleImage.name = "Project Image";
            this.puzzleImage.desc = "한 껨 하셔야죠? ^-^)/";
            this.previewHint = true;
            this.drawNum = true;
            this.drawNumType = DrawNumType.Numeric;
            this.fontColor = Color.Black;
            this.ignoreBoardType = false;
        }
        */
        public BoardOption(PuzzleImage puzzleImage)
        {
            this.puzzleImage = puzzleImage;
            this.previewHint = true;
            this.drawNum = true;
            this.drawNumType = DrawNumType.Numeric;
            this.fontColor = Color.Black;
            this.ignoreBoardType = false;
        }
        public BoardOption(PuzzleImage puzzleImage, bool previewHint, bool drawNum, DrawNumType drawNumType, Color fontColor, bool ignoreBoardType)
        {
            this.puzzleImage = puzzleImage;
            this.previewHint = previewHint;
            this.drawNum = drawNum;
            this.drawNumType = drawNumType;
            this.fontColor = fontColor;
            this.ignoreBoardType = ignoreBoardType;
        }
    }
    /// <summary>
    /// BoardType을 이용한 여러가지 변환 작업에 쓰이는 클래스
    /// </summary>
    public class TypeChanger
    {
        public Color[] tcColor = new Color[]
        {
            Color.Black,
            Color.White, 
            Color.SkyBlue,
            Color.DodgerBlue,
            Color.SteelBlue,
            Color.Crimson,
            Color.Tan,
            Color.Brown,
            Color.Khaki,
            Color.Red
        };

        private int DNTLength = 0;
            public int DrawNumTypeLength
            {
                get
                {
                    return DNTLength;
                }
            }

        private int BTLength = 0;
            public int BoardTypeLength
            {
                get
                {
                    return BTLength;
                }
            }

        public TypeChanger()
        {
            DNTLength = this.DrawNumTypeCount();
            BTLength = this.BoardTypeCount();
        }
        /// <summary>
        /// 입력된 문자열중 보드타입과 관련된 것을 찾아서 BoardType 열거형으로 반환 합니다.
        /// 문자열의 형태가 '(NxN) 포함', 또는 'TypeNxN'
        /// </summary>
        /// <param name="str">변환할 문자열.</param>
        /// <returns>BoardType 열거형</returns>
        public BoardType ExtractToBoardType(string str)
        {
            BoardType bt = BoardType.Type3x3;
            try
            {
                int num = Convert.ToInt32(str.Substring(1, str.IndexOf('x') - 1));
                return bt + (num - 3);
            }
            catch
            {
                try
                {
                    int num = Convert.ToInt32(str.Substring(4, str.IndexOf('x') - 4));
                    return bt + (num - 3);
                }
                catch
                {
                    return BoardType.TypeAny;
                }
            }
            
        }
        /// <summary>
        /// 입력된 BoardType을 적당한 문자열로 바꿔줍니다.
        /// </summary>
        /// <param name="type">BoardType 열거형</param>
        /// <returns>string 문자열</returns>
        public string BoardTypeToDesc(BoardType type)
        {
            try
            {
                string str = type.ToString().Substring(4, type.ToString().IndexOf('x') - 4);
                return str + " x " + str;
            }
            catch
            {
                return "Any Type";
            }
        }
        /// <summary>
        /// BoardType 형태와 연관된 문자열을 BoardTypeToDesc의 반환형과 동일한 형태로 반환 합니다.
        /// </summary>
        /// <param name="str">바꿀 문자열</param>
        /// <returns>string 문자열</returns>
        public string ComboChange(string str)//하하
        {
            return BoardTypeToDesc(ExtractToBoardType(str));
        }
        private int BoardTypeCount()
        {
            int n =0;
            BoardType bType = BoardType.TypeAny;
            do
            {
            } while (!Char.IsNumber((bType + (n++)).ToString(), 0));
            return --n;
        }

        /// <summary>
        /// DrawNumType 형태와 연관된 문자열을 DrawNumType 열거형으로 변환 합니다.
        /// </summary>
        /// <param name="str">변환 시킬 문자열</param>
        /// <returns>DrawNumType</returns>
        public DrawNumType DrawNumTypeChange(string str)
        {
            DrawNumType dnt = DrawNumType.Alphabet;
            for(int i = 0; i < DrawNumTypeLength; i++)
            {
                if (str == (dnt + i).ToString()) return dnt + i;
            }
            //MessageBox.Show("하악");
            return DrawNumType.Numeric;
        }
        /// <summary>
        /// 열거형 DrawNumType의 요소가 몇개인지 알아보는 메서드 입니다.
        /// </summary>
        /// <returns>int</returns>
        private int DrawNumTypeCount()
        {
            int n = 0;
            DrawNumType dnType = DrawNumType.Alphabet;
            do
            {
            } while (!Char.IsNumber((dnType + (n++)).ToString(), 0));
            return --n;
        }



        /// <summary>
        /// 입력된 문자열을 Color 형태로 바꿔 줍니다.
        /// </summary>
        /// <param name="str">string형. 바꿀 문자열</param>
        /// <returns>Color</returns>
        public Color ColorChange(string str)
        {
            int i = 0;
            do
            {
                if (("Color [" + str + "]") == tcColor[i].ToString()) return tcColor[i];
                i++;
            } while (i < tcColor.Length);
            return Color.Black;
        }
        /// <summary>
        /// 입력된 Color를 문자열로 바꿔 줍니다.
        /// </summary>
        /// <param name="color">System.Drawing.Color 형태의 값</param>
        /// <returns>string</returns>
        public string ColorChange(Color color)
        {
            try
            {
                string str = color.ToString();
                return str.Substring(7, str.Length - 8);
            }
            catch
            {
                return "Black";
            }
        }
    }
}