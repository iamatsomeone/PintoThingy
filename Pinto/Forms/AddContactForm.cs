﻿using PintoNS.Forms.Notification;
using System;
using System.Windows.Forms;

namespace PintoNS.Forms
{
    public partial class AddContactForm : Form
    {
        private MainForm mainForm;

        public AddContactForm(MainForm mainForm)
        {
            InitializeComponent();
            Icon = Program.GetFormIcon();
            this.mainForm = mainForm;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContactName.Text))
            {
                MsgBox.ShowNotification(this, "Invalid username!", "Error", MsgBoxIconType.ERROR);
                return;
            }
            Close();
            mainForm.NetManager.NetHandler.SendAddContactPacket(txtContactName.Text);
        }

        private void txtContactName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
