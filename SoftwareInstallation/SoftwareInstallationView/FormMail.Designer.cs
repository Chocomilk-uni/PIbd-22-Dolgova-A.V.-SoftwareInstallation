
namespace SoftwareInstallationView
{
    partial class FormMail
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.buttonGetPage = new System.Windows.Forms.Button();
            this.textBoxGetPage = new System.Windows.Forms.TextBox();
            this.labelPage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(1, -2);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(901, 109);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPrevious.Enabled = false;
            this.buttonPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrevious.Location = new System.Drawing.Point(188, 121);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(110, 38);
            this.buttonPrevious.TabIndex = 2;
            this.buttonPrevious.Text = "←";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.Location = new System.Drawing.Point(397, 121);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(110, 38);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "→";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxPage.Location = new System.Drawing.Point(321, 132);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.ReadOnly = true;
            this.textBoxPage.Size = new System.Drawing.Size(53, 22);
            this.textBoxPage.TabIndex = 4;
            this.textBoxPage.Text = "1";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonGetPage
            // 
            this.buttonGetPage.Location = new System.Drawing.Point(784, 121);
            this.buttonGetPage.Name = "buttonGetPage";
            this.buttonGetPage.Size = new System.Drawing.Size(106, 38);
            this.buttonGetPage.TabIndex = 5;
            this.buttonGetPage.Text = "Перейти";
            this.buttonGetPage.UseVisualStyleBackColor = true;
            this.buttonGetPage.Click += new System.EventHandler(this.buttonGetPage_Click);
            // 
            // textBoxGetPage
            // 
            this.textBoxGetPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxGetPage.Location = new System.Drawing.Point(725, 129);
            this.textBoxGetPage.Name = "textBoxGetPage";
            this.textBoxGetPage.Size = new System.Drawing.Size(53, 22);
            this.textBoxGetPage.TabIndex = 6;
            this.textBoxGetPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(643, 132);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(76, 17);
            this.labelPage.TabIndex = 7;
            this.labelPage.Text = "Страница:";
            // 
            // FormMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 175);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.textBoxGetPage);
            this.Controls.Add(this.buttonGetPage);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormMail";
            this.Text = "Почта";
            this.Load += new System.EventHandler(this.FormMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Button buttonGetPage;
        private System.Windows.Forms.TextBox textBoxGetPage;
        private System.Windows.Forms.Label labelPage;
    }
}