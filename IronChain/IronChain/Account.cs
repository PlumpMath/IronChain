﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace IronChain {
    [Serializable]
    public class Account {

        public string name;
        public string publicKey;
        public int analysedBlock;
        public int coinCounter;
        public string privateKey;

        public Account() {

        }

        public Account(string nam, int num) {
            name = nam;
            publicKey = nam;
            analysedBlock = num;
            privateKey = "lul";
        }

        public void addKeys(string s) {

            RSACryptoServiceProvider provider = new RSACryptoServiceProvider(512);

            provider.FromXmlString(s);

            privateKey = provider.ToXmlString(true);
            publicKey = provider.ToXmlString(false);
        }

        public override string ToString() {
            return name;
        }
    }
}
