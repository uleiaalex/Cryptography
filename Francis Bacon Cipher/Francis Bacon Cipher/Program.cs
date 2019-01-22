using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Francis_Bacon_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char iIndex;

            string s, s1, tempS2, s2;

            char tempChar;

            s = "Ana are mere.";
            s1 = "";
            s2 = "";

            string[] a = new string['Z' + 1];

            a['A'] = "aaaaa";

            a['B'] = "aaaab";

            a['C'] = "aaaba";

            a['D'] = "aaabb";

            a['E'] = "aabaa";

            a['F'] = "aabab";

            a['G'] = "aabba";

            a['H'] = "aabbb";

            a['I'] = "abaaa";

            a['J'] = "abaab";

            a['K'] = "ababa";

            a['L'] = "ababb";

            a['M'] = "abbaa";

            a['N'] = "abbab";

            a['O'] = "abbba";

            a['P'] = "abbbb";

            a['Q'] = "baaaa";

            a['R'] = "baaab";

            a['S'] = "baaba";

            a['T'] = "baabb";

            a['U'] = "babaa";

            a['V'] = "babab";

            a['W'] = "babba";

            a['X'] = "babbb";

            a['Y'] = "bbaaa";

            a['Z'] = "bbaab";


            for (int i = 0; i < s.Length; i++)

            {


                if (s[i] == ' ')

                    s1 = s1 + ' ';


                else if (s[i] == '.')

                    s1 = s1 + '.';


                else

                {

                    tempChar = s[i];

                    if ((tempChar >= 'a') && (tempChar <= 'z'))

                    tempChar = (char)((s[i]) - 32);

                s1= s1 + a[tempChar];

                }

        }

            Console.WriteLine("Sir initial: " + s);

            Console.WriteLine("Sir cryptat: " + s1 + " | Lungime: " + s1.Length + " caractere.");

        //Decriptare

        int j = 0;
            while (j < s1.Length-1)
            {
                if (!(s1[j] == ' '))
                {
                    tempS2 = "";
                    tempS2 = tempS2 + s1[j];
                    tempS2 = tempS2 + s1[j + 1];
                    tempS2 = tempS2 + s1[j + 2];
                    tempS2 = tempS2 + s1[j + 3];
                    tempS2 = tempS2 + s1[j + 4];
                    for (iIndex = 'A'; iIndex <= 'Z'; iIndex++)

                        if (a[iIndex] == tempS2)
                        {
                            s2 = s2 + iIndex;
                            break;
                        }

                    j += 5;

                }
                else
                {
                    s2 = s2 + s1[j];
                    j++;
                }
            }
            s2 = s2 + s1[s1.Length-1];
            Console.Write("Sir decryptat: " + s2);
            Console.WriteLine();
        }
    }
}
