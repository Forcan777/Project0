using System;

namespace EmployeeManagementSystem
{
    public class ExHandle
    {
        //Checking for Input Format Exception (numeric input)
        public int InputExceptionCheck()
        {
            int uSelect = -1; //Set a default value for user's choice.
            
            try
            {
                uSelect = Convert.ToInt32(System.Console.ReadLine()); // receives user input and convert to number
            }
            catch (FormatException)
            {
                // If a format exception is encounter in the input (character input)
                System.Console.WriteLine("Invalid Input, Please try again!");
            }                
            catch (Exception exEnc)
            {
                // Chatch thrown exceptions
                System.Console.WriteLine(exEnc.Message);
            }

            return uSelect;
        }
        
        //Checking for Input's Range based on parameter counts and index, also check for format exception
        public int InputExceptionCheck(int paramCount, int indexStart)
        {
            int uSelect = -1; //Set a default value for user's choice.
            
            try
            {
                uSelect = Convert.ToInt32(System.Console.ReadLine()); // receives user input and convert to number
                if (uSelect < indexStart || uSelect > paramCount)
                {
                    // if the integer value is outside of the parameter, throw an Exception
                    throw new Exception("Invalid Input, Please try again!"); 
                }
            }
            catch (FormatException)
            {
                // If a format exception is encounter in the input (character input)
                System.Console.WriteLine("Invalid Input, Please try again!");
            }                
            catch (Exception exEnc)
            {
                // Chatch thrown exceptions
                System.Console.WriteLine(exEnc.Message);
            }

            return uSelect;
        }
        
    }

}