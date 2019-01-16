using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifrulPlayfair
{
    class Playfair
    {
        public static string mess = "Hide the gold in the tree stump";
        public static char[] message = new char[0];


        const string prop = "The quick brown fox jumps over the lazy dog";
        public static char[,] theM = new char[5, 5];

        public static void ReadMessage()
        {
            Console.WriteLine("Insert the messege: ");
            mess = Console.ReadLine();
        }

        #region Bidimensional Array Methodes
        public static char[,] CreareMatrice(string prop)
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
        static bool VerifyExistChar(char[,] theM, char theChar)
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
        public static void AfisareMatrice(char[,] theM)
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
        public static char ToLower(char theChar)
        {
            if ((int)theChar >= 65 && (int)theChar <= 91)
                return (char)((int)theChar + 32);
            return theChar;
        }
        public static char ToUpper(char theChar)
        {
            if ((int)theChar >= 97 && (int)theChar <= 123)
                return (char)((int)theChar - 32);
            return theChar;
        }
        #endregion

        #region PlayFair
        static void StartPlayfairEnc(int vIndex, char[,] m)
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
        static void StartPlayfairDec(int vIndex, char[,] m)
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
        static void DeleteUnwantedChar(char uW = 'X')
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
        //Help you to prepare the message for playfair
        public static void InitMessage()
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
                    if (i < tMess.Length - 1 && tMess[i] == tMess[i + 1])
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

        public static void ShowInitialMessage()
        {
            //Show initial message
            Console.WriteLine("Initial Message: " + mess);
            Console.WriteLine();
        }

        public static void ShowEncryptedMessage(char[,] theM)
        {
            //Show encrypted message
            Console.Write("Encrypter Message: ");
            for (int i = 0; i < message.Length; i += 2)
            {
                StartPlayfairEnc(i, theM);
            }
            Console.WriteLine(MessageView());
            Console.WriteLine();

        }

        public static void ShowDecryptedMessage(char[,] theM)
        {
            //Show decrypted message
            Console.Write("Decrypted Message: ");
            for (int i = 0; i < message.Length; i += 2)
            {
                StartPlayfairDec(i, theM);
            }
            DeleteUnwantedChar(); //--delete X sau Q // caracterul este optional - default X
            Console.WriteLine(MessageView());
            Console.WriteLine();
        }
        public static string MessageView()
        {
            string s = "";
            for (int i = 0; i < message.Length; i += 2)
            {
                if (message[i] != ' ')
                    s += message[i].ToString();
                if (message[i + 1] != ' ')
                    s += message[i + 1].ToString();
            }
            return s;
        }
        #endregion
    }
}
