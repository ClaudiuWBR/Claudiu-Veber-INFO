
//media numere divizibile cu 3 mai mici decat n de la tastatura
using System;

Console.Write("Introduceti nr n: ");
if (!int.TryParse(Console.ReadLine(), out int n))
{
    Console.WriteLine("Introduceti un numar int valid.");
    return;
}
int k = 3;
int count = 0;
int sum = 0;
int i;
for (i = 1; i <= n; i++)
{
    if (i % k == 0)
    {
        count++;
        sum += i;
    }
}
if (count == 0)
{
    Console.WriteLine("Nu exista numere divizibile cu 3 mai mici decat n.");
}
else
{
double media = (double)sum / count;
Console.WriteLine($"Media numerelor divizibile cu {k} este {media}");
}