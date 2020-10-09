using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TrabalhandoComColeções
{
    internal class ComparadorTextos : IComparer<string>
    {
        public int Compare([AllowNull] string x, [AllowNull] string y)
        {
            return string.Compare(x, y, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}