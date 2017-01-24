using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pairs
{
    public static class GameCommands
    {
        private static RoutedUICommand newGameSinglePlayer;

        static GameCommands()
        {
            CreateNewGameSinglePlayerCommand();
        }

        private static void CreateNewGameSinglePlayerCommand()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.F2));
            newGameSinglePlayer = new RoutedUICommand("New Game (Single Player)", "NewGameSinglePlayer", typeof(GameCommands), inputs);
        }

        public static RoutedUICommand NewGameSinglePlayer
        {
            get
            {
                return newGameSinglePlayer;
            }
        }
    }
}
