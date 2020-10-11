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
using static Random_Number_Game.Definitions;

namespace Random_Number_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameControl _GameController;

        private string _BasicStatusText = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            _GameController = new GameControl();
        }

        /// <summary>
        /// Generate the random number. Determine the difficulty from the radio buttons, use hte game controller to set up the new game and initialise UI
        /// </summary>
        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
            Difficulty diff;

            try
            {
                diff = RadioButtonEasy.IsChecked == true ? Difficulty.Easy :
               RadioButtonMedium.IsChecked == true ? Difficulty.Medium :
               Difficulty.Hard;

                _GameController.SetNewGame(diff);
                labelResult.Content = string.Empty;
                textBoxGuess.Text = string.Empty;
                textBoxGuess.IsEnabled = true;
                buttonGuess.IsEnabled = true;
                _BasicStatusText = _GameController.GetStatusText();
                labelRange.Content = _BasicStatusText;
            }
            catch (Exception ex)
            {
                //TBD Log the exception
                textBoxGuess.Text = "Random number failure";
            }
        }

        /// <summary>
        /// Guess processing. Use the game controller to check the guess then display the results
        /// </summary>
        private void buttonGuess_Click(object sender, RoutedEventArgs e)
        {
            int guess = 0;
            int remainingGuesses = 0;
            GuessResult guessRes;

            try
            {
                if (int.TryParse(textBoxGuess.Text, out guess))
                {
                    guessRes = _GameController.CheckGuess(guess, out remainingGuesses);
                    labelResult.Content = guessRes.ToString();
                    labelRange.Content = _BasicStatusText + remainingGuesses + " guesses remaining.";
                    if (guessRes == GuessResult.Correct || guessRes == GuessResult.Incorrect)
                    {
                        textBoxGuess.IsEnabled = false;
                        buttonGuess.IsEnabled = false;
                    }
                }
                else
                {
                    labelResult.Content = "Invalid guess";
                }
                textBoxGuess.Text = string.Empty;
            }
            catch (Exception ex)
            {
                //TBD Log the exception
                textBoxGuess.Text = "Guess check failure";
            }        
        }
    }
}
