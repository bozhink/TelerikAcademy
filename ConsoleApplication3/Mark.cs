using SchoolSystem;
using System;

namespace SchoolSystem
{
    class Mark {
        public Mark(Subjct sbj, float va) {
            subject = sbj;
            value = va;
        }
        internal float value;
        internal Subjct subject;
    }
}
