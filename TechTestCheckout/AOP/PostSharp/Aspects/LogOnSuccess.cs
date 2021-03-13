using AOP.PostSharp.Extensions;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOP.PostSharp.Aspects
{
    [PSerializable]
    public class LogOnSuccess : OnMethodBoundaryAspect
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, nut
        /// only when the method successfully returns (i.e. when no exception flies out the method).
        /// </summary>
        /// <param name="args"></param>
        public override void OnSuccess(MethodExecutionArgs args)
        {
            _logger.Info($"{Environment.NewLine}{args.MethodFullName()}{Environment.NewLine}Succeeded...{Environment.NewLine}");
        }
    }
}
