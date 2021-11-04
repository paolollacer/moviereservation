using MovieReservation.classes;
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
    public partial class frmSeatSelectorConfirmation : Form
    {
        public bool transactionIsComplete;
        public bool cancelSeatsMode;
        public string customerName;
        public string movieName;
        public string timeslot;
        public List<string> listOfSelectedSeats;
        public int noOfselectedSeats;
        public decimal ticketPrice;
        public decimal totalAmount;
        public long movieTimeslotId;

        public frmSeatSelectorConfirmation()
        {
            InitializeComponent();
            this.transactionIsComplete = false;
            this.cancelSeatsMode = false;
            this.customerName = "";
            this.movieName = "";
            this.timeslot = "";
            this.listOfSelectedSeats = new List<string> { };
            this.noOfselectedSeats = 0;
            this.ticketPrice = 0;
            this.totalAmount = 0;
            this.movieTimeslotId = 0;
        }

        private void frmSeatSelectorConfirmation_Load(object sender, EventArgs e)
        {
            int label_XPosition;
            double fontSize;

            try
            {
                label_XPosition = (panelReviewPurchaseDetails.Size.Width - labelReviewPurchaseDetails.Size.Width) / 2;
                labelReviewPurchaseDetails.Location = new Point(label_XPosition, labelReviewPurchaseDetails.Location.Y);

                label_XPosition = (panelConfirmPurchase.Size.Width - labelConfirmPurchase.Size.Width) / 2;
                labelConfirmPurchase.Location = new Point(label_XPosition, labelConfirmPurchase.Location.Y);

                btnOK.Location = new Point((panelConfirmationButtons.Width / 2) - btnOK.Width - 10, 0);
                btnCancel.Location = new Point((panelConfirmationButtons.Width / 2) + 10, 0);

                labelCustomerNameValue.Text = this.customerName;
                labelMovieNameValue.Text = this.movieName;
                labelTimeslotValue.Text = this.timeslot;

                labelSelectedSeatsValue.Text = string.Join(", ", this.listOfSelectedSeats);

                if (labelSelectedSeatsValue.Text.Length < 120)
                    tblLayoutPanel_Details.RowStyles[3].Height *= (labelSelectedSeatsValue.Text.Length / 40) + 1;
                else
                {
                    tblLayoutPanel_Details.RowStyles[3].Height *= 4;

                    fontSize = labelSelectedSeatsValue.Text.Length < 250 ? 10 :
                               labelSelectedSeatsValue.Text.Length < 500 ? 8 : 6.001;

                    labelSelectedSeatsValue.Font = new Font(labelSelectedSeats.Font.FontFamily,
                        (float)fontSize, //(labelSelectedSeats.Font.Size * 110 / labelSelectedSeatsValue.Text.Length),
                        labelSelectedSeats.Font.Style);
                }

                labelNoOfSeatsValue.Text = this.noOfselectedSeats.ToString();
                labelTicketPriceValue.Text = this.ticketPrice.ToString("N2");
                labelTotalAmountValue.Text = this.totalAmount.ToString("N2");

                this.Focus();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sqlQuery;
            long next_wid;
            long transaction_tableId;
            bool isCancelled;
            bool setDatabase;
            functionMySQL mySQLfunction;
            functionMSSQL microsoftSQLfunction;

            try
            {
                isCancelled = this.cancelSeatsMode;
                mySQLfunction = new functionMySQL();
                microsoftSQLfunction = new functionMSSQL();

                transaction_tableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("[transaction]") : mySQLfunction.getNextTableId("transaction");
                sqlQuery = $"UPDATE {(classGlobalVariables.MSSQLMode ? "[transaction]" : "`transaction`")} SET `movietimeslot_id`= @timeslotId ," +
                           $" `customername`= @customer ," +
                           $" `date_of_transaction`= @date ," +
                           $" `totalamount`= @totalAmount " +
                           $" WHERE `table_id`= @transactionTableId ";
                               
                setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string> 
                              {
                                    ["@timeslotId"] = this.movieTimeslotId.ToString(),
                                    ["@customer"] = this.customerName,
                                    ["@date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@totalAmount"] = totalAmount.ToString(),
                                    ["@transactionTableId"] = transaction_tableId.ToString()
                              }) :
                              functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                              {
                                  ["@timeslotId"] = this.movieTimeslotId.ToString(),
                                  ["@customer"] = this.customerName,
                                  ["@date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                  ["@totalAmount"] = totalAmount.ToString(),
                                  ["@transactionTableId"] = transaction_tableId.ToString()
                              });

                foreach (string seat in listOfSelectedSeats)
                {
                    next_wid = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("transactiondetail") : mySQLfunction.getNextTableId("transactiondetail");
                    sqlQuery = $"UPDATE `transactiondetail` SET `transaction_id`= @transactionTableId ," +
                           $" `seatnumber`= @seat ," +
                           $" `iscancelled`= @isCancelled " +
                           $" WHERE `table_id`= @tableId";

                    setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                  {
                                        ["@transactionTableId"] = transaction_tableId.ToString(),
                                        ["@seat"] = seat,
                                        ["@customer"] = this.customerName,
                                        ["@isCancelled"] = isCancelled ? "1" : "0" ,
                                        ["@tableId"] = next_wid.ToString()                                        
                                  }) :
                                  functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                  {
                                      ["@transactionTableId"] = transaction_tableId.ToString(),
                                      ["@seat"] = seat,
                                      ["@customer"] = this.customerName,
                                      ["@isCancelled"] = isCancelled ? "1" : "0",
                                      ["@tableId"] = next_wid.ToString()
                                  });
                }

                MessageBox.Show($"Your seat {(this.cancelSeatsMode ? "cancellation" : "reservation")} was successful!", "Success", MessageBoxButtons.OK);
                this.transactionIsComplete = true;
                this.Close();
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                MessageBox.Show($"Your seat {(this.cancelSeatsMode ? "cancellation" : "reservation")} failed. Please check your logs.", "Error", MessageBoxButtons.OK);
                return;
            }

            
        }
    }
}
