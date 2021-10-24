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
    public partial class frmSeatSelector : Form
    {
        public bool FormIsClosed;
        public bool IsReservationSuccessful;
        public bool CancelSeatsMode;

        private string _movieTitle;
        private string _timeslot;
        private string _moviePosterFilePath;
        private long _cinemaNumber;
        private long _movieTimeslotId;
        private decimal _ticketPriceOfSingleSeat;
        private int _numberOfSelectedSeats;
        private decimal _totalPriceAmountOfSelectedSeats;
        private List<string> _listOfSelectedSeats;
        private List<string> _reservedSeats;

        private bool _hasTimeslotElapsed;

        public frmSeatSelector(classMovieTimeslot movieTimeslot)
        {
            InitializeComponent();
            this.IsReservationSuccessful = false;
            this.CancelSeatsMode = false;

            this._movieTitle = movieTimeslot.getMovieTitle();
            this._timeslot = movieTimeslot.getTimeslot();
            this._moviePosterFilePath = movieTimeslot.getMoviePosterFilePath();
            this._cinemaNumber = movieTimeslot.getCinemaId();
            this._ticketPriceOfSingleSeat = movieTimeslot.getTicketPrice();
            this._numberOfSelectedSeats = 0;
            this._totalPriceAmountOfSelectedSeats = 0;
            this._listOfSelectedSeats = new List<string> { };
            this._movieTimeslotId = movieTimeslot.getId();
            this._reservedSeats = movieTimeslot.getListOfReservedSeats();
            this._hasTimeslotElapsed = DateTime.Now > DateTime.Parse(this._timeslot);
        }

        private void frmSeatSelector_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = $"Cinema {this._cinemaNumber} - Seat Selector";

                btnProceed.Enabled = 
                    textBoxCustomerName.Enabled = 
                    btnCancelSeats.Enabled = (DateTime.Now < DateTime.Parse(this._timeslot));
                
                btnProceed.Location = new Point((panelConfirmationMain.Width / 2) - btnProceed.Width - 10, 0);
                btnBack.Location = new Point((panelConfirmationMain.Width / 2) + 10, 0);
                btnCancelSeats.Location = new Point((panelCancelSeatsButton.Width / 2) - (btnCancelSeats.Width / 2), 0);
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case 0x0112:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == 0xF010)
                        return;
                    break;

                case 0x00A3:
                    message.Result = IntPtr.Zero;
                    return;
            }

            base.WndProc(ref message);
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.CancelSeatsMode && string.IsNullOrWhiteSpace(textBoxCustomerName.Text.Trim()))
                {
                    MessageBox.Show("Please enter Customer Name first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this._numberOfSelectedSeats == 0)
                {
                    MessageBox.Show("Please select a seat first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmSeatSelectorConfirmation confirmationForm = new frmSeatSelectorConfirmation();
                confirmationForm.customerName = this.textBoxCustomerName.Text;
                confirmationForm.movieName = this._movieTitle;
                confirmationForm.timeslot = this._timeslot;
                confirmationForm.movieTimeslotId = this._movieTimeslotId;
                confirmationForm.listOfSelectedSeats = this._listOfSelectedSeats;
                confirmationForm.noOfselectedSeats = this._numberOfSelectedSeats;
                confirmationForm.ticketPrice = this._ticketPriceOfSingleSeat;
                confirmationForm.totalAmount = !this.CancelSeatsMode ? this._totalPriceAmountOfSelectedSeats : (-1 * this._totalPriceAmountOfSelectedSeats);
                confirmationForm.cancelSeatsMode = this.CancelSeatsMode;
                confirmationForm.ShowDialog();

                if (confirmationForm.transactionIsComplete)
                {
                    this.IsReservationSuccessful = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        public List<string> GetListOfSelectedSeats() { return this._listOfSelectedSeats; }

        public void DrawSeatSelector()
        {
            int seatColumnIndex;
            int seatRowIndex;
            int seatCounter;
            string rowLetter;
            string seatNumber;
            bool isSeatNumberReserved;

            try
            {
                this.Hide();
                seatCounter = 0;
                rowLetter = "";

                if(!string.IsNullOrWhiteSpace(this._moviePosterFilePath))
                    picBoxPoster.BackgroundImage = new Bitmap(this._moviePosterFilePath);

                labelMovieTitle.Text = this._movieTitle;
                labelTimeslot.Text = this._timeslot + (this._hasTimeslotElapsed ? " - ALREADY STARTED" : "");
                labelTicketPriceValue.Text = this._ticketPriceOfSingleSeat.ToString("N2");
                labelNoOfSeatsValue.Text = this._numberOfSelectedSeats.ToString();

                for (seatColumnIndex = 0; seatColumnIndex < tableLayoutSeatSelector.ColumnCount; seatColumnIndex++)
                {
                    seatCounter += seatColumnIndex == 4 || seatColumnIndex == 15 ? 0 : 1;

                    for (seatRowIndex = 0; seatRowIndex < tableLayoutSeatSelector.RowCount; seatRowIndex++)
                    {
                        rowLetter = Convert.ToChar('A' + seatRowIndex).ToString();

                        if (seatColumnIndex == 4 || seatColumnIndex == 15)
                        {
                            tableLayoutSeatSelector.Controls.Add(new Label
                            {
                                ForeColor = Color.Yellow,
                                Text = rowLetter,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Font = new Font(labelMovieTitle.Font.FontFamily, 8, FontStyle.Bold)
                            }, seatColumnIndex, seatRowIndex);

                            continue;
                        }

                        seatNumber = rowLetter + (seatCounter).ToString();
                        isSeatNumberReserved = this._reservedSeats.Contains(seatNumber) ? true : false;

                        tableLayoutSeatSelector.Controls.Add(new Button
                        {
                            BackColor = isSeatNumberReserved ? Color.Red : Color.White,
                            Enabled = _hasTimeslotElapsed ? false : !isSeatNumberReserved,
                            Text = Convert.ToString(seatCounter),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font(labelMovieTitle.Font.FontFamily, 8, FontStyle.Bold),
                            FlatStyle = FlatStyle.Flat,
                            Name = seatNumber
                        }, seatColumnIndex, seatRowIndex) ;
                    }
                }


                tableLayoutSeatSelector.BackColor = Color.Black;
                tableLayoutScreen.Width = tableLayoutSeatSelector.Width;
                tableLayoutScreen.Controls.Add(new Label
                {
                    BackColor = Color.White,
                    Text = "S C R E E N",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font(labelMovieTitle.Font.FontFamily, 20, FontStyle.Bold),
                    Size = tableLayoutScreen.Size,
                    Dock = DockStyle.Fill
                });

                foreach(Control item in tableLayoutSeatSelector.Controls)
                {
                    if (item is Button)
                        item.Click += new System.EventHandler(this.HandleButtonClick);
                }

                this.Show();
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void HandleButtonClick(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                switch(button.BackColor.Name)
                {
                    case "White":
                        if (this.CancelSeatsMode)
                            break;

                        button.BackColor = Color.Cyan;
                        this._listOfSelectedSeats.Add(button.Name);
                        this._numberOfSelectedSeats += 1;
                        break;
                    case "Red":
                        if (!this.CancelSeatsMode)
                            break;

                        button.BackColor = Color.Orange;
                        this._listOfSelectedSeats.Add(button.Name);
                        this._numberOfSelectedSeats += 1;
                        break;
                    case "Cyan":
                        if (this.CancelSeatsMode)
                            break;

                        button.BackColor = Color.White;
                        this._listOfSelectedSeats.Remove(button.Name);
                        this._numberOfSelectedSeats -= 1;
                        break;
                    default:
                        break;

                }

                this._totalPriceAmountOfSelectedSeats = this._numberOfSelectedSeats * _ticketPriceOfSingleSeat;
                this._listOfSelectedSeats.Sort();

                labelNoOfSeatsValue.Text = this._numberOfSelectedSeats.ToString();
                labelTotalAmountValue.Text = this._totalPriceAmountOfSelectedSeats.ToString("N2");
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void buttonCancelSeats_Click(object sender, EventArgs e)
        {
            string message;
            string titleBarText;

            try
            {
                message = this.CancelSeatsMode ? "Do you wish to reserve more seats?" : "Do you wish to cancel reserved seats?";
                titleBarText = this.CancelSeatsMode ? "Reserve Seats" : "Cancel Seats";

                if (MessageBox.Show(message, titleBarText, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.CancelSeatsMode = !this.CancelSeatsMode;
                    btnCancelSeats.Text = this.CancelSeatsMode ? "Reserve" : "Cancel Seats";
                    foreach (Control item in tableLayoutSeatSelector.Controls)
                    {
                        if (item is Button)
                        {
                            item.Enabled = !item.Enabled;
                            if (this._listOfSelectedSeats.Contains(item.Name))
                                item.BackColor = Color.White;
                        }
                    }
                    this._listOfSelectedSeats = new List<string> { };
                    this._numberOfSelectedSeats = 0;
                    labelNoOfSeatsValue.Text = "0";
                    labelTotalAmountValue.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }
    }
}
