using System;

namespace CallFunctionsFromOtherProject
{
    class Person
    {
        
        private string _name;

        public string Name
        {
            get { return _name; }
            init { if (!String.IsNullOrEmpty(value))
                    _name = value; }
        }

        private int _age;

        public int Age
        {
            get => _age;
            set {
                if (value > 0)
                {
                    _age = value;
                }
            }
        }



        public override string ToString()
        {
            Func<string, int, string> nameAge = (name, age) =>  $"Name : {name}, age : {age}";
            return nameAge(this.Name, this.Age);

        }

    }
}
