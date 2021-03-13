using AOP.PostSharp.Extensions;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOP.PostSharp.Aspects
{
    [PSerializable]
    public class LogOnException : OnMethodBoundaryAspect
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied,
        /// in case that the method resulted with an exception
        /// </summary>
        /// <param name="args"></param>
        public override void OnException(MethodExecutionArgs args)
        {
            var logDescription = $"ERROR/FAILED ! at {args.MethodFullName()}{Environment.NewLine}";

            if (args.Exception != null)
            {
                logDescription += $"{args.Exception.Message}{Environment.NewLine}";
                if (args.Exception.InnerException != null)
                {
                    logDescription += $"Inner Exception:{Environment.NewLine}{args.Exception.InnerException.Message}";
                }
            }

            _logger.Error($"{Environment.NewLine}{logDescription}{Environment.NewLine}");
        }
    }
}
