using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarakaBladepoint.Shared.Consts;

namespace NarakaBladepoint.Shared.Enums
{
    public enum TeamSize
    {
        [Description(TeamSizeConstant.Solo)]
        Solo = 1,

        [Description(TeamSizeConstant.Duo)]
        Duo = 2,

        [Description(TeamSizeConstant.Trio)]
        Trio = 3,
    }
}
