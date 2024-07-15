
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("# ----- Welcome to Money First Insurance ----- #");
Console.WriteLine();


string firstName;
string memberFirstName;
string lastName;
string memberLastName;
string dateOfBirthInput;
string memberDateOfBirthInput;
DateTime dateOfBirth;
var idFirst6Digits = string.Empty;
string idLast7Digits;
string id;
char gender;
char memberGender;
int phoneNumber;
var familyMembers = new List<FamilyMember>();
int insurancePrice = 1000;
int age;



try
{   
    WelcomeMenu();
    int welcomeMenuOption = Convert.ToInt32(Console.ReadLine());
    while (welcomeMenuOption is not 1 && welcomeMenuOption is not 2)
    {
        WelcomeMenu();
        welcomeMenuOption = Convert.ToInt32(Console.ReadLine());
    }

    switch (welcomeMenuOption)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("***** - Register a new Insurance - *****");
            Console.WriteLine();

            Console.Write("First Name: ");
            firstName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Last Name: ");
            lastName = Console.ReadLine();
            Console.WriteLine();


            Console.Write("Date of birth(Jan 21, 2006): ");
            dateOfBirthInput = Console.ReadLine();
            CheckDateOfBirth();
            AgeGroups();
            Console.WriteLine();

            GetFirst6DigitsOfID();
            Console.Write($"ID: {idFirst6Digits}");
            idLast7Digits = Console.ReadLine();
            CheckID();
            Console.WriteLine();

            Console.Write("Gender (M/F): ");
            gender = Convert.ToChar(Console.ReadLine());
            CheckGender();
            Console.WriteLine();

            Console.Write("Phone Number: +27 ");
            phoneNumber = Convert.ToInt32((Console.ReadLine()));
            CheckPhoneNumber();
            Console.Clear();

            Console.WriteLine($"***** - Welcome, {FullName()} - *****");
            Console.WriteLine();

            AccountHolderDetails();
            Console.WriteLine();
            AccountHolderMenu();
            int accountMenuOption = Convert.ToInt16(Console.ReadLine()); ;

            switch (accountMenuOption)
            {
                case 1:

                    while (true)
                    {


                        Console.Clear();
                        Console.WriteLine("***** - Adding a family member - *****");
                        Console.WriteLine();

                        Console.Write("First Name (or type 'done' to Stop adding): ");
                        memberFirstName = Console.ReadLine();
                        Console.WriteLine();

                        if (memberFirstName.ToLower() == "done")
                            break;

                        Console.Write("Last Name: ");
                        memberLastName = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("Date of birth(Jan 21, 2006): ");
                        memberDateOfBirthInput = Console.ReadLine();
                        CheckDateOfBirthofmember();
                        Console.WriteLine();

                        Console.Write("Gender (M/F): ");
                        memberGender = Convert.ToChar(Console.ReadLine());
                        CheckGender();
                        Console.WriteLine();

                        familyMembers.Add(new FamilyMember(memberFirstName, memberLastName));
                    }

                    Console.Clear();

                    Console.WriteLine("***** - Account Holder - *****");
                    AccountHolderDetails();

                    Console.WriteLine();

                    DisplayMembers();

                    Console.WriteLine();
                    InsurancePrice();
                    break;

                case 2:
                    break;
                default:
                    WelcomeMenu();
                    break;
            }

            break;

        case 2:
            break;
        default:
            WelcomeMenu();
            break;
    }
}
catch
{
    Console.WriteLine("Invalid Input, try again and make sure u answer all question accordingly");
    Console.ReadLine();
}

Console.WriteLine("Thank you for choosing Money First Insurance");

void AgeGroups()
{
    int child = ( age > 0 && age < 18) ? 1 : 0;
    int middleAged = (age <= 18 && age < 65) ? 2 : 0;
    int seniors = (age > 65 && age < 75) ? 3 : 0;
}

void InsurancePrice()
{
    int count = familyMembers.Count;
    int finalprice = insurancePrice + (count * 500); 
    if (count <= 2)
    {
        double finalinsuranceprice = finalprice * 0.2;
        Console.WriteLine($"Insurance price (per month): {finalinsuranceprice}");
    }
    else
    {
        Console.WriteLine($"Insurance price (per month): {finalprice}");

    }
}

void DisplayMembers()
{
    Console.WriteLine("***** - Members - *****");
    foreach (var member in familyMembers)
    {
        Console.WriteLine($"{member.LastName}, {member.FirstName}");
    }
}
void AccountHolderDetails()
{
    Console.WriteLine($"Full Name: {FullName()}");
    Console.WriteLine($"Date of birth: {dateOfBirthInput}");
    Console.WriteLine($"ID: {id}");
    Console.WriteLine($"Sex: {gender}");
    Console.WriteLine($"Phone Number: +27{phoneNumber}");

}

void CheckDateOfBirthofmember()
{
    bool validDateOfBirth;
    do
    {
        validDateOfBirth = DateTime.TryParse(dateOfBirthInput, out dateOfBirth);
        if (validDateOfBirth is false)
        {
            Console.WriteLine("Invalid format. Try Again");
            Console.Write("Date of birth(Jan 21, 2006): ");
            dateOfBirthInput = Console.ReadLine();
            CheckDateOfBirth();
        }
    } while (validDateOfBirth is false);
    DateTime today = DateTime.Now;
    TimeSpan ageCalculation = today - dateOfBirth;
    int age = ageCalculation.Days / 365;

    string ageCheck = (age <= 18) ? "" : "You can only register for insurance when you 18 and older.";
    Console.WriteLine(ageCheck);
}

void AccountHolderMenu()
{

    Console.WriteLine("Menu");
    Console.WriteLine("1. Add a Family to your Insurance Policy");
    Console.WriteLine("2. Exit");
}

string FullName()
{
    string fullName = firstName + " " + lastName;
    return fullName; 
}

void CheckPhoneNumber()
{
    string phoneNumberstring = phoneNumber.ToString();
    if (phoneNumberstring.Length == 9 && long.TryParse(phoneNumberstring, out _))
    {
        Console.WriteLine("Valid input: " + phoneNumberstring);
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter exactly 10 numeric digits.");
        Console.Write("Phone Number: +27 ");
        phoneNumber = Convert.ToInt32((Console.ReadLine()));

        CheckPhoneNumber();
    }
}

void GetFirst6DigitsOfID()
{
    idFirst6Digits = dateOfBirth.ToString("yyMMdd");
    idFirst6Digits.Substring(0, 5);
}

void CheckGender()
{
    do
    {
        Console.WriteLine("Invalid Option, Try Again");
        Console.Write("Gender (M/F): ");
        gender = Convert.ToChar(Console.ReadLine());
        CheckGender();
    } while (gender is not 'M' && gender is not 'F' && gender is not 'm' && gender is not 'f');
}

void CheckID()
{
    do
    {
        id = idFirst6Digits + idLast7Digits;

        if (idLast7Digits.Length is not 7)
        {
            Console.WriteLine("Please enter the last 7 digits of your ID number.");
            Console.WriteLine();
            GetFirst6DigitsOfID();
            Console.Write($"ID: {idFirst6Digits}");
            idLast7Digits = Console.ReadLine();
            CheckID();
            Console.WriteLine();
        }

    } while (idLast7Digits.Length is not 7);
}

void CheckDateOfBirth()
{
    bool validDateOfBirth;
    do
    {
        validDateOfBirth = DateTime.TryParse(dateOfBirthInput, out dateOfBirth);
        if (validDateOfBirth is false)
        {
            Console.WriteLine("Invalid format. Try Again");
            Console.Write("Date of birth(Jan 21, 2006): ");
            dateOfBirthInput = Console.ReadLine();
            CheckDateOfBirth();
        }
    } while (validDateOfBirth is false);
    DateTime today = DateTime.Now;
    TimeSpan ageCalculation = today - dateOfBirth;
    age = ageCalculation.Days / 365;

    if (age < 18 || age > 65)
    {
        string ageCheck = (age >= 18 && age <= 65) ? "" : "You can only register for insurance when you 18 and younger than 65.";
        Console.WriteLine(ageCheck);
        
        Console.Write("Date of birth(Jan 21, 2006): ");
        dateOfBirthInput = Console.ReadLine();
        CheckDateOfBirth();
        AgeGroups();
        Console.WriteLine();
    }
}

void WelcomeMenu()
{
    
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Register a new Insurance policy");
    Console.WriteLine("2. Exit");
    Console.Write("Option: ");

}

class FamilyMember
{
    public string FirstName { get; }
    public string LastName { get; }
 



    public FamilyMember(string memberFirstName, string memberLastName)
    {
        FirstName = memberFirstName;
        LastName = memberLastName;

    }
}