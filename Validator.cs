using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine_system
{
    internal class Validator
    {
        // <summary>
        /// Gets user input and attempts to convert it to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="prompt">The prompt message for user input.</param>
        /// <returns>The converted value or null if conversion fails.</returns>
        public static T? Convert<T>(string prompt) where T :struct
        {
            bool valid = false;
            //result = null;
            string userInput;
            
            while(!valid)
            {
                if (string.IsNullOrEmpty(prompt))
                {
                    return null;
                }
                else
                {
                    Console.Write($"Enter {prompt}: ");
                }

                userInput = Console.ReadLine();

                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if(converter != null )
                    {
                       
                        return (T)converter.ConvertFromString(userInput);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (FormatException)
                {

                    Console.WriteLine("Invalid input format");
                }
            }
            return default;
            
        }
    }
}
