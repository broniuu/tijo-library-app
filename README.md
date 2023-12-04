# Kurs

Testowanie i Jakość Oprogramowania / Projekt

# Autor

Filip Broniek

# Temat projektu

Aplikacja do wyporzyczania książek

# Opis projektu

![app overview](app_overview.png)

**Biblioteka** to miejsce, gdzie przechowuje się i udostępnia różnego rodzaju zasoby informacyjne, takie jak książki, czasopisma, materiały multimedialne, dokumenty historyczne, a także oprogramowanie lub narzędzia edukacyjne. Biblioteki pełnią istotną rolę w zbieraniu, organizowaniu, przechowywaniu i udostępnianiu wiedzy oraz kultury.

**Mechanizm filtrowania** jest szególnie potrzebny w elektronicznej wersji biblioteki, gdzie nie ma bilbiotekarza, który mógłby pomóc nam w znalezieniu interesującej nas książki.

Każda **książka** ma swoich **autorów** i **tagi** określające kategorię książki.

# Uruchomienie projektu

Pobierz i zainstaluj [.Net7.0](https://dotnet.microsoft.com/en-us/download) jeżeli nie masz go na swoim komputerze

## API
1. Przejdź do folderu `src/LibraryApp.Api`
2. Jeżeli uruchamiasz pierwszy raz wykonaj następującą komendę

```
dotnet ef database update
```

3. Uruchom api poleceniem:

```
dotnet run
```

## Web
1. Przejdź do folderu `src/LibraryApp.Web`
2. Uruchom apikację webową poleceniem:

```
dotnet run
```

# Uruchomienie testów

## Testy jednostkowe

1. Przejdź do folderu `src/LibraryApp.Api.UnitTests`
2. Uruchom testy poleceniem:

```
dotnet test   
```

# Dokumentacja API

1) `/books`
    - Parametry: `TagIds`, `AuthorIds`, `KeyWord`, `HardcoverRequirement`, `ShowBorrowed`
    - Typ: `GET`
    - Zwraca: Książki w formacie JSON przefiltrowane za pomocą parametrów
2) `/authors`
   - Typ: `GET`
   - Zwraca: Wszyscy autorzy w formacie JSON
3) `/tags`
   - Typ: `GET`
   - Zwraca: Wszystkie tagi w formacie JSON

# Scenariusze testowe dla testera manualnego

## Testy przechodzenia do panelu książek

| Test Case ID | Opis                                                          | Kroki testowe                | Oczekwiany wynik         |
|--------------|---------------------------------------------------------------|------------------------------|--------------------------|
| TC_01        | Przejście do panelu filtrowania książek przez hiperłącze.     | 1. Naciśnij słowo "here".    | Otwarcie panelu książek. |
| TC_02        | Przejście do panelu filtrowania książek przez pasek nawigacji | 1. Naciśnij przycisk "Books" | Otwarcie panelu książek. |

## Testy filtrowania książek

| Test Case ID | Opis                                       | Kroki testowe                                                                                                                                                                                                                                                                 | Oczekiwany wynik                                                                                                                                                                                |
|--------------|--------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| TC_03        | Wyszukiwania książek.                      | 1. Nacisnąć przycisk "Search".                                                                                                                                                                                                                                                | Wyświetlenie książek.                                                                                                                                                                           |
| TC_04        | Filtrowanie po nazwie.                     | 1. W pole tekstowe wpisać słowo "the". <br/> 2. Nacisnąć przycisk "Search".                                                                                                                                                                                                   | Wyświetlenie książek zawierających w tytule wyraz "the".                                                                                                                                        |
| TC_05        | Pokazywanie wyporzyczonych książek.        | 1. Zaznaczyć checkbox "Show borrowed". <br/> 2. Nacisnąć przycisk "Search".                                                                                                                                                                                                   | Wśród wyświetlonych książek powinny znajdować się książki z czerwonym napisem "All print copies of this book are borrowed" i zablokowanym przyciskiem "Borrow"                                  |
| TC_06        | Filtrowanie po rodzaju okładki.            | 1. Naciśnąć przycisk "Search". <br/> 2. W polu wyboru "Hardcover" wybrać przycisk "Don't Have." <br/> 3. Nacisnąć przycisk "Search". <br/> 4. w polu wyboru "Hardcover" wybrać opcję "Indiferrent". <br/> 5. Nacisnąć przycisk "Search"                                       | Wyświetlone za pierwszym razem książki powinny być inne niż te wyświetlone za drugim razem. Za trzecim razem powinny być wyświetlone zarówno książki z pierwszego, jak i drugiego wyszukiwania. |
| TC_07        | Filtrowanie po autorach.                   | 1. Nacisnąć przycisk "Authors". <br/> 2. Zanzaczyć opcje: "Marcel Lefebvre" i "Robert Makłowicz" <br/> 3. Nacisnąć przycisk "Search".                                                                                                                                         | Wyświetlone powinny zostać jedynie książki o tytułach: "They Have Uncrowned Him" i "An Godd Dish For Hogwart Catholics".                                                                        |
| TC_08        | Filtrowanie po tagach.                     | 1. Nacisnąć przycisk "Tags". <br/> 2. Zaznaczyć opcje: "kitchen", "thriller", "history". <br/> 3. Nacisnąć przycisk "Search"                                                                                                                                                  | Wyświetlone powinny zostać jedynie książki o tytułach: "Lord of the Dumbledor", "Witcher can into space", "An Good Dish For Hogwart Catholics", "They Have Uncrowned Him"                       |
| TC_09        | Filtrowanie po różnych kategoriach.        | 1. W polu tekstowym wpisać "t". <br/> 2. Zaznaczyć pole "Show borrowed". <br/> 3. W polu wybory "Hardcover" wybrać opcję "Indifferent". <br/> 4. Wybrać autorów: "Joanne Rowling" i "Andrzej Sapkowski". <br/> 5. Wybrać tag: "thriller". <br/> 6. Nacisnąć przycisk "Search" | Wyświetlone powinny zostać jedynie książki o tytułąch: "Lord of the Dumbledore", "Witcher can into space"                                                                                       |
| TC_10        | Nawigowanie do panelu porzyczania książki. | 1. Nacisnąć przycisk "Search". <br/> 2. Na pierwszej książce nacisnąć przycisk "Borrow".                                                                                                                                                                                      | Powinna zostać wyświetlona strona zawierająca szczegóły dotyczące książki i jej wyporzyczenia.                                                                                                  |


# Technologie użyte w projekcie

- C# 11.0
- .NET 7.0
- Blazor
- Markdown
- HTML
- CSS
- Entity Framework
- ASP .NET Core
- XUnit