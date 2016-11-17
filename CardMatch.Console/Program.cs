using CardMatch.Core.Models.Cards;
using CardMatch.TurnBased.Facade;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch.ConsoleApp
{
    class Program
    {
        private static IKernel kernel = new StandardKernel(new MainModule());

        private static ITurnBasedGameFieldFacade<ICard> _gameFacade;

        static void Main(string[] args)
        {
            Init();
            RunTest();
        }

        private static void RunTest()
        {
            _gameFacade.NewGame();
        }

        private static void Init()
        {
            _gameFacade = (ITurnBasedGameFieldFacade<ICard>)kernel.Get<ITurnBasedGameFieldFacade<ICard>>();

            _gameFacade.CardsClosing += _gameFacade_CardsClosing;
            _gameFacade.OnBonusApplied += _gameFacade_OnBonusApplied;
            _gameFacade.OnCardMatched += _gameFacade_OnCardMatched;
            _gameFacade.OnCardRevealed += _gameFacade_OnCardRevealed;
        }

        static void _gameFacade_OnCardRevealed(object sender, CardRevelationEventArgs<ICard> e)
        {
            Console.WriteLine(String.Format("Revealed card {0}", e.Card.Value));
        }

        static void _gameFacade_OnCardMatched(object sender, CardMatchEventArgs<ICard> e)
        {
            Console.WriteLine(String.Format("Mached cards: {0} and {1}", e.CardPair.Item1.Value, e.CardPair.Item2.Value));
        }

        static void _gameFacade_OnBonusApplied(object sender, CardBonusEventArgs e)
        {
            Console.WriteLine(String.Format("Applied bonus {0}.", e.ToString()));
        }

        static void _gameFacade_CardsClosing(object sender, EventArgs e)
        {
            Console.WriteLine("Cards closing.");
        }
    }
}
