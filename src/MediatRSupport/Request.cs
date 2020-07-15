﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBlocks.Autofac.Examples.MediatRSupport
{
    public class Request : IRequest<Response>
    {
        public string Input { get; set; }

        public override string ToString() => $"Input: {Input}";
    }
}
