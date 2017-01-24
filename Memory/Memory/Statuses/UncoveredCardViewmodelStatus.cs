using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pairs.Client.Statuses
{
    public class UncoveredCardViewmodelStatus : CardViewmodelStatus
    {
        private readonly CardViewmodel _statusOwner;
        private readonly CardImageSet _images;

        public UncoveredCardViewmodelStatus(CardImageSet images,
            CardViewmodel statusOwner)
        {
            _statusOwner = statusOwner;
            _images = images;
        }

        public override void Flip()
        {
            _statusOwner.ModelStatus = new CoveredCardViewmodelStatus(_images, _statusOwner);
            _statusOwner.TriggerStatusChange();
        }

        public override CardStatus Status
        {
            get
            {
                return CardStatus.Uncovered;
            }
        }

        protected override BitmapImage GetActiveImage()
        {
            return _images.FrontImage;
        }
    }
}
