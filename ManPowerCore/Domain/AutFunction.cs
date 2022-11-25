using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class AutFunction
    {
        [DBField("ID")]
        public int AutFunctionId { get; set; }

        [DBField("FUNCTION_NAME")]
        public string FunctionName { get; set; }

        [DBField("URL")]
        public string Url { get; set; }

        [DBField("MENU_ICON")]
        public string MenuIcon { get; set; }
    }
}
