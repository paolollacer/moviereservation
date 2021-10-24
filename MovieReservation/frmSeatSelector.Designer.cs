
namespace MovieReservation
{
    partial class frmSeatSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeatSelector));
            this.picBoxPoster = new System.Windows.Forms.PictureBox();
            this.labelMovieTitle = new System.Windows.Forms.Label();
            this.labelTimeslot = new System.Windows.Forms.Label();
            this.panelMovieTimeslot = new System.Windows.Forms.Panel();
            this.panelCustomerTxtBox = new System.Windows.Forms.Panel();
            this.textBoxCustomerName = new System.Windows.Forms.TextBox();
            this.panelCustomerName = new System.Windows.Forms.Panel();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTotalAmountValue = new System.Windows.Forms.Label();
            this.labelNoOfSeatsValue = new System.Windows.Forms.Label();
            this.labelTicketPriceValue = new System.Windows.Forms.Label();
            this.labelTotalAmt = new System.Windows.Forms.Label();
            this.labelTicketPrice = new System.Windows.Forms.Label();
            this.labelNoOfSeatSelected = new System.Windows.Forms.Label();
            this.panelTimeslot = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelPoster = new System.Windows.Forms.Panel();
            this.panelSeatSelector = new System.Windows.Forms.Panel();
            this.tableLayoutSeatSelector = new System.Windows.Forms.TableLayoutPanel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelConfirmationMain = new System.Windows.Forms.Panel();
            this.panelCancelSeatsButton = new System.Windows.Forms.Panel();
            this.btnCancelSeats = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnProceed = new System.Windows.Forms.Button();
            this.panelScreenMain = new System.Windows.Forms.Panel();
            this.tableLayoutScreen = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPoster)).BeginInit();
            this.panelMovieTimeslot.SuspendLayout();
            this.panelCustomerTxtBox.SuspendLayout();
            this.panelCustomerName.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTimeslot.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panelPoster.SuspendLayout();
            this.panelSeatSelector.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelConfirmationMain.SuspendLayout();
            this.panelCancelSeatsButton.SuspendLayout();
            this.panelScreenMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoxPoster
            // 
            this.picBoxPoster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxPoster.BackgroundImage")));
            this.picBoxPoster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxPoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxPoster.Location = new System.Drawing.Point(10, 10);
            this.picBoxPoster.Name = "picBoxPoster";
            this.picBoxPoster.Size = new System.Drawing.Size(163, 253);
            this.picBoxPoster.TabIndex = 25;
            this.picBoxPoster.TabStop = false;
            // 
            // labelMovieTitle
            // 
            this.labelMovieTitle.AutoSize = true;
            this.labelMovieTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelMovieTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMovieTitle.Location = new System.Drawing.Point(0, 5);
            this.labelMovieTitle.Name = "labelMovieTitle";
            this.labelMovieTitle.Size = new System.Drawing.Size(87, 39);
            this.labelMovieTitle.TabIndex = 28;
            this.labelMovieTitle.Text = "Title";
            // 
            // labelTimeslot
            // 
            this.labelTimeslot.AutoSize = true;
            this.labelTimeslot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTimeslot.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeslot.Location = new System.Drawing.Point(0, 8);
            this.labelTimeslot.Name = "labelTimeslot";
            this.labelTimeslot.Size = new System.Drawing.Size(117, 31);
            this.labelTimeslot.TabIndex = 29;
            this.labelTimeslot.Text = "Timeslot";
            // 
            // panelMovieTimeslot
            // 
            this.panelMovieTimeslot.AutoSize = true;
            this.panelMovieTimeslot.Controls.Add(this.panelCustomerTxtBox);
            this.panelMovieTimeslot.Controls.Add(this.panelCustomerName);
            this.panelMovieTimeslot.Controls.Add(this.tableLayoutPanel1);
            this.panelMovieTimeslot.Controls.Add(this.panelTimeslot);
            this.panelMovieTimeslot.Controls.Add(this.panelTitle);
            this.panelMovieTimeslot.Controls.Add(this.panelPoster);
            this.panelMovieTimeslot.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMovieTimeslot.Location = new System.Drawing.Point(0, 0);
            this.panelMovieTimeslot.Name = "panelMovieTimeslot";
            this.panelMovieTimeslot.Size = new System.Drawing.Size(973, 273);
            this.panelMovieTimeslot.TabIndex = 32;
            // 
            // panelCustomerTxtBox
            // 
            this.panelCustomerTxtBox.Controls.Add(this.textBoxCustomerName);
            this.panelCustomerTxtBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCustomerTxtBox.Location = new System.Drawing.Point(183, 230);
            this.panelCustomerTxtBox.Name = "panelCustomerTxtBox";
            this.panelCustomerTxtBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panelCustomerTxtBox.Size = new System.Drawing.Size(790, 43);
            this.panelCustomerTxtBox.TabIndex = 44;
            // 
            // textBoxCustomerName
            // 
            this.textBoxCustomerName.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustomerName.Location = new System.Drawing.Point(5, 0);
            this.textBoxCustomerName.MaxLength = 50;
            this.textBoxCustomerName.Name = "textBoxCustomerName";
            this.textBoxCustomerName.Size = new System.Drawing.Size(312, 30);
            this.textBoxCustomerName.TabIndex = 39;
            // 
            // panelCustomerName
            // 
            this.panelCustomerName.Controls.Add(this.labelCustomerName);
            this.panelCustomerName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCustomerName.Location = new System.Drawing.Point(183, 199);
            this.panelCustomerName.Name = "panelCustomerName";
            this.panelCustomerName.Size = new System.Drawing.Size(790, 31);
            this.panelCustomerName.TabIndex = 43;
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerName.Location = new System.Drawing.Point(0, 0);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(160, 25);
            this.labelCustomerName.TabIndex = 38;
            this.labelCustomerName.Text = "Customer Name:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.20356F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.79644F));
            this.tableLayoutPanel1.Controls.Add(this.labelTotalAmountValue, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelNoOfSeatsValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTicketPriceValue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTotalAmt, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelTicketPrice, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelNoOfSeatSelected, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(183, 83);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(790, 116);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // labelTotalAmountValue
            // 
            this.labelTotalAmountValue.AutoSize = true;
            this.labelTotalAmountValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTotalAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalAmountValue.Location = new System.Drawing.Point(320, 76);
            this.labelTotalAmountValue.Name = "labelTotalAmountValue";
            this.labelTotalAmountValue.Size = new System.Drawing.Size(54, 40);
            this.labelTotalAmountValue.TabIndex = 40;
            this.labelTotalAmountValue.Text = "0.00";
            this.labelTotalAmountValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelNoOfSeatsValue
            // 
            this.labelNoOfSeatsValue.AutoSize = true;
            this.labelNoOfSeatsValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelNoOfSeatsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoOfSeatsValue.Location = new System.Drawing.Point(320, 38);
            this.labelNoOfSeatsValue.Name = "labelNoOfSeatsValue";
            this.labelNoOfSeatsValue.Size = new System.Drawing.Size(23, 38);
            this.labelNoOfSeatsValue.TabIndex = 39;
            this.labelNoOfSeatsValue.Text = "0";
            this.labelNoOfSeatsValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTicketPriceValue
            // 
            this.labelTicketPriceValue.AutoSize = true;
            this.labelTicketPriceValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTicketPriceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTicketPriceValue.Location = new System.Drawing.Point(320, 0);
            this.labelTicketPriceValue.Name = "labelTicketPriceValue";
            this.labelTicketPriceValue.Size = new System.Drawing.Size(23, 38);
            this.labelTicketPriceValue.TabIndex = 38;
            this.labelTicketPriceValue.Text = "0";
            this.labelTicketPriceValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTotalAmt
            // 
            this.labelTotalAmt.AutoSize = true;
            this.labelTotalAmt.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTotalAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalAmt.Location = new System.Drawing.Point(123, 76);
            this.labelTotalAmt.Name = "labelTotalAmt";
            this.labelTotalAmt.Size = new System.Drawing.Size(191, 40);
            this.labelTotalAmt.TabIndex = 0;
            this.labelTotalAmt.Text = "TOTAL AMOUNT:";
            // 
            // labelTicketPrice
            // 
            this.labelTicketPrice.AutoSize = true;
            this.labelTicketPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTicketPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTicketPrice.Location = new System.Drawing.Point(194, 0);
            this.labelTicketPrice.Name = "labelTicketPrice";
            this.labelTicketPrice.Size = new System.Drawing.Size(120, 38);
            this.labelTicketPrice.TabIndex = 37;
            this.labelTicketPrice.Text = "Ticket Price:";
            // 
            // labelNoOfSeatSelected
            // 
            this.labelNoOfSeatSelected.AutoSize = true;
            this.labelNoOfSeatSelected.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelNoOfSeatSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoOfSeatSelected.Location = new System.Drawing.Point(26, 38);
            this.labelNoOfSeatSelected.Name = "labelNoOfSeatSelected";
            this.labelNoOfSeatSelected.Padding = new System.Windows.Forms.Padding(100, 0, 0, 0);
            this.labelNoOfSeatSelected.Size = new System.Drawing.Size(288, 38);
            this.labelNoOfSeatSelected.TabIndex = 1;
            this.labelNoOfSeatSelected.Text = "# of Seats Selected:";
            // 
            // panelTimeslot
            // 
            this.panelTimeslot.Controls.Add(this.labelTimeslot);
            this.panelTimeslot.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTimeslot.Location = new System.Drawing.Point(183, 44);
            this.panelTimeslot.Name = "panelTimeslot";
            this.panelTimeslot.Size = new System.Drawing.Size(790, 39);
            this.panelTimeslot.TabIndex = 36;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.labelMovieTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(183, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(790, 44);
            this.panelTitle.TabIndex = 35;
            // 
            // panelPoster
            // 
            this.panelPoster.Controls.Add(this.picBoxPoster);
            this.panelPoster.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPoster.Location = new System.Drawing.Point(0, 0);
            this.panelPoster.Name = "panelPoster";
            this.panelPoster.Padding = new System.Windows.Forms.Padding(10);
            this.panelPoster.Size = new System.Drawing.Size(183, 273);
            this.panelPoster.TabIndex = 34;
            // 
            // panelSeatSelector
            // 
            this.panelSeatSelector.Controls.Add(this.tableLayoutSeatSelector);
            this.panelSeatSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSeatSelector.Location = new System.Drawing.Point(0, 342);
            this.panelSeatSelector.Name = "panelSeatSelector";
            this.panelSeatSelector.Padding = new System.Windows.Forms.Padding(100, 0, 100, 20);
            this.panelSeatSelector.Size = new System.Drawing.Size(973, 307);
            this.panelSeatSelector.TabIndex = 33;
            // 
            // tableLayoutSeatSelector
            // 
            this.tableLayoutSeatSelector.BackColor = System.Drawing.Color.White;
            this.tableLayoutSeatSelector.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutSeatSelector.ColumnCount = 20;
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutSeatSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSeatSelector.Location = new System.Drawing.Point(100, 0);
            this.tableLayoutSeatSelector.Name = "tableLayoutSeatSelector";
            this.tableLayoutSeatSelector.RowCount = 10;
            this.tableLayoutSeatSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutSeatSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutSeatSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutSeatSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutSeatSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutSeatSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutSeatSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutSeatSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutSeatSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutSeatSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutSeatSelector.Size = new System.Drawing.Size(773, 287);
            this.tableLayoutSeatSelector.TabIndex = 33;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelSeatSelector);
            this.panelMain.Controls.Add(this.panelConfirmationMain);
            this.panelMain.Controls.Add(this.panelScreenMain);
            this.panelMain.Controls.Add(this.panelMovieTimeslot);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(973, 709);
            this.panelMain.TabIndex = 33;
            // 
            // panelConfirmationMain
            // 
            this.panelConfirmationMain.Controls.Add(this.panelCancelSeatsButton);
            this.panelConfirmationMain.Controls.Add(this.btnBack);
            this.panelConfirmationMain.Controls.Add(this.btnProceed);
            this.panelConfirmationMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelConfirmationMain.Location = new System.Drawing.Point(0, 649);
            this.panelConfirmationMain.Name = "panelConfirmationMain";
            this.panelConfirmationMain.Size = new System.Drawing.Size(973, 60);
            this.panelConfirmationMain.TabIndex = 35;
            // 
            // panelCancelSeatsButton
            // 
            this.panelCancelSeatsButton.Controls.Add(this.btnCancelSeats);
            this.panelCancelSeatsButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelCancelSeatsButton.Location = new System.Drawing.Point(698, 0);
            this.panelCancelSeatsButton.Name = "panelCancelSeatsButton";
            this.panelCancelSeatsButton.Size = new System.Drawing.Size(275, 60);
            this.panelCancelSeatsButton.TabIndex = 3;
            // 
            // btnCancelSeats
            // 
            this.btnCancelSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelSeats.Location = new System.Drawing.Point(19, 6);
            this.btnCancelSeats.Name = "btnCancelSeats";
            this.btnCancelSeats.Size = new System.Drawing.Size(190, 44);
            this.btnCancelSeats.TabIndex = 4;
            this.btnCancelSeats.Text = "Cancel Seats";
            this.btnCancelSeats.UseVisualStyleBackColor = true;
            this.btnCancelSeats.Click += new System.EventHandler(this.buttonCancelSeats_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(397, 26);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 44);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnProceed
            // 
            this.btnProceed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.Location = new System.Drawing.Point(206, 26);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(140, 44);
            this.btnProceed.TabIndex = 1;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // panelScreenMain
            // 
            this.panelScreenMain.Controls.Add(this.tableLayoutScreen);
            this.panelScreenMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelScreenMain.Location = new System.Drawing.Point(0, 273);
            this.panelScreenMain.Name = "panelScreenMain";
            this.panelScreenMain.Size = new System.Drawing.Size(973, 69);
            this.panelScreenMain.TabIndex = 34;
            // 
            // tableLayoutScreen
            // 
            this.tableLayoutScreen.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutScreen.ColumnCount = 1;
            this.tableLayoutScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutScreen.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutScreen.Name = "tableLayoutScreen";
            this.tableLayoutScreen.Padding = new System.Windows.Forms.Padding(100, 10, 100, 20);
            this.tableLayoutScreen.RowCount = 1;
            this.tableLayoutScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutScreen.Size = new System.Drawing.Size(973, 69);
            this.tableLayoutScreen.TabIndex = 1;
            // 
            // frmSeatSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 709);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSeatSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSeatSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPoster)).EndInit();
            this.panelMovieTimeslot.ResumeLayout(false);
            this.panelCustomerTxtBox.ResumeLayout(false);
            this.panelCustomerTxtBox.PerformLayout();
            this.panelCustomerName.ResumeLayout(false);
            this.panelCustomerName.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelTimeslot.ResumeLayout(false);
            this.panelTimeslot.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelPoster.ResumeLayout(false);
            this.panelSeatSelector.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelConfirmationMain.ResumeLayout(false);
            this.panelCancelSeatsButton.ResumeLayout(false);
            this.panelScreenMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picBoxPoster;
        private System.Windows.Forms.Label labelMovieTitle;
        private System.Windows.Forms.Label labelTimeslot;
        private System.Windows.Forms.Panel panelMovieTimeslot;
        private System.Windows.Forms.Panel panelSeatSelector;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTimeslot;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelPoster;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSeatSelector;
        private System.Windows.Forms.Panel panelConfirmationMain;
        private System.Windows.Forms.Panel panelScreenMain;
        private System.Windows.Forms.Label labelTicketPrice;
        private System.Windows.Forms.Label labelTotalAmt;
        private System.Windows.Forms.Label labelNoOfSeatSelected;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.TextBox textBoxCustomerName;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutScreen;
        private System.Windows.Forms.Panel panelCustomerName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelCustomerTxtBox;
        private System.Windows.Forms.Label labelTotalAmountValue;
        private System.Windows.Forms.Label labelNoOfSeatsValue;
        private System.Windows.Forms.Label labelTicketPriceValue;
        private System.Windows.Forms.Button btnCancelSeats;
        private System.Windows.Forms.Panel panelCancelSeatsButton;
    }
}

