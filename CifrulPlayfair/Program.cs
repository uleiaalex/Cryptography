using System;
using System.Collections.Generic;

namespace CifrulPlayfair
{
    class Program
    {
        public static string mess = "Hide the gold in the tree stump";
        public static char[] message = new char[0];
        public static string MessageView()
        {
            string s = "";
            for (int i = 0; i < message.Length; i+=2)
            {
                if (message[i] != ' ')
                    s += message[i].ToString();
                if (message[i + 1] != ' ')
                    s += message[i + 1].ToString();
                //s += message[i].ToString() + message[i+1].ToString() + " ";
            }
            return s;
        }
        static bool VerifyExistChar(char[,] theM,char theChar)
        {
            for (int i = 0; i < theM.GetLength(0); i++)
            {
                for (int j = 0; j < theM.GetLength(1); j++)
                {
                    if (theM[i, j] == theChar)
                        return true;
                }
            }
            return false;
        }
        static void AfisareMatrice(char[,] theM)
        {
            for (int i = 0; i < theM.GetLength(0); i++)
            {
                for (int j = 0; j < theM.GetLength(1); j++)
                {
                    Console.Write(theM[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static char ToLower(char theChar)
        {
            if ((int)theChar >= 65 && (int)theChar <= 91)
                return (char)((int)theChar + 32);
            return theChar;
        }
        static char ToUpper(char theChar)
        {
            if ((int)theChar >= 97 && (int)theChar <= 123)
                return (char)((int)theChar - 32);
            return theChar;
        }
        static char[,] CreareMatrice(string prop)
        {
            char[,] theM = new char[5, 5];
            int i = 0; int j = 0;
            for (int z = 0; z < prop.Length; z++)
            {
                char elem = ToLower(prop[z]);
                if (elem == 'j')
                    elem = 'i';
                if (i < 5 && elem != ' ' && !VerifyExistChar(theM, elem))
                {
                    theM[i, j] = elem;
                    j++;
                    if (j >= theM.GetLength(0))
                    {
                        i++;
                        j = 0;
                    }
                }
            }
            return theM;
        }
        static void StartPlayfareEnc(int vIndex,char[,] m)
        {
            int i1 = 0, j1 = 0, i2 = 0, j2 = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] == message[vIndex])
                    {
                        i1 = i;j1 = j;
                    }
                    if (m[i, j] == message[vIndex+1])
                    {
                        i2 = i; j2 = j;
                    }
                }
            }
            if (i1 != i2 && j1 != j2)
            {
                message[vIndex] = m[i1, j2];
                message[vIndex + 1] = m[i2, j1];
            }
            else if (i1 == i2)
            {
                if (j1 >= m.GetLength(0) - 1)
                    j1 = j1 - m.GetLength(0) + 1;
                else
                    j1++;
                if (j2 >= m.GetLength(0) - 1)
                    j2 = j2 - m.GetLength(0) + 1;
                else
                    j2++;
                message[vIndex] = m[i1, j1];
                message[vIndex + 1] = m[i2, j2];
            }
            else if (j1 == j2)
            {
                if (i1 >= m.GetLength(1) - 1)
                    i1 = i1 - m.GetLength(1) + 1;
                else
                    i1++;
                if (i2 >= m.GetLength(1) - 1)
                    i2 = i2 - m.GetLength(1) + 1;
                else
                    i2++;
                message[vIndex] = m[i1, j1];
                message[vIndex + 1] = m[i2, j2];
            }

        }
        static void StartPlayfareDec(int vIndex, char[,] m)
        {
            int i1 = 0, j1 = 0, i2 = 0, j2 = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] == message[vIndex])
                    {
                        i1 = i; j1 = j;
                    }
                    if (m[i, j] == message[vIndex + 1])
                    {
                        i2 = i; j2 = j;
                    }
                }
            }
            if (i1 != i2 && j1 != j2)
            {
                message[vIndex] = m[i1, j2];
                message[vIndex + 1] = m[i2, j1];
            }
            else if (i1 == i2)
            {
                if (j1 <= 0)
                    j1 = m.GetLength(0) - 1 - j1;
                else
                    j1--;
                if (j2 <= 0)
                    j2 = m.GetLength(0) - 1 - j2;
                else
                    j2--;
                message[vIndex] = m[i1, j1];
                message[vIndex + 1] = m[i2, j2];
            }
            else if (j1 == j2)
            {
                if (i1 <= 0)
                    i1 = m.GetLength(0) - 1 - i1;
                else
                    i1--;
                if (i2 <= 0)
                    i2 = m.GetLength(0) - 1 - i2;
                else
                    i2--;
                message[vIndex] = m[i1, j1];
                message[vIndex + 1] = m[i2, j2];
            }

            
        }
        public static void deleteUnwantedChar(char uW='X')
        {
            //scapam de X sau Q care nu trebuie
            uW = ToLower(uW);
            int indx = 0;
            while (indx < message.Length)
            {
                if (message[indx] == uW && message[indx + 1] != uW)
                {
                    message[indx] = ' ';
                }
                indx++;
            }

        }
        public static void initMessage()
        {
            string tMess = "";
            for (int i = 0; i < mess.Length; i++)
            {
                if (mess[i] != ' ')
                {
                    tMess += ToLower(mess[i]);
                }
            }

            for (int i = 0; i < tMess.Length; i++)
            {
                if (tMess[i] != ' ')
                {
                    Array.Resize(ref message, message.Length + 1);
                    message[message.Length - 1] = tMess[i];
                    if (i < tMess.Length - 1  && tMess[i] == tMess[i+1])
                    {
                        Array.Resize(ref message, message.Length + 1);
                        message[message.Length - 1] = 'x';
                    }
                } 
            }

            if (message.Length % 2 != 0)
            {
                Array.Resize(ref message, message.Length + 1);
                message[message.Length - 1] = 'x';
            }
        }
        static void Main(string[] args)
        {
            string prop = "The quick brown fox jumps over the lazy dog";

            initMessage();

            char[,] theM = new char[5, 5];
            theM = CreareMatrice(prop);

            AfisareMatrice(theM);
            Console.WriteLine();
            //Show initial message
            Console.WriteLine("Initial Message: " + mess);
            Console.WriteLine();
            //Show encrypted message
            Console.Write("Encrypter Message: ");
            for (int i = 0; i < message.Length; i+=2)
            {
                StartPlayfareEnc(i, theM);
            }
            Console.WriteLine(MessageView());
            Console.WriteLine();

            //Show decrypted message
            Console.Write("Decrypted Message: ");
            for (int i = 0; i < message.Length; i += 2)
            {
                StartPlayfareDec(i, theM);
            }
            deleteUnwantedChar(); //--delete X sau Q
            Console.WriteLine(MessageView());
            Console.WriteLine();



            Console.ReadKey();
        }
    }
}
