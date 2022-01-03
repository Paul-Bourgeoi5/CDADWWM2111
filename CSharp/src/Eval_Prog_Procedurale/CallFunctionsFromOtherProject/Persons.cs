using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallFunctionsFromOtherProject
{
    class Persons : List<Person>
    {
        public override string ToString()
        {
            StringBuilder result = new("List of persons in the list :\n");
            foreach(Person person in this)
            {
                result.Append($"{person.ToString()}\n");
            }
            return result.ToString();
        }
    }
}
