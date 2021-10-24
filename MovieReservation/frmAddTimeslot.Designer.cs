
namespace MovieReservation
{
    partial class frmAddTimeslot
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panelLabelNewValue = new System.Windows.Forms.Panel();
            this.labelEnterNewValue = new System.Windows.Forms.Label();
            this.panelTxtBoxNewValue = new System.Windows.Forms.Panel();
            this.pickerNewTimeslot = new System.Windows.Forms.DateTimePicker();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelLabelNewValue.SuspendLayout();
            this.panelTxtBoxNewValue.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(213, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 44);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(32, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(125, 44);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelLabelNewValue
            // 
            this.panelLabelNewValue.Controls.Add(this.labelEnterNewValue);
            this.panelLabelNewValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabelNewValue.Location = new System.Drawing.Point(0, 0);
            this.panelLabelNewValue.Name = "panelLabelNewValue";
            this.panelLabelNewValue.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panelLabelNewValue.Size = new System.Drawing.Size(364, 34);
            this.panelLabelNewValue.TabIndex = 5;
            // 
            // labelEnterNewValue
            // 
            this.labelEnterNewValue.AutoSize = true;
            this.labelEnterNewValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEnterNewValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnterNewValue.Location = new System.Drawing.Point(0, 5);
            this.labelEnterNewValue.Name = "labelEnterNewValue";
            this.labelEnterNewValue.Size = new System.Drawing.Size(208, 25);
            this.labelEnterNewValue.TabIndex = 0;
            this.labelEnterNewValue.Text = "Enter the new timeslot:";
            // 
            // panelTxtBoxNewValue
            // 
            this.panelTxtBoxNewValue.Controls.Add(this.pickerNewTimeslot);
            this.panelTxtBoxNewValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTxtBoxNewValue.Location = new System.Drawing.Point(0, 34);
            this.panelTxtBoxNewValue.Name = "panelTxtBoxNewValue";
            this.panelTxtBoxNewValue.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.panelTxtBoxNewValue.Size = new System.Drawing.Size(364, 46);
            this.panelTxtBoxNewValue.TabIndex = 6;
            // 
            // pickerNewTimeslot
            // 
            this.pickerNewTimeslot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickerNewTimeslot.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerNewTimeslot.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.pickerNewTimeslot.Location = new System.Drawing.Point(5, 5);
            this.pickerNewTimeslot.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.pickerNewTimeslot.Name = "pickerNewTimeslot";
            this.pickerNewTimeslot.ShowUpDown = true;
            this.pickerNewTimeslot.Size = new System.Drawing.Size(354, 30);
            this.pickerNewTimeslot.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnOK);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 80);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(364, 51);
            this.panelButtons.TabIndex = 7;
            // 
            // frmAddTimeslot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 131);
            this.ControlBox = false;
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTxtBoxNewValue);
            this.Controls.Add(this.panelLabelNewValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddTimeslot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Timeslot";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAddTimeslot_Load);
            this.panelLabelNewValue.ResumeLayout(false);
            this.panelLabelNewValue.PerformLayout();
            this.panelTxtBoxNewValue.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panelLabelNewValue;
        private System.Windows.Forms.Label labelEnterNewValue;
        private System.Windows.Forms.Panel panelTxtBoxNewValue;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.DateTimePicker pickerNewTimeslot;
    }
}