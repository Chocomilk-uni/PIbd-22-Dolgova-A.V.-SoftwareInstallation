namespace SoftwareInstallationView
{
    partial class FormMain
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
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пакетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнениеСкладаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокИзделийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоПакетамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовПоДатамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоСкладамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОЗаказахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.почтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 33);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(968, 358);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(998, 60);
            this.buttonCreateOrder.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(221, 28);
            this.buttonCreateOrder.TabIndex = 1;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Location = new System.Drawing.Point(998, 252);
            this.buttonPayOrder.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(221, 28);
            this.buttonPayOrder.TabIndex = 4;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(998, 318);
            this.buttonRef.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(221, 28);
            this.buttonRef.TabIndex = 5;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнениеСкладаToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.запускРаботToolStripMenuItem,
            this.почтаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1247, 28);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.пакетыToolStripMenuItem,
            this.складыToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.исполнителиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.КомпонентыToolStripMenuItem_Click);
            // 
            // пакетыToolStripMenuItem
            // 
            this.пакетыToolStripMenuItem.Name = "пакетыToolStripMenuItem";
            this.пакетыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.пакетыToolStripMenuItem.Text = "Пакеты";
            this.пакетыToolStripMenuItem.Click += new System.EventHandler(this.ПакетыToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.СкладыToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.ClientsToolStripMenuItem_Click);
            // 
            // пополнениеСкладаToolStripMenuItem
            // 
            this.пополнениеСкладаToolStripMenuItem.Name = "пополнениеСкладаToolStripMenuItem";
            this.пополнениеСкладаToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.пополнениеСкладаToolStripMenuItem.Text = "Пополнение склада";
            this.пополнениеСкладаToolStripMenuItem.Click += new System.EventHandler(this.ПополнениеСкладаToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокИзделийToolStripMenuItem,
            this.компонентыПоПакетамToolStripMenuItem,
            this.списокЗаказовПоДатамToolStripMenuItem,
            this.списокСкладовToolStripMenuItem,
            this.компонентыПоСкладамToolStripMenuItem,
            this.информацияОЗаказахToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // списокИзделийToolStripMenuItem
            // 
            this.списокИзделийToolStripMenuItem.Name = "списокИзделийToolStripMenuItem";
            this.списокИзделийToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.списокИзделийToolStripMenuItem.Text = "Список изделий";
            this.списокИзделийToolStripMenuItem.Click += new System.EventHandler(this.ReportPackagesToolStripMenuItem_Click);
            // 
            // компонентыПоПакетамToolStripMenuItem
            // 
            this.компонентыПоПакетамToolStripMenuItem.Name = "компонентыПоПакетамToolStripMenuItem";
            this.компонентыПоПакетамToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.компонентыПоПакетамToolStripMenuItem.Text = "Компоненты по пакетам";
            this.компонентыПоПакетамToolStripMenuItem.Click += new System.EventHandler(this.ReportPackageComponentsToolStripMenuItem_Click);
            // 
            // списокЗаказовПоДатамToolStripMenuItem
            // 
            this.списокЗаказовПоДатамToolStripMenuItem.Name = "списокЗаказовПоДатамToolStripMenuItem";
            this.списокЗаказовПоДатамToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.списокЗаказовПоДатамToolStripMenuItem.Text = "Список заказов по датам";
            this.списокЗаказовПоДатамToolStripMenuItem.Click += new System.EventHandler(this.ReportOrdersByDatesToolStripMenuItem_Click);
            // 
            // списокСкладовToolStripMenuItem
            // 
            this.списокСкладовToolStripMenuItem.Name = "списокСкладовToolStripMenuItem";
            this.списокСкладовToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.списокСкладовToolStripMenuItem.Text = "Список складов";
            this.списокСкладовToolStripMenuItem.Click += new System.EventHandler(this.ReportWarehousesToolStripMenuItem_Click);
            // 
            // компонентыПоСкладамToolStripMenuItem
            // 
            this.компонентыПоСкладамToolStripMenuItem.Name = "компонентыПоСкладамToolStripMenuItem";
            this.компонентыПоСкладамToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.компонентыПоСкладамToolStripMenuItem.Text = "Компоненты по складам";
            this.компонентыПоСкладамToolStripMenuItem.Click += new System.EventHandler(this.ReportWarehouseComponentsToolStripMenuItem_Click);
            // 
            // информацияОЗаказахToolStripMenuItem
            // 
            this.информацияОЗаказахToolStripMenuItem.Name = "информацияОЗаказахToolStripMenuItem";
            this.информацияОЗаказахToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.информацияОЗаказахToolStripMenuItem.Text = "Информация о заказах";
            this.информацияОЗаказахToolStripMenuItem.Click += new System.EventHandler(this.ReportAllOrdersInfoToolStripMenuItem_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.ImplementersToolStripMenuItem_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.DoWorkToolStripMenuItem_Click);
            // 
            // почтаToolStripMenuItem
            // 
            this.почтаToolStripMenuItem.Name = "почтаToolStripMenuItem";
            this.почтаToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.почтаToolStripMenuItem.Text = "Почта";
            this.почтаToolStripMenuItem.Click += new System.EventHandler(this.MailToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 391);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Главная форма";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пакетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнениеСкладаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИзделийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоПакетамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовПоДатамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоСкладамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияОЗаказахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem почтаToolStripMenuItem;
    }
}