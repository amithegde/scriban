// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license. 
// See license.txt file in the project root for full license information.
using Scriban.Runtime;

namespace Scriban.Syntax
{
    [ScriptSyntax("capture statement", "capture <variable> ... end")]
    public class ScriptCaptureStatement : ScriptStatement
    {
        public ScriptExpression Target { get; set; }

        public ScriptBlockStatement Body { get; set; }

        public override object Evaluate(TemplateContext context)
        {
            // unit test: 230-capture-statement.txt
            context.PushOutput();
            try
            {
                context.Evaluate(Body);
            }
            finally
            {
                var result = context.PopOutput();
                context.SetValue(Target, result);
            }
            return null;
        }

        protected override void WriteImpl(RenderContext context)
        {
            context.Write("capture").WithSpace();
            Target?.Write(context);
            context.WithEos();
            Body?.Write(context);
            WriteEnd(context);
        }
    }
}