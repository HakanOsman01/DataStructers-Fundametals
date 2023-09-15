
using System;

namespace Ganchev
{
    public class Collections
    {
        private List<Person> persons;
        public Collections()
        {
            persons=new List<Person> ();
        }
        public IReadOnlyCollection<Person> Persons()
        {
            return persons.AsReadOnly();
        }
    }
}
