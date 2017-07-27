using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestDemo.ViewModels
{
    public class ToggleVm
    {
        public bool Good { get; set; }
        public bool Bad { get; set; }
        public bool SetTrue { get; set; } = true;
        public bool SetFalse { get; set; } = false;

        public bool SetTrueThenFalse { get; set; } = true;
        public bool SetFalseThenTrue { get; set; } = false;
    }
}