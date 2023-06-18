using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CsvHelper;
using MyClassLibrary;

namespace CSI124_Final
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        List<Transaction> transactions = new List<Transaction>();
        public UserWindow()
        {
            InitializeComponent();

            lbName.Content = Data.CurrentUser.Name;

            CreateNewFile(Data.UsersTransactionsName());

            transactions = ReadTransactions<Transaction>(Data.UsersTransactionsName());
            lvTransaction.ItemsSource = transactions;

        }
        private void CreateNewFile(string filePath) // Used to create a file on load to guarantee a file exists. Use on page load.
        {
            FileStream tryout = File.OpenWrite(filePath);
            tryout.Close();
            tryout.Dispose();
        }

        public void UpdateListView() // Updates the listview
        {
            lvTransaction.Items.Refresh();
        }

        private void Clear()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtExportNewCSV.Text = "";

        }

        private void btnAddTran_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            double price = double .Parse(txtPrice.Text);

            transactions.Add(new Transaction(name, price));

            UpdateListView();
            Clear();

        }

        public void SaveTransactionToCSVfile<T>(string filePath, List<T> list) 
            // When called saves transaction list to the users csv
        {
            CultureInfo ci = CultureInfo.InvariantCulture;

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    using (var csvWriter = new CsvWriter(writer, ci))
                    {
                        csvWriter.WriteRecords(list);

                        writer.Flush();
                    }
                }
            }
        }

        private void btnSaveTran_Click(object sender, RoutedEventArgs e)
        {
            SaveTransactionToCSVfile(Data.UsersTransactionsName(), transactions);
        }

        private void btnSortName_Click(object sender, RoutedEventArgs e)
        {
            transactions.Sort();
            lvTransaction.ItemsSource = transactions;

            UpdateListView();
        }

        private void btnTranPrice_Click(object sender, RoutedEventArgs e)
        {
            Transaction_Sort_Price sortPrice = new Transaction_Sort_Price();
            transactions.Sort(sortPrice);

            UpdateListView();
        }

        private void btnSortTranTime_Click(object sender, RoutedEventArgs e)
        {
            Transaction_Sort_Time sortTime = new Transaction_Sort_Time();
            transactions.Sort(sortTime);

            UpdateListView();
        }

        private void btnExportCSV_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = txtExportNewCSV.Text;
            string filePathCSV = $"{FilePath}{".csv"}";

            SaveTransactionToCSVfile(filePathCSV, transactions);

            Clear();

        }
        public List<T> ReadTransactions<T>(string filepath) /// Loads the users specific csv
        {
            List<T> tempList = new List<T>();

            using (StreamReader sr = new StreamReader(filepath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                tempList = csv.GetRecords<T>().ToList();
            }
            return tempList;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }//class
}//namespace
