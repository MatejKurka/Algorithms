# Úkol 5: Kruhové vězení (Circular Prison Puzzle)

Program v C#, který řeší klasickou logickou hádanku o vězni v kruhovém vězení.

## Definice hádanky
Vězeň se nachází v kruhovém vězení, kde jsou všechny místnosti identické a uspořádané do kruhu. V každé místnosti je vypínač světla (světlo buď svítí, nebo je zhasnuté). Vězeň se může pohybovat do sousedních místností (vlevo/vpravo) a může měnit stav světla v místnosti, kde se právě nachází. 

**Úkol:** Zjistit přesný počet místností v kruhu.

## Implementovaná strategie
Algoritmus v metodě `countRooms` používá následující postup:
1. Rozsvítí světlo v první (startovní) místnosti jako značku.
2. Jde o `D` kroků vpřed (začíná na `D=1`).
3. Pokud najde rozsvícené světlo:
   - Zhasne ho.
   - Vrátí se o `D` kroků zpět na start.
   - Pokud je na startu nyní zhasnuto, znamená to, že se vrátil do stejné místnosti a kruh má velikost `D`.
   - Pokud na startu stále svítí, vrátí se k místnosti `D`, rozsvítí ji (aby obnovil stav) a zkusí `D = D + 1`.
4. Pokud najde zhasnuté světlo, vrátí se na start a zkusí `D = D + 1`.

## Struktura projektu
- `Program.cs`: Obsahuje algoritmus `countRooms` a testovací sadu.
- `World`: Třída simulující kruhové prostředí, zapouzdřuje logiku pohybu a stavu světel.

## Jak spustit
Otevřete projekt v aplikaci Visual Studio a spusťte jej. Program ověří funkčnost algoritmu na několika testovacích scénářích (různý počet místností a počáteční stavy světel).
