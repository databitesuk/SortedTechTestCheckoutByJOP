using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOP.PostSharp.Extensions
{
    /// <summary>
    /// Get full name (namespace, class and method names
    /// </summary>
    public static class MethodExecutionArgsExtensions
    {
        public static string MethodFullName(this MethodExecutionArgs args) => $"{args.Method.DeclaringType.FullName}_{args.Method.Name}";
    }
}
