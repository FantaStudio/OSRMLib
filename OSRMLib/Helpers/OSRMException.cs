using OSRMLib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;


class OSRMException : Exception
{
    public Service Service { get; set; }
    public OSRMException(string message): base(message) { }
}

