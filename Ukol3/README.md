# Úkol 3: Piškvorky v konzoli

Klasická hra Piškvorky (Tic-Tac-Toe) implementovaná v prostředí Windows Console. Hra umožňuje dvěma hráčům soupeřit na dynamicky se posouvajícím herním poli.

## Klíčové vlastnosti
- **Nekonečné pole:** Díky použití datové struktury `Dictionary<Point, char>` není velikost pole fixně omezena. Hráč se může šipkami posouvat kamkoliv do prostoru.
- **Barevné odlišení:** Hráč 'X' (modrý) a hráč 'O' (žlutý) jsou jasně odlišeni pro lepší přehlednost.
- **Detekce výhry:** Hra automaticky kontroluje vodorovné, svislé i diagonální řady.
- **Cíl hry:** Seřadit 3 své symboly do jedné řady.

## Ovládání
- **Šipky (Nahoru, Dolů, Vlevo, Vpravo):** Posun herního pole (pohled).
- **ENTER:** Položení symbolu na aktuální střed pole (pozice v mřížce).
- **Střídání:** Hra automaticky přepíná mezi hráči po každém platném tahu.

## Technické detaily
- Implementováno v C# (.NET Console App).
- Využívá knihovnu `System.Drawing` pro práci se strukturou `Point`.
- Algoritmus pro kontrolu výhry prohledává okolí posledního tahu v osmi směrech.

## Jak spustit
Otevřete projekt ve Visual Studiu (soubor `.slnx` nebo `.csproj`) a spusťte pomocí klávesy F5.
