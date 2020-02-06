using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PrepCode.IEnumeratorExample
{
    class PeopleEnum : IEnumerator
    {
        int position = -1;
        Person[] _people;

        public PeopleEnum(Person[] list)
        {
            _people = list;
        }
        public object Current
        {
            get
            {
                try
                {
                    return (Person)_people[position];
                }
                catch (IndexOutOfRangeException)
                {

                    throw new InvalidOperationException();
                }
               
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
