using System.Collections.Generic;

namespace projectRobin
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Input number of strings to  store in the array :");
            int numString= int.Parse(Console.ReadLine());


            string[] repStrings = new string[numString];

            Console.WriteLine("Input {0} strings for the array :",numString);

            for (int i = 0; i < repStrings.Length; i++)
            {
                Console.Write("Element[{0}]",i);
                repStrings[i] = Console.ReadLine();

            }


            Console.Write("Input the minimum length of the item you want to find : ");
            int numChar = int.Parse(Console.ReadLine());


            List<string> items = new List<string>();

            foreach (var item in repStrings)
            {
                if (item.Length >= numChar)
                {
                    items.Add(item);
                }

            }

            Console.WriteLine("The items of minimum {0} characters are", numChar);


            List<string> sortedWords = SortOrder(items);

            foreach (string word in sortedWords)
            {
                Console.WriteLine(word);
            }


            Console.ReadKey();
        }


        static List<string> SortOrder(List<string> wordList)
        {

            for (int i = 1; i < wordList.Count; i++)
            {
                string key = wordList[i];
                int j = i - 1;

                while (j >= 0 && CompareWord(key, wordList[j]))
                {
                    wordList[j + 1] = wordList[j];
                    j--;
                }
                wordList[j + 1] = key;
            }


            return wordList;
        }

         static bool CompareWord(string a, string b)
         {
             if(a == b) throw new NotImplementedException();

             if (a[0] == b[0] && a.Length < b.Length)
             {
                 return true;
             }
             else if (a[0] == b[0] && a.Length > b.Length)
             {
                 return false;
             }

             int lenght = a.Length < b.Length ? a.Length : b.Length;

             for (int i = 0; i < lenght; i++)
             {

                 if (a[i] != b[i])
                 {
                     return a[i] < b[i]; 
                 }

             }

             return false;
         }
    



    }
}
