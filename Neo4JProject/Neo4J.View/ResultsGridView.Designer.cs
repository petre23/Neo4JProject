namespace Neo4J.View
{
    partial class ResultsGridView
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
            this.tblResults = new System.Windows.Forms.TableLayoutPanel();
            this.grdLocations = new System.Windows.Forms.DataGridView();
            this.grdLocationsPositive = new System.Windows.Forms.DataGridView();
            this.grdLocationsNegative = new System.Windows.Forms.DataGridView();
            this.lblAllLocationsGrid = new System.Windows.Forms.Label();
            this.lblLocationsWithPositiveComments = new System.Windows.Forms.Label();
            this.lblMedieTotal = new System.Windows.Forms.Label();
            this.lblLocationsWithNegativeCommets = new System.Windows.Forms.Label();
            this.lblUserAvarage = new System.Windows.Forms.Label();
            this.tblResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocationsPositive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocationsNegative)).BeginInit();
            this.SuspendLayout();
            // 
            // tblResults
            // 
            this.tblResults.ColumnCount = 2;
            this.tblResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblResults.Controls.Add(this.grdLocations, 0, 1);
            this.tblResults.Controls.Add(this.grdLocationsPositive, 1, 1);
            this.tblResults.Controls.Add(this.grdLocationsNegative, 0, 3);
            this.tblResults.Controls.Add(this.lblAllLocationsGrid, 0, 0);
            this.tblResults.Controls.Add(this.lblLocationsWithPositiveComments, 1, 0);
            this.tblResults.Controls.Add(this.lblMedieTotal, 1, 2);
            this.tblResults.Controls.Add(this.lblLocationsWithNegativeCommets, 0, 2);
            this.tblResults.Controls.Add(this.lblUserAvarage, 1, 3);
            this.tblResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblResults.Location = new System.Drawing.Point(0, 0);
            this.tblResults.Name = "tblResults";
            this.tblResults.RowCount = 4;
            this.tblResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.603448F));
            this.tblResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.18103F));
            this.tblResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.172414F));
            this.tblResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.47414F));
            this.tblResults.Size = new System.Drawing.Size(829, 464);
            this.tblResults.TabIndex = 0;
            // 
            // grdLocations
            // 
            this.grdLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLocations.Location = new System.Drawing.Point(3, 28);
            this.grdLocations.Name = "grdLocations";
            this.grdLocations.RowTemplate.Height = 24;
            this.grdLocations.Size = new System.Drawing.Size(408, 198);
            this.grdLocations.TabIndex = 0;
            // 
            // grdLocationsPositive
            // 
            this.grdLocationsPositive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLocationsPositive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLocationsPositive.Location = new System.Drawing.Point(417, 28);
            this.grdLocationsPositive.Name = "grdLocationsPositive";
            this.grdLocationsPositive.RowTemplate.Height = 24;
            this.grdLocationsPositive.Size = new System.Drawing.Size(409, 198);
            this.grdLocationsPositive.TabIndex = 1;
            // 
            // grdLocationsNegative
            // 
            this.grdLocationsNegative.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLocationsNegative.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLocationsNegative.Location = new System.Drawing.Point(3, 255);
            this.grdLocationsNegative.Name = "grdLocationsNegative";
            this.grdLocationsNegative.RowTemplate.Height = 24;
            this.grdLocationsNegative.Size = new System.Drawing.Size(408, 206);
            this.grdLocationsNegative.TabIndex = 3;
            // 
            // lblAllLocationsGrid
            // 
            this.lblAllLocationsGrid.AutoSize = true;
            this.lblAllLocationsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAllLocationsGrid.Location = new System.Drawing.Point(3, 0);
            this.lblAllLocationsGrid.Name = "lblAllLocationsGrid";
            this.lblAllLocationsGrid.Size = new System.Drawing.Size(408, 25);
            this.lblAllLocationsGrid.TabIndex = 4;
            this.lblAllLocationsGrid.Text = "All Locations";
            this.lblAllLocationsGrid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocationsWithPositiveComments
            // 
            this.lblLocationsWithPositiveComments.AutoSize = true;
            this.lblLocationsWithPositiveComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocationsWithPositiveComments.Location = new System.Drawing.Point(417, 0);
            this.lblLocationsWithPositiveComments.Name = "lblLocationsWithPositiveComments";
            this.lblLocationsWithPositiveComments.Size = new System.Drawing.Size(409, 25);
            this.lblLocationsWithPositiveComments.TabIndex = 5;
            this.lblLocationsWithPositiveComments.Text = "Locations with more than 10 Positive Comments";
            this.lblLocationsWithPositiveComments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMedieTotal
            // 
            this.lblMedieTotal.AutoSize = true;
            this.lblMedieTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMedieTotal.Location = new System.Drawing.Point(417, 229);
            this.lblMedieTotal.Name = "lblMedieTotal";
            this.lblMedieTotal.Size = new System.Drawing.Size(409, 23);
            this.lblMedieTotal.TabIndex = 6;
            this.lblMedieTotal.Text = "Avarage User Grade for all Locations";
            this.lblMedieTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocationsWithNegativeCommets
            // 
            this.lblLocationsWithNegativeCommets.AutoSize = true;
            this.lblLocationsWithNegativeCommets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocationsWithNegativeCommets.Location = new System.Drawing.Point(3, 229);
            this.lblLocationsWithNegativeCommets.Name = "lblLocationsWithNegativeCommets";
            this.lblLocationsWithNegativeCommets.Size = new System.Drawing.Size(408, 23);
            this.lblLocationsWithNegativeCommets.TabIndex = 7;
            this.lblLocationsWithNegativeCommets.Text = "Locations with more than 10 Negative Comments";
            this.lblLocationsWithNegativeCommets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserAvarage
            // 
            this.lblUserAvarage.AutoSize = true;
            this.lblUserAvarage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserAvarage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAvarage.Location = new System.Drawing.Point(417, 252);
            this.lblUserAvarage.Name = "lblUserAvarage";
            this.lblUserAvarage.Size = new System.Drawing.Size(409, 212);
            this.lblUserAvarage.TabIndex = 8;
            this.lblUserAvarage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultsGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 464);
            this.Controls.Add(this.tblResults);
            this.Name = "ResultsGridView";
            this.Text = "ResultsGrid";
            this.tblResults.ResumeLayout(false);
            this.tblResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocationsPositive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocationsNegative)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblResults;
        private System.Windows.Forms.DataGridView grdLocations;
        private System.Windows.Forms.DataGridView grdLocationsPositive;
        private System.Windows.Forms.DataGridView grdLocationsNegative;
        private System.Windows.Forms.Label lblAllLocationsGrid;
        private System.Windows.Forms.Label lblLocationsWithPositiveComments;
        private System.Windows.Forms.Label lblMedieTotal;
        private System.Windows.Forms.Label lblLocationsWithNegativeCommets;
        private System.Windows.Forms.Label lblUserAvarage;
    }
}