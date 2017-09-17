using System;
using System.Drawing;
using PuzzlePiece;

namespace PuzzleMain
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuProg = new System.Windows.Forms.ToolStripMenuItem();
            this.strpNew = new System.Windows.Forms.ToolStripMenuItem();
            this.strpMix = new System.Windows.Forms.ToolStripMenuItem();
            this.strpMix_sub100 = new System.Windows.Forms.ToolStripMenuItem();
            this.strpMix_sub200 = new System.Windows.Forms.ToolStripMenuItem();
            this.strpMix_sub300 = new System.Windows.Forms.ToolStripMenuItem();
            this.strpMix_sub400 = new System.Windows.Forms.ToolStripMenuItem();
            this.strpMix_sub500 = new System.Windows.Forms.ToolStripMenuItem();
            this.strpMix_subMax = new System.Windows.Forms.ToolStripMenuItem();
            this.strpSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.strpEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.strpOption = new System.Windows.Forms.ToolStripMenuItem();
            this.strpBoardType = new System.Windows.Forms.ToolStripMenuItem();
            this.strpNum = new System.Windows.Forms.ToolStripMenuItem();
            this.strpImgSelector = new System.Windows.Forms.ToolStripMenuItem();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdjustNum = new System.Windows.Forms.TextBox();
            this.txtPieceNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progClick = new System.Windows.Forms.ProgressBar();
            this.progTime = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProg,
            this.strpOption});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(794, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuProg
            // 
            this.menuProg.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strpNew,
            this.strpMix,
            this.strpSave,
            this.toolStripMenuItem1,
            this.strpEnd});
            this.menuProg.Name = "menuProg";
            this.menuProg.Size = new System.Drawing.Size(69, 20);
            this.menuProg.Text = "함 해볼까";
            // 
            // strpNew
            // 
            this.strpNew.Name = "strpNew";
            this.strpNew.Size = new System.Drawing.Size(156, 22);
            this.strpNew.Text = "새로시작";
            this.strpNew.Click += new System.EventHandler(this.strpNew_Click);
            // 
            // strpMix
            // 
            this.strpMix.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strpMix_sub100,
            this.strpMix_sub200,
            this.strpMix_sub300,
            this.strpMix_sub400,
            this.strpMix_sub500,
            this.strpMix_subMax});
            this.strpMix.Name = "strpMix";
            this.strpMix.Size = new System.Drawing.Size(156, 22);
            this.strpMix.Text = "좀만 더 섞자;;";
            // 
            // strpMix_sub100
            // 
            this.strpMix_sub100.Name = "strpMix_sub100";
            this.strpMix_sub100.Size = new System.Drawing.Size(190, 22);
            this.strpMix_sub100.Text = "100번 섞기";
            this.strpMix_sub100.Click += new System.EventHandler(this.strpMix_Click);
            // 
            // strpMix_sub200
            // 
            this.strpMix_sub200.Name = "strpMix_sub200";
            this.strpMix_sub200.Size = new System.Drawing.Size(190, 22);
            this.strpMix_sub200.Text = "200번 섞기";
            this.strpMix_sub200.Click += new System.EventHandler(this.strpMix_Click);
            // 
            // strpMix_sub300
            // 
            this.strpMix_sub300.Name = "strpMix_sub300";
            this.strpMix_sub300.Size = new System.Drawing.Size(190, 22);
            this.strpMix_sub300.Text = "300번 섞기";
            this.strpMix_sub300.Click += new System.EventHandler(this.strpMix_Click);
            // 
            // strpMix_sub400
            // 
            this.strpMix_sub400.Name = "strpMix_sub400";
            this.strpMix_sub400.Size = new System.Drawing.Size(190, 22);
            this.strpMix_sub400.Text = "400번 섞기";
            this.strpMix_sub400.Click += new System.EventHandler(this.strpMix_Click);
            // 
            // strpMix_sub500
            // 
            this.strpMix_sub500.Name = "strpMix_sub500";
            this.strpMix_sub500.Size = new System.Drawing.Size(190, 22);
            this.strpMix_sub500.Text = "500번 섞기";
            this.strpMix_sub500.Click += new System.EventHandler(this.strpMix_Click);
            // 
            // strpMix_subMax
            // 
            this.strpMix_subMax.Name = "strpMix_subMax";
            this.strpMix_subMax.Size = new System.Drawing.Size(190, 22);
            this.strpMix_subMax.Text = "t(-_-t) 컴터를 죽이자";
            this.strpMix_subMax.Click += new System.EventHandler(this.strpMix_Click);
            // 
            // strpSave
            // 
            this.strpSave.Name = "strpSave";
            this.strpSave.Size = new System.Drawing.Size(156, 22);
            this.strpSave.Text = "현재 설정 저장";
            this.strpSave.Click += new System.EventHandler(this.strpSave_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // strpEnd
            // 
            this.strpEnd.Name = "strpEnd";
            this.strpEnd.Size = new System.Drawing.Size(156, 22);
            this.strpEnd.Text = "아쒸뭥미~!";
            this.strpEnd.Click += new System.EventHandler(this.strpEnd_Click);
            // 
            // strpOption
            // 
            this.strpOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strpBoardType,
            this.strpNum,
            this.strpImgSelector});
            this.strpOption.Name = "strpOption";
            this.strpOption.Size = new System.Drawing.Size(90, 20);
            this.strpOption.Text = "퍼즐 옵션~♬";
            // 
            // strpBoardType
            // 
            this.strpBoardType.Name = "strpBoardType";
            this.strpBoardType.Size = new System.Drawing.Size(168, 22);
            this.strpBoardType.Text = "보드 형태";
            // 
            // strpNum
            // 
            this.strpNum.Checked = true;
            this.strpNum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.strpNum.Name = "strpNum";
            this.strpNum.Size = new System.Drawing.Size(168, 22);
            this.strpNum.Text = "조각에 문자 출력";
            this.strpNum.Click += new System.EventHandler(this.strpNum_Click);
            // 
            // strpImgSelector
            // 
            this.strpImgSelector.Name = "strpImgSelector";
            this.strpImgSelector.Size = new System.Drawing.Size(168, 22);
            this.strpImgSelector.Text = "퍼즐 그림 바꾸기";
            this.strpImgSelector.Click += new System.EventHandler(this.strpImgSelector_Click);
            // 
            // picPreview
            // 
            this.picPreview.Image = ((System.Drawing.Image)(resources.GetObject("picPreview.Image")));
            this.picPreview.Location = new System.Drawing.Point(656, 60);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(100, 100);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPreview.TabIndex = 5;
            this.picPreview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(696, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "/";
            this.label1.Visible = false;
            // 
            // txtAdjustNum
            // 
            this.txtAdjustNum.BackColor = System.Drawing.SystemColors.Control;
            this.txtAdjustNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdjustNum.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjustNum.Location = new System.Drawing.Point(656, 239);
            this.txtAdjustNum.Name = "txtAdjustNum";
            this.txtAdjustNum.Size = new System.Drawing.Size(40, 32);
            this.txtAdjustNum.TabIndex = 11;
            this.txtAdjustNum.TabStop = false;
            this.txtAdjustNum.Text = "0";
            this.txtAdjustNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdjustNum.Visible = false;
            // 
            // txtPieceNum
            // 
            this.txtPieceNum.BackColor = System.Drawing.SystemColors.Control;
            this.txtPieceNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPieceNum.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPieceNum.Location = new System.Drawing.Point(716, 239);
            this.txtPieceNum.Name = "txtPieceNum";
            this.txtPieceNum.Size = new System.Drawing.Size(40, 32);
            this.txtPieceNum.TabIndex = 12;
            this.txtPieceNum.TabStop = false;
            this.txtPieceNum.Text = "0";
            this.txtPieceNum.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("돋움", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(660, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "맞춘 개수";
            this.label2.Visible = false;
            // 
            // progClick
            // 
            this.progClick.Location = new System.Drawing.Point(636, 321);
            this.progClick.Name = "progClick";
            this.progClick.Size = new System.Drawing.Size(146, 23);
            this.progClick.TabIndex = 15;
            this.progClick.Value = 100;
            this.progClick.Visible = false;
            // 
            // progTime
            // 
            this.progTime.Location = new System.Drawing.Point(636, 388);
            this.progTime.Name = "progTime";
            this.progTime.Size = new System.Drawing.Size(146, 23);
            this.progTime.TabIndex = 16;
            this.progTime.Value = 100;
            this.progTime.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(634, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "남은 클릭";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(634, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "남은 시간";
            this.label4.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 660);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progTime);
            this.Controls.Add(this.progClick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPieceNum);
            this.Controls.Add(this.txtAdjustNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = ":::: 오호라~! Puzzle (R) -_-?  :::: - 허접하고 허접한 퍼즐 프로그램 - by TheSON";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Click += new System.EventHandler(this.frmMain_Click);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.PictureBox picPreview;

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuProg;
        private System.Windows.Forms.ToolStripMenuItem strpNew;
        private System.Windows.Forms.ToolStripMenuItem strpMix;
        private System.Windows.Forms.ToolStripMenuItem strpMix_sub100;
        private System.Windows.Forms.ToolStripMenuItem strpMix_sub200;
        private System.Windows.Forms.ToolStripMenuItem strpMix_sub300;
        private System.Windows.Forms.ToolStripMenuItem strpMix_sub400;
        private System.Windows.Forms.ToolStripMenuItem strpMix_sub500;
        private System.Windows.Forms.ToolStripMenuItem strpMix_subMax;
        private System.Windows.Forms.ToolStripMenuItem strpEnd;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem strpOption;
        private System.Windows.Forms.ToolStripMenuItem strpBoardType;
        private System.Windows.Forms.ToolStripMenuItem strpNum;
        private System.Windows.Forms.ToolStripMenuItem strpSave;
        private System.Windows.Forms.ToolStripMenuItem strpImgSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdjustNum;
        private System.Windows.Forms.TextBox txtPieceNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progClick;
        private System.Windows.Forms.ProgressBar progTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;







    }
}

