using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.BusinessLogic;
using SoftwareInstallationBusinessLogic.ViewModels;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Unity;

namespace SoftwareInstallationView
{
    public partial class FormMail : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MailLogic logic;

        private bool hasNext = false;
        private readonly int mailsOnPage = 2;
        private int currentPage = 0;

        public FormMail(MailLogic logic)
        {
            this.logic = logic;
            if (mailsOnPage < 1) { mailsOnPage = 5; }
            InitializeComponent();
        }

        private void FormMail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(new MessageInfoBindingModel { ToSkip = currentPage * mailsOnPage, ToTake = mailsOnPage + 1});

                var method = typeof(Program).GetMethod("ConfigGrid");
                MethodInfo generic = method.MakeGenericMethod(typeof(MessageInfoViewModel));

                hasNext = !(list.Count <= mailsOnPage);

                if (hasNext)
                {
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = false;
                }

                generic.Invoke(this, new object[] { list.Take(mailsOnPage).ToList(), dataGridView });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (hasNext)
            {
                currentPage++;
                textBoxPage.Text = (currentPage + 1).ToString();
                buttonPrevious.Enabled = true;
                LoadData();
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if ((currentPage - 1) >= 0)
            {
                currentPage--;
                textBoxPage.Text = (currentPage + 1).ToString();
                buttonNext.Enabled = true;
                if (currentPage == 0)
                {
                    buttonPrevious.Enabled = false;
                }
                LoadData();
            }
        }

        private void buttonGetPage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxGetPage.Text))
            {
                MessageBox.Show("Введите номер страницы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var list = logic.Read(null);

            if (Convert.ToInt32(textBoxGetPage.Text) < 0 || Convert.ToInt32(textBoxGetPage.Text) > list.Count)
            {
                MessageBox.Show("Недопустимый номер страницы номер страницы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentPage = Convert.ToInt32(textBoxGetPage.Text) - 1;
            textBoxPage.Text = (currentPage + 1).ToString();
            LoadData();
        }
    }
}
