using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validatio_Task
{
    internal class Program
    {
            static void Main(string[] args)
            {
                string firstName, lastName, username, password, emailAddress;
                int age;

            // get the user inputs until all are valid.
            // The username should only be output once
            bool validity = false;
            while (validity == false)
            {
                Console.Write("Enter first name: ");
                firstName = Console.ReadLine();
                validity = ValidName(firstName);
            }
            validity = false;
            while (validity == false)
            {
                Console.Write("Enter last name: ");
                lastName = Console.ReadLine();
                validity = ValidName(lastName);
            }
            validity = false;
            Console.Write("Enter age: ");
                age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
                Console.Write("Enter email address: ");
                emailAddress = Console.ReadLine();


                //username = createUserName(firstName, lastName, age);
                //Console.WriteLine($"Username is {username}, you have successfully registered please remember your password");

                //  Test your program with a range of tests to show all validation works
                // Show your evidence in the Readme

            }
        static bool ValidName(string name)
        {
            // name must be at least two characters and contain only letters
            bool letters = false;
            if (name.Length > 2)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    letters = int.TryParse(name[i].ToString(), out int result);
                    if (letters == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

            static bool validAge(int age)
            {
                //age must be between 11 and 18 inclusive
                if (age < 18 && age > 11)
                {
                    return true;
                }
            return false;
            }


            static bool ValidPassword(string password)
            {
            // Check password is at least 8 characters in length
            int passwordLength = password.Length;
                if (passwordLength < 8)
            {
                return false;
            }

            // Check password contains a mix of lower case, upper case and non letter characters
            // QWErty%^& = valid
            // QWERTYUi = not valid
            // ab£$%^&* = not valid
            // QWERTYu! = valid
            bool uppercase = false;
            bool lowercase = false;
            bool NonLetter = false;
            int[] ASCIIValues = { };
            Array.Resize(ref ASCIIValues, passwordLength);
            for (int i = 0; i < passwordLength;i++)
            {
                ASCIIValues[i] = Convert.ToInt32(password[i]);
            }
            int capitals = 0;
            for (int i = 0; i < passwordLength; i++)
            {
                if (ASCIIValues[i] < 91 && ASCIIValues[i] > 64)
                {
                    capitals++;
                }
            }
            if (capitals > 0)
            {
                uppercase = true;
            }
            int NotCapital = 0;
            for (int i = 0; i < passwordLength; i++)
            {
                if (ASCIIValues[i] < 123 && ASCIIValues[i] > 96)
                {
                    NotCapital++;
                }
            }
            if (NotCapital > 0)
            {
                lowercase = true;
            }
            for (int i = 0; i < passwordLength; i++)
            {
                if (ASCIIValues[i] < 123 && ASCIIValues[i] > 64)
                {
                    if (ASCIIValues[i] < 91 && ASCIIValues[i] > 96)
                    {
                        NonLetter = true;
                    }
                    NonLetter = false;
                }
            }
            NonLetter = true;
            if (NonLetter == true && lowercase == true && uppercase == true)
            {



                // Check password contains no runs of more than 2 consecutive or repeating letters or numbers
                // AAbbdd!2 = valid (only 2 consecutive letters A and B and only 2 repeating of each)
                // abC461*+ = not valid (abC are 3 consecutive letters)
                // 987poiq! = not valid (987 are consecutive)
                for (int i = 0; i < passwordLength - 2; i++)
                {
                    if (ASCIIValues[i + 1]-1 == ASCIIValues[i] && ASCIIValues[i] == ASCIIValues[i+2]-2)
                    {
                        return false;
                    }
                }
            }
            return true;

        }
        static bool validEmail(string email)
        {
            // a valid email address
            // has at least 2 characters followed by an @ symbol
            // has at least 2 characters followed by a .
            // has at least 2 characters after the .
            // contains only one @ and any number of .
            // does not contain any other non letter or number characters
            int indexOfAt = email.IndexOf("@");
            if (indexOfAt -2 < 0)
            {
                return false;
            }
            int indexOfDot = email.IndexOf('.');
            if (indexOfDot + 2 > email.Length - 1)
            {
                return false;
            }
           if ( email.LastIndexOf('@') == email.IndexOf('@'))
            {
                return false;
            }
            int[] ASCII = { };
            Array.Resize(ref ASCII, email.Length);
           for (int i = 0; i < email.Length; i++)
            {
                ASCII[i] = Convert.ToInt32(email[i]);
            }
            for (int i = 0; i < email.Length; i++)
            {
                if (ASCII[i] < 123 && ASCII[i] > 64)
                {
                    if (ASCII[i] < 91 && ASCII[i] > 96)
                    {
                        return true;
                    }
                    return  false;
                }
            }
            return true;
        }
        static string createUserName(string firstName, string lastName, int age)
        {
            // username is made up from:
            // first two characters of first name

            // last two characters of last name
            // age
            //e.g. Bob Smith aged 34 would have the username Both34
            string Username;
            Username = firstName.Substring(0, 2);
            Username.Concat(lastName.Substring(lastName.Length - 2, 2));
            Username = String.Concat(Username, age);
            return Username;


        }

    }
    }
