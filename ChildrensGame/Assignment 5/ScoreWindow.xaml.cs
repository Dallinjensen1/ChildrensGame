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

namespace Assignment_5
{
    /// <summary>
    /// Interaction logic for ScoreWindow.xaml
    /// </summary>
    public partial class ScoreWindow : Window
    {
        MainWindow wndMainWindow;
        public User user;

        /// <summary>
        /// Sets the textbox with the users info and score
        /// </summary>
        /// <param name="u"></param>
        public ScoreWindow(User u)
        {
            InitializeComponent();
            user = u;

            scoreBox.Text += "Name: " + user.Name + "\n";
            scoreBox.Text += "Age: " + user.Age + "\n";
            scoreBox.Text += "Correct: " + user.numberCorrect + "\n";
            scoreBox.Text += "Incorrect: " + (10 - user.numberCorrect) + "\n";
            scoreBox.Text += "Time:" + user.gameSeconds + " seconds" + "\n";
            
        }


        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            //Hide the menu
            this.Close();
           
            
           
        }
    }
}
