
namespace SoftwareInstallationView
{
    partial class FormReportAllOrdersInfo
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportOrdersForInfoViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonSaveToPdf = new System.Windows.Forms.Button();
            this.buttonFormReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersForInfoViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportOrdersForInfoViewModelBindingSource
            // 
            this.ReportOrdersForInfoViewModelBindingSource.DataSource = typeof(SoftwareInstallationBusinessLogic.ViewModels.ReportAllOrdersInfoViewModel);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSetOrdersInfo";
            reportDataSource1.Value = this.ReportOrdersForInfoViewModelBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "SoftwareInstallationView.ReportAllOrdersInfo.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(1, 36);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1057, 531);
            this.reportViewer.TabIndex = 13;
            // 
            // buttonSaveToPdf
            // 
            this.buttonSaveToPdf.Location = new System.Drawing.Point(646, 5);
            this.buttonSaveToPdf.Name = "buttonSaveToPdf";
            this.buttonSaveToPdf.Size = new System.Drawing.Size(127, 25);
            this.buttonSaveToPdf.TabIndex = 12;
            this.buttonSaveToPdf.Text = "В Pdf";
            this.buttonSaveToPdf.UseVisualStyleBackColor = true;
            this.buttonSaveToPdf.Click += new System.EventHandler(this.ButtonSaveToPdf_Click);
            // 
            // buttonFormReport
            // 
            this.buttonFormReport.Location = new System.Drawing.Point(200, 5);
            this.buttonFormReport.Name = "buttonFormReport";
            this.buttonFormReport.Size = new System.Drawing.Size(128, 25);
            this.buttonFormReport.TabIndex = 11;
            this.buttonFormReport.Text = "Сформировать";
            this.buttonFormReport.UseVisualStyleBackColor = true;
            this.buttonFormReport.Click += new System.EventHandler(this.ButtonFormReport_Click);
            // 
            // FormReportAllOrdersInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 572);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonSaveToPdf);
            this.Controls.Add(this.buttonFormReport);
            this.Name = "FormReportAllOrdersInfo";
            this.Text = "Информация о заказах";
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersForInfoViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Button buttonSaveToPdf;
        private System.Windows.Forms.Button buttonFormReport;
        private System.Windows.Forms.BindingSource ReportOrdersForInfoViewModelBindingSource;
    }
}