﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronChain {
    [Serializable]
    public class Block {

        [Serializable]
        public struct Coin {
            public string owner { get; set; }
            public int amount { get; set; }

            public Coin(string owner, int amount) {
                this.owner = owner;
                this.amount = amount;
            }
        };

        public string nonce { get; set; }
        public int name { get; set; }
        public string hashOfParticle { get; set; }
        public string hashOfLightParticle { get; set; }

        public int numberOfTransactions { get; set; }
        public List<Coin> allCoins { get; set; }

        public Block() {
            name = 0;
            hashOfParticle = "";
            numberOfTransactions = 0;
            allCoins = new List<Coin>();
        }

        public Block(int n) {
            name = n;
            hashOfParticle = "";
            numberOfTransactions = 0;
            allCoins = new List<Coin>();
        }

        public void addHash(int i) {
            hashOfParticle = Utility.ComputeHash("P"+ (i+1));
            hashOfLightParticle = Utility.ComputeHash("L" + (i+1));

        }

        public void giveSomeCoins(string minerAddress, int num) {
                allCoins.Add(new Coin(minerAddress,num));
        }

        public void createCoins(string minerAddress) {
                allCoins.Add(new Coin(minerAddress, numberOfTransactions+3));
        }

    }
}
