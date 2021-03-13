using AOP.PostSharp.Extensions;
using Newtonsoft.Json;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOP.PostSharp.Aspects
{
    [PSerializable]
    public class LogOnEntryOnExit : OnMethodBoundaryAspect
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Method executed before the body of methods to which this aspect is applied.
        /// </summary>
        /// <param name="args"></param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            var logDescription = $"{args.MethodFullName()}{Environment.NewLine}Started/OnEntry...{Environment.NewLine}";

            if (args.Arguments != null && args.Arguments.Count > 0)
            {
                var parameters = args.Method.GetParameters().ToDictionary(key => key.Name, value => args.Arguments[value.Position]);

                // Serialize to JSON (newtonsoft lib)
                logDescription += $"args/paremters:{Environment.NewLine}{JsonConvert.SerializeObject(parameters)}";
            }

            _logger.Info($"{Environment.NewLine}{logDescription}{Environment.NewLine}");
        }

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, even
        /// when the method exists with an exception (this method is invoked from the finally block).
        /// </summary>
        /// <param name="args"></param>
        public override void OnExit(MethodExecutionArgs args)
        {
            _logger.Info($"{Environment.NewLine}{args.MethodFullName()}{Environment.NewLine}Ended/Exited...{Environment.NewLine}");
        }
    }
}
