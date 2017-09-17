/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2009-07-14
 * Time: 오전 11:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WaitingProgress
{
	partial class frmWaiting
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 35);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(268, 23);
			this.progressBar.TabIndex = 0;
			this.progressBar.UseWaitCursor = true;
			// 
			// frmWaiting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 70);
			this.Controls.Add(this.progressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmWaiting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.TopMost = true;
			this.UseWaitCursor = true;
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ProgressBar progressBar;
	}
}
