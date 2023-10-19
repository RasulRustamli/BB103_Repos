using bb103_Exception.Exceptions;

namespace bb103_Exception
{
    internal class Student
    {
        int _age;
        public int Age
        {
            get
            { return _age; }
            set
            {
                if(value>18)
                {
                    _age = value;
                }
                else
                {
                    throw new AgeException("18den asagi telebeleri qebul etmirik");
                }
            }
        }
        public string Name { get; set; }
    }
}
