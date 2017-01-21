namespace TxtCrawler.Common.View
{
    partial class SettingsView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblMainSettings = new System.Windows.Forms.TableLayoutPanel();
            this.grdSettings = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tblMainSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMainSettings
            // 
            this.tblMainSettings.ColumnCount = 2;
            this.tblMainSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainSettings.Controls.Add(this.grdSettings, 0, 0);
            this.tblMainSettings.Controls.Add(this.btnSave, 1, 1);
            this.tblMainSettings.Controls.Add(this.btnCancel, 0, 1);
            this.tblMainSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainSettings.Location = new System.Drawing.Point(0, 0);
            this.tblMainSettings.Name = "tblMainSettings";
            this.tblMainSettings.RowCount = 2;
            this.tblMainSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.66666F));
            this.tblMainSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tblMainSettings.Size = new System.Drawing.Size(634, 492);
            this.tblMainSettings.TabIndex = 0;
            // 
            // grdSettings
            // 
            this.grdSettings.AllowUserToAddRows = false;
            this.grdSettings.AllowUserToDeleteRows = false;
            this.grdSettings.BackgroundColor = System.Drawing.Color.White;
            this.grdSettings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSettings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblMainSettings.SetColumnSpan(this.grdSettings, 2);
            this.grdSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSettings.Location = new System.Drawing.Point(3, 3);
            this.grdSettings.Name = "grdSettings";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSettings.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdSettings.RowHeadersVisible = false;
            this.grdSettings.RowTemplate.Height = 24;
            this.grdSettings.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSettings.Size = new System.Drawing.Size(628, 444);
            this.grdSettings.TabIndex = 2;
            this.grdSettings.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSettings_CellEndEdit);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(320, 453);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(201, 36);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(99, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(215, 36);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 492);
            this.Controls.Add(this.tblMainSettings);
            this.Name = "SettingsView";
            this.Text = "SettingsView";
            this.tblMainSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMainSettings;
        private System.Windows.Forms.DataGridView grdSettings;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}