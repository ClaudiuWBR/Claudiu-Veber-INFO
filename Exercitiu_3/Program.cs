#region vector min+sort
using System;

int i;
int j;
int min;
int p_min;
int x;
Console.Write("n: ");
int n = int.Parse(Console.ReadLine());
int[] a = new int[n];

for (i = 0; i < n; i++)
{
    Console.Write($"a[{i}] = ");
    a[i] = int.Parse(Console.ReadLine());
}

min = a[0];
for (i = 1; i < n; i++)
{
    if (a[i] < min)
    {
        min = a[i];
    }
}
Console.WriteLine($"Min = {min}");

for (i = 0; i < n-1; i++)
{
    p_min = i;
    min = a[i];
    for (j = i + 1; j < n; j++)
    {
        if (a[j] < min)
        {
            p_min = j;
            min = a[j];
        }
    }
x = a[i];
a[i] = a[p_min];
a[p_min] = x;
}

Console.WriteLine("Sorted ascending:");
for (i = 0; i < n; i++)
{
    Console.Write(a[i] + " ");
}
Console.WriteLine();
#endregion