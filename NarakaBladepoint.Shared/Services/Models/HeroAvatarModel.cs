using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using NarakaBladepoint.Framework.Core.Extensions;
using NarakaBladepoint.Resources;

namespace NarakaBladepoint.Shared.Services.Models
{
    public class HeroAvatarModel
    {
        /// <summary>
        /// 索引
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// 英雄名字
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// 英雄头像
        /// </summary>
        public ImageSource Avatar { get; internal set; }
    }
}
