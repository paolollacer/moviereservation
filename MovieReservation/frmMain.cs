using MovieReservation.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieReservation
{
    public partial class frmMain : Form
    {
        private classMovie movie1;
        private classMovie movie2;
        private classMovie movie3;

        public frmMain()
        {
            InitializeComponent();
            InitializeCinemas();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            int label_XPosition;

            try
            {
                label_XPosition = (panelWelcome.Size.Width - labelWelcome.Size.Width) / 2;
                labelWelcome.Location = new Point(label_XPosition, labelWelcome.Location.Y);

                comBoxTimeslots1.SelectedItem = comBoxTimeslots1.Items[0];
                comBoxTimeslots2.SelectedItem = comBoxTimeslots2.Items[0];
                comBoxTimeslots3.SelectedItem = comBoxTimeslots3.Items[0];
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

        private void btnBookSeats1_Click(object sender, EventArgs e)
        {
            classMovieTimeslot movieTimeslot;

            try
            {
                if (string.IsNullOrWhiteSpace(comBoxTimeslots1.Text))
                {
                    MessageBox.Show("Please select a valid Timeslot first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                movieTimeslot = movie1.getListOfMovieTimeslots().Where(x => x.getTimeslot() == comBoxTimeslots1.Text).FirstOrDefault();
                movieTimeslot.setMovieTitle(movie1.getMovieTitle());
                movieTimeslot.setTicketPrice(Convert.ToDecimal(labelTicketValue1.Text));
                this.CreateNewReservation(movieTimeslot);
            }
            catch(Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void btnBookSeats2_Click(object sender, EventArgs e)
        {
            classMovieTimeslot movieTimeslot;

            try
            {
                if (string.IsNullOrWhiteSpace(comBoxTimeslots2.Text))
                {
                    MessageBox.Show("Please select a valid Timeslot first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                movieTimeslot = movie2.getListOfMovieTimeslots().Where(x => x.getTimeslot() == comBoxTimeslots2.Text).FirstOrDefault();
                movieTimeslot.setMovieTitle(movie2.getMovieTitle());
                movieTimeslot.setTicketPrice(Convert.ToDecimal(labelTicketValue2.Text));
                this.CreateNewReservation(movieTimeslot);
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void btnBookSeats3_Click(object sender, EventArgs e)
        {
            classMovieTimeslot movieTimeslot;

            try
            {
                if (string.IsNullOrWhiteSpace(comBoxTimeslots3.Text))
                {
                    MessageBox.Show("Please select a valid Timeslot first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                movieTimeslot = movie3.getListOfMovieTimeslots().Where(x => x.getTimeslot() == comBoxTimeslots3.Text).FirstOrDefault();
                movieTimeslot.setMovieTitle(movie3.getMovieTitle());
                movieTimeslot.setTicketPrice(Convert.ToDecimal(labelTicketValue3.Text));
                this.CreateNewReservation(movieTimeslot);
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void CreateNewReservation(classMovieTimeslot movieTimeslot)
        {
            List<string> selectedSeats;
            frmSeatSelector movieSeatSelectorForm;

            try
            {
                if (DateTime.Now > DateTime.Parse(movieTimeslot.getTimeslot()))
                    MessageBox.Show("Movie has already started. You can no longer add more seats for this timeslot.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                movieSeatSelectorForm = new frmSeatSelector(movieTimeslot);
                movieSeatSelectorForm.DrawSeatSelector();
                this.Hide();

                movieSeatSelectorForm.Visible = false;
                movieSeatSelectorForm.ShowDialog();

                if (movieSeatSelectorForm.IsReservationSuccessful)
                {
                    selectedSeats = movieSeatSelectorForm.GetListOfSelectedSeats();
                    foreach (string seats in selectedSeats)
                    {
                        if (movieSeatSelectorForm.CancelSeatsMode)
                            movieTimeslot.getListOfReservedSeats().Remove(seats);
                        else
                            movieTimeslot.getListOfReservedSeats().Add(seats);
                    }

                    switch(movieTimeslot.getCinemaId())
                    {
                        case 1:
                            labelSeatsValue1.Text = (180 - movieTimeslot.getListOfReservedSeats().Count()).ToString();
                            break;

                        case 2:
                            labelSeatsValue2.Text = (180 - movieTimeslot.getListOfReservedSeats().Count()).ToString();
                            break;

                        case 3:
                            labelSeatsValue3.Text = (180 - movieTimeslot.getListOfReservedSeats().Count()).ToString();
                            break;

                        default:
                            break;
                    }
                }

                this.Show();
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void InitializeCinemas()
        {
            string sqlQuery;
            string cinemaNumber;
            long nextTableId;
            functionMySQL mySQLfunction;
            functionMSSQL microsoftSQLfunction;
            DataTable cinemaInfoDataTable;
            DataTable movieTimeslotDataTable;
            DataTable reservedSeatsDataTable;
            DateTime tempDateTime;
            classMovieTimeslot classMovieTimeslot;
            bool setDatabase;
            
            try
            {
                movie1 = new classMovie();
                movie2 = new classMovie();
                movie3 = new classMovie();
                nextTableId = 0;
                mySQLfunction = new functionMySQL();
                microsoftSQLfunction = new functionMSSQL();

                for (int cinemaId = 1; cinemaId <= 3; cinemaId += 1)
                {
                    sqlQuery = @"SELECT C.`table_id` as `cinema_id`, C.`movietitle_id`, C.`ticketprice`, C.`poster_filepath`
                                FROM cinema as C
                                WHERE C.`table_id` in (" + cinemaId + ")";
                    
                    if (classGlobalVariables.MSSQLMode)
                    {
                        if (functionMSSQL.getFromDatabase(sqlQuery).Rows.Count <= 0)
                        {
                            sqlQuery = $"INSERT INTO `cinema` (`table_id`,`movietitle_id`,`ticketprice`,`poster_filepath`) VALUES (@cinemaId,100000000001,0,'')";
                            functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>() { ["@cinemaId"] = cinemaId.ToString() });
                        }
                    }
                    else if (functionMySQL.getFromDatabase(sqlQuery).Rows.Count <= 0)
                    {
                        sqlQuery = $"INSERT INTO `cinema` (`table_id`,`movietitle_id`,`ticketprice`,`poster_filepath`) VALUES (@cinemaId,100000000001,0,'')";
                        functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>() { ["@cinemaId"] = cinemaId.ToString() });
                    }

                    sqlQuery = @"SELECT M.`table_id`
                                FROM movietitle as M
                                LEFT JOIN cinema as C ON M.`table_id` = C.`movietitle_id`
                                WHERE C.`table_id` in (" + cinemaId + ")";
                                        
                    if (classGlobalVariables.MSSQLMode)
                    {
                        nextTableId = classGlobalVariables.MSSQLMode? microsoftSQLfunction.getNextTableId("movietitle") : mySQLfunction.getNextTableId("movietitle");
                        if (functionMSSQL.getFromDatabase(sqlQuery).Rows.Count == 1)
                        {
                            sqlQuery = $"UPDATE `movietitle` SET `movietitle`='Movie Title {cinemaId.ToString()}' WHERE `table_id`={nextTableId}";
                            functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>()
                            {
                                ["@nextTableId"] = nextTableId.ToString()
                            });
                        }
                    }
                    else if (functionMySQL.getFromDatabase(sqlQuery).Rows.Count <= 0)
                    {
                        nextTableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("movietitle") : mySQLfunction.getNextTableId("movietitle");
                        sqlQuery = $"UPDATE `movietitle` SET `movietitle`='Movie Title {cinemaId.ToString()}' WHERE `table_id`={nextTableId}";
                        functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>()
                        {
                            ["@nextTableId"] = nextTableId.ToString()
                        });
                    }
                }

                sqlQuery = @"SELECT C.`table_id` as `cinema_id`, C.`movietitle_id`, V.`movietitle`, C.`ticketprice`, C.`poster_filepath`
                                FROM cinema as C
                                LEFT JOIN movietitle as V ON V.`table_id` = C.`movietitle_id`
                                WHERE C.`table_id` in (1,2,3)";
                if (classGlobalVariables.MSSQLMode)
                {
                    cinemaInfoDataTable = functionMSSQL.getFromDatabase(sqlQuery);
                    if (cinemaInfoDataTable.Rows.Count <= 0)
                        return;
                }
                else
                {
                    cinemaInfoDataTable = functionMySQL.getFromDatabase(sqlQuery);
                    if (cinemaInfoDataTable.Rows.Count <= 0)
                        return;
                }
                

                foreach (DataRow row in cinemaInfoDataTable.Rows)
                {
                    cinemaNumber = row["cinema_id"].ToString();
                    sqlQuery = @"SELECT S.`table_id` as `movietimeslot_id`, S.`timeslot`
                                            FROM movietimeslot as S
                                            LEFT JOIN cinema as C ON C.`table_id` = S.`cinema_id`
                                            WHERE S.`cinema_id` in (" + cinemaNumber + ")" +
                                            " AND C.`movietitle_id` = S.`movietitle_id`" +
                                            " AND S.`isremoved`=0";
                    movieTimeslotDataTable = classGlobalVariables.MSSQLMode ? functionMSSQL.getFromDatabase(sqlQuery) : 
                                             functionMySQL.getFromDatabase(sqlQuery);

                    switch (cinemaNumber)
                    {
                        case "1":
                            movie1.setCinemaId(cinemaNumber);
                            movie1.setMovieId((long)Convert.ToDecimal(row["movietitle_id"].ToString()));
                            movie1.setMovieName(row["movietitle"].ToString());
                            movie1.setTicketPrice(Convert.ToDecimal(row["ticketprice"].ToString()));

                            labelMovieTitle1.Text = movie1.getMovieTitle().ToUpper();
                            labelTicketValue1.Text = movie1.getTicketPrice().ToString("N2");
                            if (File.Exists(row["poster_filepath"].ToString()))
                            {
                                picBoxPoster1.BackgroundImage = new Bitmap(row["poster_filepath"].ToString());
                                movie1.setMoviePosterPath(row["poster_filepath"].ToString());
                            }

                            if (movieTimeslotDataTable.Rows.Count <= 0)
                            {
                                tempDateTime = DateTime.Today.Date + TimeSpan.Parse("01:00:00");
                                for (int index = 0; index < 5; index += 1)
                                {
                                    nextTableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("movietimeslot") : mySQLfunction.getNextTableId("movietimeslot");
                                    sqlQuery = $"UPDATE `movietimeslot` SET `movietitle_id`= @movietitle_id," +
                                               $"`cinema_id`= @cinemaId," +
                                               $"`timeslot`= @timeslot WHERE `table_id`= @nextTableId";
                                    setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                    {
                                        ["@movietitle_id"] = movie1.getMovieId().ToString(),
                                        ["@cinemaId"] = movie1.getCinemaId().ToString(),
                                        ["@timeslot"] = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                        ["@nextTableId"] = nextTableId.ToString()
                                    }) : functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                    {
                                        ["@movietitle_id"] = movie1.getMovieId().ToString(),
                                        ["@cinemaId"] = movie1.getCinemaId().ToString(),
                                        ["@timeslot"] = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                        ["@nextTableId"] = nextTableId.ToString()
                                    });

                                    classMovieTimeslot = new classMovieTimeslot();
                                    classMovieTimeslot.setId(nextTableId);
                                    classMovieTimeslot.setTimeslot(tempDateTime.ToString("hh:mm tt"));
                                    classMovieTimeslot.setCinemaId(1);
                                    classMovieTimeslot.setMovieTitle(labelMovieTitle1.Text);
                                    classMovieTimeslot.setTicketPrice(movie1.getTicketPrice());
                                    classMovieTimeslot.setMoviePosterFilePath(movie1.getMoviePosterPath());

                                    movie1.getListOfMovieTimeslots().Add(classMovieTimeslot);
                                    comBoxTimeslots1.Items.Add(classMovieTimeslot.getTimeslot());
                                    tempDateTime = tempDateTime.AddHours(1);
                                }

                                break;
                            }

                            foreach (DataRow timeslotRow in movieTimeslotDataTable.Rows)
                            {
                                classMovieTimeslot = new classMovieTimeslot();
                                classMovieTimeslot.setId((long)Convert.ToDecimal(timeslotRow["movietimeslot_id"].ToString()));
                                classMovieTimeslot.setTimeslot(DateTime.Parse(timeslotRow["timeslot"].ToString()).ToString("hh:mm tt"));
                                classMovieTimeslot.setCinemaId(1);
                                classMovieTimeslot.setMovieTitle(labelMovieTitle1.Text);
                                classMovieTimeslot.setTicketPrice(movie1.getTicketPrice());
                                classMovieTimeslot.setMoviePosterFilePath(movie1.getMoviePosterPath());

                                sqlQuery = @"SELECT D.`seatnumber`
                                            FROM transactiondetail as D
                                            LEFT JOIN " + (classGlobalVariables.MSSQLMode ? "[transaction]" : "transaction") + @" as T ON D.`transaction_id` = T.`table_id`
                                            WHERE T.`movietimeslot_id` in (" + classMovieTimeslot.getId() + 
                                            ") AND D.`iscancelled` = 0";

                                reservedSeatsDataTable = classGlobalVariables.MSSQLMode ? functionMSSQL.getFromDatabase(sqlQuery) :
                                                         functionMySQL.getFromDatabase(sqlQuery);
                                if (reservedSeatsDataTable.Rows.Count > 0)
                                {
                                    foreach (DataRow seat in reservedSeatsDataTable.Rows)
                                    {
                                        sqlQuery = @"SELECT D.`seatnumber`
                                            FROM transactiondetail as D
                                            LEFT JOIN " + (classGlobalVariables.MSSQLMode ? "[transaction]" : "transaction") + @" as T ON D.`transaction_id` = T.`table_id`
                                            WHERE T.`movietimeslot_id` in (" + classMovieTimeslot.getId() +
                                            ") AND D.`seatnumber`='" + seat["seatnumber"].ToString() + "' AND D.`iscancelled` = 1";

                                        if (classGlobalVariables.MSSQLMode)
                                        {
                                            if (functionMSSQL.getFromDatabase(sqlQuery).Rows.Count <= 0)
                                                classMovieTimeslot.getListOfReservedSeats().Add(seat["seatnumber"].ToString());
                                        }
                                        else if (functionMySQL.getFromDatabase(sqlQuery).Rows.Count <= 0)
                                            classMovieTimeslot.getListOfReservedSeats().Add(seat["seatnumber"].ToString());
                                    }
                                }

                                movie1.getListOfMovieTimeslots().Add(classMovieTimeslot);
                                comBoxTimeslots1.Items.Add(classMovieTimeslot.getTimeslot());
                            }

                            if (comBoxTimeslots1.Items.Count >= 5)                            
                                break;

                            tempDateTime = DateTime.Parse(movie1.getListOfMovieTimeslots().LastOrDefault().getTimeslot());
                            for (int index = (5 - movieTimeslotDataTable.Rows.Count); comBoxTimeslots1.Items.Count < 5; index += 1)
                            {
                                tempDateTime = tempDateTime.AddHours(1);
                                nextTableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("movietimeslot") : mySQLfunction.getNextTableId("movietimeslot");
                                sqlQuery = $"UPDATE `movietimeslot` SET `movietitle_id`= @movietitle_id," +
                                           $"`cinema_id`= @cinemaId," +
                                           $"`timeslot`= @timeslot WHERE `table_id`= @nextTableId";
                                setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@movietitle_id"] = movie1.getMovieId().ToString(),
                                    ["@cinemaId"] = movie1.getCinemaId().ToString(),
                                    ["@timeslot"] = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@nextTableId"] = nextTableId.ToString()
                                }) : functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@movietitle_id"] = movie1.getMovieId().ToString(),
                                    ["@cinemaId"] = movie1.getCinemaId().ToString(),
                                    ["@timeslot"] = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@nextTableId"] = nextTableId.ToString()
                                });

                                classMovieTimeslot = new classMovieTimeslot();
                                classMovieTimeslot.setId(nextTableId);
                                classMovieTimeslot.setTimeslot(tempDateTime.ToString("hh:mm tt"));
                                classMovieTimeslot.setCinemaId(1);
                                classMovieTimeslot.setMovieTitle(labelMovieTitle1.Text);
                                classMovieTimeslot.setTicketPrice(movie1.getTicketPrice());
                                classMovieTimeslot.setMoviePosterFilePath(movie1.getMoviePosterPath());

                                movie1.getListOfMovieTimeslots().Add(classMovieTimeslot);
                                comBoxTimeslots1.Items.Add(classMovieTimeslot.getTimeslot());
                            }

                            break;

                        case "2":
                            movie2.setCinemaId(cinemaNumber);
                            movie2.setMovieId((long)Convert.ToDecimal(row["movietitle_id"].ToString()));
                            movie2.setMovieName(row["movietitle"].ToString());
                            movie2.setTicketPrice(Convert.ToDecimal(row["ticketprice"].ToString()));

                            labelMovieTitle2.Text = movie2.getMovieTitle().ToUpper();
                            labelTicketValue2.Text = movie2.getTicketPrice().ToString("N2");
                            if (File.Exists(row["poster_filepath"].ToString()))
                            {
                                picBoxPoster2.BackgroundImage = new Bitmap(row["poster_filepath"].ToString());
                                movie2.setMoviePosterPath(row["poster_filepath"].ToString());
                            }

                            if (movieTimeslotDataTable.Rows.Count <= 0)
                            {
                                tempDateTime = DateTime.Today.Date + TimeSpan.Parse("01:00:00");
                                for (int index = 0; index < 5; index += 1)
                                {
                                    nextTableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("movietimeslot") : mySQLfunction.getNextTableId("movietimeslot");
                                    sqlQuery = $"UPDATE `movietimeslot` SET `movietitle_id`= @movietitle_id," +
                                               $"`cinema_id`= @cinemaId," +
                                               $"`timeslot`= @timeslot WHERE `table_id`= @nextTableId";
                                    setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                    {
                                        ["@movietitle_id"] = movie2.getMovieId().ToString(),
                                        ["@cinemaId"] = movie2.getCinemaId().ToString(),
                                        ["@timeslot"] = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                        ["@nextTableId"] = nextTableId.ToString()
                                    }) : functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                    {
                                        ["@movietitle_id"] = movie2.getMovieId().ToString(),
                                        ["@cinemaId"] = movie2.getCinemaId().ToString(),
                                        ["@timeslot"] = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                        ["@nextTableId"] = nextTableId.ToString()
                                    });

                                    classMovieTimeslot = new classMovieTimeslot();
                                    classMovieTimeslot.setId(nextTableId);
                                    classMovieTimeslot.setTimeslot(tempDateTime.ToString("hh:mm tt"));
                                    classMovieTimeslot.setCinemaId(2);
                                    classMovieTimeslot.setMovieTitle(labelMovieTitle2.Text);
                                    classMovieTimeslot.setTicketPrice(movie2.getTicketPrice());
                                    classMovieTimeslot.setMoviePosterFilePath(movie2.getMoviePosterPath());

                                    movie2.getListOfMovieTimeslots().Add(classMovieTimeslot);
                                    comBoxTimeslots2.Items.Add(classMovieTimeslot.getTimeslot());
                                    tempDateTime = tempDateTime.AddHours(1);
                                }

                                break;
                            }

                            foreach (DataRow timeslotRow in movieTimeslotDataTable.Rows)
                            {                                
                                classMovieTimeslot = new classMovieTimeslot();
                                classMovieTimeslot.setId((long)Convert.ToDecimal(timeslotRow["movietimeslot_id"].ToString()));
                                classMovieTimeslot.setTimeslot(DateTime.Parse(timeslotRow["timeslot"].ToString()).ToString("hh:mm tt"));
                                classMovieTimeslot.setCinemaId(2);
                                classMovieTimeslot.setMovieTitle(labelMovieTitle2.Text);
                                classMovieTimeslot.setTicketPrice(movie2.getTicketPrice());
                                classMovieTimeslot.setMoviePosterFilePath(movie2.getMoviePosterPath());

                                sqlQuery = @"SELECT D.`seatnumber`
                                            FROM transactiondetail as D
                                            LEFT JOIN " + (classGlobalVariables.MSSQLMode ? "[transaction]" : "transaction") + @" as T ON D.`transaction_id` = T.`table_id`
                                            WHERE T.`movietimeslot_id` in (" + classMovieTimeslot.getId() +
                                            ") AND D.`iscancelled` = 0";

                                reservedSeatsDataTable =  classGlobalVariables.MSSQLMode ? functionMSSQL.getFromDatabase(sqlQuery) :
                                                          functionMySQL.getFromDatabase(sqlQuery);
                                if (reservedSeatsDataTable.Rows.Count > 0)
                                {
                                    foreach (DataRow seat in reservedSeatsDataTable.Rows)
                                    {
                                        sqlQuery = @"SELECT D.`seatnumber`
                                            FROM transactiondetail as D
                                            LEFT JOIN " + (classGlobalVariables.MSSQLMode ? "[transaction]" : "transaction") + @" as T ON D.`transaction_id` = T.`table_id`
                                            WHERE T.`movietimeslot_id` in (" + classMovieTimeslot.getId() +
                                            ") AND D.`seatnumber`='" + seat["seatnumber"].ToString() + "' AND D.`iscancelled` = 1";

                                        if (classGlobalVariables.MSSQLMode)
                                        {
                                            if (functionMSSQL.getFromDatabase(sqlQuery).Rows.Count <= 0)
                                                classMovieTimeslot.getListOfReservedSeats().Add(seat["seatnumber"].ToString());
                                        }
                                        else if (functionMySQL.getFromDatabase(sqlQuery).Rows.Count <= 0)
                                            classMovieTimeslot.getListOfReservedSeats().Add(seat["seatnumber"].ToString());
                                    }
                                }

                                movie2.getListOfMovieTimeslots().Add(classMovieTimeslot);
                                comBoxTimeslots2.Items.Add(classMovieTimeslot.getTimeslot());
                            }

                            if (comBoxTimeslots2.Items.Count >= 5)
                                break;

                            tempDateTime = DateTime.Parse(movie2.getListOfMovieTimeslots().LastOrDefault().getTimeslot());
                            for (int index = (5 - movieTimeslotDataTable.Rows.Count); comBoxTimeslots2.Items.Count < 5; index += 1)
                            {
                                tempDateTime = tempDateTime.AddHours(1);
                                nextTableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("movietimeslot") : mySQLfunction.getNextTableId("movietimeslot");
                                sqlQuery = $"UPDATE `movietimeslot` SET `movietitle_id`= @movietitle_id," +
                                           $"`cinema_id`= @cinemaId," +
                                           $"`timeslot`= @timeslot WHERE `table_id`= @nextTableId";
                                setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@movietitle_id"] = movie2.getMovieId().ToString(),
                                    ["@cinemaId"] = movie2.getCinemaId().ToString(),
                                    ["@timeslot"] = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@nextTableId"] = nextTableId.ToString()
                                }) : functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@movietitle_id"] = movie2.getMovieId().ToString(),
                                    ["@cinemaId"] = movie2.getCinemaId().ToString(),
                                    ["@timeslot"] = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@nextTableId"] = nextTableId.ToString()
                                });

                                classMovieTimeslot = new classMovieTimeslot();
                                classMovieTimeslot.setId(nextTableId);
                                classMovieTimeslot.setTimeslot(tempDateTime.ToString("hh:mm tt"));
                                classMovieTimeslot.setCinemaId(2);
                                classMovieTimeslot.setMovieTitle(labelMovieTitle2.Text);
                                classMovieTimeslot.setTicketPrice(movie2.getTicketPrice());
                                classMovieTimeslot.setMoviePosterFilePath(movie2.getMoviePosterPath());

                                movie2.getListOfMovieTimeslots().Add(classMovieTimeslot);
                                comBoxTimeslots2.Items.Add(classMovieTimeslot.getTimeslot());
                            }

                            break;

                        case "3":
                            movie3.setCinemaId(cinemaNumber);
                            movie3.setMovieId((long)Convert.ToDecimal(row["movietitle_id"].ToString()));
                            movie3.setMovieName(row["movietitle"].ToString());
                            movie3.setTicketPrice(Convert.ToDecimal(row["ticketprice"].ToString()));

                            labelMovieTitle3.Text = movie3.getMovieTitle().ToUpper();
                            labelTicketValue3.Text = movie3.getTicketPrice().ToString("N2");
                            if (File.Exists(row["poster_filepath"].ToString()))
                            {
                                picBoxPoster3.BackgroundImage = new Bitmap(row["poster_filepath"].ToString());
                                movie3.setMoviePosterPath(row["poster_filepath"].ToString());
                            }

                            if (movieTimeslotDataTable.Rows.Count <= 0)
                            {
                                tempDateTime = DateTime.Today.Date + TimeSpan.Parse("01:00:00");
                                for (int index = 0; index < 5; index += 1)
                                {
                                    nextTableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("movietimeslot") : mySQLfunction.getNextTableId("movietimeslot");
                                    sqlQuery = $"UPDATE `movietimeslot` SET `movietitle_id`= @movietitle_id," +
                                               $"`cinema_id`= @cinemaId," +
                                               $"`timeslot`= @timeslot WHERE `table_id`= @nextTableId";
                                    setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                    {
                                        ["@movietitle_id"] = movie3.getMovieId().ToString(),
                                        ["@cinemaId"] = movie3.getCinemaId().ToString(),
                                        ["@timeslot"] = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                        ["@nextTableId"] = nextTableId.ToString()
                                    }) : functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                    {
                                        ["@movietitle_id"] = movie3.getMovieId().ToString(),
                                        ["@cinemaId"] = movie3.getCinemaId().ToString(),
                                        ["@timeslot"] = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                        ["@nextTableId"] = nextTableId.ToString()
                                    });

                                    classMovieTimeslot = new classMovieTimeslot();
                                    classMovieTimeslot.setId(nextTableId);
                                    classMovieTimeslot.setTimeslot(tempDateTime.ToString("hh:mm tt"));
                                    classMovieTimeslot.setCinemaId(3);
                                    classMovieTimeslot.setMovieTitle(labelMovieTitle3.Text);
                                    classMovieTimeslot.setTicketPrice(movie3.getTicketPrice());
                                    classMovieTimeslot.setMoviePosterFilePath(movie3.getMoviePosterPath());

                                    movie3.getListOfMovieTimeslots().Add(classMovieTimeslot);
                                    comBoxTimeslots3.Items.Add(classMovieTimeslot.getTimeslot());
                                    tempDateTime = tempDateTime.AddHours(1);
                                }

                                break;
                            }

                            foreach (DataRow timeslotRow in movieTimeslotDataTable.Rows)
                            {                                
                                classMovieTimeslot = new classMovieTimeslot();
                                classMovieTimeslot.setId((long)Convert.ToDecimal(timeslotRow["movietimeslot_id"].ToString()));
                                classMovieTimeslot.setTimeslot(DateTime.Parse(timeslotRow["timeslot"].ToString()).ToString("hh:mm tt"));
                                classMovieTimeslot.setCinemaId(3);
                                classMovieTimeslot.setMovieTitle(labelMovieTitle3.Text);
                                classMovieTimeslot.setTicketPrice(movie3.getTicketPrice());
                                classMovieTimeslot.setMoviePosterFilePath(movie3.getMoviePosterPath());

                                sqlQuery = @"SELECT D.`seatnumber`
                                            FROM transactiondetail as D
                                            LEFT JOIN " + (classGlobalVariables.MSSQLMode ? "[transaction]" : "transaction") + @" as T ON D.`transaction_id` = T.`table_id`
                                            WHERE T.`movietimeslot_id` in (" + classMovieTimeslot.getId() +
                                            ") AND D.`iscancelled` = 0";

                                reservedSeatsDataTable = classGlobalVariables.MSSQLMode ? functionMSSQL.getFromDatabase(sqlQuery) :
                                                         functionMySQL.getFromDatabase(sqlQuery);
                                if (reservedSeatsDataTable.Rows.Count > 0)
                                {
                                    foreach (DataRow seat in reservedSeatsDataTable.Rows)
                                    {
                                        sqlQuery = @"SELECT D.`seatnumber`
                                            FROM transactiondetail as D
                                            LEFT JOIN " + (classGlobalVariables.MSSQLMode ? "[transaction]" : "transaction") + @" as T ON D.`transaction_id` = T.`table_id`
                                            WHERE T.`movietimeslot_id` in (" + classMovieTimeslot.getId() +
                                            ") AND D.`seatnumber`='" + seat["seatnumber"].ToString() + "' AND D.`iscancelled` = 1";

                                        if (classGlobalVariables.MSSQLMode)
                                        {
                                            if (functionMSSQL.getFromDatabase(sqlQuery).Rows.Count <= 0)
                                                classMovieTimeslot.getListOfReservedSeats().Add(seat["seatnumber"].ToString());
                                        }
                                        else if (functionMySQL.getFromDatabase(sqlQuery).Rows.Count <= 0)
                                            classMovieTimeslot.getListOfReservedSeats().Add(seat["seatnumber"].ToString());
                                    }
                                }

                                movie3.getListOfMovieTimeslots().Add(classMovieTimeslot);
                                comBoxTimeslots3.Items.Add(classMovieTimeslot.getTimeslot());
                            }

                            if (comBoxTimeslots3.Items.Count >= 5)
                                break;

                            tempDateTime = DateTime.Parse(movie3.getListOfMovieTimeslots().LastOrDefault().getTimeslot());
                            for (int index = (5 - movieTimeslotDataTable.Rows.Count); comBoxTimeslots3.Items.Count < 5; index += 1)
                            {
                                tempDateTime = tempDateTime.AddHours(1);
                                nextTableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("movietimeslot") : mySQLfunction.getNextTableId("movietimeslot");
                                sqlQuery = $"UPDATE `movietimeslot` SET `movietitle_id`= @movietitle_id," +
                                           $"`cinema_id`= @cinemaId," +
                                           $"`timeslot`= @timeslot WHERE `table_id`= @nextTableId";
                                setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@movietitle_id"] = movie3.getMovieId().ToString(),
                                    ["@cinemaId"] = movie3.getCinemaId().ToString(),
                                    ["@timeslot"] = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@nextTableId"] = nextTableId.ToString()
                                }) : functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@movietitle_id"] = movie3.getMovieId().ToString(),
                                    ["@cinemaId"] = movie3.getCinemaId().ToString(),
                                    ["@timeslot"] = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@nextTableId"] = nextTableId.ToString()
                                });

                                classMovieTimeslot = new classMovieTimeslot();
                                classMovieTimeslot.setId(nextTableId);
                                classMovieTimeslot.setTimeslot(tempDateTime.ToString("hh:mm tt"));
                                classMovieTimeslot.setCinemaId(3);
                                classMovieTimeslot.setMovieTitle(labelMovieTitle3.Text);
                                classMovieTimeslot.setTicketPrice(movie3.getTicketPrice());
                                classMovieTimeslot.setMoviePosterFilePath(movie3.getMoviePosterPath());

                                movie3.getListOfMovieTimeslots().Add(classMovieTimeslot);
                                comBoxTimeslots3.Items.Add(classMovieTimeslot.getTimeslot());
                            }

                            break;

                        default:
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void picBoxPoster1_DoubleClick(object sender, EventArgs e)
        {
            ConfirmNewPosterChange(1);
        }

        private void picBoxPoster2_DoubleClick(object sender, EventArgs e)
        {
            ConfirmNewPosterChange(2);
        }

        private void picBoxPoster3_DoubleClick(object sender, EventArgs e)
        {
            ConfirmNewPosterChange(3);
        }

        private void comBoxTimeslots1_SelectedIndexChanged(object sender, EventArgs e)
        {
            classMovieTimeslot item = movie1.getListOfMovieTimeslots().Where(x => x.getTimeslot() == comBoxTimeslots1.Text).FirstOrDefault();
            if (item != null)
                labelSeatsValue1.Text = (180 - item.getListOfReservedSeats().Count()).ToString();
        }

        private void comBoxTimeslots2_SelectedIndexChanged(object sender, EventArgs e)
        {
            classMovieTimeslot item = movie2.getListOfMovieTimeslots().Where(x => x.getTimeslot() == comBoxTimeslots2.Text).FirstOrDefault();
            if (item != null)
                labelSeatsValue2.Text = (180 - item.getListOfReservedSeats().Count()).ToString();
        }

        private void comBoxTimeslots3_SelectedIndexChanged(object sender, EventArgs e)
        {
            classMovieTimeslot item = movie3.getListOfMovieTimeslots().Where(x => x.getTimeslot() == comBoxTimeslots3.Text).FirstOrDefault();
            if (item != null)
                labelSeatsValue3.Text = (180 - item.getListOfReservedSeats().Count()).ToString();
        }

        private void ConfirmNewPosterChange(int cinemaNumber)
        {
            string sqlQuery;
            bool setDatabase;
            try
            {
                if (MessageBox.Show("Do you want to change the displayed poster?", "Change Movie Poster", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG|All files (*.*)|*.*";
                openFileDialog.ShowDialog();

                switch (cinemaNumber)
                {
                    case 1:
                        picBoxPoster1.BackgroundImage = new Bitmap(openFileDialog.FileName);
                        movie1.setMoviePosterPath(openFileDialog.FileName);
                        foreach(classMovieTimeslot movie1_timeslot in movie1.getListOfMovieTimeslots())
                            movie1_timeslot.setMoviePosterFilePath(openFileDialog.FileName);
                        break;
                    case 2:
                        picBoxPoster2.BackgroundImage = new Bitmap(openFileDialog.FileName);
                        movie2.setMoviePosterPath(openFileDialog.FileName);
                        foreach (classMovieTimeslot movie2_timeslot in movie2.getListOfMovieTimeslots())
                            movie2_timeslot.setMoviePosterFilePath(openFileDialog.FileName);
                        break;
                    case 3:
                        picBoxPoster3.BackgroundImage = new Bitmap(openFileDialog.FileName);
                        movie3.setMoviePosterPath(openFileDialog.FileName);
                        foreach (classMovieTimeslot movie3_timeslot in movie3.getListOfMovieTimeslots())
                            movie3_timeslot.setMoviePosterFilePath(openFileDialog.FileName);
                        break;
                    default:
                        break;
                }

                sqlQuery = @"UPDATE `cinema` set `poster_filepath`= @poster WHERE `table_id`= @cinemaId ";
                setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string> 
                              {
                                    ["@poster"] = openFileDialog.FileName,
                                    ["@cinemaId"] = cinemaNumber.ToString()
                              }) :
                              functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                              {
                                  ["@poster"] = openFileDialog.FileName,
                                  ["@cinemaId"] = cinemaNumber.ToString()
                              });
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void labelTicketValue1_DoubleClick(object sender, EventArgs e)
        {
            ChangeTicketPrice(1);
        }

        private void labelTicketValue2_DoubleClick(object sender, EventArgs e)
        {
            ChangeTicketPrice(2);
        }

        private void labelTicketValue3_Click(object sender, EventArgs e)
        {
            ChangeTicketPrice(3);
        }

        private void ChangeTicketPrice(int cinemaId)
        {
            string sqlQuery;
            bool setDatabase;

            try
            {
                sqlQuery = "";

                if (MessageBox.Show($"Do you want to change the ticket price of Cinema {cinemaId}?", "Change Ticket Price", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

                frmChangeValue changeForm = new frmChangeValue();
                changeForm.Text = "Change Ticket Price";
                changeForm.ShowDialog();

                if (changeForm.Decision)
                {
                    sqlQuery = $"UPDATE `cinema` SET `ticketprice`= @ticketprice WHERE `table_id`= @cinemaId ";
                    setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string> 
                                {
                                    ["@ticketprice"] = changeForm.NewValue,
                                    ["@cinemaId"] = cinemaId.ToString()
                                }) : functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@ticketprice"] = changeForm.NewValue,
                                    ["@cinemaId"] = cinemaId.ToString()
                                });

                    switch (cinemaId)
                    {
                        case 1:
                            labelTicketValue1.Text = Convert.ToDecimal(changeForm.NewValue).ToString("N2");
                            break;
                        case 2:
                            labelTicketValue2.Text = Convert.ToDecimal(changeForm.NewValue).ToString("N2");
                            break;
                        case 3:
                            labelTicketValue3.Text = Convert.ToDecimal(changeForm.NewValue).ToString("N2");
                            break;
                        default:
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void labelMovieTitle1_DoubleClick(object sender, EventArgs e)
        {
            ChangeMovieTitle(1);
        }

        private void labelMovieTitle2_DoubleClick(object sender, EventArgs e)
        {
            ChangeMovieTitle(2);
        }

        private void labelMovieTitle3_DoubleClick(object sender, EventArgs e)
        {
            ChangeMovieTitle(3);
        }

        private void ChangeMovieTitle(int cinemaId)
        {
            string sqlQuery;
            long nextTableId;
            functionMySQL mySQLfunction;
            functionMSSQL microsoftSQLfunction;
            bool setDatabase;
            classMovieTimeslot movieTimeslot;
            DateTime time;

            try
            {
                sqlQuery = "";
                nextTableId = 0;
                mySQLfunction = new functionMySQL();
                microsoftSQLfunction = new functionMSSQL();

                if (MessageBox.Show($"Do you want to change the Movie Title in Cinema {cinemaId}?", "Change Movie Title", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

                frmChangeValue changeForm = new frmChangeValue();
                changeForm.Text = "Change Movie Title";
                changeForm.ShowDialog();

                if (changeForm.Decision)
                {
                    nextTableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("movietitle") :
                                  mySQLfunction.getNextTableId("movietitle");

                    sqlQuery = $"UPDATE `movietitle` SET `movietitle`= @movieTitle WHERE `table_id`= @tableId";
                    setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string> 
                                  {
                                        ["@movieTitle"] = changeForm.NewValue,
                                        ["@tableId"] = nextTableId.ToString()
                                  }) :
                                  functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                  {
                                      ["@movieTitle"] = changeForm.NewValue,
                                      ["@tableId"] = nextTableId.ToString()
                                  });

                    sqlQuery = $"UPDATE `cinema` SET `movietitle_id`= @movieTitleId WHERE `table_id`= @tableId ";
                    setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                  {
                                        ["@movieTitleId"] = nextTableId.ToString(),
                                        ["@tableId"] = cinemaId.ToString(),
                                  }) :
                                  functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                  {
                                      ["@movieTitleId"] = nextTableId.ToString(),
                                      ["@tableId"] = cinemaId.ToString(),
                                  });

                    switch (cinemaId)
                    {
                        case 1:
                            labelMovieTitle1.Text = changeForm.NewValue.ToUpper();
                            movie1.setMovieId(nextTableId);
                            movie1.setMovieName(changeForm.NewValue);
                            movie1.getListOfMovieTimeslots().Clear();
                            comBoxTimeslots1.Items.Clear();

                            time = DateTime.Today.Date + new TimeSpan(1, 0, 0);
                            for (int index = 0; index < 5; index += 1)
                            {
                                nextTableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("movietimeslot") :
                                              mySQLfunction.getNextTableId("movietimeslot");

                                sqlQuery = $"UPDATE `movietimeslot` SET `movietitle_id`= @movietitle_id," +
                                           $"`cinema_id`= @cinemaId," +
                                           $"`timeslot`= @timeslot WHERE `table_id`= @nextTableId";
                                setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@movietitle_id"] = movie1.getMovieId().ToString(),
                                    ["@cinemaId"] = cinemaId.ToString(),
                                    ["@timeslot"] = time.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@nextTableId"] = nextTableId.ToString()
                                }) : functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@movietitle_id"] = movie1.getMovieId().ToString(),
                                    ["@cinemaId"] = cinemaId.ToString(),
                                    ["@timeslot"] = time.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@nextTableId"] = nextTableId.ToString()
                                });

                                movieTimeslot = new classMovieTimeslot();
                                movieTimeslot.setId(nextTableId);
                                movieTimeslot.setTimeslot(time.ToString("hh:mm tt"));
                                movieTimeslot.setCinemaId(1);
                                movieTimeslot.setMovieTitle(labelMovieTitle1.Text);
                                movieTimeslot.setTicketPrice(movie1.getTicketPrice());
                                movieTimeslot.setMoviePosterFilePath(movie1.getMoviePosterPath());

                                movie1.getListOfMovieTimeslots().Add(movieTimeslot);
                                comBoxTimeslots1.Items.Add(movieTimeslot.getTimeslot());
                                time = time.AddHours(1);
                            }

                            labelSeatsValue1.Text = "180";
                            comBoxTimeslots1.SelectedIndex = 0;
                            break;

                        case 2:
                            labelMovieTitle2.Text = changeForm.NewValue.ToUpper();
                            movie2.setMovieId(nextTableId);
                            movie2.setMovieName(changeForm.NewValue);
                            movie2.getListOfMovieTimeslots().Clear();
                            comBoxTimeslots2.Items.Clear();

                            time = DateTime.Today.Date + new TimeSpan(1, 0, 0);
                            for (int index = 0; index < 5; index += 1)
                            {
                                nextTableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("movietimeslot") :
                                              mySQLfunction.getNextTableId("movietimeslot");

                                sqlQuery = $"UPDATE `movietimeslot` SET `movietitle_id`= @movietitle_id," +
                                           $"`cinema_id`= @cinemaId," +
                                           $"`timeslot`= @timeslot WHERE `table_id`= @nextTableId";
                                setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@movietitle_id"] = movie2.getMovieId().ToString(),
                                    ["@cinemaId"] = cinemaId.ToString(),
                                    ["@timeslot"] = time.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@nextTableId"] = nextTableId.ToString()
                                }) : functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@movietitle_id"] = movie2.getMovieId().ToString(),
                                    ["@cinemaId"] = cinemaId.ToString(),
                                    ["@timeslot"] = time.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@nextTableId"] = nextTableId.ToString()
                                });

                                movieTimeslot = new classMovieTimeslot();
                                movieTimeslot.setId(nextTableId);
                                movieTimeslot.setTimeslot(time.ToString("hh:mm tt"));
                                movieTimeslot.setCinemaId(2);
                                movieTimeslot.setMovieTitle(labelMovieTitle2.Text);
                                movieTimeslot.setTicketPrice(movie2.getTicketPrice());
                                movieTimeslot.setMoviePosterFilePath(movie2.getMoviePosterPath());

                                movie2.getListOfMovieTimeslots().Add(movieTimeslot);
                                comBoxTimeslots2.Items.Add(movieTimeslot.getTimeslot());
                                time = time.AddHours(1);
                            }

                            labelSeatsValue2.Text = "180";
                            comBoxTimeslots2.SelectedIndex = 0;
                            break;

                        case 3:
                            labelMovieTitle3.Text = changeForm.NewValue.ToUpper();
                            movie3.setMovieId(nextTableId);
                            movie3.setMovieName(changeForm.NewValue);
                            movie3.getListOfMovieTimeslots().Clear();
                            comBoxTimeslots3.Items.Clear();

                            time = DateTime.Today.Date + new TimeSpan(1, 0, 0);
                            for (int index = 0; index < 5; index += 1)
                            {
                                nextTableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("movietimeslot") :
                                              mySQLfunction.getNextTableId("movietimeslot");

                                sqlQuery = $"UPDATE `movietimeslot` SET `movietitle_id`= @movietitle_id," +
                                           $"`cinema_id`= @cinemaId," +
                                           $"`timeslot`= @timeslot WHERE `table_id`= @nextTableId";
                                setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@movietitle_id"] = movie3.getMovieId().ToString(),
                                    ["@cinemaId"] = cinemaId.ToString(),
                                    ["@timeslot"] = time.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@nextTableId"] = nextTableId.ToString()
                                }) : functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                {
                                    ["@movietitle_id"] = movie3.getMovieId().ToString(),
                                    ["@cinemaId"] = cinemaId.ToString(),
                                    ["@timeslot"] = time.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ["@nextTableId"] = nextTableId.ToString()
                                });

                                movieTimeslot = new classMovieTimeslot();
                                movieTimeslot.setId(nextTableId);
                                movieTimeslot.setTimeslot(time.ToString("hh:mm tt"));
                                movieTimeslot.setCinemaId(3);
                                movieTimeslot.setMovieTitle(labelMovieTitle3.Text);
                                movieTimeslot.setTicketPrice(movie3.getTicketPrice());
                                movieTimeslot.setMoviePosterFilePath(movie3.getMoviePosterPath());

                                movie3.getListOfMovieTimeslots().Add(movieTimeslot);
                                comBoxTimeslots3.Items.Add(movieTimeslot.getTimeslot());
                                time = time.AddHours(1);
                            }

                            labelSeatsValue3.Text = "180";
                            comBoxTimeslots3.SelectedIndex = 0;
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void buttonAddTimeslot1_Click(object sender, EventArgs e)
        {
            AddNewTimeslot(1);
        }

        private void buttonAddTimeslot2_Click(object sender, EventArgs e)
        {
            AddNewTimeslot(2);
        }

        private void buttonAddTimeslot3_Click(object sender, EventArgs e)
        {
            AddNewTimeslot(3);
        }

        private void AddNewTimeslot(int cinemaId)
        {
            string sqlQuery;
            long nextTableId;
            classMovie movieTitle;
            classMovieTimeslot movieTimeslot;
            functionMySQL mySQLfunction;
            functionMSSQL microsoftSQLfunction;
            bool setDatabase;

            try
            {
                sqlQuery = "";
                nextTableId = 0;
                mySQLfunction = new functionMySQL();
                microsoftSQLfunction = new functionMSSQL();

                movieTitle = (cinemaId == 1) ? movie1 : 
                             (cinemaId == 2) ? movie2 : 
                             (cinemaId == 3) ? movie3: 
                             new classMovie();

                if (movieTitle.getMovieId() == 0)
                    return;

                frmAddTimeslot addForm = new frmAddTimeslot(movieTitle);
                addForm.ShowDialog();

                if (addForm.Decision)
                {
                    nextTableId = classGlobalVariables.MSSQLMode ? microsoftSQLfunction.getNextTableId("movietimeslot") :
                                  mySQLfunction.getNextTableId("movietimeslot");
                    sqlQuery = $"UPDATE `movietimeslot` SET `movietitle_id`= @movietitle_id," +
                               $"`cinema_id`= @cinemaId, `timeslot`= @timeslot " +
                               $"WHERE `table_id`= @nextTableId ";
                    setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                  {
                                        ["@movietitle_id"] = movieTitle.getMovieId().ToString(),
                                        ["@cinemaId"] = cinemaId.ToString(),
                                        ["@timeslot"] = DateTime.Parse(addForm.NewValue).ToString($"{DateTime.Now.Date.ToString("yyyy-MM-dd")} HH:mm:ss"),
                                        ["@nextTableId"] = nextTableId.ToString()
                                  }) : functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                  {
                                      ["@movietitle_id"] = movieTitle.getMovieId().ToString(),
                                      ["@cinemaId"] = cinemaId.ToString(),
                                      ["@timeslot"] = DateTime.Parse(addForm.NewValue).ToString($"{DateTime.Now.Date.ToString("yyyy-MM-dd")} HH:mm:ss"),
                                      ["@nextTableId"] = nextTableId.ToString()
                                  });

                    movieTimeslot = new classMovieTimeslot();
                    movieTimeslot.setId(nextTableId);
                    movieTimeslot.setCinemaId(cinemaId);
                    movieTimeslot.setMoviePosterFilePath(movieTitle.getMoviePosterPath());
                    movieTimeslot.setMovieTitle(movieTitle.getMovieTitle());
                    movieTimeslot.setTicketPrice(movieTitle.getTicketPrice());
                    movieTimeslot.setTimeslot(addForm.NewValue);
                    movieTitle.getListOfMovieTimeslots().Add(movieTimeslot);

                    switch (cinemaId)
                    {
                        case 1:
                            comBoxTimeslots1.Items.Add(addForm.NewValue);
                            break;
                        case 2:
                            comBoxTimeslots2.Items.Add(addForm.NewValue);
                            break;
                        case 3:
                            comBoxTimeslots3.Items.Add(addForm.NewValue);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void buttonRemoveTimeslot1_Click(object sender, EventArgs e)
        {
            RemoveTimeslot(1);
        }

        private void buttonRemoveTimeslot2_Click(object sender, EventArgs e)
        {
            RemoveTimeslot(2);
        }

        private void buttonRemoveTimeslot3_Click(object sender, EventArgs e)
        {
            RemoveTimeslot(3);
        }

        private void RemoveTimeslot(int cinemaId)
        {
            string sqlQuery;
            classMovie movieTitle;
            bool setDatabase;
            long removedTimeslotId;

            try
            {
                sqlQuery = "";
                removedTimeslotId = 0;

                movieTitle = (cinemaId == 1) ? movie1 :
                             (cinemaId == 2) ? movie2 :
                             (cinemaId == 3) ? movie3 :
                             new classMovie();

                if (movieTitle.getMovieId() == 0)
                    return;

                frmRemoveTimeslot removeForm = new frmRemoveTimeslot(movieTitle);
                removeForm.ShowDialog();

                if (removeForm.Decision)
                {
                    removedTimeslotId = removeForm.RemovedMovieTimeslotId;
                    sqlQuery = $"UPDATE `movietimeslot` SET `isremoved`= '1' WHERE `table_id`= @removedTimeslotId";
                    setDatabase = classGlobalVariables.MSSQLMode ? functionMSSQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                  { ["@removedTimeslotId"] = removedTimeslotId.ToString() }) : 
                                  functionMySQL.setDatabase(sqlQuery, new Dictionary<string, string>
                                  { ["@removedTimeslotId"] = removedTimeslotId.ToString() });

                    classMovieTimeslot removedMovieTimeslot = movieTitle.getListOfMovieTimeslots().Where(x => x.getId() == removedTimeslotId).FirstOrDefault();
                    movieTitle.removeMovieTimeslotFromList(removedMovieTimeslot);

                    switch (cinemaId)
                    {
                        case 1:
                            comBoxTimeslots1.Items.Remove(removedMovieTimeslot.getTimeslot());
                            comBoxTimeslots1.SelectedIndex = 0;
                            break;
                        case 2:
                            comBoxTimeslots2.Items.Remove(removedMovieTimeslot.getTimeslot());
                            comBoxTimeslots2.SelectedIndex = 0;
                            break;
                        case 3:
                            comBoxTimeslots3.Items.Remove(removedMovieTimeslot.getTimeslot());
                            comBoxTimeslots3.SelectedIndex = 0;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }

        private void btnViewHistory1_Click(object sender, EventArgs e)
        {
            ViewHistory(1);
        }

        private void btnViewHistory2_Click(object sender, EventArgs e)
        {
            ViewHistory(2);
        }

        private void btnViewHistory3_Click(object sender, EventArgs e)
        {
            ViewHistory(3);
        }

        private void ViewHistory(int cinemaId)
        {
            string sqlQuery;
            DataTable cinemaHistory;

            try
            {
                if (classGlobalVariables.MSSQLMode)
                    sqlQuery = @"SELECT T.date_of_transaction as ""Date of Transaction"", 
                                T.customername as ""Customer"", 
                                STUFF((
							      SELECT ',' + D.seatnumber
							      FROM transactiondetail D
							      WHERE T.table_id = D.transaction_id
							      FOR XML PATH('')), 1, 1, '') as ""Seat Number"", 
                                S.timeslot as ""Timeslot"", 
                                M.movietitle as ""Movie"",
                                IIF (D.iscancelled=1, 'Cancelled', IIF(CURRENT_TIMESTAMP > S.timeslot,'Used','Reserved')) as ""Status"" 
                                FROM [transaction] as T
                                LEFT JOIN movietimeslot as S ON T.movietimeslot_id = S.table_id
                                LEFT JOIN cinema as C ON S.cinema_id = C.table_id
                                LEFT JOIN transactiondetail as D ON T.table_id = D.transaction_id
                                LEFT JOIN movietitle as M on M.table_id=S.movietitle_id
                                WHERE C.table_id=" + cinemaId +
                                " GROUP BY T.table_id, T.date_of_transaction, T.customername, S.timeslot, M.movietitle, D.iscancelled";
                else
                    sqlQuery = @"SELECT T.`date_of_transaction` as `Date of Transaction`, 
                                T.`customername` as `Customer`, 
                                GROUP_CONCAT( D.`seatnumber`) as `Seat Number`, 
                                S.`timeslot` as `Timeslot`, 
                                M.`movietitle` as `Movie`,
                                IF (D.`iscancelled`=1, 'Cancelled', IF(NOW() > S.`timeslot`,'Used','Reserved')) as `Status` 
                                FROM `transaction` as T
                                LEFT JOIN `movietimeslot` as S ON T.`movietimeslot_id` = S.`table_id`
                                LEFT JOIN `cinema` as C ON S.`cinema_id` = C.`table_id`
                                LEFT JOIN `transactiondetail` as D ON T.`table_id` = D.`transaction_id`
                                LEFT JOIN `movietitle` as M on M.`table_id`=S.`movietitle_id`
                                WHERE C.`table_id`=" + cinemaId + 
                                " GROUP BY T.`table_id`";

                cinemaHistory = classGlobalVariables.MSSQLMode ? functionMSSQL.getFromDatabase(sqlQuery) :
                                functionMySQL.getFromDatabase(sqlQuery);

                if (cinemaHistory.Rows.Count <= 0)
                {
                    MessageBox.Show("No records to show", "View History", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; //no records to show
                }

                frmViewHistory historyForm = new frmViewHistory(cinemaHistory);
                historyForm.CinemaId = cinemaId;
                historyForm.ShowDialog();
                
                classMovie movie = cinemaId == 1 ? movie1 :
                                   cinemaId == 2 ? movie2 :
                                   cinemaId == 3 ? movie3 : new classMovie();

                Label seatsValue = cinemaId == 1 ? labelSeatsValue1 :
                                   cinemaId == 2 ? labelSeatsValue2 :
                                   cinemaId == 3 ? labelSeatsValue3 : null;

                if (historyForm.DoneClear)
                {
                    foreach(classMovieTimeslot movieTimeslot in movie.getListOfMovieTimeslots())
                    {
                        if (DateTime.Now < DateTime.Parse(movieTimeslot.getTimeslot()))
                            movieTimeslot.setListOfReservedSeats(new List<string> { });
                    }

                    if (seatsValue != null)
                        seatsValue.Text = "180";
                }

                return;
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                return;
            }
        }
    }
}
