using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.BusinessLogic;
using SoftwareInstallationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace SoftwareInstallationView
{
    public partial class FormReplenishWarehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int WarehouseId
        {
            get
            {
                return Convert.ToInt32(comboBoxWarehouse.SelectedValue);
            }
            set
            {
                comboBoxWarehouse.SelectedValue = value;
            }
        }

        public int ComponentId
        {
            get
            {
                return Convert.ToInt32(comboBoxComponent.SelectedValue);
            }
            set
            {
                comboBoxComponent.SelectedValue = value;
            }
        }

        public int Count
        {
            get
            {
                return Convert.ToInt32(textBoxCount.Text);
            }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        private readonly WarehouseLogic _warehouseLogic;

        public FormReplenishWarehouse(ComponentLogic componentLogic, WarehouseLogic warehouseLogic)
        {
            InitializeComponent();
            _warehouseLogic = warehouseLogic;

            List<ComponentViewModel> componentViewModels = componentLogic.Read(null);
            if (componentViewModels != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = componentViewModels;
                comboBoxComponent.SelectedItem = null;
            }

            List<WarehouseViewModel> warehouseViewModels = warehouseLogic.Read(null);
            if (warehouseViewModels != null)
            {
                comboBoxWarehouse.DisplayMember = "WarehouseName";
                comboBoxWarehouse.ValueMember = "Id";
                comboBoxWarehouse.DataSource = warehouseViewModels;
                comboBoxWarehouse.SelectedItem = null;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _warehouseLogic.AddComponents(new AddComponentBindingModel
            {
                ComponentId = Convert.ToInt32(comboBoxComponent.SelectedValue),
                WarehouseId = Convert.ToInt32(comboBoxWarehouse.SelectedValue),
                Count = Convert.ToInt32(textBoxCount.Text)
            });

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}