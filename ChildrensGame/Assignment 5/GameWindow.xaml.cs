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
using System.Windows.Threading;

namespace Assignment_5
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    /// 
    
    public partial class GameWindow : Window
    {

        ScoreWindow wndScoreWindow;
        int score = 0;
        int rounds = 0;
        public int time = 0;
        int iSeconds;
        DispatcherTimer MyTimer;
       


        public User user;

        public Game game = new Game();
        public GameWindow()
        {
            InitializeComponent();

           

            lblValid.Content = "";

            //Instantiate the DispatcherTimer
            MyTimer = new DispatcherTimer();
            //Make the timer go off every second
            MyTimer.Interval = TimeSpan.FromSeconds(1);
            //Tell it which method will handle the click event
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }

        void MyTimer_Tick(object sender, EventArgs e)
        {
            lblTimer.Content = time + " seconds";
            time++;
        }
        public void startGame()
        {
            
            game.runGame();
            lblPlaceHolder.Content = game.gameQuestion.LeftNumber + " " + game.GameType + " " + game.gameQuestion.RightNumber;

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
           if(rounds < 10)

            {

                int guess = 0;
                try
                {
                    guess = Int32.Parse(ansTextBox.Text);
                }
                catch
                {

                }
                
             

                if (game.ValidatePlayerGuess(guess))
                {
                    System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer("YEAH1.wav");
                    score++;
                    lblValid.Content = "Correct!";
                    simpleSound.Play();
                }
                else
                {
                    lblValid.Content = "Incorrect!! :(";
                }

                rounds++;
                ansTextBox.Text = "";
                startGame();

            }
            else
            {

                rounds = 0;
                user.numberCorrect = score;
                user.gameSeconds = time;
                wndScoreWindow = new ScoreWindow(user);

                //Hide the menu
                this.Hide();
                //Show the game form
              
                wndScoreWindow.ShowDialog();
                

            }


        }
    }
}
