using System;
using System.Collections.Generic;

namespace cipher.Utility
{
    public class GenerateCipher 
    {
        public static int ADJUST = 5 ; 

        public static string CipherString( string input )
        {
            char[] array = new char[] { 'a', 'b', 'c','d', 'e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z' };
            List<char> charList = new List<char>();

            // for (int i = 0; i < 26; i++)
            // {
            //     if(!charList.Contains(array[i]))
            //     {
            //         input = input.Replace( array[i] , getNewChar(array[i]));
            //         charList.Add(getNewChar(array[i]));
            //     }
            //     if(!charList.Contains(Char.ToUpper(array[i])))
            //     {
            //         input = input.Replace( Char.ToUpper(array[i]), getNewChar(Char.ToUpper(array[i])));
            //         charList.Add(Char.ToUpper(getNewChar(Char.ToUpper(array[i]))));
            //     }      
            // }

            string output = string.Empty;
            foreach(char ch in input)
            {
                output += getNewChar(ch);
            }  
            return output; 
        }

        public static char getNewChar( char ch )
        {
            int start = (int ) ch ; 
            if((start > 64 && start < 91) || ( start > 96 && start < 123))
            {
                int t = ( start + ADJUST ) ; 
                if( ( start < 91 && t > 90) || ( t > 122 ))
                {
                    t = t - 26; 
                }
                return (char) t;
            }
            return (char) start; 
        }
        
    }
}