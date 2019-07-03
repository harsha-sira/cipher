using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;

namespace cipher.Utility
{
    public class GenerateCipher 
    {
        public static int ADJUST = 5 ; 

        // public static string CipherString( string input )
        // {
        //     char[] array = new char[] { 'a', 'b', 'c','d', 'e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z' };
        //     List<char> charList = new List<char>();

        //     string output = string.Empty;
        //     foreach(char ch in input)
        //     {
        //         output += KeyStore.getNewChar(ch);
        //     }  
        //     return output; 
        // }

        public static string CipherString( char[] input )
        {
            string output = string.Empty;
            foreach(char ch in input)
            {
                output += KeyStore.getStoreValue(ch);
                
            }  
            return output; 
        }
        
    }
}