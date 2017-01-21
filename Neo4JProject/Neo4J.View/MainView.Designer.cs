namespace Neo4J.View
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
            this.tbcMainControl = new System.Windows.Forms.TabControl();
            this.tabNeo4J = new System.Windows.Forms.TabPage();
            this.tlblNeo4J = new System.Windows.Forms.TableLayoutPanel();
            this.txtInfoLog = new System.Windows.Forms.TextBox();
            this.btnStartAnalysis = new System.Windows.Forms.Button();
            this.pgbNeo4JQuery = new System.Windows.Forms.ProgressBar();
            this.tabNeo4JvSql = new System.Windows.Forms.TabPage();
            this.tblNvS = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.lbNeo4JSearch = new System.Windows.Forms.ListBox();
            this.lbSQLSearch = new System.Windows.Forms.ListBox();
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.lblNeo4JSearch = new System.Windows.Forms.Label();
            this.lblSqlSearch = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStartVersusForLocation = new System.Windows.Forms.Button();
            this.btnDatabaseGenerator = new System.Windows.Forms.Button();
            this.tblMain.SuspendLayout();
            this.tbcMainControl.SuspendLayout();
            this.tabNeo4J.SuspendLayout();
            this.tlblNeo4J.SuspendLayout();
            this.tabNeo4JvSql.SuspendLayout();
            this.tblNvS.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.Controls.Add(this.tbcMainControl, 0, 2);
            this.tblMain.Controls.Add(this.btnDatabaseGenerator, 1, 1);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 3;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.722772F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.316832F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.15842F));
            this.tblMain.Size = new System.Drawing.Size(718, 505);
            this.tblMain.TabIndex = 0;
            // 
            // tbcMainControl
            // 
            this.tblMain.SetColumnSpan(this.tbcMainControl, 2);
            this.tbcMainControl.Controls.Add(this.tabNeo4J);
            this.tbcMainControl.Controls.Add(this.tabNeo4JvSql);
            this.tbcMainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMainControl.Location = new System.Drawing.Point(3, 82);
            this.tbcMainControl.Name = "tbcMainControl";
            this.tbcMainControl.SelectedIndex = 0;
            this.tbcMainControl.Size = new System.Drawing.Size(712, 420);
            this.tbcMainControl.TabIndex = 1;
            // 
            // tabNeo4J
            // 
            this.tabNeo4J.Controls.Add(this.tlblNeo4J);
            this.tabNeo4J.Location = new System.Drawing.Point(4, 25);
            this.tabNeo4J.Name = "tabNeo4J";
            this.tabNeo4J.Padding = new System.Windows.Forms.Padding(3);
            this.tabNeo4J.Size = new System.Drawing.Size(704, 391);
            this.tabNeo4J.TabIndex = 0;
            this.tabNeo4J.Text = "Neo4J";
            this.tabNeo4J.UseVisualStyleBackColor = true;
            // 
            // tlblNeo4J
            // 
            this.tlblNeo4J.ColumnCount = 2;
            this.tlblNeo4J.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlblNeo4J.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlblNeo4J.Controls.Add(this.txtInfoLog, 0, 2);
            this.tlblNeo4J.Controls.Add(this.btnStartAnalysis, 1, 0);
            this.tlblNeo4J.Controls.Add(this.pgbNeo4JQuery, 0, 1);
            this.tlblNeo4J.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlblNeo4J.Location = new System.Drawing.Point(3, 3);
            this.tlblNeo4J.Name = "tlblNeo4J";
            this.tlblNeo4J.RowCount = 3;
            this.tlblNeo4J.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.12987F));
            this.tlblNeo4J.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.16883F));
            this.tlblNeo4J.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.7013F));
            this.tlblNeo4J.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlblNeo4J.Size = new System.Drawing.Size(698, 385);
            this.tlblNeo4J.TabIndex = 0;
            // 
            // txtInfoLog
            // 
            this.tlblNeo4J.SetColumnSpan(this.txtInfoLog, 2);
            this.txtInfoLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfoLog.Enabled = false;
            this.txtInfoLog.Location = new System.Drawing.Point(3, 84);
            this.txtInfoLog.Multiline = true;
            this.txtInfoLog.Name = "txtInfoLog";
            this.txtInfoLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfoLog.Size = new System.Drawing.Size(692, 298);
            this.txtInfoLog.TabIndex = 1;
            // 
            // btnStartAnalysis
            // 
            this.btnStartAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartAnalysis.Location = new System.Drawing.Point(352, 3);
            this.btnStartAnalysis.Name = "btnStartAnalysis";
            this.btnStartAnalysis.Size = new System.Drawing.Size(343, 33);
            this.btnStartAnalysis.TabIndex = 0;
            this.btnStartAnalysis.Text = "Start Database Analysis";
            this.btnStartAnalysis.UseVisualStyleBackColor = true;
            this.btnStartAnalysis.Click += new System.EventHandler(this.btnStartAnalysis_Click);
            // 
            // pgbNeo4JQuery
            // 
            this.tlblNeo4J.SetColumnSpan(this.pgbNeo4JQuery, 2);
            this.pgbNeo4JQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgbNeo4JQuery.Location = new System.Drawing.Point(3, 42);
            this.pgbNeo4JQuery.Name = "pgbNeo4JQuery";
            this.pgbNeo4JQuery.Size = new System.Drawing.Size(692, 36);
            this.pgbNeo4JQuery.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbNeo4JQuery.TabIndex = 2;
            this.pgbNeo4JQuery.Visible = false;
            // 
            // tabNeo4JvSql
            // 
            this.tabNeo4JvSql.Controls.Add(this.tblNvS);
            this.tabNeo4JvSql.Location = new System.Drawing.Point(4, 25);
            this.tabNeo4JvSql.Name = "tabNeo4JvSql";
            this.tabNeo4JvSql.Padding = new System.Windows.Forms.Padding(3);
            this.tabNeo4JvSql.Size = new System.Drawing.Size(704, 391);
            this.tabNeo4JvSql.TabIndex = 1;
            this.tabNeo4JvSql.Text = "Neo4J v SQL";
            this.tabNeo4JvSql.UseVisualStyleBackColor = true;
            // 
            // tblNvS
            // 
            this.tblNvS.ColumnCount = 2;
            this.tblNvS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNvS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNvS.Controls.Add(this.lblSearch, 0, 0);
            this.tblNvS.Controls.Add(this.txtSearchBox, 1, 0);
            this.tblNvS.Controls.Add(this.lbNeo4JSearch, 0, 3);
            this.tblNvS.Controls.Add(this.lbSQLSearch, 1, 3);
            this.tblNvS.Controls.Add(this.btnStartSearch, 1, 4);
            this.tblNvS.Controls.Add(this.lblNeo4JSearch, 0, 2);
            this.tblNvS.Controls.Add(this.lblSqlSearch, 1, 2);
            this.tblNvS.Controls.Add(this.btnClear, 0, 4);
            this.tblNvS.Controls.Add(this.btnStartVersusForLocation, 1, 1);
            this.tblNvS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblNvS.Location = new System.Drawing.Point(3, 3);
            this.tblNvS.Name = "tblNvS";
            this.tblNvS.RowCount = 5;
            this.tblNvS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.10148F));
            this.tblNvS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.42857F));
            this.tblNvS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.792208F));
            this.tblNvS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.96104F));
            this.tblNvS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.42857F));
            this.tblNvS.Size = new System.Drawing.Size(698, 385);
            this.tblNvS.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(3, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(343, 42);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search For Location";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchBox.Location = new System.Drawing.Point(352, 3);
            this.txtSearchBox.Multiline = true;
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(343, 36);
            this.txtSearchBox.TabIndex = 1;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            // 
            // lbNeo4JSearch
            // 
            this.lbNeo4JSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNeo4JSearch.FormattingEnabled = true;
            this.lbNeo4JSearch.ItemHeight = 16;
            this.lbNeo4JSearch.Location = new System.Drawing.Point(3, 117);
            this.lbNeo4JSearch.Name = "lbNeo4JSearch";
            this.lbNeo4JSearch.Size = new System.Drawing.Size(343, 219);
            this.lbNeo4JSearch.TabIndex = 4;
            // 
            // lbSQLSearch
            // 
            this.lbSQLSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSQLSearch.FormattingEnabled = true;
            this.lbSQLSearch.ItemHeight = 16;
            this.lbSQLSearch.Location = new System.Drawing.Point(352, 117);
            this.lbSQLSearch.Name = "lbSQLSearch";
            this.lbSQLSearch.Size = new System.Drawing.Size(343, 219);
            this.lbSQLSearch.TabIndex = 5;
            // 
            // btnStartSearch
            // 
            this.btnStartSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartSearch.Location = new System.Drawing.Point(352, 342);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(343, 40);
            this.btnStartSearch.TabIndex = 6;
            this.btnStartSearch.Text = "Start Comparation";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            this.btnStartSearch.Click += new System.EventHandler(this.btnStartSearch_Click);
            // 
            // lblNeo4JSearch
            // 
            this.lblNeo4JSearch.AutoSize = true;
            this.lblNeo4JSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNeo4JSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeo4JSearch.Location = new System.Drawing.Point(3, 85);
            this.lblNeo4JSearch.Name = "lblNeo4JSearch";
            this.lblNeo4JSearch.Size = new System.Drawing.Size(343, 29);
            this.lblNeo4JSearch.TabIndex = 7;
            this.lblNeo4JSearch.Text = "Neo4J Results";
            this.lblNeo4JSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSqlSearch
            // 
            this.lblSqlSearch.AutoSize = true;
            this.lblSqlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSqlSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSqlSearch.Location = new System.Drawing.Point(352, 85);
            this.lblSqlSearch.Name = "lblSqlSearch";
            this.lblSqlSearch.Size = new System.Drawing.Size(343, 29);
            this.lblSqlSearch.TabIndex = 8;
            this.lblSqlSearch.Text = "SQL Results";
            this.lblSqlSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(3, 342);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(343, 40);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStartVersusForLocation
            // 
            this.btnStartVersusForLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartVersusForLocation.Enabled = false;
            this.btnStartVersusForLocation.Location = new System.Drawing.Point(352, 45);
            this.btnStartVersusForLocation.Name = "btnStartVersusForLocation";
            this.btnStartVersusForLocation.Size = new System.Drawing.Size(343, 37);
            this.btnStartVersusForLocation.TabIndex = 10;
            this.btnStartVersusForLocation.Text = "Search Location";
            this.btnStartVersusForLocation.UseVisualStyleBackColor = true;
            this.btnStartVersusForLocation.Click += new System.EventHandler(this.btnStartVersusForLocation_Click);
            // 
            // btnDatabaseGenerator
            // 
            this.btnDatabaseGenerator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDatabaseGenerator.Location = new System.Drawing.Point(362, 41);
            this.btnDatabaseGenerator.Name = "btnDatabaseGenerator";
            this.btnDatabaseGenerator.Size = new System.Drawing.Size(353, 35);
            this.btnDatabaseGenerator.TabIndex = 0;
            this.btnDatabaseGenerator.Text = "Show Database Generator";
            this.btnDatabaseGenerator.UseVisualStyleBackColor = true;
            this.btnDatabaseGenerator.Click += new System.EventHandler(this.btnDatabaseGenerator_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 505);
            this.Controls.Add(this.tblMain);
            this.Name = "MainView";
            this.Text = "Main";
            this.tblMain.ResumeLayout(false);
            this.tbcMainControl.ResumeLayout(false);
            this.tabNeo4J.ResumeLayout(false);
            this.tlblNeo4J.ResumeLayout(false);
            this.tlblNeo4J.PerformLayout();
            this.tabNeo4JvSql.ResumeLayout(false);
            this.tblNvS.ResumeLayout(false);
            this.tblNvS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.TabControl tbcMainControl;
        private System.Windows.Forms.TabPage tabNeo4J;
        private System.Windows.Forms.TableLayoutPanel tlblNeo4J;
        private System.Windows.Forms.TabPage tabNeo4JvSql;
        private System.Windows.Forms.TableLayoutPanel tblNvS;
        private System.Windows.Forms.Button btnDatabaseGenerator;
        private System.Windows.Forms.Button btnStartAnalysis;
        private System.Windows.Forms.TextBox txtInfoLog;
        private System.Windows.Forms.ProgressBar pgbNeo4JQuery;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.ListBox lbNeo4JSearch;
        private System.Windows.Forms.ListBox lbSQLSearch;
        private System.Windows.Forms.Button btnStartSearch;
        private System.Windows.Forms.Label lblNeo4JSearch;
        private System.Windows.Forms.Label lblSqlSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStartVersusForLocation;
    }
}

