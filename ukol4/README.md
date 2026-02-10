# Úkol 4: Šíření ohně (Burn Time)

Jednoduchý algoritmus v C# určený k výpočtu času šíření požáru v obdélníkové mřížce.

## Popis algoritmu
Program počítá, za jak dlouho oheň zasáhne celou plochu mřížky, pokud začne hořet v zadaném bodě `[x, y]`. Předpokládá se, že oheň se šíří do sousedních polí (nahoru, dolů, vlevo, vpravo) v každém kroku. 

Výpočet je založen na **Manhattanovské vzdálenosti** k nejvzdálenějšímu rohu mřížky, což odpovídá času, kdy oheň pohltí i poslední políčko.

## Funkce
- `burn_time`: Jádro programu, které provádí matematický výpočet vzdáleností k rohům.
- `Test`: Pomocná metoda pro automatizované ověření správnosti výsledků oproti očekávaným hodnotám.

## Příklad testů
- Mřížka 3x3, start uprostřed (1,1) -> Čas: 2
- Mřížka 4x4, start v rohu (0,0) -> Čas: 6
- Mřížka 6x3, start (0,1) -> Čas: 6

## Jak spustit
Otevřete projekt v aplikaci Visual Studio a spusťte jej. Program v konzoli vypíše výsledky testů a potvrdí správnost implementace.
