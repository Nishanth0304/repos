//Console.WriteLine("Hello, World!");


//Selection(Decision - Making) Statements
// 1. If Statement

//int age = 18;
//if (age >= 18)
//{
//    Console.WriteLine("Eligible to vote");
//}

//2.If Else Statement

//int number = 10;
//if (number % 2 == 0)
//{
//    Console.WriteLine("Even");
//}
//else
//{
//    Console.WriteLine("Odd");
//}

//3. if else if Statement

//int marks = 75;
//if (marks >= 90)
//{
//    Console.WriteLine("Grade A");
//}
//else if (marks >= 70)
//{
//    Console.WriteLine("Grade B");
//}
//else if (marks >= 50)
//{
//    Console.WriteLine("Grade C");
//}
//else
//{
//    Console.WriteLine("Fail");
//}

//4. switch Statement

//int day = 2;
//switch (day)
//{
//    case 1:
//        Console.WriteLine("Monday");
//        break;
//    case 2:
//        Console.WriteLine("Tuesday");
//        break;
//    default:
//        Console.WriteLine("Invalid Day");
//        break;
//}


//Iteration(Looping) Statements
// 1. for Loop

//for (int i = 1; i <= 5; i++)
//{
//    Console.WriteLine(i);
//}

// 2. while Loop

//int i = 1;
//while (i <= 5)
//{
//    Console.WriteLine(i);
//    i++;
//}

// 3. do-while Loop

//int i = 1;
//do
//{
//    Console.WriteLine(i);
//    i++;
//}
//while (i <= 5);

// 4. foreach Loop

//string[] names = { "John", "Mary", "David" };
//foreach (string name in names)
//{
//    Console.WriteLine(name);
//}


// Jump Statements
// 1 . break

//for (int i = 1; i <= 10; i++)
//{
//    if (i == 5)
//        break;
//    Console.WriteLine(i);
//}

// 2 . continue

//for (int i = 1; i <= 5; i++)
//{
//    if (i == 3)
//        continue;
//    Console.WriteLine(i);
//}

// 3. return

//int result = Add(3, 4);
//Console.WriteLine(result);
//int Add(int a, int b)
//{
//    return a + b;
//}

// 4 . goto

//goto Label;
//Label:
//Console.WriteLine("Goto Example");




class Programs
{
    static void Main()
    {
        int[] numbers = { 50, 20, 40, 10, 30 };
        Array.Sort(numbers);
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
        int[] numbers = { 10, 20, 30, 40, 50 };
        Array.Reverse(numbers);
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
        int[] numbers = { 10, 20, 30, 40, 50 };
        int index = Array.IndexOf(numbers, 30);
        Console.WriteLine(index);
        int[] numbers = { 10, 20, 30, 40 };
        bool result = Array.Exists(numbers, x => x > 35);
        Console.WriteLine(result);
    }
}