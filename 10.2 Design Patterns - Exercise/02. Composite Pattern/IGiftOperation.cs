using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    public interface IGiftOperation
    {
        void Add(GiftBase gift);
        void Remove(GiftBase gift);
    }
}
