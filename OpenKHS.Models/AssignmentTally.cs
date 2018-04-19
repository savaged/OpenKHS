
using System;

namespace OpenKHS.Models
{
    public struct AssignmentTally
    {
        private int _tally;

        public AssignmentTally(int tally)
        {
            _tally = tally;
        }

        public void Reset(int lowestCongMemberTally)
        {
            _tally = lowestCongMemberTally;
        }

        public static AssignmentTally operator ++(AssignmentTally value)
        {
            value._tally++;
            return value;
        }

        public static AssignmentTally operator --(AssignmentTally value)
        {
            value._tally--;
            return value;
        }

        public static bool operator ==(AssignmentTally a, int i)
        {
            return a._tally == i;
        }

        public static bool operator !=(AssignmentTally a, int i)
        {
            return !(a == i);
        }

        public static bool operator !=(AssignmentTally l, AssignmentTally r)
        {
            return !(l == r);
        }

        public static bool operator ==(AssignmentTally l, AssignmentTally r)
        {
            return l._tally == r._tally;
        }

        public override bool Equals(object o)
        {
            if (o is null)
            {
                return false;
            }
            if (o is int i)
            {
                return i == _tally;
            }
            if (o is AssignmentTally a)
            {
                return a._tally == _tally;
            }
            return false;
        }

        public bool Equals(AssignmentTally a)
        {
            return a._tally == _tally;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _tally;
        }

        public static bool operator <(AssignmentTally a, int i)
        {
            return a._tally < i;
        }
        public static bool operator >(AssignmentTally a, int i)
        {
            return a._tally > i;
        }

        public static bool operator <(AssignmentTally l, AssignmentTally r)
        {
            return l._tally < r._tally;
        }
        public static bool operator >(AssignmentTally l, AssignmentTally r)
        {
            return l._tally > r._tally;
        }

        public static explicit operator AssignmentTally(int i)
        {
            return new AssignmentTally(i);
        }

        public static implicit operator int(AssignmentTally a)
        {
            return a._tally;
        }

        public override string ToString()
        {
            return _tally.ToString();
        }
    }
}
