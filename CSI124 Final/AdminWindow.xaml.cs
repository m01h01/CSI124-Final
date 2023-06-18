using System;
using System.Collections.Generic;
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
using MyClassLibrary;

namespace CSI124_Final
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            PreloadComboBox();
            lvUserInfo.ItemsSource = Data.Accounts;
            lbLogInName.Content = Data.CurrentUser.Name;
        }

        public void PreloadComboBox()
        {
            cbRolls.Items.Add("User");
            cbRolls.Items.Add("Admin");
            cbRolls.SelectedIndex = 0;
        }

        public void Clear()
        {
            txtName.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
        
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
             
            UserAccount.Role role = (UserAccount.Role)cbRolls.SelectedIndex;

            Data.AddUser(new UserAccount(name, userName, password, role));

            lvUserInfo.Items.Refresh();//updateListViewInformation

            Clear();
          
        }
    }//class
}//namespace
