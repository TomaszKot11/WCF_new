﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfHomework.Exceptions
{
    class WrongSignatureException
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}