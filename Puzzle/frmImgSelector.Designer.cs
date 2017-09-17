namespace PuzzleMain
{
    partial class frmImgSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImgSelector));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnComplete = new System.Windows.Forms.Button();
            this.panel_ImgSelector = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkTypeIgnore = new System.Windows.Forms.CheckBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.chkNumEnable = new System.Windows.Forms.CheckBox();
            this.chkImageHint = new System.Windows.Forms.CheckBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnFileSearch = new System.Windows.Forms.Button();
            this.picPreview = new PuzzlePiece.Piece();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "*.jpg";
            this.openFileDialog.Filter = "JPG파일|*.jpg";
            // 
            // btnComplete
            // 
            this.btnComplete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnComplete.Location = new System.Drawing.Point(284, 410);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(132, 23);
            this.btnComplete.TabIndex = 0;
            this.btnComplete.Text = "확인";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // panel_ImgSelector
            // 
            this.panel_ImgSelector.AutoScroll = true;
            this.panel_ImgSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_ImgSelector.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel_ImgSelector.Location = new System.Drawing.Point(12, 40);
            this.panel_ImgSelector.Name = "panel_ImgSelector";
            this.panel_ImgSelector.Size = new System.Drawing.Size(250, 392);
            this.panel_ImgSelector.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // chkTypeIgnore
            // 
            this.chkTypeIgnore.Location = new System.Drawing.Point(284, 380);
            this.chkTypeIgnore.Name = "chkTypeIgnore";
            this.chkTypeIgnore.Size = new System.Drawing.Size(125, 24);
            this.chkTypeIgnore.TabIndex = 3;
            this.chkTypeIgnore.Text = "보드 형태 무시";
            this.chkTypeIgnore.UseVisualStyleBackColor = true;
            this.chkTypeIgnore.CheckedChanged += new System.EventHandler(this.chkTypeIgnore_CheckedChanged);
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(6, 129);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(119, 20);
            this.cmbColor.TabIndex = 4;
            this.cmbColor.Text = "Black";
            this.cmbColor.SelectedIndexChanged += new System.EventHandler(this.cmbColor_SelectedIndexChanged);
            // 
            // grpBox
            // 
            this.grpBox.BackColor = System.Drawing.SystemColors.Control;
            this.grpBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grpBox.BackgroundImage")));
            this.grpBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grpBox.Controls.Add(this.label2);
            this.grpBox.Controls.Add(this.label1);
            this.grpBox.Controls.Add(this.cmbType);
            this.grpBox.Controls.Add(this.chkNumEnable);
            this.grpBox.Controls.Add(this.cmbColor);
            this.grpBox.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpBox.Location = new System.Drawing.Point(284, 189);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(132, 155);
            this.grpBox.TabIndex = 5;
            this.grpBox.TabStop = false;
            this.grpBox.Text = " 퍼즐 조각 옵션";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "새김 문자 색깔";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "새김 문자 형태";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(6, 82);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(119, 20);
            this.cmbType.TabIndex = 5;
            this.cmbType.Text = "Numeric";
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // chkNumEnable
            // 
            this.chkNumEnable.Checked = true;
            this.chkNumEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNumEnable.Location = new System.Drawing.Point(6, 29);
            this.chkNumEnable.Name = "chkNumEnable";
            this.chkNumEnable.Size = new System.Drawing.Size(119, 24);
            this.chkNumEnable.TabIndex = 3;
            this.chkNumEnable.Text = "조각에 숫자 첨가";
            this.chkNumEnable.UseVisualStyleBackColor = true;
            this.chkNumEnable.CheckedChanged += new System.EventHandler(this.ChkNumEnable_CheckedChanged);
            // 
            // chkImageHint
            // 
            this.chkImageHint.Checked = true;
            this.chkImageHint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImageHint.Location = new System.Drawing.Point(284, 350);
            this.chkImageHint.Name = "chkImageHint";
            this.chkImageHint.Size = new System.Drawing.Size(125, 24);
            this.chkImageHint.TabIndex = 6;
            this.chkImageHint.Text = "미리보기 힌트";
            this.chkImageHint.UseVisualStyleBackColor = true;
            this.chkImageHint.CheckedChanged += new System.EventHandler(this.chkImageHint_CheckedChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDesc.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDesc.Location = new System.Drawing.Point(284, 118);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(132, 58);
            this.txtDesc.TabIndex = 8;
            this.txtDesc.TabStop = false;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "기본",
            "사용자"});
            this.cmbCategory.Location = new System.Drawing.Point(12, 12);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 20);
            this.cmbCategory.TabIndex = 9;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // btnFileSearch
            // 
            this.btnFileSearch.Location = new System.Drawing.Point(139, 12);
            this.btnFileSearch.Name = "btnFileSearch";
            this.btnFileSearch.Size = new System.Drawing.Size(123, 23);
            this.btnFileSearch.TabIndex = 10;
            this.btnFileSearch.Text = "찾아보기...";
            this.btnFileSearch.UseVisualStyleBackColor = true;
            this.btnFileSearch.Click += new System.EventHandler(this.btnFileSearch_Click);
            // 
            // picPreview
            // 
            this.picPreview.isBlank = false;
            this.picPreview.Location = new System.Drawing.Point(298, 12);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(100, 100);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPreview.TabIndex = 7;
            this.picPreview.TabStop = false;
            // 
            // frmImgSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(428, 444);
            this.Controls.Add(this.btnFileSearch);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.chkImageHint);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.chkTypeIgnore);
            this.Controls.Add(this.panel_ImgSelector);
            this.Controls.Add(this.btnComplete);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImgSelector";
            this.ShowInTaskbar = false;
            this.Text = ":::::::::: 그림 선택기 - _-;;  ::::::::::";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmImgSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.CheckBox chkNumEnable;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.CheckBox chkTypeIgnore;

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panel_ImgSelector;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkImageHint;
        private PuzzlePiece.Piece picPreview;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnFileSearch;
    }
}