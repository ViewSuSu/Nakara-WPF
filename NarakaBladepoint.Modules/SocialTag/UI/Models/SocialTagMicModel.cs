using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarakaBladepoint.Shared.Datas;

namespace NarakaBladepoint.Modules.SocialTag.UI.Models
{
    internal class SocialTagMicModel : BindableBase
    {
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged();
            }
        }

        public SocialTagMicData SocialTagMicData { get; }

        public SocialTagMicModel(SocialTagMicData socialTagMicData)
        {
            SocialTagMicData = socialTagMicData;
        }
    }
}
