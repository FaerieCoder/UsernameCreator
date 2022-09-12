using System.Threading;
using System;

namespace LoginCreator 
{
    public class Program
    {
        static void Main(string[] args)
        {
            //## Creating object instance(??)
            CreatingLoginDetails CLD = new CreatingLoginDetails();

            //## Calling the method in the class
            CLD.NameCollecting();

            //## Ask if want to go back to the beginning
            Console.WriteLine("\nWould you like generate new login details? [Yes/No]");
            CLD.ReturnToBeginning();
        }
    }

    public class CreatingLoginDetails
    {
        public void NameCollecting()
        {
            //## The variables needed
            string firstName, letterFirstName, lastName, username, passWord;
            Random random = new Random();

            Console.WriteLine("- - [Username Creator App] - -\n");

            //## Asking for the first name to collect the first letter
            Console.WriteLine("Enter your first name please:");

            firstName = Console.ReadLine();
            letterFirstName = ConvertFirstNameToChar(firstName);

            //## Asking for the last name
            Console.WriteLine("\nEnter your last name name please:");

            lastName = Console.ReadLine();
            lastName = string.Concat(Convert.ToString(char.ToUpper(lastName[0])) + lastName.Substring(1)); 
            // Makes the first letter a captial letter and adds the rest of the text to the letter

            //## Asking for the length of password
            Console.WriteLine("\nEnter the length you want your new password to be:");

            int passwordLength = Convert.ToInt32(Console.ReadLine());
            passWord = PasswordGenerator(passwordLength, random);


            //## Sending the information to get merged together
            username = MergeTheNames(letterFirstName, lastName);

            //##Displaying the username and password
            DisplayingDetails(username, passWord);

        }

        //## THE METHODS
        //## To get the first letter 
        static string ConvertFirstNameToChar(string name)
        {
            //## To get the first letter, we need the index of the letter and convert it to a string
            string input = Convert.ToString(name[0]);
            input = input.ToLower();
            return input;
        }

        //## Creating the username
        static string MergeTheNames(string letter, string lastname)
        {
            string input = letter + lastname;
            return input;

        }

        //## Creating a password
        private static string PasswordGenerator(int length, Random random)
        {
            //## Needed variables
            string randomletters = " ";
            string randomNumbersAndSymbols = " ";
            string allLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string allNumbers = "0123456789#$%&[]_?";

            //## If the length of the requested password is even e.g. 9, 13, 3
            if (length % 2 == 0)
            {
                for (int i = 0; i < (length / 2); i++)
                {
                    int randomNum = random.Next(0, allLetters.Length);
                    randomletters += allLetters[randomNum];
                }

                for (int i = 0; i < (length / 2); i++)
                {
                    int randomNum = random.Next(0, allNumbers.Length);
                    randomNumbersAndSymbols += allNumbers[randomNum];
                }
            }

            //## If the length of the requested password is odd e.g. 9, 13, 3
            if (length % 2 == 1)
            {
                for (int i = 0; i < ((length / 2) + 0.5); i++)
                {
                    int randomNum = random.Next(0, allLetters.Length);
                    randomletters += allLetters[randomNum];
                }

                for (int i = 0; i < ((length / 2) - 0.5); i++)
                {
                    int randomNum = random.Next(0, allNumbers.Length);
                    randomNumbersAndSymbols += allNumbers[randomNum];
                }
            }

            string randomPassword = randomletters + randomNumbersAndSymbols;
            return randomPassword.Replace(" ", "");
        }

        //## Displaying the information at the end
        public void DisplayingDetails(string username, string password)
        {
            Console.Clear();

            Console.WriteLine("Generating username and password . . . \n");

            Thread.Sleep(1000);

            Console.WriteLine($"Username: {username}\n");
            Console.WriteLine($"Password:{password}");

            Console.ReadLine();

        }

        //## Ask if want to go back to the beginning
        public void ReturnToBeginning()
        {
            string answer = Console.ReadLine();
            
            switch (answer)
            {
                case "Yes":
                    Console.Clear();
                    NameCollecting();
                    break;
                case "No":
                    Console.WriteLine("\nThank you, the program will now quit. . .");
                    Thread.Sleep(1300);
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nPlease enter Yes or No:");
                    ReturnToBeginning();
                    break;
            }
        }
    }

}
