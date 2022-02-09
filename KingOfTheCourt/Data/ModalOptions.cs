﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingOfTheCourt.Data
{
    public class ModalOptions
    {
        public string Position { get; set; }
        public string Style { get; set; }
        public bool? DisableBackgroundChannel { get; set; }
        public bool? HideButton { get; set; }
        public bool? HideCloseButton { get; set; }
    }
}
