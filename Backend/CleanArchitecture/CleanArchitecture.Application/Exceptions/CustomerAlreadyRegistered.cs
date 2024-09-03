#nullable enable

using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Exceptions
{
    public class CustomerAlreadyRegisteredException : Exception
    {
        public CustomerAlreadyRegisteredException(string? message) : base(message)
        {
        }
    }
}
