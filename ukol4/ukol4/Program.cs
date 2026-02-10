using System;

/// <summary>
/// Program pro výpočet času šíření ohně v mřížce.
/// </summary>
class Program
{
    /// <summary>
    /// Vypočítá čas (počet kroků), za který oheň zasáhne celou mřížku.
    /// Oheň se šíří z bodu [start_x, start_y] Manhattanovskou vzdáleností.
    /// </summary>
    /// <param name="width">Šířka mřížky.</param>
    /// <param name="height">Výška mřížky.</param>
    /// <param name="start_x">X souřadnice počátku požáru.</param>
    /// <param name="start_y">Y souřadnice počátku požáru.</param>
    /// <returns>Maximální čas šíření.</returns>
    static int burn_time(int width, int height, int start_x, int start_y)
    {
        int maxX = width - 1;
        int maxY = height - 1;

        // Výpočet vzdáleností ke všem čtyřem rohům mřížky
        // Oheň zasáhne celou plochu v momentě, kdy dorazí do nejvzdálenějšího rohu.
        int d1 = Math.Abs(start_x - 0) + Math.Abs(start_y - 0);       // Horní levý roh
        int d2 = Math.Abs(start_x - 0) + Math.Abs(start_y - maxY);    // Dolní levý roh
        int d3 = Math.Abs(start_x - maxX) + Math.Abs(start_y - 0);    // Horní pravý roh
        int d4 = Math.Abs(start_x - maxX) + Math.Abs(start_y - maxY); // Dolní pravý roh

        // Vrátí největší ze vzdáleností
        return Math.Max(Math.Max(d1, d2), Math.Max(d3, d4));
    }


    // ===== Testovací prostředí =====

    /// <summary>
    /// Pomocná metoda pro ověření správnosti výpočtu.
    /// </summary>
    static bool Test(int w, int h, int x, int y, int expected)
    {
        int result = burn_time(w, h, x, y);
        bool ok = (result == expected);
        Console.WriteLine($"{w}x{h}, start=({x},{y}) -> {result} (očekáváno {expected}) [{(ok ? "OK" : "FAIL")}]");
        return ok;
    }

    static void Main()
    {
        bool allOk = true;

        // Definované testovací případy
        allOk &= Test(3, 3, 1, 1, 2);
        allOk &= Test(4, 4, 0, 0, 6);
        allOk &= Test(6, 3, 0, 1, 6);

        if (allOk)
            Console.WriteLine("\nVšechny testy prošly úspěšně.");
        else
            Console.WriteLine("\nNěkteré testy NEPROŠLY – zkontrolujte algoritmus v burn_time.");
        
        Console.ReadKey();
    }
}
