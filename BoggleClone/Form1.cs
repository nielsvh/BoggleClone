using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace BoggleClone
{
    public partial class BoggleClone : Form
    {
        /// <summary>
        /// The lexicon of words loaded from file.
        /// </summary>
        LibraryInterface lib;

        /// <summary>
        /// The dice either loaded from predefined dice or by letter frequencey within the library
        /// </summary>
        Dice dice;

        /// <summary>
        /// The width/height of the dice
        /// </summary>
        const int BUTTON_WIDTH = 100;

        /// <summary>
        /// Array of buttons that represent the dice, where buttons[x,y] represents the button at location (X(horizontal), Y(vertical)).
        /// </summary>
        Button[,] buttons;

        /// <summary>
        /// Array of visited nodes on the board so that the same letters cannot be chosen twice.
        /// </summary>
        bool[,] visited;

        /// <summary>
        /// LibraryLoader user control
        /// </summary>
        LibraryLoader loader;

        /// <summary>
        /// GameStatus user control
        /// </summary>
        GameStatus gameStatusController;

        /// <summary>
        /// board width in dice
        /// </summary>
        int boardWidth = 4;

        /// <summary>
        /// board height in dice.
        /// </summary>
        int boardHeight = 4;

        public BoggleClone()
        {
            InitializeComponent();


            // initialize the library, first run always uses a tree library for efficiency sake.
            lib = new TreeLibrary();
            lib.BuildLibrary("lexicon.txt");

            // initialize the dice
            dice = new Dice();
            dice.rollDice();

            // add the controls & buttons
            loader = new LibraryLoader();
            this.Controls.Add(loader);
            //loader.loadTimeL.Text = ts.Milliseconds.ToString();
            gameStatusController = new GameStatus();
            this.Controls.Add(gameStatusController);
            // add the library loader button listener
            loader.libLoadB.Click += new System.EventHandler(this.libLoadB_Click);
            loader.resizeB.Click += new System.EventHandler(this.resizeB_Click);
            gameStatusController.submitB.Click += new EventHandler(this.submitB_Click);
            gameStatusController.solveB.Click += new EventHandler(solveB_Click);
            setupBoard();

            // roll the dice
            //this.gameStatusController.startGame();
        }

        /// <summary>
        /// Add buttons to the board, set the width/height of the window to accommodate the layout, set the width of the timer to the width of the window
        /// </summary>
        void setupBoard()
        {
            if (buttons != null)
            {
                foreach (Button button in buttons)
                {
                    this.Controls.Remove(button);
                }
            }

            // set up the buttons
            buttons = new Button[boardWidth, boardHeight];
            //set up the visited map
            visited = new bool[boardWidth, boardHeight];

            for (int row = 0; row < boardHeight; row++)
            {
                for (int col = 0; col < boardWidth; col++)
                {
                    visited[col, row] = false;
                    buttons[col, row] = new Button();
                    buttons[col, row].Location = new Point(col * BUTTON_WIDTH, loader.Height + row * BUTTON_WIDTH);
                    buttons[col, row].Name = col.ToString() + "-" + row.ToString();
                    buttons[col, row].Size = new System.Drawing.Size(BUTTON_WIDTH, BUTTON_WIDTH);
                    buttons[col, row].TabIndex = col * boardWidth + row;
                    buttons[col, row].UseVisualStyleBackColor = true;
                    buttons[col, row].Click += new EventHandler(Die_Click);
                    buttons[col, row].Enabled = false;
                    this.Controls.Add(buttons[col, row]);
                }
            }

            // setup the width/height of the window
            if (loader.Location.X + loader.Width >= buttons[buttons.GetLength(0) - 1, 0].Location.X + buttons[buttons.GetLength(0) - 1, 0].Width)
                this.Width = loader.Location.X + loader.Width + 20;
            else
                this.Width = buttons[buttons.GetLength(0) - 1, 0].Location.X + buttons[buttons.GetLength(0) - 1, 0].Width + 20;

            this.gameStatusController.Width = this.Width;
            this.gameStatusController.Location = new Point(0, buttons[0, buttons.GetLength(1) - 1].Location.Y + buttons[0, buttons.GetLength(1) - 1].Height + 10);
            this.Height = this.gameStatusController.Location.Y + this.gameStatusController.Height + 30;


            // set the location of the begin button's center to the center of the board
            this.beginB.Location = new Point((buttons[0, 0].Location.X + buttons[boardWidth - 1, 0].Location.X + BUTTON_WIDTH) / 2 - this.beginB.Width / 2, (buttons[0, 0].Location.Y + buttons[0, boardHeight - 1].Location.Y + BUTTON_WIDTH) / 2 - this.beginB.Height / 2);

            //set the width of the timer
            // initialize the dice
            dice = new Dice(boardWidth * boardHeight);
            dice.rollDice();
        }

        private void libLoadB_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            switch (loader.libTypeLB.SelectedIndex)
            {
                case 0:
                    this.lib = new TreeLibrary();
                    break;
                case 1:
                    this.lib = new HashLibrary();
                    break;
                case 2:
                    this.lib = new ArrayLibrary();
                    break;
                default:
                    break;
            }
            this.lib.BuildLibrary(Strings.LexiconFile);
            sw.Stop();
            this.loader.loadTimeL.Text = String.Format("{0} ms", sw.ElapsedMilliseconds);
        }

        private void Die_Click(object sender, EventArgs e)
        {
            // get the index of the button
            string name = ((Button)sender).Name;
            int x = int.Parse(name.Substring(0, name.IndexOf('-')));
            int y = int.Parse(name.Substring(name.IndexOf('-') + 1));


            gameStatusController.CurrentWord += buttons[x, y].Text;

            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }

            bool xOverZero = (x - 1 >= 0);
            bool yOverZero = (y - 1 >= 0);
            bool xUnderMax = (x + 1 < buttons.GetLength(0));
            bool yUnderMax = (y + 1 < buttons.GetLength(1));

            //buttons[x, y].Enabled = true;
            visited[x, y] = true;
            if (xOverZero)
            {
                buttons[x - 1, y].Enabled = true && !visited[x - 1, y];
                if (yOverZero)
                {
                    buttons[x - 1, y - 1].Enabled = true && !visited[x - 1, y - 1];
                    buttons[x, y - 1].Enabled = true && !visited[x, y - 1];
                }
                if (yUnderMax)
                {
                    buttons[x - 1, y + 1].Enabled = true && !visited[x - 1, y + 1];
                    buttons[x, y + 1].Enabled = true && !visited[x, y + 1];
                }
            }
            if (xUnderMax)
            {
                buttons[x + 1, y].Enabled = true && !visited[x + 1, y];
                if (yOverZero)
                {
                    buttons[x + 1, y - 1].Enabled = true && !visited[x + 1, y - 1];
                    buttons[x, y - 1].Enabled = true && !visited[x, y - 1];
                }
                if (yUnderMax)
                {
                    buttons[x + 1, y + 1].Enabled = true && !visited[x + 1, y + 1];
                    buttons[x, y + 1].Enabled = true && !visited[x, y + 1];
                }
            }
        }

        internal void gameEnd()
        {
            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
        }

        private void beginB_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            this.beginB.Enabled = false;
            this.beginB.Visible = false;
            this.dice.rollDice();
            for(int row = 0;row<boardHeight;row++)
            {
                for (int col = 0; col < boardWidth; col++)
                {
                    buttons[col,row].Enabled = true;
                    buttons[col, row].Text = this.dice.getFace(col + row * col).ToString();
                }
            }
        }


        private void submitB_Click(object sender, EventArgs e)
        {
            string word = this.gameStatusController.CurrentWord.ToLower();
            //Console.WriteLine(lib.SearchLibrary(word));
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SearchResult res = lib.SearchLibrary(word);
            sw.Stop();
            this.gameStatusController.CurrentWord = String.Empty;
            gameStatusController.searchTime.Text = String.Format("{0} ms", sw.ElapsedMilliseconds);

            if ((res.ExistFlags & (int)ExistTypes.DOES_EXIST) == (int)ExistTypes.DOES_EXIST
                && (res.ExistFlags & (int)ExistTypes.END_OF_WORD) == (int)ExistTypes.END_OF_WORD)
            {
                this.gameStatusController.wordPadTB.Text += String.Format("{0},", word);
            }

            for (int i = 0; i < boardWidth; i++)
                for (int j = 0; j < boardHeight; j++)
                    visited[i, j] = false;

            foreach (Button button in buttons)
                button.Enabled = true;
        }

        private void resizeB_Click(object sender, EventArgs e)
        {
            this.boardHeight = (int)loader.heightNUM.Value;
            this.boardWidth = (int)loader.widthNUM.Value;
            this.setupBoard();
            this.StartGame();
        }

        void solveB_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < boardWidth; row++)
            {
                for (int col = 0; col < boardHeight; col++)
                {
                    visited = new bool[boardWidth, boardHeight];
                    SolveBoard(row, col, "");

                }
            }
        }

        void SolveBoard(int row, int col, string word)
        {
            word += dice.getFace(col + row * col);
            visited[col, row] = true;

            SearchResult res = new SearchResult();
            if (word.Length >= 3)
            {
                res = this.lib.SearchLibrary(word.ToLower());
                if ((res.ExistFlags & (int)ExistTypes.DOES_EXIST) == (int)ExistTypes.DOES_EXIST && (res.ExistFlags & (int)ExistTypes.END_OF_WORD) == (int)ExistTypes.END_OF_WORD)
                {
                    this.gameStatusController.wordPadTB.Text += String.Format("{0}, ", word);
                    if ((res.ExistFlags & (int)ExistTypes.MIDDLE_OF_WORD) != (int)ExistTypes.MIDDLE_OF_WORD)
                    {
                        visited[col, row] = false;
                        return;
                    }
                }

                if ((res.ExistFlags&(int)ExistTypes.DOES_EXIST) != (int)ExistTypes.DOES_EXIST)
                {
                    visited[col, row] = false;
                    return;
                }
                Console.Write(String.Format("{0}, ", word));
            }

            int nDRow = row - 1, nURow = row + 1; // next row
            int nDCol = col - 1, nUCol = col + 1; // next collumn up and down
            if (row > 0)
            {
                if (col > 0 && !visited[nDCol, nDRow])
                {
                    SolveBoard(nDRow, nDCol, word);
                }
                if (!visited[col, nDRow])
                {
                    SolveBoard(nDRow, col, word);
                }
                if (col < boardWidth - 1 && !visited[nUCol, nDRow])
                {
                    SolveBoard(nDRow, nUCol, word);
                }
            }
            if (col > 0 && !visited[nDCol, row])
            {
                SolveBoard(row, nDCol, word);
            }
            if (nUCol <= boardWidth - 1 && !visited[nUCol, row])
            {
                SolveBoard(row, nUCol, word);
            }
            if (row < boardHeight - 1)
            {
                if (col > 0 && !visited[nDCol, nURow])
                {
                    SolveBoard(nURow, nDCol, word);
                }
                if (!visited[col, nURow])
                {
                    SolveBoard(nURow, col, word);
                }
                if (col < boardWidth - 1 && !visited[nUCol, nURow])
                {
                    SolveBoard(nURow, nUCol, word);
                }
            }

            visited[col, row] = false;
        }
    }
}