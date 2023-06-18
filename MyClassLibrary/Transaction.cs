using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyClassLibrary
{
    public class Transaction : IComparable<Transaction>
    {
        static DateTime _transactionTime;
        string _name;
        double _price;
        double _tax = 0.1;
        double _total;

        public DateTime TransactionTime { get => DateTime.Now; }
        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price; set => _price = value; }
        public double Tax { get => _tax;}
        public double Total { get => _total; set => _total = value; }

        
        public Transaction(string name, double price)
        {
            _name = name;
            _price = price;
            _total = price + ( price * _tax);
        }

        public Transaction() { }

        public int CompareTo(Transaction? other)
        {
            return this._name.CompareTo(other._name);
        }
    }//class
}//nameapace
