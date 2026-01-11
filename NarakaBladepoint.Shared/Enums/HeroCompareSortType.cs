using System.ComponentModel;

namespace NarakaBladepoint.Shared.Enums
{
    public enum HeroCompareSortType
    {
        [Description("游戏时间")]
        GameTime,

        [Description("前五率")]
        TopFiveRate,

        [Description("场均伤害")]
        AverageDamage,

        [Description("击败/被击败")]
        KillDeathRatio,

        [Description("英雄积分")]
        HeroScore
    }
}