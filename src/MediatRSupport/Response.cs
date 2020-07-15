using System;
using System.Collections.Generic;
using System.Text;

namespace AppBlocks.Autofac.Examples.MediatRSupport
{
    public class Response
    {
        public string Output { get; set; }

        public override string ToString() => $"Output: {Output}";
    }
}
