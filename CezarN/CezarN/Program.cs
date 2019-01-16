using System;

interface ICrypto
{
    void Encrypt();
    void Decrypt();
    string GetKey();
}
class Cryptography : ICrypto
{
    #region Internal Variables
    string s = "";
    string key = "";
    int n = 0;
    #endregion
    public void Encrypt()
    {
        string aux = "";
        for (int i = 0; i < s.Length; i++)
        {
            int chrASCII = (int)s[i]+n;

            if ((int)s[i] >= 65 && (int)s[i] <= 90)
            {
                while (chrASCII > 90)
                {
                    int tAscii = chrASCII - 91;
                    chrASCII = 65 + (tAscii);
                }
            }
            else if ((int)s[i] >= 97 && (int)s[i] <= 122)
            {
                while (chrASCII > 122)
                {
                    int tAscii = chrASCII - 123;
                    chrASCII = 97 + (tAscii);
                }
            }
            aux += (char)chrASCII;
        }
        key = aux;
    }
    public void Decrypt()
    {
        string aux = "";
        for (int i = 0; i < s.Length; i++)
        {
            int chrASCII = (int)s[i] - n;

            if ((int)s[i] >= 65 && (int)s[i] <= 90)
            {
                while (chrASCII < 65)
                {
                    int tAscii = 65 - chrASCII;
                    chrASCII = 91 - tAscii;
                }
            }
            else if ((int)s[i] >= 97 && (int)s[i] <= 122)
            {
                while (chrASCII < 97)
                {
                    int tAscii = 97 - chrASCII;
                    chrASCII = 123-tAscii;
                }
            }
            aux += (char)chrASCII;
        }
        key = aux;
    }
    public string GetKey()
    {
        return key;
    }
    public Cryptography(string s, int n)
    {
        this.s = s;
        this.n = n;
    }
}

class Program
{
    static void Rot13(string s)
    {
        Console.WriteLine("ROT13: Init message: " + s);

        Cryptography crp = new Cryptography(s, 13);
        crp.Encrypt();
        Console.WriteLine("ROT13: Encrypted message: " + crp.GetKey());

        Cryptography crp1 = new Cryptography(crp.GetKey(), 13);
        crp1.Decrypt();
        Console.WriteLine("ROT13: Decrypted message: " + crp1.GetKey());
    } //Rot13 Methode
    static void Cezar(string s, int n)
    {
        Console.WriteLine("Cezar " + n + " : Init message: " + s);
        Cryptography crp = new Cryptography(s, n);
        crp.Encrypt();
        Console.WriteLine("Cezar " + n + " : Encrypted message: " + crp.GetKey());

        Cryptography crp1 = new Cryptography(crp.GetKey(), n);
        crp1.Decrypt();
        Console.WriteLine("Cezar " + n + " : Decrypted message: " + crp1.GetKey());
    }
    static void Main(string[] args)
    {
        string s = "ABC";
        int n = 13;
        //Cezar n
        {
            Cezar(s, n); //Call Cezar de n 
        }
        Console.WriteLine();

        Rot13("ABC"); //Call Rot13 Methode

        Console.ReadKey();
    }
}

