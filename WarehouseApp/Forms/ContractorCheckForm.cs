
using NLog;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма проверки контрагента.
    /// </summary>
    public partial class ContractorCheckForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IContractorCheckService contractorCheckService;

        /// <summary>
        /// Последний результат проверки контрагента.
        /// </summary>
        public ContractorCheckResult LastResult { get; private set; }

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
                logger.Warn("CONTRACTOR_INN_VALIDATION_ERROR. Category: {Category}. LegalStatus: {LegalStatus}", "Validation", status);
                MessageBox.Show($"ИНН должен содержать {expectedLength} цифр.");
                txtInn.Focus();
                return;
            }

            try
            {
                btnCheck.Enabled = false;
                var result = await contractorCheckService.CheckAsync(inn, status);
                LastResult = result;
                SaveCheckHistory(inn, status, result);

                if (result.IsSuccess)
                    logger.Info("CONTRACTOR_CHECK_SUCCESS. Category: {Category}. Inn: {Inn}", "Api", inn);
                else
                    logger.Warn("CONTRACTOR_CHECK_FAILED. Category: {Category}. Inn: {Inn}", "Api", inn);
                MessageBox.Show(result.Message);
            }
            finally
            {
                btnCheck.Enabled = true;
            }
        }

        private void SaveCheckHistory(string inn, string legalStatus, ContractorCheckResult result)
        {
            var currentUser = UserContext.Current;
            if (currentUser == null)
                return;

            try
            {
                using (var db = new WarehouseContext())
                {
                    db.ActionHistory.Add(new ActionHistory
                    {
                        IdAction = Guid.NewGuid(),
                        EventData = DateTime.Now,
                        Action = "Проверка контрагента",
                        Details = $"ИНН: {inn}; Статус: {legalStatus}; Результат: {result.Message}",
                        Id = currentUser.Id
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "CONTRACTOR_CHECK_HISTORY_SAVE_ERROR. Category: {Category}", "System");
            }
        }

        private void txtInn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
