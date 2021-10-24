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
    public partial class frmRemoveTimeslot : Form
    {
        public bool Decision;
        public long RemovedMovieTimeslotId;
        private classMovie _movieTitle;

        public frmRemoveTimeslot(classMovie movieTitle)
        {
            InitializeComponent();
            this.Decision = false;
            this.RemovedMovieTimeslotId = 0;
            this._movieTitle = movieTitle;
        }

        private void frmRemoveTimeslot_Load(object sender, EventArgs e)
        {
            try
            {
                btnOK.Location = new Point((panelButtons.Width / 2) - btnOK.Width - 5, 0);
                btnCancel.Location = new Point((panelButtons.Width / 2) + 5, 0);

                foreach(classMovieTimeslot movieTimeslot in this._movieTitle.getListOfMovieTimeslots())
                    this.comBoxTimeslot.Items.Add(movieTimeslot.getTimeslot());

                this.comBoxTimeslot.SelectedIndex = 0;
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
                if (comBoxTimeslot.Items.Count <= 5)
                {
                    MessageBox.Show($"Must maintain at least 5 timeslots per movie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"Proceed with removing timeslot '{this.comBoxTimeslot.SelectedItem.ToString()}'?", "Remove Timeslot", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

                if (MessageBox.Show($"Are you really sure to remove timeslot '{this.comBoxTimeslot.SelectedItem.ToString()}'? Any reserved seating for this timeslot will not be retrieved", "Remove Timeslot", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;

                this.Decision = true;
                this.RemovedMovieTimeslotId = this._movieTitle.getListOfMovieTimeslots().Where(x => x.getTimeslot() == this.comBoxTimeslot.SelectedItem.ToString()).FirstOrDefault().getId();
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
                if (MessageBox.Show($"Cancel remove timeslot?", "Remove Timeslot", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
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
