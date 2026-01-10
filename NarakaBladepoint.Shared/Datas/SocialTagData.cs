using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarakaBladepoint.Shared.Datas
{
    public enum SocialTagType
    {
        /// <summary>
        /// 战斗
        /// </summary>
        Fight,

        /// <summary>
        /// 社交
        /// </summary>
        Social,

        /// <summary>
        /// 个性
        /// </summary>
        Personality,

        /// <summary>
        /// 模式
        /// </summary>
        Mode,

        /// <summary>
        /// 语言
        /// </summary>
        Language,
    }

    public class SocialTagData
    {
        public int Index { get; set; }

        public string Text { get; set; }

        public SocialTagType TagType { get; set; }
    }
}
