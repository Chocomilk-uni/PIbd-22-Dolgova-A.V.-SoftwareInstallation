using Microsoft.Reporting.WinForms;
using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.BusinessLogic;
using System;
using System.Reflection;
using System.Windows.Forms;
using Unity;

namespace SoftwareInstallationView
{
    public partial class FormReportOrdersByDates : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;

        public FormReportOrdersByDates(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void ButtonFormReport_Click(object sender, EventArgs e)
        {
            if (dateTimePickerDateFrom.Value.Date >= dateTimePickerDateTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ReportParameter parameter = new ReportParameter("ReportParameterPeriod", "с " + dateTimePickerDateFrom.Value.ToShortDateString() + " по " + dateTimePickerDateTo.Value.ToShortDateString());
                reportViewer.LocalReport.SetParameters(parameter);

                MethodInfo method = logic.GetType().GetMethod("GetOrdersByDates");
                var dataSource = method.Invoke(logic, new object[]
                {
                    new ReportBindingModel
                    {
                        DateFrom = dateTimePickerDateFrom.Value,
                        DateTo = dateTimePickerDateTo.Value
                    }
                });

                ReportDataSource source = new ReportDataSource("DataSetOrders", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSaveToPdf_Click(object sender, EventArgs e)
        {
            if (dateTimePickerDateFrom.Value.Date >= dateTimePickerDateTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = GetType().GetMethod("SaveOrdersByDatesToPdfFile");
                        method.Invoke(logic, new object[]
                            {
                                new ReportBindingModel
                                {
                                    FileName = dialog.FileName,
                                    DateFrom = dateTimePickerDateFrom.Value,
                                    DateTo = dateTimePickerDateTo.Value
                                }
                            });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}