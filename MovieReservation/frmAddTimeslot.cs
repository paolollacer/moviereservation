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
    public partial class frmAddTimeslot : Form
    {
        public bool Decision;
        public string NewValue;
        private classMovie _movieTitle;

        public frmAddTimeslot(classMovie movieTitle)
        {
            InitializeComponent();
            this.Decision = false;
            this.NewValue = "";
            this._movieTitle = movieTitle;
        }

        private void frmAddTimeslot_Load(object sender, EventArgs e)
        {
            try
            {
                btnOK.Location = new Point((panelButtons.Width / 2) - btnOK.Width - 5, 0);
                btnCancel.Location = new Point((panelButtons.Width / 2) + 5, 0);

                pickerNewTimeslot.Value = DateTime.Now.Date + new TimeSpan(0,0,0);
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
                if (this._movieTitle.getListOfMovieTimeslots().Where(x => x.getTimeslot() == pickerNewTimeslot.Value.ToString("HH:mm tt")).FirstOrDefault() != null)
                {
                    MessageBox.Show($"Timeslot already exists. Please enter another timeslot", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"Proceed with adding new timeslot?", "Add New Timeslot", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

                this.Decision = true;
                this.NewValue = pickerNewTimeslot.Value.ToString("hh:mm tt");
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
