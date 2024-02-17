using ProgramareDinamica;
using System.Reflection.Metadata.Ecma335;

internal class Program
{

    public static void Memorare()
    {
        Memorare memorare = new Memorare();

        //Recursivitate VS ProgramareDinamica

        //
        //
        //PROBLEMA 1
        Console.WriteLine("PROBLEMA 1");
        //Recursivitate
        Console.WriteLine(memorare.fibRecursiv(5));//O(2^n) time
                                                   //O(n) space

        //ProgramareDinamica
        Console.WriteLine(memorare.fibDinamic(50));//O(n) time
                                                   //O(n) space
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 2
        Console.WriteLine("PROBLEMA 2");
        //Recursivitate
        Console.WriteLine(memorare.travelRecursiv(2, 3));

        //ProgramareDinamica
        Console.WriteLine(memorare.travelDinamic(2, 3));
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 3
        Console.WriteLine("PROBLEMA 3");
        //Recursivitate
        Console.WriteLine(memorare.canSumRecursiv(7, [5, 3, 4, 7]));

        //ProgramareDinamica
        Console.WriteLine(memorare.canSumDinamic(300, [7, 14]));
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 4
        Console.WriteLine("PROBLEMA 4");
        //Recursivitate
        foreach (var item in memorare.howSumRecursiv(7, [2, 3]))
        {
            Console.Write(item + ",");
        }
        Console.WriteLine("\n");
        //ProgramareDinamica
        foreach (var item in memorare.howSumDinamic(7, [2, 3]))
        {
            Console.Write(item + ",");
        }
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 5
        Console.WriteLine("PROBLEMA 5");
        //Recursivitate
        foreach (var item in memorare.bestSumRecursiv(7, [5, 3, 4, 7]))
        {
            Console.Write(item + ",");
        }
        Console.WriteLine("\n");
        //ProgramareDinamica
        foreach (var item in memorare.bestSumDinamic(7, [5, 3, 4, 7]))
        {
            Console.Write(item + ",");
        }
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 6
        Console.WriteLine("PROBLEMA 6");
        //Recursivitate
        Console.Write(memorare.canConstructRecurisv("abcdef", ["ab", "abc", "cd", "def", "abcd"]));
        Console.WriteLine("\n");
        //ProgramareDinamica
        Console.Write(memorare.canConstructDinamic("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", ["e",
"ee",
"eee",
"eeee",
"eeeee",
"eeeeee"]));
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 7
        Console.WriteLine("PROBLEMA 7");
        //Recursivitate
        Console.Write(memorare.countConstructRecurisv("abcdef", ["ab", "abc", "cd", "def", "abcd"]));
        Console.WriteLine("\n");
        //ProgramareDinamica
        Console.Write(memorare.countConstructDinamic("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", ["e",
"ee",
"eee",
"eeee",
"eeeee",
"eeeeee"]));
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 8
        Console.WriteLine("PROBLEMA 8");
        //Recursivitate
        foreach (var item in memorare.allConstructRecurisv("abcdef", ["ab", "abc", "cd", "def", "abcd", "ef", "c"]))
        {
            foreach (var subitem in item)
            {
                Console.Write(subitem + ",");
            }
            Console.WriteLine("\n");
        }
        Console.WriteLine("\n");
        //ProgramareDinamica

        foreach (var item in memorare.allConstructDinamic("aaaaaaaaaaaaaaaaaaaaaaaaaaz", ["a", "aa", "aaa", "aaaa", "aaaaa"]))
        {
            foreach (var subitem in item)
            {
                Console.Write(subitem + ",");
            }
            Console.WriteLine("\n");
        }
        Console.WriteLine("\n");
        //
        //


    }

    public static void Tabulare()
    {

        Tabulare tabulare = new Tabulare();

        //ProgramareDinamica

        //
        //
        //PROBLEMA 1
        Console.WriteLine("PROBLEMA 1");
        //ProgramareDinamica
        Console.WriteLine(tabulare.fibDinamic(50));//O(n) time
                                                   //O(n) space
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 2
        Console.WriteLine("PROBLEMA 2");
        //ProgramareDinamica
        Console.WriteLine(tabulare.travelDinamic(18,18));
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 3
        Console.WriteLine("PROBLEMA 3");
        //ProgramareDinamica
        Console.WriteLine(tabulare.canSumDinamic(7, [5,3,4]));
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 4
        Console.WriteLine("PROBLEMA 4");
        //ProgramareDinamica
        foreach (var item in tabulare.howSumDinamic(7, [5,3,4]))
        {
            Console.Write(item + ",");
        }
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 5
        Console.WriteLine("PROBLEMA 5");
        //ProgramareDinamica
        foreach (var item in tabulare.bestSumDinamic(8, [2, 3, 5]))
        {
            Console.Write(item + ",");
        }
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 6
        Console.WriteLine("PROBLEMA 6");
        //ProgramareDinamica
        Console.Write(tabulare.canConstructDinamic("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", ["e",
"ee",
"eee",
"eeee",
"eeeee",
"eeeeee"]));
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 7
        Console.WriteLine("PROBLEMA 7");
        //ProgramareDinamica
        Console.Write(tabulare.countConstructDinamic("purple", ["purp","pur","le","purp"]));
        Console.WriteLine("\n");
        //
        //

        //
        //
        //PROBLEMA 8
        Console.WriteLine("PROBLEMA 8");
        //ProgramareDinamica

        foreach (var item in tabulare.allConstructDinamic("abcdef", ["ab", "abc", "cd", "def", "abcd","ef","c"]))
        {
            foreach (var subitem in item)
            {
                Console.Write(subitem + ",");
            }
            Console.WriteLine("\n");
        }
        Console.WriteLine("\n");
        //
        //


    }

    private static void Main(string[] args)
    {
        //1.Memorare
        //Memorare();

        //2.Tabulare
        Tabulare();
    }
}