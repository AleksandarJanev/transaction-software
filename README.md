# transaction-software

Апликацијата претставува сервис кој калкулира трансакции кои се базирани на динамички правила. Клиентите праќаат Payment Request и сервисот дава одговор со калкулирана цена и применато правило. 
Применува: Strategy Pattern, Dependency Injection, Open Closed Principle

Што би направил како додаток ако би имал повеќе време:
 1. Поврзување со датабаза
 2. Динамичко креирање на правила
 3. Додавање на UI поврзан со бекенд
 4. Создавање на Authentication/Authorization систем

Како да се уклучи:
```bash
dotnet restore
dotnet run --project TransactionSoftware
