using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoggleClone
{
    /// <summary>
    /// control holding all game status controls
    /// </summary>
    public partial class GameStatus : UserControl
    {
        public GameStatus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// on resize, make sure everything else is the same size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameStatus_Resize(object sender, EventArgs e)
        {
            // set the locations and widths of all children controlls
            this.wordPad.Width = this.Width-20;
            this.wordPadTB.Width = this.wordPad.Width - submitB.Width - 20;
            this.submitB.Location = new Point(this.wordPadTB.Location.X + this.wordPadTB.Width + 5, this.submitB.Location.Y);
            this.timer.Width = this.Width - 20;
        }

        /// <summary>
        /// On every tick, tick down the counter and check to see if the game has ended.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // check to see if the game is at an end.
            if (this.timer.Value == 0)
            {
                this.gameTimer.Stop();
                this.submitB.Enabled = false;
                ((BoggleClone)this.Parent).gameEnd();
                
            }
            else
                this.timer.Value -= 1;
        }

        /// <summary>
        /// Start the game timer
        /// </summary>
        public void startGameTimer()
        {
            this.gameTimer.Start();
        }

        public String CurrentWord
        {
            get { return this.currentWord.Text; }
            set { this.currentWord.Text = value; }
        }
    }
}
