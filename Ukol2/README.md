# Úkol 2: Hádání hesla (Mastermind)

Jednoduchá konzolová hra v C#, ve které má hráč za úkol uhodnout tajné heslo složené ze speciálních znaků. Hra je inspirována klasickou logickou hrou Mastermind (Logik).

## Jak hra funguje
1. Po spuštění hra náhodně vygeneruje 4místné heslo ze znaků: `@`, `#`, `&`, `~`, `*`.
2. Každý znak se v hesle vyskytuje maximálně jednou.
3. Hráč zadává své tipy do konzole.
4. Hra po každém pokusu barevně označí zadané znaky:
   - **Zelená:** Znak je v hesle a je na správném místě.
   - **Žlutá:** Znak je v hesle, ale nachází se na jiné pozici.
   - **Červená:** Znak v hesle vůbec není.

## Technické vlastnosti
- Využívá objektově orientovaný přístup (třída `heslo` pro logiku generování a validace).
- Barevný výstup do konzole pro intuitivní zpětnou vazbu.
- Smyčka `while` zajišťuje, že hra běží, dokud není heslo uhodnuto.

## Jak spustit
Projekt lze otevřít a spustit v Microsoft Visual Studiu pomocí souboru `.slnx` nebo `.csproj`.
