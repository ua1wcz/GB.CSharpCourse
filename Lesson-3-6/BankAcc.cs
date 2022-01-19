using BankAccount;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount2
{
    class BankAcc2 : BankAcc
    {
        public BankAcc2(double bal, TypeBankAccount tba) : base(bal, tba)
        {
            balance = bal;
            typebankaccount = tba;
        }

        public BankAcc2() : base()
        {
        }
        public static bool operator ==(BankAcc2 b1, BankAcc2 b2)
        {
            return (b1.numaccount == b2.numaccount & b1.typebankaccount == b2.typebankaccount);
        }
        public static bool operator !=(BankAcc2 b1, BankAcc2 b2)
        {
            return (b1.numaccount != b2.numaccount | b1.typebankaccount != b2.typebankaccount);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            BankAcc2 ba = (BankAcc2)obj;
            return (this.numaccount == ba.numaccount &
                this.typebankaccount == ba.typebankaccount);
        }

        public override int GetHashCode()
        {
            return this.numaccount.GetHashCode();
        }

        public override string ToString()
        {
            return "Номер счета: " + numaccount + "\nБаланс: " + balance +
                "\nТип счета: " + typebankaccount.ToString();
        }
    }
}
