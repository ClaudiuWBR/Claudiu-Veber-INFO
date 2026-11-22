#region 1. Ecuatie de gradul 1
Console.WriteLine("Ecuatie de gradul 1: ax + b = 0");
// 1. Citim a si il transformam in numar; o valoare invalida opreste programul.
Console.Write("a = ");
if (!double.TryParse(Console.ReadLine(), out double a) || !double.IsFinite(a))
{
    Console.WriteLine("Valoare invalida pentru a.");
    return;
}

// 2. Citim si verificam b in acelasi mod.
Console.Write("b = ");
if (!double.TryParse(Console.ReadLine(), out double b) || !double.IsFinite(b))
{
    Console.WriteLine("Valoare invalida pentru b.");
    return;
}

// 3. Daca a este zero, b determina daca exista o infinitate de solutii sau niciuna.
if (a == 0)
{
    if (b == 0)
    {
        Console.WriteLine("Ecuatia are o infinitate de solutii.");
    }
    else
    {
        Console.WriteLine("Ecuatia nu are solutii.");
    }
}
else
{
    // 4. Daca a nu este zero, calculam x = -b / a.
    double x = -b / a;
    // 5. Afisam solutia daca este finita; altfel, semnalam depasirea limitei.
    if (!double.IsFinite(x))
    {
        Console.WriteLine("Solutia este prea mare pentru a fi reprezentata.");
    }
    else
    {
        Console.WriteLine($"Solutia este x = {x}");
    }
}
#endregion

#region 2. Ecuatie de gradul 2
Console.WriteLine("Ecuatie de gradul 2: ax^2 + bx + c = 0");
// 1. Citim coeficientii si verificam daca sunt numere finite.
Console.Write("a = ");
if (!double.TryParse(Console.ReadLine(), out double a2) || !double.IsFinite(a2))
{
    Console.WriteLine("Valoare invalida pentru a.");
    return;
}

Console.Write("b = ");
if (!double.TryParse(Console.ReadLine(), out double b2) || !double.IsFinite(b2))
{
    Console.WriteLine("Valoare invalida pentru b.");
    return;
}

Console.Write("c = ");
if (!double.TryParse(Console.ReadLine(), out double c2) || !double.IsFinite(c2))
{
    Console.WriteLine("Valoare invalida pentru c.");
    return;
}

// 2. Daca a este zero, ecuatia devine bx + c = 0.
if (a2 == 0)
{
    if (b2 == 0)
    {
        if (c2 == 0)
        {
            Console.WriteLine("Ecuatia are o infinitate de solutii.");
        }
        else
        {
            Console.WriteLine("Ecuatia nu are solutii.");
        }
    }
    else
    {
        double x = -c2 / b2;
        if (!double.IsFinite(x))
        {
            Console.WriteLine("Solutia este prea mare pentru a fi reprezentata.");
        }
        else
        {
            Console.WriteLine($"Solutia este x = {x}");
        }
    }
}
else
{
    // 3. Calculam discriminantul si verificam daca poate fi reprezentat.
    double delta = b2 * b2 - 4 * a2 * c2;
    if (!double.IsFinite(delta))
    {
        Console.WriteLine("Discriminantul este prea mare pentru a fi reprezentat.");
    }
    else if (delta >= 0)
    {
        // 4. Un discriminant pozitiv da doua solutii reale, iar zero da una dubla.
        double radical = Math.Sqrt(delta);
        double x1 = (-b2 / 2 + radical / 2) / a2;
        double x2 = (-b2 / 2 - radical / 2) / a2;
        if (!double.IsFinite(x1) || !double.IsFinite(x2))
        {
            Console.WriteLine("O solutie este prea mare pentru a fi reprezentata.");
        }
        else if (delta == 0)
        {
            Console.WriteLine($"Solutia dubla este x = {x1}");
        }
        else
        {
            Console.WriteLine($"Solutiile sunt x1 = {x1} si x2 = {x2}");
        }
    }
    else
    {
        // 5. Un discriminant negativ da doua solutii complexe conjugate.
        double parteaReala = (-b2 / 2) / a2;
        double parteaImaginara = (Math.Sqrt(-delta) / 2) / Math.Abs(a2);
        if (!double.IsFinite(parteaReala) || !double.IsFinite(parteaImaginara))
        {
            Console.WriteLine("O solutie este prea mare pentru a fi reprezentata.");
        }
        else
        {
            Console.WriteLine($"Solutiile complexe sunt x1 = {parteaReala} + {parteaImaginara}i si x2 = {parteaReala} - {parteaImaginara}i");
        }
    }
}
#endregion

#region 3. Divizibilitatea lui n cu k
Console.WriteLine("Verificarea divizibilitatii lui n cu k");

// 1. Citim n si verificam daca este un numar intreg valid.
Console.Write("n = ");
if (!int.TryParse(Console.ReadLine(), out int n))
{
    Console.WriteLine("Valoare invalida pentru n.");
    return;
}

// 2. Citim k si verificam daca este un numar intreg valid.
Console.Write("k = ");
if (!int.TryParse(Console.ReadLine(), out int k))
{
    Console.WriteLine("Valoare invalida pentru k.");
    return;
}

// 3. Impartirea la zero nu este definita.
if (k == 0)
{
    Console.WriteLine("Nu se poate verifica divizibilitatea cu zero.");
}
// 4. n este divizibil cu k daca restul impartirii este zero.
// Folosim long pentru a evita depasirea la int.MinValue si k = -1.
else if ((long)n % k == 0)
{
    Console.WriteLine($"{n} este divizibil cu {k}.");
}
else
{
    Console.WriteLine($"{n} nu este divizibil cu {k}.");
}
#endregion

#region 4. An bisect
{
    Console.WriteLine("1. Verificarea unui an bisect");
    // 1. Citim un an pozitiv din calendarul gregorian.
    if (!CitesteIntreg("y", out int an)) return;
    if (an < 1)
    {
        Console.WriteLine("Anul trebuie sa fie pozitiv.");
        return;
    }

    // 2. Anii divizibili cu 4 sunt bisecti, cu exceptia secolelor nedivizibile cu 400.
    bool bisect = an % 400 == 0 || (an % 4 == 0 && an % 100 != 0);
    Console.WriteLine(bisect ? "Anul este bisect." : "Anul nu este bisect.");
}
#endregion

#region 5. Cifra de la sfarsit
{
    Console.WriteLine("2. A k-a cifra de la sfarsit");
    // 1. Citim numarul si pozitia, numerotata de la 1.
    if (!CitesteIntreg("numar", out int numar) ||
        !CitesteIntreg("pozitie", out int pozitie)) return;
    if (pozitie < 1)
    {
        Console.WriteLine("Pozitia trebuie sa fie cel putin 1.");
        return;
    }

    // 2. Ignoram semnul si eliminam pe rand cifrele din dreapta.
    long ramas = Math.Abs((long)numar);
    for (int i = 1; i < pozitie; i++)
    {
        if (ramas < 10)
        {
            Console.WriteLine("Numarul nu are atatea cifre.");
            return;
        }
        ramas /= 10;
    }

    // 3. Restul impartirii la 10 este cifra cautata.
    Console.WriteLine($"Cifra este {ramas % 10}.");
}
#endregion

#region 6. Laturile unui triunghi
{
    Console.WriteLine("3. Verificarea laturilor unui triunghi");
    // 1. Citim cele trei lungimi pozitive.
    if (!CitesteLungime("a", out decimal latura1) ||
        !CitesteLungime("b", out decimal latura2) ||
        !CitesteLungime("c", out decimal latura3)) return;

    // 2. Fiecare latura trebuie sa fie mai mica decat suma celorlalte doua.
    // Comparatia prin scadere evita depasirea la adunarea lungimilor mari.
    bool triunghi = latura1 > latura3 - latura2 &&
                    latura2 > latura1 - latura3 &&
                    latura3 > latura2 - latura1;
    Console.WriteLine(triunghi ? "Laturile formeaza un triunghi." : "Laturile nu formeaza un triunghi.");
}
#endregion

#region 7. Interschimbare cu variabila auxiliara
{
    Console.WriteLine("4. Interschimbarea a doua numere");
    // 1. Citim cele doua valori.
    if (!CitesteNumar("a", out decimal primul) || !CitesteNumar("b", out decimal alDoilea)) return;

    // 2. Salvam prima valoare, apoi o mutam pe a doua in prima variabila.
    decimal auxiliar = primul;
    primul = alDoilea;

    // 3. Punem valoarea salvata in a doua variabila si afisam rezultatul.
    alDoilea = auxiliar;
    Console.WriteLine($"a = {primul}, b = {alDoilea}");
}
#endregion

#region 8. Interschimbare fara variabila auxiliara
{
    Console.WriteLine("5. Interschimbarea fara variabila auxiliara");
    // 1. Citim doua numere.
    if (!CitesteNumar("a", out decimal primul) || !CitesteNumar("b", out decimal alDoilea)) return;

    // 2. Atribuirea de tuplu inverseaza valorile fara o variabila auxiliara explicita.
    (primul, alDoilea) = (alDoilea, primul);
    Console.WriteLine($"a = {primul}, b = {alDoilea}");
}
#endregion

#region 9. Divizorii unui numar
{
    Console.WriteLine("6. Divizorii pozitivi ai unui numar");
    // 1. Citim numarul; zero are o infinitate de divizori nenuli.
    if (!CitesteIntreg("n", out int numar)) return;
    if (numar == 0)
    {
        Console.WriteLine("Zero are o infinitate de divizori nenuli.");
    }
    else
    {
        // 2. Cautam perechi de divizori pana la radacina valorii absolute.
        long valoare = Math.Abs((long)numar);
        var divizoriMari = new List<long>();
        Console.Write("Divizori pozitivi: ");
        for (long divizor = 1; divizor <= valoare / divizor; divizor++)
        {
            if (valoare % divizor == 0)
            {
                Console.Write($"{divizor} ");
                if (divizor != valoare / divizor)
                    divizoriMari.Add(valoare / divizor);
            }
        }

        // 3. Afisam divizorii din perechi in ordine crescatoare.
        for (int i = divizoriMari.Count - 1; i >= 0; i--)
            Console.Write($"{divizoriMari[i]} ");
        Console.WriteLine();
    }
}
#endregion

#region 10. Test de primalitate
{
    Console.WriteLine("7. Test de primalitate");
    // 1. Citim numarul; numerele mai mici decat 2 nu sunt prime.
    if (!CitesteIntreg("n", out int numar)) return;
    bool prim = numar >= 2;

    // 2. Este suficient sa cautam un divizor pana la radacina numarului.
    for (int divizor = 2; prim && divizor <= numar / divizor; divizor++)
        if (numar % divizor == 0) prim = false;

    Console.WriteLine(prim ? "Numarul este prim." : "Numarul nu este prim.");
}
#endregion

#region 11. Cifre in ordine inversa
{
    Console.WriteLine("8. Cifrele unui numar in ordine inversa");
    // 1. Citim numarul si pastram separat semnul, daca este negativ.
    if (!CitesteIntreg("n", out int numar)) return;
    long valoare = Math.Abs((long)numar);
    Console.Write("Cifre inversate: ");
    if (numar < 0) Console.Write("-");

    // 2. Afisam ultima cifra si o eliminam, inclusiv pentru numarul zero.
    do
    {
        Console.Write(valoare % 10);
        valoare /= 10;
    } while (valoare > 0);
    Console.WriteLine();
}
#endregion

#region 12. Multipli intr-un interval
{
    Console.WriteLine("9. Numere divizibile intr-un interval");
    // 1. Citim divizorul si capetele intervalului inclusiv.
    if (!CitesteIntreg("n", out int divizor) ||
        !CitesteIntreg("a", out int limitaJos) ||
        !CitesteIntreg("b", out int limitaSus)) return;
    if (divizor == 0 || limitaJos > limitaSus)
    {
        Console.WriteLine("Divizorul trebuie sa fie nenul si a trebuie sa fie cel mult b.");
        return;
    }

    // 2. Scadem multiplii de pana la a - 1 din multiplii de pana la b.
    long modul = Math.Abs((long)divizor);
    long numarMultipli = CatInferior(limitaSus, modul) - CatInferior((long)limitaJos - 1, modul);
    Console.WriteLine($"Numarul de multipli este {numarMultipli}.");
}
#endregion

#region 13. Ani bisecti intr-un interval
{
    Console.WriteLine("10. Numarul de ani bisecti dintr-un interval");
    // 1. Citim capetele incluse ale intervalului de ani pozitivi.
    if (!CitesteIntreg("y1", out int an1) || !CitesteIntreg("y2", out int an2)) return;
    if (an1 < 1 || an1 > an2)
    {
        Console.WriteLine("Anii trebuie sa fie pozitivi, iar y1 trebuie sa fie cel mult y2.");
        return;
    }

    // 2. Numaram multiplii de 4, scadem multiplii de 100 si adaugam multiplii de 400.
    long panaLaAn2 = an2 / 4L - an2 / 100L + an2 / 400L;
    long inainteDeAn1 = (an1 - 1L) / 4 - (an1 - 1L) / 100 + (an1 - 1L) / 400;
    Console.WriteLine($"Numarul de ani bisecti este {panaLaAn2 - inainteDeAn1}.");
}
#endregion

#region 14. Palindrom
{
    Console.WriteLine("11. Verificarea unui palindrom");
    // 1. Citim numarul; un numar negativ nu este considerat palindrom.
    if (!CitesteIntreg("n", out int numar)) return;
    if (numar < 0)
    {
        Console.WriteLine("Numarul nu este palindrom.");
    }
    else
    {
        // 2. Formam inversul si il comparam cu numarul initial.
        int ramas = numar;
        long invers = 0;
        while (ramas > 0)
        {
            invers = invers * 10 + ramas % 10;
            ramas /= 10;
        }
        Console.WriteLine(invers == numar ? "Numarul este palindrom." : "Numarul nu este palindrom.");
    }
}
#endregion

#region 15. Ordonarea a trei numere
{
    Console.WriteLine("12. Ordonarea a trei numere");
    // 1. Citim cele trei numere.
    if (!CitesteNumar("a", out decimal primul) ||
        !CitesteNumar("b", out decimal alDoilea) ||
        !CitesteNumar("c", out decimal alTreilea)) return;

    // 2. Interschimbam perechile care nu sunt in ordine crescatoare.
    if (primul > alDoilea) (primul, alDoilea) = (alDoilea, primul);
    if (primul > alTreilea) (primul, alTreilea) = (alTreilea, primul);
    if (alDoilea > alTreilea) (alDoilea, alTreilea) = (alTreilea, alDoilea);
    Console.WriteLine($"Ordine crescatoare: {primul} {alDoilea} {alTreilea}");
}
#endregion

#region 16. Ordonarea a cinci numere fara tablou
{
    Console.WriteLine("13. Ordonarea a cinci numere fara tablou");
    // 1. Citim cinci variabile separate, fara a folosi un tablou.
    if (!CitesteNumar("a", out decimal primul) ||
        !CitesteNumar("b", out decimal alDoilea) ||
        !CitesteNumar("c", out decimal alTreilea) ||
        !CitesteNumar("d", out decimal alPatrulea) ||
        !CitesteNumar("e", out decimal alCincilea)) return;

    // 2. Interschimbam perechile pentru a aseza fiecare valoare in ordine.
    if (primul > alDoilea) (primul, alDoilea) = (alDoilea, primul);
    if (primul > alTreilea) (primul, alTreilea) = (alTreilea, primul);
    if (primul > alPatrulea) (primul, alPatrulea) = (alPatrulea, primul);
    if (primul > alCincilea) (primul, alCincilea) = (alCincilea, primul);
    if (alDoilea > alTreilea) (alDoilea, alTreilea) = (alTreilea, alDoilea);
    if (alDoilea > alPatrulea) (alDoilea, alPatrulea) = (alPatrulea, alDoilea);
    if (alDoilea > alCincilea) (alDoilea, alCincilea) = (alCincilea, alDoilea);
    if (alTreilea > alPatrulea) (alTreilea, alPatrulea) = (alPatrulea, alTreilea);
    if (alTreilea > alCincilea) (alTreilea, alCincilea) = (alCincilea, alTreilea);
    if (alPatrulea > alCincilea) (alPatrulea, alCincilea) = (alCincilea, alPatrulea);
    Console.WriteLine($"Ordine crescatoare: {primul} {alDoilea} {alTreilea} {alPatrulea} {alCincilea}");
}
#endregion

#region 17. CMMDC si CMMMC
{
    Console.WriteLine("17. CMMDC si CMMMC");
    // 1. Citim numerele si lucram cu valorile lor absolute.
    if (!CitesteIntreg("a", out int primul) || !CitesteIntreg("b", out int alDoilea)) return;
    long valoare1 = Math.Abs((long)primul);
    long valoare2 = Math.Abs((long)alDoilea);
    long rest1 = valoare1;
    long rest2 = valoare2;

    // 2. Algoritmul lui Euclid inlocuieste numerele cu al doilea si restul impartirii.
    while (rest2 != 0)
    {
        long rest = rest1 % rest2;
        rest1 = rest2;
        rest2 = rest;
    }

    // 3. CMMMC se obtine din produsul valorilor impartit la CMMDC.
    long cmmmc = rest1 == 0 ? 0 : valoare1 / rest1 * valoare2;
    Console.WriteLine($"CMMDC = {rest1}, CMMMC = {cmmmc}");
}
#endregion

#region 18. Descompunerea in factori primi
{
    Console.WriteLine("18. Descompunerea in factori primi");
    // 1. Citim numarul; zero nu are o descompunere finita in factori primi.
    if (!CitesteIntreg("n", out int numar)) return;
    if (numar == 0)
    {
        Console.WriteLine("Zero nu are o descompunere finita in factori primi.");
    }
    else
    {
        long ramas = Math.Abs((long)numar);
        var factori = new List<string>();
        if (numar < 0) factori.Add("-1");

        // 2. Impartim repetat la fiecare divizor si numaram exponentul.
        for (long divizor = 2; divizor <= ramas / divizor; divizor++)
        {
            int exponent = 0;
            while (ramas % divizor == 0)
            {
                ramas /= divizor;
                exponent++;
            }
            if (exponent > 0) factori.Add($"{divizor}^{exponent}");
        }

        // 3. Daca a ramas un numar mai mare decat 1, acesta este factor prim.
        if (ramas > 1) factori.Add($"{ramas}^1");
        Console.WriteLine(factori.Count == 0 ? "1" : string.Join(" x ", factori));
    }
}
#endregion

#region 19. Exact doua cifre distincte
{
    Console.WriteLine("16. Verificarea celor doua cifre distincte");
    // 1. Citim numarul si ignoram semnul lui.
    if (!CitesteIntreg("n", out int numar)) return;
    long ramas = Math.Abs((long)numar);
    int primaCifra = -1;
    int aDouaCifra = -1;
    bool altaCifra = false;

    // 2. Retinem primele doua cifre distincte si verificam daca apare o a treia.
    do
    {
        int cifra = (int)(ramas % 10);
        if (primaCifra == -1) primaCifra = cifra;
        else if (cifra != primaCifra && aDouaCifra == -1) aDouaCifra = cifra;
        else if (cifra != primaCifra && cifra != aDouaCifra) altaCifra = true;
        ramas /= 10;
    } while (ramas > 0 && !altaCifra);

    Console.WriteLine(aDouaCifra != -1 && !altaCifra
        ? "Numarul este format din exact doua cifre distincte."
        : "Numarul nu este format din exact doua cifre distincte.");
}
#endregion

#region 20. Fractie zecimala periodica
{
    Console.WriteLine("17. Reprezentarea zecimala a unei fractii");
    // 1. Citim numaratorul si numitorul nenul.
    if (!CitesteIntreg("m", out int numarator) || !CitesteIntreg("n", out int numitor)) return;
    if (numitor == 0)
    {
        Console.WriteLine("Numitorul nu poate fi zero.");
        return;
    }

    // 2. Calculam partea intreaga si restul, lucrand cu valori pozitive.
    long modulNumarator = Math.Abs((long)numarator);
    long modulNumitor = Math.Abs((long)numitor);
    long rest = modulNumarator % modulNumitor;
    string semn = numarator != 0 && (numarator < 0) != (numitor < 0) ? "-" : "";
    var rezultat = new System.Text.StringBuilder($"{semn}{modulNumarator / modulNumitor}");
    var pozitiiResturi = new Dictionary<long, int>();
    int inceputPerioada = -1;

    // 3. Impartim in continuare; un rest repetat indica inceputul perioadei.
    if (rest != 0) rezultat.Append('.');
    while (rest != 0)
    {
        if (pozitiiResturi.TryGetValue(rest, out inceputPerioada))
            break;
        pozitiiResturi[rest] = rezultat.Length;
        rest *= 10;
        rezultat.Append(rest / modulNumitor);
        rest %= modulNumitor;
        inceputPerioada = -1;
    }

    // 4. Incadram perioada in paranteze, daca exista.
    if (inceputPerioada >= 0)
    {
        rezultat.Insert(inceputPerioada, '(');
        rezultat.Append(')');
    }
    Console.WriteLine($"{numarator}/{numitor} = {rezultat}");
}
#endregion

#region 21. Ghicirea unui numar
{
    Console.WriteLine("18. Gandeste-te la un numar intre 1 si 1024.");
    int limitaJos = 1;
    int limitaSus = 1024;

    // 1. Injumatatim intervalul prin intrebari cu raspuns da sau nu.
    while (limitaJos < limitaSus)
    {
        int mijloc = limitaJos + (limitaSus - limitaJos + 1) / 2;
        Console.Write($"Numarul este mai mare sau egal cu {mijloc}? (da/nu): ");
        string? raspuns = Console.ReadLine()?.Trim();
        if (raspuns == null)
        {
            Console.WriteLine("Nu a fost furnizat un raspuns.");
            return;
        }
        if (raspuns.Equals("da", StringComparison.OrdinalIgnoreCase))
            limitaJos = mijloc;
        else if (raspuns.Equals("nu", StringComparison.OrdinalIgnoreCase))
            limitaSus = mijloc - 1;
        else
            Console.WriteLine("Raspunde cu da sau nu.");
    }

    // 2. Cand a ramas o singura valoare, aceasta este numarul ales.
    Console.WriteLine($"Numarul ales este {limitaJos}.");
}
#endregion

#region 22.Functii auxiliare pentru citire si impartire
// Citim un numar intreg si afisam o eroare daca textul nu este valid.
static bool CitesteIntreg(string nume, out int valoare)
{
    Console.Write($"{nume} = ");
    if (int.TryParse(Console.ReadLine(), out valoare)) return true;
    Console.WriteLine($"Valoare intreaga invalida pentru {nume}.");
    return false;
}

// Citim o valoare numerica care poate avea si zecimale.
static bool CitesteNumar(string nume, out decimal valoare)
{
    Console.Write($"{nume} = ");
    if (decimal.TryParse(Console.ReadLine(), out valoare)) return true;
    Console.WriteLine($"Valoare numerica invalida pentru {nume}.");
    return false;
}

// O lungime trebuie sa fie un numar zecimal pozitiv.
static bool CitesteLungime(string nume, out decimal valoare)
{
    Console.Write($"{nume} = ");
    if (decimal.TryParse(Console.ReadLine(), out valoare) && valoare > 0) return true;
    Console.WriteLine($"Lungime invalida pentru {nume}; introdu un numar pozitiv.");
    return false;
}

// Pentru un divizor pozitiv, obtinem catul rotunjit in jos si pentru valori negative.
static long CatInferior(long deImpartit, long divizor)
{
    long cat = deImpartit / divizor;
    return deImpartit % divizor < 0 ? cat - 1 : cat;
}
#endregion
