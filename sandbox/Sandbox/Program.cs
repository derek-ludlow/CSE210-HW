using System;

class Program
{
    static void Main(string[] args)
    {

        var personOne = new Person("luke skywalker");

        var byuiPerson = new BYUIPerson("obi-wan", "1");

        var studentOne = new Student("darth vader", "2", "the dark side of the force");


    }
}
// Parent class 
// Super class 
// Base class 
class Person
{
    protected string _name;

    private string _height;

    public Person(string name)
    {
        _name = name;
    }

    public Person(string name, string height)
    {

    }
}
class BYUIPerson : Person
{
    protected string _iNumber;

    public BYUIPerson(string name, string iNumber) : base(name)
    {
        _iNumber = iNumber;
    }
}
// Sub class 
// Child class 
class Student : BYUIPerson
{
    private string _major;

    public Student(string name, string iNumber, string major) : base(name, iNumber)
    {
        _major = major;
    }
}

class Teacher : BYUIPerson
{
    private string _department;

    public Teacher(string name, string iNumber, string department) : base(name, iNumber)
    {
        _department = department;
    }


}
