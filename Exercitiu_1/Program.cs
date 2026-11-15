//Programul determina numerele prime mai mici sau egale cu n

using static System.Math;

Console.Write("n:");
int n = int.Parse(Console.ReadLine());
Console.Write($"Numerele prime mai mici sau egale cu {n} sunt:");
for (int i = 2; i <= n; i++)
{
    bool isPrime = true;
    for (int j = 2; j <= Sqrt(i); j++)
    {
        if (i % j == 0)
        {
            isPrime = false;
            break;
        }
    }
    if (isPrime)
    {
        Console.Write($"{i} ");
    }
}