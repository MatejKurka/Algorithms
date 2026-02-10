using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

/// <summary>
/// Program řešící logickou hádanku "Vězeň v kruhovém vězení".
/// Cílem je zjistit počet místností v kruhu, přičemž v každé lze rozsvítit/zhasnout světlo.
/// </summary>
public static class Program
{
    private static World world;

    // Pomocné metody pro ovládání světa
    public static bool isLightOn() => world.IsLightOn();
    public static void toggleLight() => world.ToggleLight();
    public static void moveNext() => world.MoveNext();
    public static void movePrev() => world.MovePrev();

    /// <summary>
    /// Algoritmus pro spočítání místností v kruhu.
    /// Strategie: Rozsvítíme v první místnosti. Pak jdeme o 1, 2, 3... místností dál.
    /// Pokud najdeme rozsvíceno, zhasneme a vrátíme se na začátek. Pokud je tam zhasnuto,
    /// znamená to, že jsme oběhli celý kruh.
    /// </summary>
    public static int countRooms()
    {
        int currentDistance = 1;

        // V první místnosti rozsvítíme světlo jako "značku"
        if (!isLightOn())
        {
            toggleLight();
        }

        while (true)
        {
            // Posun o aktuální testovanou vzdálenost (currentDistance)
            for (int i = 0; i < currentDistance; i++)
            {
                moveNext();
            }

            // Pokud v cílové místnosti svítí světlo, zkusíme, zda je to naše původní místnost
            if (isLightOn())
            {
                toggleLight(); // Zhasneme ho

                // Vrátíme se zpět na start
                for (int i = 0; i < currentDistance; i++)
                {
                    movePrev();
                }

                // Pokud je na startu nyní zhasnuto, ušli jsme přesně jeden okruh
                if (!isLightOn())
                {
                    return currentDistance;
                }
                
                // Pokud na startu stále svítí, jdeme zase dopředu, rozsvítíme a zkusíme větší vzdálenost
                for (int i = 0; i < currentDistance; i++)
                {
                    moveNext();
                }
                toggleLight(); // Opět rozsvítíme (vrátíme do původního stavu)

                for (int i = 0; i < currentDistance; i++)
                {
                    movePrev();
                }
            }
            else
            {
                // Pokud je v cíli zhasnuto, jen se vrátíme na start
                for (int i = 0; i < currentDistance; i++)
                {
                    movePrev();
                }
            }

            // Zkusíme delší cestu
            currentDistance++;
        }
    }

    /// <summary>
    /// Spustí test pro danou konfiguraci světa.
    /// </summary>
    private static bool RunTest(int n, bool[] lights, int startPos)
    {
        world = new World(lights, startPos);
        int result = countRooms();
        bool ok = result == n;

        Console.WriteLine($"Test n={n}, start={startPos}, lights=[{string.Join(",", lights)}] " +
                          $"=> countRooms()={result}  {(ok ? "OK" : "FAIL")}");
        return ok;
    }

    public static void Main()
    {
        bool allOk = true;
        // Test 1: 5 místností, různá světla
        allOk &= RunTest(5, new[] { false, true, true, false, true }, 2);
        // Test 2: 3 místnosti
        allOk &= RunTest(3, new[] { true, false, true }, 0);

        if (!allOk)
            Console.WriteLine("\nNěkteré testy selhaly – prověřte algoritmus.");
        else
            Console.WriteLine("\nVšechny testy prošly úspěšně.");
        
        Console.ReadKey();
    }
}

/// <summary>
/// Reprezentuje uzavřený svět (kruhové vězení).
/// </summary>
public class World
{
    private List<bool> lights;
    private int pos;

    public World(bool[] initialLights, int startPos)
    {
        lights = new List<bool>(initialLights);
        // Ošetření startovní pozice tak, aby byla v rámci pole
        pos = ((startPos % lights.Count) + lights.Count) % lights.Count;
    }

    public bool IsLightOn() => lights[pos];

    public void ToggleLight() => lights[pos] = !lights[pos];

    public void MoveNext() => pos = (pos + 1) % lights.Count;

    public void MovePrev() => pos = (pos - 1 + lights.Count) % lights.Count;
}
