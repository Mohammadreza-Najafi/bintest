namespace projectRobin3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Original strings: AACC, ZZQQ");
            Console.WriteLine("Check the same character pattern: {0}",CheckSamePattern("AACC", "ZZQQ"));

            Console.WriteLine();

            Console.WriteLine("Original strings: PABA, ADAD");
            Console.WriteLine("Check the same character pattern: {0}", CheckSamePattern("PABA", "ADAD"));


            Console.ReadKey();
        }

        static bool CheckSamePattern(string str1, string str2)
        {
          
            if (str1.Length != str2.Length)
            {
                return false;
            }

            return GetPattern(str1).SequenceEqual(GetPattern(str2));
        }

        static List<int> GetPattern(string str)
        {
            var pattern = new Dictionary<char, int>();

            var patternList = new List<int>();

    
            for (int i = 0; i < str.Length; i++)
            {
         
                if (!pattern.ContainsKey(str[i]))
                {
                    pattern[str[i]] = pattern.Count;
                }
               
                patternList.Add(pattern[str[i]]);
            }

       
            return patternList;
        }


        
    }
}
