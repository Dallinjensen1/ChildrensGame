using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    public class Game
    {


        public string GameType = string.Empty;

        public int iUserGuess;
        public GameQuestion gameQuestion;
        public void runGame()
        {
            gameQuestion = new GameQuestion();
            gameQuestion = GenerateQuestion(gameQuestion);
        }


        /// <summary>
        /// Takes the radio button inputs generates a random question based on what button was selected.
        /// </summary>
        /// <param name="gq"></param>
        /// <returns></returns>
        public GameQuestion GenerateQuestion(GameQuestion gq)
        {


            if (GameType == "+")
            {
                gq.Answer = gq.LeftNumber + gq.RightNumber;
            }
            else if (GameType == "-")
            {
                gq.Answer = gq.LeftNumber + gq.RightNumber;
            }
            else if (GameType == "*")
            {
                gq.Answer = gq.LeftNumber * gq.RightNumber;
            }
            else //Game Type = Divide if none else
            {
               gq.LeftNumber = gq.LeftNumber * gq.RightNumber;
               gq.Answer = gq.LeftNumber / gq.RightNumber;
            }
            return gq;


        }
        /// <summary>
        /// Validates that the user's guess is equal to the answer
        /// </summary>
        /// <param name="iUserGuess"></param>
        /// <returns></returns>
        public bool ValidatePlayerGuess(int iUserGuess)
        {

         
           return iUserGuess == gameQuestion.Answer;
            
           
        }
    }
  
    /// <summary>
    /// Takes 2 numbers and randomizes them to be used in another class to generate questions.
    /// </summary>
    public class GameQuestion
    {

        Random rnd;


        public int LeftNumber;
        public int RightNumber;
        public int Answer;

        public GameQuestion()
        {
            rnd = new Random();

            LeftNumber = rnd.Next(6, 11);
            RightNumber = rnd.Next(1, 5);
        }


    }
}
