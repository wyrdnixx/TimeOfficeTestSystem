
namespace TimeOfficeTestSystem
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRefreshTestsystem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnStartTestsystem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRefreshTestsystem
            // 
            this.btnRefreshTestsystem.BackColor = System.Drawing.SystemColors.Info;
            this.btnRefreshTestsystem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshTestsystem.Location = new System.Drawing.Point(12, 454);
            this.btnRefreshTestsystem.Name = "btnRefreshTestsystem";
            this.btnRefreshTestsystem.Size = new System.Drawing.Size(553, 191);
            this.btnRefreshTestsystem.TabIndex = 3;
            this.btnRefreshTestsystem.Text = "Timeoffice Testsystem refresh";
            this.btnRefreshTestsystem.UseVisualStyleBackColor = false;
            this.btnRefreshTestsystem.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(568, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Protokoll";
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(571, 28);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResult.Size = new System.Drawing.Size(600, 617);
            this.tbResult.TabIndex = 5;
            this.tbResult.Text = "Programmstart";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(622, 4);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 6;
            this.btnClearLog.Text = "clear";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnStartTestsystem
            // 
            this.btnStartTestsystem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnStartTestsystem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTestsystem.Location = new System.Drawing.Point(12, 28);
            this.btnStartTestsystem.Name = "btnStartTestsystem";
            this.btnStartTestsystem.Size = new System.Drawing.Size(553, 183);
            this.btnStartTestsystem.TabIndex = 7;
            this.btnStartTestsystem.Text = "Timeoffice Testsystem starten...";
            this.btnStartTestsystem.UseVisualStyleBackColor = false;
            this.btnStartTestsystem.Click += new System.EventHandler(this.btnStartTestsystem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 667);
            this.Controls.Add(this.btnStartTestsystem);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefreshTestsystem);
            this.Name = "Form1";
            this.Text = "Timeoffice Testsystem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRefreshTestsystem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnStartTestsystem;
    }
}

