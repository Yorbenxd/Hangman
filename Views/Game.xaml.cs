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

namespace Hangman.Views
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
		private string secretWord;
		List<char> guessedLetters = new List<char>();

		List<char> rightLetters = new List<char>();
		List<char> wrongLetters = new List<char>();
		private int livesLeft = 10;
		private int imageBackground = 1;

		public Game(string cleanWord)
        {
            InitializeComponent();
			secretWord = cleanWord;
			MaskWord();
		}

		private void MaskWord()
		{
			foreach(char c in secretWord)
			{
				lblSecretWord.Content += "__ ";
			}
		}

		private void mnuHeadmenu_Click(object sender, RoutedEventArgs e)
		{
			BackToHeadmenu();
			Close();
		}

		private void BackToHeadmenu()
		{
			Headmenu headmenu = new Headmenu();
			headmenu.Show();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			char guessedLetter = txtGuess.Text[0];
			lblSecretWord.Content = "";

			if (char.IsLetter(guessedLetter))
			{
				if (secretWord.Contains(guessedLetter) && !guessedLetters.Contains(guessedLetter))
				{
					RightGuess(guessedLetter);
				}
				else if(!secretWord.Contains(guessedLetter) && !guessedLetters.Contains(guessedLetter))
				{
					WrongGuess(guessedLetter);
				}
				else if (guessedLetters.Contains(guessedLetter))
				{
					MessageBox.Show("You have already guessed this letter!", "Oops");
				}

				UpdateMaskedWord();

				UpdateWrongLetters();

				CheckLivesLeft();

				CheckIfWordGuessed();
			}
			else MessageBox.Show("Please, only fill in letters!", "Error!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
		}

		private void RightGuess(char guessedLetter)
		{
			rightLetters.Add(guessedLetter);
			guessedLetters.Add(guessedLetter);
		}

		private void WrongGuess(char guessedLetter)
		{
			wrongLetters.Add(guessedLetter);
			guessedLetters.Add(guessedLetter);

			livesLeft--;
			imageBackground++;

			imgBackground.Source = new BitmapImage(new Uri($@"/Assets/GalgjeAchtergrond{imageBackground}.jpg", UriKind.Relative));
			lblLivesLeft.Content = $"Lives left: {livesLeft}";
		}

		private void UpdateMaskedWord()
		{
			foreach (char c in secretWord)
			{
				if (rightLetters.Contains(c))
				{
					lblSecretWord.Content += $"{c} ";
				}
				else
				{
					lblSecretWord.Content += "__ ";
				}
			}
		}

		private void UpdateWrongLetters()
		{
			lblWrongLetters.Content = "Wrong letters:";
			foreach (char c in wrongLetters)
			{
				lblWrongLetters.Content += $" {c}";
			}
		}

		private void CheckLivesLeft()
		{
			if (livesLeft == 0)
			{
				MessageBox.Show($"You have lost! The secret word was: {secretWord}", "Boooo!");
				btnGuess.IsEnabled = false;
			}
		}

		private void CheckIfWordGuessed()
		{
			string guessedWord = lblSecretWord.Content.ToString();
			string guessedWordWithoutSpaces = guessedWord.Replace(" ", string.Empty);

			if (guessedWordWithoutSpaces == secretWord)
			{
				MessageBox.Show($"You have won with {livesLeft} lives left!", "Congratz!");
				btnGuess.IsEnabled = false;
			}
		}
	}
}
