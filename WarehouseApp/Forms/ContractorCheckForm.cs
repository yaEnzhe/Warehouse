using System;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма проверки контрагента.
    /// </summary>
    public partial class ContractorCheckForm : Form
    {
        public ContractorCheckForm()
        {
            InitializeComponent();
            WarehouseApp.ResponsiveFormHelper.Enable(this);
            cmbLegalStatus.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string inn = txtInn.Text.Trim();
            string status = cmbLegalStatus.SelectedItem?.ToString();
            int expectedLength = status == "ИП" ? 12 : 10;

            if (inn.Length != expectedLength)
            {
                MessageBox.Show($"ИНН должен содержать {expectedLength} цифр.");
                txtInn.Focus();
                return;
            }

            Close();
        }

        private void txtInn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
