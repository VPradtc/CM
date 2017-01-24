using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pairs.Client.Statuses
{
    public abstract class CardViewmodelStatus : ICardViewmodelStatus
    {
        public abstract CardStatus Status { get; }

        public Brush ActiveImage
        {
            get
            {
                var image = GetActiveImage();

                return new ImageBrush(image)
                {
                    Stretch = Stretch.Uniform,
                };
            }
        }

        protected abstract BitmapImage GetActiveImage();

        public abstract void Flip();
    }
}
