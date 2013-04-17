﻿using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.Shell.Interop;

namespace NuPattern.VisualStudio.Diagnostics
{
    internal class OutputWindowTextWriter : TextWriter
    {
        IVsOutputWindowPane outputPane;

        public OutputWindowTextWriter(IVsOutputWindowPane outputPane)
        {
            this.outputPane = outputPane;
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }

        public override void Write(string value)
        {
            outputPane.OutputStringThreadSafe(value);
        }

        public override void WriteLine()
        {
            outputPane.OutputStringThreadSafe(Environment.NewLine);
        }

        public override void WriteLine(string value)
        {
            Write(value);
            WriteLine();
        }
    }
}
