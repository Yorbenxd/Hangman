using Hangman.Views;
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

namespace Hangman
{
    /// <summary>
    /// Interaction logic for Headmenu.xaml
    /// </summary>
    public partial class Headmenu : Window
    {
        public Headmenu()
        {
            InitializeComponent();
        }

		private void mnuNewGame_Click(object sender, RoutedEventArgs e)
		{
			StartNewGame();
			Close();
		}

		private void StartNewGame()
		{
			NewGame newGame = new NewGame();
			newGame.Show();
		}


		private void mnuAllHighscore_Click(object sender, RoutedEventArgs e)
		{

        }

		private void mnuHighscore_Click(object sender, RoutedEventArgs e)
		{

        }

		private void mnuQuit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
