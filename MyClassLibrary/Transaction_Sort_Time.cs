using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class Transaction_Sort_Time : IComparer<Transaction>
    {
        public int Compare(Transaction? x, Transaction? y)
        {
            return x.TransactionTime.CompareTo(y.TransactionTime);
        }
    }
}
