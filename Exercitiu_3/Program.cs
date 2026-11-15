using System;

int i;
int j;
int min;
int p_min;
int x;
int[] a;
a = new int[n];
Console.Write("n:");
int n = int.Parse(Console.ReadLine());

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