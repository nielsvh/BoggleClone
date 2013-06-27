using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoggleClone
{
    class Dice
    {
        /// <summary>
        /// structure representing the individual die
        /// </summary>
        struct Die
        {
            public char[] faces;
        }

        /// <summary>
        /// This is the dice layout of the new and updated game
        /// </summary>
        string[] NEW_DICE = {"AACIOT","AHMORS","EGKLUY","ABILTY","ACDEMP","EGINTV","GILRUW","ELPSTU","DENOSW","ACELRS","ABJMOQ","EEFHIY","EHINPS","DKNOTU","ADENVZ","BIFORX"};
        /// <summary>
        /// This is the dice layout of the old game
        /// </summary>
        string[] OLD_DICE = {"AAEEGN","ELRTTY","AOOTTW","ABBJOO","EHRTVW","CIMOTU","DISTTY","EIOSST","DELRVY","ACHOPS","HIMNQU","EEINSU","EEGHNW","AFFKPS","HLNNRZ","DEILRX"};
        /// <summary>
        /// the number of dice on the board. The default number is 16 for a 4X4 board
        /// </summary>
        int count = 16;
        /// <summary>
        /// this is the position of the die on the board.
        /// </summary>
        int[] positions;
        /// <summary>
        /// this is the array of faces that are visible (face up). This refers to the dice array, not the positions array.
        /// </summary>
        int[] visibleFaces;
        /// <summary>
        /// array of dice
        /// </summary>
        Die[] dice;

        /// <summary>
        /// Default constructor sets the number of dice to 16 for a 4X4 board, sets up the positions and visibleFaces arrays
        /// </summary>
        public Dice()
        {
            count = 16;
            dice = new Die[count];
            for (int i = 0; i < dice.Length;i++ )
            {
                dice[i] = new Die();
                dice[i].faces = OLD_DICE[i].ToCharArray();
            }
            visibleFaces = new int[count];
            positions = new int[count];
            for (int i = 0; i < count;i++ )
                positions[i] = -1;
        }

        
        public Dice(int count)
        {
            this.count = count;
            dice = new Die[count];
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = new Die();
                dice[i].faces = OLD_DICE[i % 16].ToCharArray();
            }
            visibleFaces = new int[count];
            positions = new int[count];
            for (int i = 0; i < count; i++)
                positions[i] = -1;
        }

        /// <summary>
        /// Given a library with a distribution of letters, create a 4X4 board layout
        /// </summary>
        /// <param name="lib">Already loaded library with info on letter distribution</param>
        public Dice(LibraryInterface lib) { }

        /// <summary>
        /// Create the dice given a library with a distribution of letters and a number of dice to represent it on
        /// </summary>
        /// <param name="lib">Already loaded library with info on letter distribution</param>
        /// <param name="count">The number of dice on the board</param>
        public Dice(LibraryInterface lib, int count) { }

        /// <summary>
        /// roll the dice, fill the positions and visibleFaces arrays.
        /// </summary>
        public void rollDice()
        {
            //reset dice
            visibleFaces = new int[count];
            positions = new int[count];
            for (int i = 0; i < count; i++)
                positions[i] = -1;

            Random rand = new Random();
            int pos;
            for (int i = 0; i < count; i++)
            {
                pos = rand.Next(count);
                bool locationUnfound = true;
                while (locationUnfound)
                {
                    if (positions[pos] == -1)
                    {
                        positions[pos] = i;
                        locationUnfound = false;
                    }
                    else
                    {
                        pos += 13;
                        while (pos >= count)
                            pos = pos - count;
                    }
                }
                visibleFaces[i] = rand.Next(dice[i].faces.Length);
            }
        }

        public char getFace(int position)
        {
            int dieIndex = positions[position];
            Die theDie = dice[dieIndex];
            char face = theDie.faces[visibleFaces[dieIndex]];
            return face;
        }
    }
}
