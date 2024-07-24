using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GuessNumberGame
{
    public partial class Form1 : Form
    {
        private int targetNumber;
        private int guessCount;
        private Stopwatch stopwatch;

        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            Random rand = new Random();
            targetNumber = rand.Next(1, 101); // Generera ett nummer mellan 1 och 100
            guessCount = 0;
            lblMessage.Text = "Guess a number between 1 and 100!";
            lblGuessCount.Text = "Guesses: 0";
            lblTimer.Text = "Time: 0s";
            txtGuess.Text = "";
            txtGuess.Focus();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            this.BackColor = System.Drawing.Color.LightBlue;
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            int userGuess;
            if (int.TryParse(txtGuess.Text, out userGuess))
            {
                guessCount++;
                lblGuessCount.Text = $"Guesses: {guessCount}";

                if (userGuess < targetNumber)
                {
                    lblMessage.Text = "Too low! Try again.";
                    this.BackColor = System.Drawing.Color.LightSalmon;
                }
                else if (userGuess > targetNumber)
                {
                    lblMessage.Text = "Too high! Try again.";
                    this.BackColor = System.Drawing.Color.LightSalmon;
                }
                else
                {
                    stopwatch.Stop();
                    lblMessage.Text = $"Correct! You guessed it in {guessCount} guesses and {stopwatch.Elapsed.Seconds} seconds.";
                    var result = MessageBox.Show("Do you want to play again?", "Game Over", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        StartNewGame();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                lblMessage.Text = "Please enter a valid number.";
                this.BackColor = System.Drawing.Color.IndianRed;
            }

            txtGuess.Text = "";
            txtGuess.Focus();
            lblTimer.Text = $"Time: {stopwatch.Elapsed.Seconds}s";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = $"Time: {stopwatch.Elapsed.Seconds}s";
        }
    }
}
