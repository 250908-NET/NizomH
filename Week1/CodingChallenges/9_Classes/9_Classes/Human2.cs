using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human2: Human
    {
        private string _eyeColor;
        private int _age;
        private int _weight;

        public Human2(string firstName, string lastName, string eyeColor, int age)
        {

            _firstName = firstName;
            _lastName = lastName;
            _eyeColor = eyeColor;
            _age = age;
        }
        public Human2(string firstName, string lastName, string eyeColor)
        {

            _firstName = firstName;
            _lastName = lastName;
            _eyeColor = eyeColor;
        }
        public Human2(string firstName, string lastName, int age)
        {

            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }
        public Human2() {}

        public string AboutMe2()
        {
            string info = $"My name is {_firstName} {_lastName}.";
            if (_age != 0)
            {
                info += $" My age is {_age}.";
            }
            if (_eyeColor != null)
            {
                info += $" My eye color is {_eyeColor}.";
            }
            return info;
        }
        public int Weight
        {
            get { return _weight; }
            set
            {
                if (value < 0 || value > 400)
                {
                    _weight = 0;
                }
                else
                {
                    _weight = value;
                }
            }
        }

    }
}