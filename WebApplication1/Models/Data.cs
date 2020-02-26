using System;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
    public class Data : IEquatable<Data>
    {
        public string Index { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Index;
        }
        public bool Equals([AllowNull] Data other)
        {
            return Name == other.Name && Index == other.Index;
        }
    }
}
