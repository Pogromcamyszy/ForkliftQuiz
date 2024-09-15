
# Forklift Quiz Certification Website

## Opis projektu

Ten projekt to strona quizowa służąca do certyfikacji na operatora wózka widłowego. Aplikacja jest napisana w technologii .NET przy użyciu **Onion Architecture**, aby zapewnić modularność i łatwą rozbudowę. Umożliwia przeprowadzanie quizów, a także zarządzanie nimi przez administratorów. Projekt korzysta z **JWT** do autoryzacji użytkowników oraz **role-based access control** (kontrola dostępu na podstawie ról).

### Główne funkcjonalności:

- Rejestracja i logowanie użytkowników z użyciem JWT
- Rozwiązywanie quizów przez użytkowników
- Zarządzanie quizami przez administratorów (dodawanie, edycja, usuwanie quizów)
- Role-based access control: różne poziomy uprawnień dla użytkowników i administratorów
- Zapis wyników użytkowników w bazie danych
- Możliwość integracji z zewnętrznymi serwisami dzięki architekturze modułowej

## Struktura projektu

Projekt opiera się na Onion Architecture, gdzie każda warstwa ma swoją odpowiedzialność:

- **Core** - Zawiera encje (np. `Quiz`, `Question`, `Answer`), interfejsy i logikę biznesową.
- **Application** - Zawiera serwisy aplikacyjne, takie jak `QuizService`, które odpowiadają za komunikację między kontrolerami a logiką biznesową.
- **Infrastructure** - Odpowiada za dostęp do bazy danych, np. `QuizRepository`.
- **API** - Kontrolery, które obsługują zapytania HTTP i zwracają odpowiednie odpowiedzi.

## Technologie

- .NET 6 (lub nowszy)
- ASP.NET Core Web API
- Entity Framework Core (do obsługi bazy danych)
- Moq (do testów jednostkowych)
- Xunit (framework do testów)
- JWT (do autoryzacji)
- Onion Architecture

## Wymagania

- Visual Studio 2022 lub nowszy
- .NET 6 SDK
- SQL Server lub inna kompatybilna baza danych
- Postman (opcjonalnie, do testowania API)

## Jak uruchomić projekt lokalnie?

1. **Klonowanie repozytorium**

   Skopiuj repozytorium z GitHuba:

   git clone https://github.com/twoje_repo/forklift-quiz.git
   
   cd forklift-quiz

3. **Konfiguracja bazy danych**

   Upewnij się, że masz skonfigurowaną bazę danych. Możesz zmodyfikować ustawienia połączenia w pliku appsettings.json

   Następnie uruchom migracje EF Core, aby stworzyć bazę danych:

   dotnet ef database update

5. **Uruchomienie projektu**

   Aby uruchomić aplikację, użyj następującego polecenia:

   dotnet run --project ForkliftQuiz.API

   Aplikacja powinna teraz być dostępna pod adresem `https://localhost:5001` lub `http://localhost:5000`.

6. **Testowanie API**

   Użyj narzędzia Swagger, Postman lub innej przeglądarki, aby wysyłać zapytania HTTP. Na przykład, aby przetestować pobranie quizu o określonym ID:

   GET https://localhost:5001/api/quiz/1

   Możesz również przetestować logowanie:

   POST https://localhost:5001/api/auth/login
   Content-Type: application/json
   {
     "username": "admin",
     "password": "password123"
   }

7. **Uruchomienie testów jednostkowych**

   Aby uruchomić testy jednostkowe, wykonaj poniższe polecenie w folderze głównym projektu:

   dotnet test

## Testowanie

Testy jednostkowe znajdują się w projekcie `ForkliftQuiz.Tests`. Testy obejmują serwisy, kontrolery oraz inne krytyczne elementy aplikacji, używając bibliotek takich jak `Moq` i `Xunit`.
