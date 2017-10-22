
using Newtonsoft.Json;
using OpenKHS.Interfaces;
using System.Collections.Generic;
using System.Collections;

namespace OpenKHS.Models
{
    public class Congregation : IList<Friend>, ICongregation
    {
        public Congregation()
        {
            Members = new List<Friend>();
        }

        public List<Friend> Members { get; set; }

        public int Count => ((IList<Friend>)Members).Count;

        public bool IsReadOnly => ((IList<Friend>)Members).IsReadOnly;

        public Friend this[int index] { get => ((IList<Friend>)Members)[index]; set => ((IList<Friend>)Members)[index] = value; }

        public int IndexOf(Friend item)
        {
            return ((IList<Friend>)Members).IndexOf(item);
        }

        public void Insert(int index, Friend item)
        {
            ((IList<Friend>)Members).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Friend>)Members).RemoveAt(index);
        }

        public void Add(Friend item)
        {
            ((IList<Friend>)Members).Add(item);
        }

        public void Clear()
        {
            ((IList<Friend>)Members).Clear();
        }

        public bool Contains(Friend item)
        {
            return ((IList<Friend>)Members).Contains(item);
        }

        public void CopyTo(Friend[] array, int arrayIndex)
        {
            ((IList<Friend>)Members).CopyTo(array, arrayIndex);
        }

        public bool Remove(Friend item)
        {
            return ((IList<Friend>)Members).Remove(item);
        }

        public IEnumerator<Friend> GetEnumerator()
        {
            return ((IList<Friend>)Members).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<Friend>)Members).GetEnumerator();
        }

        public override string ToString()
        {
            return JsonEncode();
        }

        public string JsonEncode()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
