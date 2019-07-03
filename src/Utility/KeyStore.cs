using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System;
using System.Collections.Generic;

namespace cipher.Utility
{
    public class KeyStore 
    {
        public static int ADJUST = 5 ; 
        public static Hashtable store = null;

        public static Hashtable getStoreInsatance()
        {
            if( store == null)
            {
                store = new Hashtable();
                init();
            }
            return store;
        }

        private static void init()
        {
            char[] array = new char[] { 'a', 'b', 'c','d', 'e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z' };
        
            foreach (var item in array)
            {
                store.Add(item,getNewChar(item));
            }
        }

        public static string getStoreValue( char input )
        {
            if(store.Contains(input))
            {
                return store[input].ToString();
            } 
            return input.ToString();   
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