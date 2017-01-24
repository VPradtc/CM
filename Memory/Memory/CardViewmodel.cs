using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using Pairs.Client.Statuses;
using Pairs.Client;

namespace Pairs
{
    public class CardViewmodel : INotifyPropertyChanged
    {
        private readonly string name;

        public ICardViewmodelStatus ModelStatus { get; set; }

        public CardViewmodel(string name, BitmapImage frontImage, BitmapImage backImage)
        {
            this.name = name;

            var imageSet = new CardImageSet()
            {
                BackImage = backImage,
                FrontImage = frontImage,
            };

            ModelStatus = new CoveredCardViewmodelStatus(imageSet, this);
        }

        public string Name
        {
            get { return name; }
        }

        public CardStatus Status
        {
            get
            {
                return ModelStatus.Status;
            }
        }

        public Brush ActiveImage
        {
            get
            {
                return ModelStatus.ActiveImage;

                throw new InvalidOperationException("Invalid Card State.");
            }
        }

        public void TriggerStatusChange()
        {
            RaiseNotifyChanged("ActiveImage");
        }

        public void Match()
        {
            this.ModelStatus = new MatchedCardViewmodelStatus();
            RaiseNotifyChanged("ActiveImage");
        }

        private void RaiseNotifyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
