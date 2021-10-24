using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieReservation
{
    public partial class frmChangeValue : Form
    {
        public bool Decision;
        public string NewValue;
        public frmChangeValue()
        {
            InitializeComponent();
            this.Decision = false;
            this.NewValue = "";
        }

        private void frmChangeValue_Load(object sender, EventArgs e)
        {
            try
            {
                btnOK.Location = new Point((panelButtons.Width / 2) - btnOK.Width - 5, 0);
                btnCancel.Location = new Point((panelButtons.Width / 2) + 5, 0);
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "Change Ticket Price" && !Decimal.TryParse(txtBoxNewValue.Text, out decimal value))
                {
                    MessageBox.Show($"Please enter a valid amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"Proceed with value change?", "Change Value", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

                this.Decision = true;
                this.NewValue = txtBoxNewValue.Text;
                this.Close();
            }
            catch(Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Cancel value change?", "Change Value", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

                this.Close();
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }
    }
}
