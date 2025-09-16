using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human
    {
        protected string _firstName = "Pat";
        protected string _lastName = "Smyth";
        public Human(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
        public Human()
        {
        }

        public string AboutMe()
        {
            return $"My name is {_firstName} {_lastName}.";
        }
    }//end of class
}//end of namespace