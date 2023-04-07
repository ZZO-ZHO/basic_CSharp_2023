namespace wf04_filecopy
{
    partial class Form1
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtSource = new System.Windows.Forms.TextBox();
            this.BtnFindSource = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTarget = new System.Windows.Forms.TextBox();
            this.BtnFindTarget = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnAsyncCopy = new System.Windows.Forms.Button();
            this.PgbCopy = new System.Windows.Forms.ProgressBar();
            this.BtnSyncCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtSource
            // 
            this.TxtSource.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TxtSource.Location = new System.Drawing.Point(72, 15);
            this.TxtSource.Name = "TxtSource";
            this.TxtSource.ReadOnly = true;
            this.TxtSource.Size = new System.Drawing.Size(243, 21);
            this.TxtSource.TabIndex = 0;
            // 
            // BtnFindSource
            // 
            this.BtnFindSource.Location = new System.Drawing.Point(321, 14);
            this.BtnFindSource.Name = "BtnFindSource";
            this.BtnFindSource.Size = new System.Drawing.Size(25, 23);
            this.BtnFindSource.TabIndex = 1;
            this.BtnFindSource.Text = "...";
            this.BtnFindSource.UseVisualStyleBackColor = true;
            this.BtnFindSource.Click += new System.EventHandler(this.BtnFindSource_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source : ";
            // 
            // TxtTarget
            // 
            this.TxtTarget.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TxtTarget.Location = new System.Drawing.Point(72, 42);
            this.TxtTarget.Name = "TxtTarget";
            this.TxtTarget.ReadOnly = true;
            this.TxtTarget.Size = new System.Drawing.Size(243, 21);
            this.TxtTarget.TabIndex = 0;
            // 
            // BtnFindTarget
            // 
            this.BtnFindTarget.Location = new System.Drawing.Point(321, 41);
            this.BtnFindTarget.Name = "BtnFindTarget";
            this.BtnFindTarget.Size = new System.Drawing.Size(25, 23);
            this.BtnFindTarget.TabIndex = 1;
            this.BtnFindTarget.Text = "...";
            this.BtnFindTarget.UseVisualStyleBackColor = true;
            this.BtnFindTarget.Click += new System.EventHandler(this.BtnFindTarget_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Target :";
            // 
            // BtnAsyncCopy
            // 
            this.BtnAsyncCopy.Location = new System.Drawing.Point(63, 90);
            this.BtnAsyncCopy.Name = "BtnAsyncCopy";
            this.BtnAsyncCopy.Size = new System.Drawing.Size(92, 23);
            this.BtnAsyncCopy.TabIndex = 3;
            this.BtnAsyncCopy.Text = "Async Copy";
            this.BtnAsyncCopy.UseVisualStyleBackColor = true;
            this.BtnAsyncCopy.Click += new System.EventHandler(this.BtnAsyncCopy_Click);
            // 
            // PgbCopy
            // 
            this.PgbCopy.Location = new System.Drawing.Point(8, 136);
            this.PgbCopy.Name = "PgbCopy";
            this.PgbCopy.Size = new System.Drawing.Size(346, 23);
            this.PgbCopy.TabIndex = 4;
            // 
            // BtnSyncCopy
            // 
            this.BtnSyncCopy.Location = new System.Drawing.Point(207, 90);
            this.BtnSyncCopy.Name = "BtnSyncCopy";
            this.BtnSyncCopy.Size = new System.Drawing.Size(92, 23);
            this.BtnSyncCopy.TabIndex = 3;
            this.BtnSyncCopy.Text = "Sync Copy";
            this.BtnSyncCopy.UseVisualStyleBackColor = true;
            this.BtnSyncCopy.Click += new System.EventHandler(this.BtnSyncCopy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 184);
            this.Controls.Add(this.PgbCopy);
            this.Controls.Add(this.BtnSyncCopy);
            this.Controls.Add(this.BtnAsyncCopy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnFindTarget);
            this.Controls.Add(this.BtnFindSource);
            this.Controls.Add(this.TxtTarget);
            this.Controls.Add(this.TxtSource);
            this.Name = "Form1";
            this.Text = "Async File Copy";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtSource;
        private System.Windows.Forms.Button BtnFindSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtTarget;
        private System.Windows.Forms.Button BtnFindTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnAsyncCopy;
        private System.Windows.Forms.ProgressBar PgbCopy;
        private System.Windows.Forms.Button BtnSyncCopy;
    }
}

