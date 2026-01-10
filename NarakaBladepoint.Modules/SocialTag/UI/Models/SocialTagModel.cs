using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarakaBladepoint.Shared.Datas;

namespace NarakaBladepoint.Modules.SocialTag.UI.Models
{
    internal class SocialTagModel : BindableBase
    {
        internal const string IsSelectedPropertyName = "IsSelected";

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

        public SocialTagData SocialTagData { get; }

        public SocialTagModel(SocialTagData socialTagData)
        {
            SocialTagData = socialTagData;
        }
    }
}
