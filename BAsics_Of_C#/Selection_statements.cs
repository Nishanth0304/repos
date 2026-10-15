//Selection(Decision - Making) Statements
 //1. If Statement

int age = 18;
if (age >= 18)
{
    Console.WriteLine("Eligible to vote");
}

//2.If Else Statement

int number = 10;
if (number % 2 == 0)
{
    Console.WriteLine("Even");
}
else
{
    Console.WriteLine("Odd");
}

//3. if else if Statement

int marks = 75;
if (marks >= 90)
{
    Console.WriteLine("Grade A");
}
else if (marks >= 70)
{
    Console.WriteLine("Grade B");
}
else if (marks >= 50)
{
    Console.WriteLine("Grade C");
}
else
{
    Console.WriteLine("Fail");
}

//4. switch Statement

int day = 2;
switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    default:
        Console.WriteLine("Invalid Day");
        break;
}