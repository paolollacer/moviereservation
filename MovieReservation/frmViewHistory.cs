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
    public partial class frmViewHistory : Form
    {
        private DataTable _dataTable;
        public int CinemaId;
        public bool DoneClear;

        public frmViewHistory(DataTable dataTable)
        {
            InitializeComponent();
            this._dataTable = dataTable;
            this.CinemaId = 0;
            this.DoneClear = false;
        }

        private void frmViewHistory_Load(object sender, EventArgs e)
        {
            try
            {
                btnClose.Location = new Point((panelButtons.Width / 2) - btnClose.Width - 5, 0);
                btnClearAll.Location = new Point((panelButtons.Width / 2) + 5, 0);
                dataGridViewHistory.DataSource = this._dataTable;

                foreach (DataGridViewColumn column in dataGridViewHistory.Columns)
                {
                    column.Width = dataGridViewHistory.Width / 6;

                    if (column.Index == 0)
                        column.Width += 2;
                }

                foreach (DataGridViewRow row in dataGridViewHistory.Rows)
                {
                    row.Height *= 2;
                }

                dataGridViewHistory.Font = new Font(dataGridViewHistory.Font.FontFamily, 10, FontStyle.Regular);
                dataGridViewHistory.ShowCellToolTips = true;
            }
            catch(Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            string sqlQuery;
            try
            {
                sqlQuery = "";

                if (MessageBox.Show("Selecting this action will clear all pending reservations. Proceed?", "Clear All Reservations", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;

                if (MessageBox.Show("Final Confirmation: Do you truly will to proceed clearing all pending reservations?", "Final Confirmation - Clear All Reservations", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;

                sqlQuery = $"UPDATE `transactiondetail` as D, `transaction` as T, `movietimeslot` as S" +
                           $" SET D.`iscancelled`=1 WHERE D.`iscancelled`=0" +
                           $" AND D.`transaction_id`=T.`table_id`" +
                           $" AND T.`movietimeslot_id`=S.`table_id`" +
                           $" AND NOW() < S.`timeslot`" +
                           $" AND S.`cinema_id`='{this.CinemaId}'";
                functionMySQL.setDatabase(sqlQuery);

                MessageBox.Show("Successfully cleared all pending reservations.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DoneClear = true;
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
