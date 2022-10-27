// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.CommandLine;

namespace MRLogs.Commands
{
    public class TraceLogCommand : Command
    {
        public TraceLogCommand() : base("trace", "Access and write trace logs")
        {
        }
    }
}
