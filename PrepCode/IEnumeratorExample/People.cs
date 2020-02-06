using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepCode.IEnumeratorExample
{
    public class People : IEnumerable
    {
        private Person[] _people;

        public People(Person[] people)
        {
            _people = people;
        }

        public IEnumerator GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }
}
