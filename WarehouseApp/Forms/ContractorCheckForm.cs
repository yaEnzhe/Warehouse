
namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма проверки контрагента.
    /// </summary>
    public partial class ContractorCheckForm : Form
    {
        private readonly IContractorCheckService contractorCheckService;

        public ContractorCheckForm(IContractorCheckService contractorCheckService = null)
        {
            InitializeComponent();
            WarehouseApp.ResponsiveFormHelper.Enable(this);
            cmbLegalStatus.SelectedIndex = 0;
            this.contractorCheckService = contractorCheckService ?? AppServices.Get<IContractorCheckService>();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            var inn = txtInn.Text.Trim();
            var status = cmbLegalStatus.SelectedItem?.ToString();
            var expectedLength = status == "ИП" ? 12 : 10;

            if (inn.Length != expectedLength)
            {
                MessageBox.Show($"ИНН должен содержать {expectedLength} цифр.");
                txtInn.Focus();
                return;
            }

            try
            {
                btnCheck.Enabled = false;
                var result = await contractorCheckService.CheckAsync(inn, status);
                MessageBox.Show(result.Message);
            }
            finally
            {
                btnCheck.Enabled = true;
            }
        }

        private void txtInn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
