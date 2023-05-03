using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning02 World!");
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();


    }
}

// EXAMPLE OF A CLASS IN CODE 
// A code template for the category of things known as Person. The
// responsibility of a Person is to hold and display personal information.
// public class Person
// {
// The C# convention is to start member variables with an underscore _
// public string _givenName = "";
// public string _familyName = "";

// A special method, called a constructor that is invoked using the  
// new keyword followed by the class name and parentheses.
// public Person()
// {
// }
// A method that displays the person's full name as used in eastern 
// countries or <family name, given name>.
// public void ShowEasternName()
// {
//     Console.WriteLine($"{_familyName}, {_givenName}");
// }
// A method that displays the person's full name as used in western 
// countries or <given name family name>.
// public void ShowWesternName()
// {
//     Console.WriteLine($"{_givenName} {_familyName}");
// }

// CREATING CLASS DIAGRAMS
//     Class: Person
// Attributes:
// * _givenName : string
// * _familyName : string
// Behaviors:
// * ShowEasternName() : void
// * ShowWesternName() : void

// input
// Person person = new Person();
// person._givenName = "Joseph";
// person._familyName = "Smith";
// person.ShowWesternName();
// person.ShowEasternName();
// output 
// Joseph Smith
// Smith, Joseph

// MULTIPLE INSTANCES CREATED AND USED IN THE SAME PROGRAM
// input
// person1 = new Person();
//     person1._givenName = "Emma";
//     person1._familyName = "Smith";
//     person1.ShowWesternName();

//     person2 = new Person();
//     person2._givenName = "Joseph";
//     person2._familyName = "Smith";
//     person2.ShowWesternName();
// output
// Emma Smith
// Joseph Smith

// In your code, whenever you use the variable kitchen it refers to a large box, 
// and if you want to refer to anything inside the box, you use the "dot" operator. 
// You can set the values as follows:
// Blind kitchen = new Blind();

// kitchen._width = 60;
// kitchen._height = 48;
// kitchen._color = "white";
// Console.WriteLine(kitchen._width);


// ADDING BEHAVIORS 
// public class Blind
// {
//     public double _width;
//     public double _height;
//     public string _color;

//     public double GetArea()
//     {
//         return _width * _height;
//     }
// }
// The GetArea() function now belongs inside the box as well. And because it is inside the box, 
// you use the "dot" notation to call it:

// double materialAmount = kitchen.GetArea();


// OBJECTS WITHIN OBJECTS 
//     public class House
// {
//     public string _owner;
//     public Blind _kitchen;
//     public Blind _livingRoom;
// }
// Remember, that you must initialize these blinds to new values. 
// You can do this after you create a new House object:

// House johnsonHome = new House();

// johnsonHome._kitchen = new Blind();
// johnsonHome._livingRoom = new Bind();
// Or, you can initialize these variables right in the class definition:

// public class House
// {
//     public string _owner = "";
//     public Blind _kitchen = new Blind();
//     public Blind _livingRoom = new Blind();
// }
// Once you have created a new House object, you can access its member variables using the "dot" operator just as before:

// House johnsonHome = new House();
// johnsonHome._owner = "Johnson Family";
// When you want to access the internal values of one of these complex-type, member variables, 
// you can just chain together multiple "dot" operations, such as:

// johnsonHome._kitchen._width = 60;


// LISTS OF CUSTOM TYPES
//     public class House
// {
//     public string _owner;
//     public List<Blind> _blinds = new List<Blind>();
// }
// With this new version of the House class, you could write code like:

// johnsonHome._blinds.Add(kitchen);
// or:

// double amount = johnsonHome._blinds[0].GetArea();
// or:

// foreach (Blind b in johnsonHome._blinds)
// {
//     double amount = b.GetArea();
// }


// TERMS AND DEFINITIONS
// Class - A new custom data type that defines attributes (member variables) and methods. 
// This is like a blueprint to create instances or objects of that class. 
// Example: A Person has given name and family name.

// Instance - A variable whose data type is the class. We often use the term Object interchangeably. 
// Example: We can have two instances of the Person class: one for John, and one for Mary.

// Instantiate - A verb that means "to create an instance of." 
// Example: We can instantiate the Person class to create a new object.

// Method - A member function. Methods are called using "dot notation" with an instance of the class before the dot. 
// Example: person1.GetEasternName()
