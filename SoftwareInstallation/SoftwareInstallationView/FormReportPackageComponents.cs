﻿using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.BusinessLogic;
using SoftwareInstallationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Unity;

namespace SoftwareInstallationView
{
    public partial class FormReportPackageComponents : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;

        public FormReportPackageComponents(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormReportPackageComponents_Load(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = logic.GetType().GetMethod("GetPackageComponent");

                List<ReportPackageComponentViewModel> dict = (List<ReportPackageComponentViewModel>)method.Invoke(logic, null);

                if (dict != null)
                {
                    dataGridView.Rows.Clear();

                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.PackageName, "", "" });

                        foreach (var listElem in elem.PackageComponents)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SavePackageComponentToExcelFile");

                        method.Invoke(logic, new object[]
                        {
                            new ReportBindingModel
                        {
                            FileName = dialog.FileName
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