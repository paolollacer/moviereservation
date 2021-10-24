using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservation.classes
{
    public class classMovie
    {
        private long _movieId;
        private string _movieTitle;
        private string _moviePosterPath;
        private List<classMovieTimeslot> _listOfMovieTimeslots;
        private decimal _ticketPrice;
        private string _cinemaId;

        public classMovie()
        {
            this._movieId = 0;
            this._movieTitle = "";
            this._moviePosterPath = "";
            this._listOfMovieTimeslots = new List<classMovieTimeslot> { };
            this._ticketPrice = 0;
            this._cinemaId = "";
        }

        public void setMovieId(long movieId) { this._movieId = movieId; }
        public long getMovieId() { return this._movieId; }
        public void setMovieName(string movieTitle) { this._movieTitle = movieTitle; }
        public string getMovieTitle() { return this._movieTitle; }
        public void setMoviePosterPath(string moviePosterPath) { this._moviePosterPath = moviePosterPath; }
        public string getMoviePosterPath() { return this._moviePosterPath; }
        public void setListOfMovieTimeslots(List<classMovieTimeslot> listOfMovieTimeslots) { this._listOfMovieTimeslots = listOfMovieTimeslots; }
        public List<classMovieTimeslot> getListOfMovieTimeslots() { return this._listOfMovieTimeslots; }
        public void setTicketPrice(decimal ticketPrice) { this._ticketPrice = ticketPrice; }
        public decimal getTicketPrice() { return this._ticketPrice; }
        public void setCinemaId(string cinemaId) { this._cinemaId = cinemaId; }
        public string getCinemaId() { return this._cinemaId; }
        public void removeMovieTimeslotFromList(classMovieTimeslot movieTimeslot)
        {
            try
            {
                if (this._listOfMovieTimeslots.Contains(movieTimeslot))
                    this._listOfMovieTimeslots.Remove(movieTimeslot);
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
