using System;
using System.Drawing;
using System.Windows.Forms;

namespace WaitingProgress
{
	public partial class frmWaiting : Form
	{
		string descStr = "";
		Font descFont = new Font("Gulim", 10);
		Brush descBrush = Brushes.Black;
		Point descPoint = new Point(12, 10);
		public frmWaiting()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.Paint += new PaintEventHandler(frmWaiting_Paint);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/// <summary>
		/// Wait폼의 진행률 컨트롤을 설정하고 설명을 표현 합니다.
		/// </summary>
		/// <param name="str">현재 상황을 설명 합니다.</param>
		/// <param name="prog">0~100 사이의 값 : 현재 작업 진행률의 백분율</param>
		public void Progress(string str, int prog)
		{
			this.descStr = str;
			prog = (prog > 100 || 0 > prog) ? 0 : prog;
			this.progressBar.Value = prog;
		}
		/// <summary>
		/// Wait폼의 진행률 컨트롤을 설정하고 설명을 표현 합니다.
		/// </summary>
		/// <param name="prog">0~100 사이의 값 : 현재 작업 진행률의 백분율</param>
		public void Progress(int prog)
		{
			prog = (prog > 100 || 0 > prog) ? 0 : prog;
			this.progressBar.Value = prog;
		}
		
		private void frmWaiting_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawString(descStr, descFont, descBrush, descPoint);
		}
	}
}
