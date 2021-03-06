﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pairs
{
    public abstract class GameController
    {
        private string iconSet;

        protected GameState state = GameState.Running;

        protected List<CardViewmodel> gameCards;

        private Stack<KeyValuePair<CardViewmodel, Rectangle>> candidateStack = new Stack<KeyValuePair<CardViewmodel, Rectangle>>();

        protected Random random = new Random(DateTime.Now.Millisecond);

        protected Grid gameGrid;

        protected SoundController soundController = new SoundController();

        public GameController(Grid gameGrid, string iconSet)
        {
            if (gameGrid == null) throw new ArgumentNullException("gameGrid can not be null.");
            if (String.IsNullOrEmpty(iconSet)) throw new ArgumentException("iconSet can not be null or empty.");

            this.gameGrid = gameGrid;
            this.iconSet = iconSet;
        }


        protected void PushCardOnCandidateStack(Rectangle cardRectangle)
        {
            candidateStack.Push(new KeyValuePair<CardViewmodel, Rectangle>((CardViewmodel)cardRectangle.DataContext, cardRectangle));
        }

        protected int CardsOnStack
        {
            get
            {
                return candidateStack.Count;
            }
        }

        private List<CardViewmodel> AssignCardsToGameGrid(Grid gameGrid, List<CardViewmodel> initialCardCollection)
        {
            List<CardViewmodel> gameCardCollection = new List<CardViewmodel>();

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    Rectangle rectangle = gameGrid.Children.OfType<Rectangle>().Single(
                        x =>
                            (int)x.GetValue(Grid.RowProperty) == row &&
                            (int)x.GetValue(Grid.ColumnProperty) == col);

                    int randomCardNumber = random.Next(0, initialCardCollection.Count);

                    CardViewmodel card = initialCardCollection[randomCardNumber];

                    gameCardCollection.Add(card);
                    rectangle.DataContext = card;

                    initialCardCollection.RemoveAt(randomCardNumber);
                    Wait(200);
                }
            }

            return gameCardCollection;
        }

        public void PickCard(Rectangle cardRectangle)
        {
            if (state == GameState.GameOver) return;

            var card = cardRectangle.DataContext as CardViewmodel;

            // Check if this card can still be played.
            if (card.Status != CardStatus.Covered)
            {
                return;
            }

            //Inform 
            OnCardPicked(card);

            soundController.Play(SoundType.Flip);
            FlipCard(cardRectangle);

            PushCardOnCandidateStack(cardRectangle);


            if (CardsOnStack == 2)
            {
                string cardName = candidateStack.Peek().Key.Name;
                bool isMatch = CheckIfCardsOnCandiateStackMatch();

                if (isMatch)
                {
                    OnMatch(cardName);
                }
                else
                {
                    OnMiss();
                }
            }


            if (!gameCards.Exists(c => c.Status == CardStatus.Covered))
            {
                state = GameState.GameOver;
            }
        }

        protected virtual void OnGameStart()
        {
            if (App.TimerStoryboard != null)
            {
                App.TimerStoryboard.Stop(gameGrid);
            }
        }

        protected virtual void OnCardPicked(CardViewmodel card)
        {
        }

        protected virtual void OnMatch(string cardName)
        {
        }

        protected virtual void OnMiss()
        {
        }

        protected bool CheckIfCardsOnCandiateStackMatch()
        {
            var evalResult = EvalCards();

            if (evalResult.Key) // It is a match
            {
                soundController.Play(SoundType.Match);
                MatchCard(evalResult.Value[0]);
                MatchCard(evalResult.Value[1]);
                return true;
            }
            else // No match
            {
                soundController.Play(SoundType.Flip);
                FlipCard(evalResult.Value[0]);
                FlipCard(evalResult.Value[1]);
                return false;
            }
        }

        protected void Wait(long milliseconds)
        {

            long dtEnd = DateTime.Now.AddTicks(milliseconds * 1000).Ticks;

            while (DateTime.Now.Ticks < dtEnd)
            {
                Grid g = new Grid();
                g.Dispatcher.Invoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object unused) { return null; }, null);
            }

        }

        protected KeyValuePair<bool, List<Rectangle>> EvalCards()
        {
            var a = candidateStack.Pop();
            var b = candidateStack.Pop();

            if (a.Key.Name == b.Key.Name) // Match Found
            {
                Wait(3500);

                return new KeyValuePair<bool, List<Rectangle>>(true, new List<Rectangle>() { a.Value, b.Value });
            }
            else // No Match
            {
                Wait(6000);

                return new KeyValuePair<bool, List<Rectangle>>(false, new List<Rectangle>() { a.Value, b.Value });
            }

        }


        protected void FlipCard(Rectangle cardRectangle)
        {
            CardViewmodel card = cardRectangle.DataContext as CardViewmodel;

            FlipCardRectangle(cardRectangle, 1, 0);

            card.ModelStatus.Flip();

            FlipCardRectangle(cardRectangle, 0, 1);
        }

        protected List<CardViewmodel> CreateCards()
        {
            List<CardViewmodel> cards = new List<CardViewmodel>();

            BitmapImage backgroundImage = GetImage("images/background.jpg");

            for (int x = 1; x < 19; x++)
            {
                BitmapImage frontImage = GetImage(String.Format("images/{1}/R{0}.png", x, iconSet));
                CardViewmodel a = new CardViewmodel(x.ToString(), frontImage, backgroundImage);

                frontImage = GetImage(String.Format("images/{1}/R{0}.png", x, iconSet));
                CardViewmodel b = new CardViewmodel(x.ToString(), frontImage, backgroundImage);

                cards.Add(a);
                cards.Add(b);
            }

            return cards;
        }


        protected void MatchCard(Rectangle rectangle)
        {
            CardViewmodel card = rectangle.DataContext as CardViewmodel;
            card.Match();
        }

        public void StartGame()
        {
            gameGrid.Children.OfType<Rectangle>().ToList().ForEach(rec => rec.DataContext = null);
            soundController.Play(SoundType.Pop);
            List<CardViewmodel> initialCards = CreateCards();
            gameCards = AssignCardsToGameGrid(gameGrid, initialCards);
            state = GameState.Running;
            //Inform, that game has started.
            OnGameStart();
        }

        private BitmapImage GetImage(string path)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = Application.GetResourceStream(new Uri(path, UriKind.Relative)).Stream;
            image.EndInit();
            return image;
        }

        private void FlipCardRectangle(Rectangle cardRectangle, int from, int to)
        {
            cardRectangle.RenderTransformOrigin = new Point(0.5, 0.5);
            ScaleTransform flipTrans = new ScaleTransform();
            flipTrans.ScaleY = 1;
            cardRectangle.RenderTransform = flipTrans;

            DoubleAnimation da = new DoubleAnimation();
            da.From = from;
            da.To = to;
            da.Duration = TimeSpan.FromMilliseconds(200);

            flipTrans.BeginAnimation(ScaleTransform.ScaleYProperty, da);
        }
    }
}
