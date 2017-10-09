
namespace OpenKHS.Models
{
    public class AssignmentTally
    {
        private int _tally;

        public AssignmentTally()
        {
            _tally = 0;
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

        public static bool operator ==(AssignmentTally a, int i)
        {
            if (a is null)
            {
                return false;
            }
            return a._tally == i;
        }

        public static bool operator !=(AssignmentTally a, int i)
        {
            return !(a == i);
        }

        public override bool Equals(object o)
        {
            var a = o as AssignmentTally;
            if (a is null)
            {
                if (!(o is int)) return false;
                return _tally == (int)o;
            }
            return a._tally == _tally;
        }

        public bool Equals(AssignmentTally a)
        {
            if (a is null) return false;
            return a._tally == _tally;
        }

        public override string ToString()
        {
            return _tally.ToString();
        }
    }
}
