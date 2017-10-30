// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license. 
// See license.txt file in the project root for full license information.

namespace Scriban.Syntax
{
    public class ScriptPage : ScriptBlockStatement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptPage"/> class.
        /// </summary>
        public ScriptPage()
        {
        }

        /// <summary>
        /// Gets or sets the front matter. May be <c>null</c> if script is not parsed using <see cref=ParsingModeParsingMode.FrontMatter"/>. See remarks.
        /// </summary>
        /// <remarks>
        /// Note that this code block is not executed when evaluating this page. It has to be evaluated separately (usually before evaluating the page).
        /// </remarks>
        public ScriptBlockStatement FrontMatter { get; set; }


        protected override void WriteImpl(RenderContext context)
        {
            // Make sure that we exit in a raw statement
            context.IsNextStatementRaw = true;

            base.WriteImpl(context);

            if (context.IsInCode)
            {
                WriteExitCode(context);
            }
        }
    }
}