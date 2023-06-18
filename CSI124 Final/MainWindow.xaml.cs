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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyClassLibrary;
using static MyClassLibrary.UserAccount;

//Name: Monika Heang
//Date: 06/17/2023
//Assigment: CSI 124 Final 

namespace CSI124_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void validateUser()
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
           
            if(Data.IsUser(userName)) 
            {
                if (Data.ValidateUser(userName, password))
                {
                    if (Data.CurrentUser.role == Role.User)
                    {
                            new UserWindow().Show();
                    }
                    else if (Data.CurrentUser.role == Role.Admin)
                    {
                            new AdminWindow().Show();
                    }
                }
                else 
                { 
                    MessageBox.Show("Sorry, UserName and Password aren't matched"); 
                }
            }
            else 
            { 
                
                MessageBox.Show("Cannot Find the Username on File");
            }
            
           
            Clear();

        }

        public void Clear()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            validateUser();
        }

    }//class
    
}//namespace
