namespace TxtCrawler.Common
{
    partial class MainView
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
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.lbNodesLog = new System.Windows.Forms.ListBox();
            this.tblTop = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartDatabaseGenerator = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.tblButtom = new System.Windows.Forms.TableLayoutPanel();
            this.pgbMain = new System.Windows.Forms.ProgressBar();
            this.lblDone = new System.Windows.Forms.Label();
            this.tblMain.SuspendLayout();
            this.tblTop.SuspendLayout();
            this.tblButtom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.lbNodesLog, 0, 1);
            this.tblMain.Controls.Add(this.tblTop, 0, 0);
            this.tblMain.Controls.Add(this.tblButtom, 0, 2);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 3;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMain.Size = new System.Drawing.Size(590, 452);
            this.tblMain.TabIndex = 2;
            // 
            // lbNodesLog
            // 
            this.lbNodesLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNodesLog.FormattingEnabled = true;
            this.lbNodesLog.ItemHeight = 16;
            this.lbNodesLog.Location = new System.Drawing.Point(3, 116);
            this.lbNodesLog.Name = "lbNodesLog";
            this.lbNodesLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbNodesLog.Size = new System.Drawing.Size(584, 220);
            this.lbNodesLog.TabIndex = 0;
            // 
            // tblTop
            // 
            this.tblTop.ColumnCount = 2;
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTop.Controls.Add(this.btnStartDatabaseGenerator, 1, 1);
            this.tblTop.Controls.Add(this.btnSettings, 0, 1);
            this.tblTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTop.Location = new System.Drawing.Point(3, 3);
            this.tblTop.Name = "tblTop";
            this.tblTop.RowCount = 2;
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.94392F));
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.05608F));
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblTop.Size = new System.Drawing.Size(584, 107);
            this.tblTop.TabIndex = 1;
            // 
            // btnStartDatabaseGenerator
            // 
            this.btnStartDatabaseGenerator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartDatabaseGenerator.Location = new System.Drawing.Point(295, 64);
            this.btnStartDatabaseGenerator.Name = "btnStartDatabaseGenerator";
            this.btnStartDatabaseGenerator.Size = new System.Drawing.Size(286, 40);
            this.btnStartDatabaseGenerator.TabIndex = 0;
            this.btnStartDatabaseGenerator.Text = "Start";
            this.btnStartDatabaseGenerator.UseVisualStyleBackColor = true;
            this.btnStartDatabaseGenerator.Click += new System.EventHandler(this.btnStartDatabaseGenerator_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSettings.Location = new System.Drawing.Point(3, 64);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(286, 40);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // tblButtom
            // 
            this.tblButtom.ColumnCount = 2;
            this.tblButtom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblButtom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tblButtom.Controls.Add(this.pgbMain, 0, 0);
            this.tblButtom.Controls.Add(this.lblDone, 1, 1);
            this.tblButtom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblButtom.Location = new System.Drawing.Point(3, 342);
            this.tblButtom.Name = "tblButtom";
            this.tblButtom.RowCount = 2;
            this.tblButtom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblButtom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblButtom.Size = new System.Drawing.Size(584, 107);
            this.tblButtom.TabIndex = 2;
            // 
            // pgbMain
            // 
            this.tblButtom.SetColumnSpan(this.pgbMain, 2);
            this.pgbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbMain.Location = new System.Drawing.Point(3, 25);
            this.pgbMain.Name = "pgbMain";
            this.pgbMain.Size = new System.Drawing.Size(578, 25);
            this.pgbMain.TabIndex = 0;
            // 
            // lblDone
            // 
            this.lblDone.AutoSize = true;
            this.lblDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDone.ForeColor = System.Drawing.Color.Red;
            this.lblDone.Location = new System.Drawing.Point(445, 53);
            this.lblDone.Name = "lblDone";
            this.lblDone.Size = new System.Drawing.Size(136, 54);
            this.lblDone.TabIndex = 1;
            this.lblDone.Text = "Done";
            this.lblDone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDone.Visible = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 452);
            this.Controls.Add(this.tblMain);
            this.Name = "MainView";
            this.Text = "Database Generator";
            this.tblMain.ResumeLayout(false);
            this.tblTop.ResumeLayout(false);
            this.tblButtom.ResumeLayout(false);
            this.tblButtom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.ListBox lbNodesLog;
        private System.Windows.Forms.TableLayoutPanel tblTop;
        private System.Windows.Forms.Button btnStartDatabaseGenerator;
        private System.Windows.Forms.TableLayoutPanel tblButtom;
        private System.Windows.Forms.ProgressBar pgbMain;
        private System.Windows.Forms.Label lblDone;
        private System.Windows.Forms.Button btnSettings;

    }
}