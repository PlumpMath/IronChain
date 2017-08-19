﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IronChain {
    public partial class sendIron : Form {
        public sendIron() {
            InitializeComponent();

            foreach (Account a in Form1.instance.accountList.Values) {
                comboBox1.Items.Add(a);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void onClickSendIron(object sender, EventArgs e) {

            string receiver = textBox2.Text;
            int amount = Convert.ToInt32(textBox1.Text);
            Random r = new Random();
            Transaction t = new Transaction(Form1.instance.latestBlock+amount);

            Console.WriteLine(t.id);

            Account thisAccount = Form1.instance.accountList[comboBox1.Text];

            //TODO SIGN IT;
            t.proofOfOwnership = Utility.encryptString(thisAccount.privateKey, t.id + "");
            t.owner = thisAccount.publicKey;
            t.receiver = receiver;

            Form1.instance.TransactionPool.Add(t);
            Form1.instance.updateTransactionPoolWindow();

            this.Close();
        }

    }
}