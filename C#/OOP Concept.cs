// // Object Oriyented Programming(Method and Set value basics)
// using System;

// class Person {
//     public string? name;
//     public int age;

//     public void Set(string s, int a) {
//         name = s;
//         age = a;
//     }
//     public void DisplayInfo() {
//         Console.WriteLine($"My name is {name}, I am {age} years old");
//     }

// }

// class Test {
//     public static void Main(string[] args) {
//         Person p1 = new Person();
//         // p1.name = "Hafiz";
//         // p1.age = 24;
//         p1.Set("Hafiz", 24);
//         p1.DisplayInfo();
//     }
// }

// Peramiterized constructor and Default Constractor

using System;

// class Person {
//     public string? name;
//     public int age;

//     public Person() {
//         name = "Not set any Name";
//         age = 0;
//     }
//     public Person(string s, int a) {
//         name = s;
//         age = a;
//     }

//     public void DisplayInfo() {
//         Console.WriteLine($"My name is {name}\n, I am {age} years old");
//     }
// }
// class Test {
//     public static void Main(string[] args) {
//         Person p1 = new Person();
//         p1.DisplayInfo();
//         Person p2 = new Person("Hafiz", 24);
//         p2.DisplayInfo();
        
//     }
// }


// This and ReadOnly

using System;


class Student {
    public string? s;
    public readonly int Age;

    public Student(int age) {
        this.Age = age;
    }
    public void DisplayInfo() {
        Console.WriteLine($"Age is: {Age}");
    }
}
class Test {
    public static void Main(string[] args) {
        Student s1 = new Student(25);
        s1.DisplayInfo();

    }
}
