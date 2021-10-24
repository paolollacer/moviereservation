using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservation.classes
{
    public class classMovieTimeslot
    {
        private long _movieTimeslotId;
        private long _cinemaId;
        private string _timeslot;
        private string _movieTitle;
        private decimal _ticketPrice;
        private string _moviePosterFilePath;
        private List<string> _reservedSeats;

        public classMovieTimeslot()
        {
            this._movieTimeslotId = 0;
            this._timeslot = "";
            this._movieTitle = "";
            this._cinemaId = 0;
            this._ticketPrice = 0;
            this._moviePosterFilePath = "";
            this._reservedSeats = new List<string> { };
        }

        public void setId(long movieTimeslotId) { this._movieTimeslotId = movieTimeslotId; }
        public long getId() { return this._movieTimeslotId; }
        public void setTimeslot(string timeslot) { this._timeslot = timeslot; }
        public string getTimeslot() { return this._timeslot; }
        public void setMovieTitle(string movieTitle) { this._movieTitle = movieTitle; }
        public string getMovieTitle() { return this._movieTitle; }
        public void setCinemaId(long cinemaId) { this._cinemaId = cinemaId; }
        public long getCinemaId() { return this._cinemaId; }
        public void setTicketPrice(decimal ticketPrice) { this._ticketPrice = ticketPrice; }
        public decimal getTicketPrice() { return this._ticketPrice; }
        public void setMoviePosterFilePath(string moviePosterFilePath) { this._moviePosterFilePath = moviePosterFilePath; }
        public string getMoviePosterFilePath() { return this._moviePosterFilePath; }
        public void setListOfReservedSeats(List<string> reservedSeats) { this._reservedSeats = reservedSeats; }
        public List<string> getListOfReservedSeats() { return this._reservedSeats; }
    }
}
