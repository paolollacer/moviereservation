
namespace MovieReservation
{
    partial class frmRemoveTimeslot
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
            this.panelLabelRemoveTimeslot = new System.Windows.Forms.Panel();
            this.labelRemoveTimeslot = new System.Windows.Forms.Label();
            this.panelComboBoxTimeslot = new System.Windows.Forms.Panel();
            this.comBoxTimeslot = new System.Windows.Forms.ComboBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelLabelRemoveTimeslot.SuspendLayout();
            this.panelComboBoxTimeslot.SuspendLayout();
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
            // panelLabelRemoveTimeslot
            // 
            this.panelLabelRemoveTimeslot.Controls.Add(this.labelRemoveTimeslot);
            this.panelLabelRemoveTimeslot.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabelRemoveTimeslot.Location = new System.Drawing.Point(0, 0);
            this.panelLabelRemoveTimeslot.Name = "panelLabelRemoveTimeslot";
            this.panelLabelRemoveTimeslot.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panelLabelRemoveTimeslot.Size = new System.Drawing.Size(364, 34);
            this.panelLabelRemoveTimeslot.TabIndex = 5;
            // 
            // labelRemoveTimeslot
            // 
            this.labelRemoveTimeslot.AutoSize = true;
            this.labelRemoveTimeslot.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelRemoveTimeslot.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRemoveTimeslot.Location = new System.Drawing.Point(0, 5);
            this.labelRemoveTimeslot.Name = "labelRemoveTimeslot";
            this.labelRemoveTimeslot.Size = new System.Drawing.Size(258, 25);
            this.labelRemoveTimeslot.TabIndex = 0;
            this.labelRemoveTimeslot.Text = "Enter the timeslot to remove:";
            // 
            // panelComboBoxTimeslot
            // 
            this.panelComboBoxTimeslot.Controls.Add(this.comBoxTimeslot);
            this.panelComboBoxTimeslot.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelComboBoxTimeslot.Location = new System.Drawing.Point(0, 34);
            this.panelComboBoxTimeslot.Name = "panelComboBoxTimeslot";
            this.panelComboBoxTimeslot.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.panelComboBoxTimeslot.Size = new System.Drawing.Size(364, 46);
            this.panelComboBoxTimeslot.TabIndex = 6;
            // 
            // comBoxTimeslot
            // 
            this.comBoxTimeslot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comBoxTimeslot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoxTimeslot.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxTimeslot.FormattingEnabled = true;
            this.comBoxTimeslot.Location = new System.Drawing.Point(5, 5);
            this.comBoxTimeslot.Name = "comBoxTimeslot";
            this.comBoxTimeslot.Size = new System.Drawing.Size(354, 33);
            this.comBoxTimeslot.Sorted = true;
            this.comBoxTimeslot.TabIndex = 34;
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
            // frmRemoveTimeslot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 131);
            this.ControlBox = false;
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelComboBoxTimeslot);
            this.Controls.Add(this.panelLabelRemoveTimeslot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRemoveTimeslot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remove Timeslot";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmRemoveTimeslot_Load);
            this.panelLabelRemoveTimeslot.ResumeLayout(false);
            this.panelLabelRemoveTimeslot.PerformLayout();
            this.panelComboBoxTimeslot.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panelLabelRemoveTimeslot;
        private System.Windows.Forms.Label labelRemoveTimeslot;
        private System.Windows.Forms.Panel panelComboBoxTimeslot;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.ComboBox comBoxTimeslot;
    }
}