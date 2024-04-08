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

namespace Assignment_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        GameWindow wndGameWindow = new GameWindow();
        ScoreWindow wndScoreWindow;

        User user;

        public MainWindow()
        {
            InitializeComponent();

            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            user = new User();



        }

        private void radAdd_Checked(object sender, RoutedEventArgs e)
        {
           wndGameWindow.game.GameType = "+";
        }

        private void radSubtraction_Checked(object sender, RoutedEventArgs e)
        {
          wndGameWindow.game.GameType = "-";
        }

        private void radMultiply_Checked(object sender, RoutedEventArgs e)
        {
           wndGameWindow.game.GameType = "*";
        }

        private void radDIvide_Checked(object sender, RoutedEventArgs e)
        {
            wndGameWindow.game.GameType = "/";
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            // Validates the user data to have a name and to be between ages 3 and 10
            int Age = 0;
            try
            {
                Age = Int32.Parse(txtAge.Text);
            }
            catch
            {

            }

            if (Age < 3 || Age > 10)
            {
                lblError.Content = "Error! Age must be between 3 and 10";
            }
            else if (String.IsNullOrEmpty(txtName.Text))
            {
                lblError.Content = "Must enter a name";
            }
            else
            {
                user.Name = txtName.Text;
                user.Age = Int32.Parse(txtAge.Text);
                //Hide the menu
                this.Hide();
                //pass user through
                wndGameWindow.user = user;
                //Reset label for 2nd playthrough
                wndGameWindow.lblValid.Content = "";
                //reset time for 2nd play through
                wndGameWindow.time = 0;
                wndGameWindow.startGame();

                wndGameWindow.ShowDialog();
                //Show the main form
                this.Show();
                lblError.Content = "";
            }


        }


    }
}
