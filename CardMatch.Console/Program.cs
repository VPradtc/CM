using CardMatch.Console;
using CardMatch.Core.Models.Enums;
using CardMatch.TurnBased.Facade;
using Ninject;
using System;
using System.Linq;

namespace CardMatch.ConsoleApp
{
    class Program
    {
        private static IKernel kernel = new StandardKernel(new MainModule());

        private static ITurnBasedGameFieldFacade _gameFacade;

        private static GameViewmodel _viewmodel = new GameViewmodel();

        static void Main(string[] args)
        {
            Init();
            RunTest();
        }

        private static void RunTest()
        {
            _gameFacade.NewGame();

            RenderGameState();

            while (!_gameFacade.IsOver())
            {
                RequestUserAction();
                _gameFacade.Save();
            }

            var endGameMessage = _gameFacade.IsVictory() ? "Congrats, you won!" : "Sorry, you lost.";

            System.Console.WriteLine(endGameMessage);

            System.Console.ReadLine();
        }

        private static void RequestUserAction()
        {
            int cardIndex;
            string input = System.Console.ReadLine();
            if (!int.TryParse(input, out cardIndex) || cardIndex < 1 || cardIndex > _viewmodel.Cards.Count)
            {
                System.Console.WriteLine("Invalid card index. Try again:");
                RequestUserAction();
                return;
            }

            var targetCard = _viewmodel.Cards[cardIndex - 1];

            _gameFacade.PickCard(targetCard);
        }

        private static void DisplayGameState()
        {
            System.Console.WriteLine("Turns left: {0}",_viewmodel.TurnsLeft);

            foreach (var card in _viewmodel.Cards)
            {
                var cardChar = card.Status == CardStatus.Revealed ? card.Value : "####";

                System.Console.Write("{0}    ",cardChar);
            }

            System.Console.WriteLine();
        }

        private static void PollGameState()
        {
            _viewmodel.TurnsLeft = _gameFacade.GetRemainingTurns();
            _viewmodel.Cards = _gameFacade.GetRemainingCards().ToList();
        }

        private static void Init()
        {
            _gameFacade = (ITurnBasedGameFieldFacade)kernel.Get<ITurnBasedGameFieldFacade>();
            _gameFacade.GameFieldChanged += _gameFacade_GameFieldChanged;
        }

        static void _gameFacade_GameFieldChanged(object sender, EventArgs e)
        {
            RenderGameState();
        }

        private static void RenderGameState()
        {
            PollGameState();
            DisplayGameState();
        }
    }
}
