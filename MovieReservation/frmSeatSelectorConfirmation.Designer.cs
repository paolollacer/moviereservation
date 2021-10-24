
namespace MovieReservation
{
    partial class frmSeatSelectorConfirmation
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
            this.panelReviewPurchaseDetails = new System.Windows.Forms.Panel();
            this.labelReviewPurchaseDetails = new System.Windows.Forms.Label();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.tblLayoutPanel_Details = new System.Windows.Forms.TableLayoutPanel();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.labelTotalAmountValue = new System.Windows.Forms.Label();
            this.labelMovieName = new System.Windows.Forms.Label();
            this.labelTimeslot = new System.Windows.Forms.Label();
            this.labelSelectedSeats = new System.Windows.Forms.Label();
            this.labelNoOfSeats = new System.Windows.Forms.Label();
            this.labelTicketPrice = new System.Windows.Forms.Label();
            this.labelCustomerNameValue = new System.Windows.Forms.Label();
            this.labelMovieNameValue = new System.Windows.Forms.Label();
            this.labelTimeslotValue = new System.Windows.Forms.Label();
            this.labelSelectedSeatsValue = new System.Windows.Forms.Label();
            this.labelNoOfSeatsValue = new System.Windows.Forms.Label();
            this.labelTotalAmount = new System.Windows.Forms.Label();
            this.labelTicketPriceValue = new System.Windows.Forms.Label();
            this.panelConfirmPurchase = new System.Windows.Forms.Panel();
            this.labelConfirmPurchase = new System.Windows.Forms.Label();
            this.panelConfirmationButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panelReviewPurchaseDetails.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.tblLayoutPanel_Details.SuspendLayout();
            this.panelConfirmPurchase.SuspendLayout();
            this.panelConfirmationButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelReviewPurchaseDetails
            // 
            this.panelReviewPurchaseDetails.Controls.Add(this.labelReviewPurchaseDetails);
            this.panelReviewPurchaseDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelReviewPurchaseDetails.Location = new System.Drawing.Point(0, 0);
            this.panelReviewPurchaseDetails.Name = "panelReviewPurchaseDetails";
            this.panelReviewPurchaseDetails.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.panelReviewPurchaseDetails.Size = new System.Drawing.Size(800, 51);
            this.panelReviewPurchaseDetails.TabIndex = 0;
            // 
            // labelReviewPurchaseDetails
            // 
            this.labelReviewPurchaseDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelReviewPurchaseDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReviewPurchaseDetails.Location = new System.Drawing.Point(10, 10);
            this.labelReviewPurchaseDetails.Name = "labelReviewPurchaseDetails";
            this.labelReviewPurchaseDetails.Size = new System.Drawing.Size(325, 31);
            this.labelReviewPurchaseDetails.TabIndex = 0;
            this.labelReviewPurchaseDetails.Text = "Review Purchase Details:";
            this.labelReviewPurchaseDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.tblLayoutPanel_Details);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetails.Location = new System.Drawing.Point(0, 51);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new System.Windows.Forms.Padding(10);
            this.panelDetails.Size = new System.Drawing.Size(800, 316);
            this.panelDetails.TabIndex = 1;
            // 
            // tblLayoutPanel_Details
            // 
            this.tblLayoutPanel_Details.AutoSize = true;
            this.tblLayoutPanel_Details.BackColor = System.Drawing.Color.White;
            this.tblLayoutPanel_Details.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblLayoutPanel_Details.ColumnCount = 2;
            this.tblLayoutPanel_Details.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPanel_Details.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPanel_Details.Controls.Add(this.labelCustomerName, 0, 0);
            this.tblLayoutPanel_Details.Controls.Add(this.labelTotalAmountValue, 1, 6);
            this.tblLayoutPanel_Details.Controls.Add(this.labelMovieName, 0, 1);
            this.tblLayoutPanel_Details.Controls.Add(this.labelTimeslot, 0, 2);
            this.tblLayoutPanel_Details.Controls.Add(this.labelSelectedSeats, 0, 3);
            this.tblLayoutPanel_Details.Controls.Add(this.labelNoOfSeats, 0, 4);
            this.tblLayoutPanel_Details.Controls.Add(this.labelTicketPrice, 0, 5);
            this.tblLayoutPanel_Details.Controls.Add(this.labelCustomerNameValue, 1, 0);
            this.tblLayoutPanel_Details.Controls.Add(this.labelMovieNameValue, 1, 1);
            this.tblLayoutPanel_Details.Controls.Add(this.labelTimeslotValue, 1, 2);
            this.tblLayoutPanel_Details.Controls.Add(this.labelSelectedSeatsValue, 1, 3);
            this.tblLayoutPanel_Details.Controls.Add(this.labelNoOfSeatsValue, 1, 4);
            this.tblLayoutPanel_Details.Controls.Add(this.labelTotalAmount, 0, 6);
            this.tblLayoutPanel_Details.Controls.Add(this.labelTicketPriceValue, 1, 5);
            this.tblLayoutPanel_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutPanel_Details.Location = new System.Drawing.Point(10, 10);
            this.tblLayoutPanel_Details.Name = "tblLayoutPanel_Details";
            this.tblLayoutPanel_Details.RowCount = 7;
            this.tblLayoutPanel_Details.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanel_Details.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanel_Details.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanel_Details.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanel_Details.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanel_Details.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanel_Details.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanel_Details.Size = new System.Drawing.Size(780, 296);
            this.tblLayoutPanel_Details.TabIndex = 0;
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerName.Location = new System.Drawing.Point(232, 1);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(154, 41);
            this.labelCustomerName.TabIndex = 0;
            this.labelCustomerName.Text = "Customer Name";
            // 
            // labelTotalAmountValue
            // 
            this.labelTotalAmountValue.AutoSize = true;
            this.labelTotalAmountValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTotalAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalAmountValue.Location = new System.Drawing.Point(393, 253);
            this.labelTotalAmountValue.Name = "labelTotalAmountValue";
            this.labelTotalAmountValue.Size = new System.Drawing.Size(64, 42);
            this.labelTotalAmountValue.TabIndex = 13;
            this.labelTotalAmountValue.Text = "value";
            // 
            // labelMovieName
            // 
            this.labelMovieName.AutoSize = true;
            this.labelMovieName.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelMovieName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMovieName.Location = new System.Drawing.Point(321, 43);
            this.labelMovieName.Name = "labelMovieName";
            this.labelMovieName.Size = new System.Drawing.Size(65, 41);
            this.labelMovieName.TabIndex = 1;
            this.labelMovieName.Text = "Movie";
            // 
            // labelTimeslot
            // 
            this.labelTimeslot.AutoSize = true;
            this.labelTimeslot.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTimeslot.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeslot.Location = new System.Drawing.Point(300, 85);
            this.labelTimeslot.Name = "labelTimeslot";
            this.labelTimeslot.Size = new System.Drawing.Size(86, 41);
            this.labelTimeslot.TabIndex = 2;
            this.labelTimeslot.Text = "Timeslot";
            // 
            // labelSelectedSeats
            // 
            this.labelSelectedSeats.AutoSize = true;
            this.labelSelectedSeats.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelSelectedSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedSeats.Location = new System.Drawing.Point(241, 127);
            this.labelSelectedSeats.Name = "labelSelectedSeats";
            this.labelSelectedSeats.Size = new System.Drawing.Size(145, 41);
            this.labelSelectedSeats.TabIndex = 3;
            this.labelSelectedSeats.Text = "Selected Seats";
            // 
            // labelNoOfSeats
            // 
            this.labelNoOfSeats.AutoSize = true;
            this.labelNoOfSeats.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelNoOfSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoOfSeats.Location = new System.Drawing.Point(204, 169);
            this.labelNoOfSeats.Name = "labelNoOfSeats";
            this.labelNoOfSeats.Size = new System.Drawing.Size(182, 41);
            this.labelNoOfSeats.TabIndex = 4;
            this.labelNoOfSeats.Text = "# of Seats Selected";
            // 
            // labelTicketPrice
            // 
            this.labelTicketPrice.AutoSize = true;
            this.labelTicketPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTicketPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTicketPrice.Location = new System.Drawing.Point(272, 211);
            this.labelTicketPrice.Name = "labelTicketPrice";
            this.labelTicketPrice.Size = new System.Drawing.Size(114, 41);
            this.labelTicketPrice.TabIndex = 5;
            this.labelTicketPrice.Text = "Ticket Price";
            // 
            // labelCustomerNameValue
            // 
            this.labelCustomerNameValue.AutoSize = true;
            this.labelCustomerNameValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelCustomerNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerNameValue.Location = new System.Drawing.Point(393, 1);
            this.labelCustomerNameValue.Name = "labelCustomerNameValue";
            this.labelCustomerNameValue.Size = new System.Drawing.Size(59, 41);
            this.labelCustomerNameValue.TabIndex = 7;
            this.labelCustomerNameValue.Text = "value";
            // 
            // labelMovieNameValue
            // 
            this.labelMovieNameValue.AutoSize = true;
            this.labelMovieNameValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelMovieNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMovieNameValue.Location = new System.Drawing.Point(393, 43);
            this.labelMovieNameValue.Name = "labelMovieNameValue";
            this.labelMovieNameValue.Size = new System.Drawing.Size(59, 41);
            this.labelMovieNameValue.TabIndex = 8;
            this.labelMovieNameValue.Text = "value";
            // 
            // labelTimeslotValue
            // 
            this.labelTimeslotValue.AutoSize = true;
            this.labelTimeslotValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTimeslotValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeslotValue.Location = new System.Drawing.Point(393, 85);
            this.labelTimeslotValue.Name = "labelTimeslotValue";
            this.labelTimeslotValue.Size = new System.Drawing.Size(59, 41);
            this.labelTimeslotValue.TabIndex = 9;
            this.labelTimeslotValue.Text = "value";
            // 
            // labelSelectedSeatsValue
            // 
            this.labelSelectedSeatsValue.AutoSize = true;
            this.labelSelectedSeatsValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSelectedSeatsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedSeatsValue.Location = new System.Drawing.Point(393, 127);
            this.labelSelectedSeatsValue.Name = "labelSelectedSeatsValue";
            this.labelSelectedSeatsValue.Size = new System.Drawing.Size(383, 41);
            this.labelSelectedSeatsValue.TabIndex = 10;
            this.labelSelectedSeatsValue.Text = "value";
            // 
            // labelNoOfSeatsValue
            // 
            this.labelNoOfSeatsValue.AutoSize = true;
            this.labelNoOfSeatsValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelNoOfSeatsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoOfSeatsValue.Location = new System.Drawing.Point(393, 169);
            this.labelNoOfSeatsValue.Name = "labelNoOfSeatsValue";
            this.labelNoOfSeatsValue.Size = new System.Drawing.Size(59, 41);
            this.labelNoOfSeatsValue.TabIndex = 11;
            this.labelNoOfSeatsValue.Text = "value";
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.AutoSize = true;
            this.labelTotalAmount.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalAmount.Location = new System.Drawing.Point(202, 253);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Size = new System.Drawing.Size(184, 42);
            this.labelTotalAmount.TabIndex = 6;
            this.labelTotalAmount.Text = "TOTAL AMOUNT";
            // 
            // labelTicketPriceValue
            // 
            this.labelTicketPriceValue.AutoSize = true;
            this.labelTicketPriceValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTicketPriceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTicketPriceValue.Location = new System.Drawing.Point(393, 211);
            this.labelTicketPriceValue.Name = "labelTicketPriceValue";
            this.labelTicketPriceValue.Size = new System.Drawing.Size(59, 41);
            this.labelTicketPriceValue.TabIndex = 12;
            this.labelTicketPriceValue.Text = "value";
            // 
            // panelConfirmPurchase
            // 
            this.panelConfirmPurchase.Controls.Add(this.labelConfirmPurchase);
            this.panelConfirmPurchase.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConfirmPurchase.Location = new System.Drawing.Point(0, 367);
            this.panelConfirmPurchase.Name = "panelConfirmPurchase";
            this.panelConfirmPurchase.Size = new System.Drawing.Size(800, 37);
            this.panelConfirmPurchase.TabIndex = 2;
            // 
            // labelConfirmPurchase
            // 
            this.labelConfirmPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelConfirmPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfirmPurchase.Location = new System.Drawing.Point(0, -1);
            this.labelConfirmPurchase.Name = "labelConfirmPurchase";
            this.labelConfirmPurchase.Size = new System.Drawing.Size(216, 29);
            this.labelConfirmPurchase.TabIndex = 1;
            this.labelConfirmPurchase.Text = "Confirm Purchase?";
            this.labelConfirmPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelConfirmationButtons
            // 
            this.panelConfirmationButtons.Controls.Add(this.btnCancel);
            this.panelConfirmationButtons.Controls.Add(this.btnOK);
            this.panelConfirmationButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConfirmationButtons.Location = new System.Drawing.Point(0, 404);
            this.panelConfirmationButtons.Name = "panelConfirmationButtons";
            this.panelConfirmationButtons.Size = new System.Drawing.Size(800, 69);
            this.panelConfirmationButtons.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(398, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 44);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(207, 25);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(140, 44);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmSeatSelectorConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.ControlBox = false;
            this.Controls.Add(this.panelConfirmationButtons);
            this.Controls.Add(this.panelConfirmPurchase);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelReviewPurchaseDetails);
            this.MaximizeBox = false;
            this.Name = "frmSeatSelectorConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirm Reservation";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSeatSelectorConfirmation_Load);
            this.panelReviewPurchaseDetails.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.tblLayoutPanel_Details.ResumeLayout(false);
            this.tblLayoutPanel_Details.PerformLayout();
            this.panelConfirmPurchase.ResumeLayout(false);
            this.panelConfirmationButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelReviewPurchaseDetails;
        private System.Windows.Forms.Label labelReviewPurchaseDetails;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.TableLayoutPanel tblLayoutPanel_Details;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.Label labelMovieName;
        private System.Windows.Forms.Label labelTimeslot;
        private System.Windows.Forms.Label labelSelectedSeats;
        private System.Windows.Forms.Label labelNoOfSeats;
        private System.Windows.Forms.Label labelTicketPrice;
        private System.Windows.Forms.Label labelTotalAmount;
        private System.Windows.Forms.Panel panelConfirmPurchase;
        private System.Windows.Forms.Label labelConfirmPurchase;
        private System.Windows.Forms.Panel panelConfirmationButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label labelTotalAmountValue;
        private System.Windows.Forms.Label labelCustomerNameValue;
        private System.Windows.Forms.Label labelMovieNameValue;
        private System.Windows.Forms.Label labelTimeslotValue;
        private System.Windows.Forms.Label labelSelectedSeatsValue;
        private System.Windows.Forms.Label labelNoOfSeatsValue;
        private System.Windows.Forms.Label labelTicketPriceValue;
    }
}