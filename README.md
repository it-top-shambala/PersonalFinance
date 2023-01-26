# PersonalFinanceAccounting

## Словарь названий сущностей
валюта - currency

доход - income

расход - expense

кошелёк - wallet

остаток - balance

## Ответственные за задачи

+ Создание БД (MySQL) - Михаил (проверяющий - Евгений)
+ Создание модели - Галина (проверяющий - Назар)
+ Создание DB API - Дарья (проверяющий - Евгений, Галина (?), Алексей (?))
+ Создание уровня бизнес-логики - Алексей (проверяющий - (?))
+ Создание UI - Назар (проверяющий - (?))

## Диаграмма модулей

```mermaid
graph
    Model --> ViewModel

    DataBase --> Model

    subgraph UI
        ViewModel --> View
    end

    subgraph Library
        extend_API
        Model --> intern_API
        Model --> db_API
    end
```

## Диаграмма таблиц БД

```mermaid
classDiagram
direction BT
class tab_categories {
   text name
   bool type
   integer category_id
}
class tab_currencies {
   text name
   text code
   integer currency_id
}
class tab_operations {
   text date_time
   integer wallet_id
   integer category_id
   real summa
   integer operation_id
}
class tab_wallets {
   text name
   real balance
   integer currency_id
   integer wallet_id
}

tab_operations  -->  tab_categories : category_id
tab_operations  -->  tab_wallets : wallet_id
tab_wallets  -->  tab_currencies : currency_id
```

## Диаграмма классов модели данных

```mermaid
classDiagram 
    class Currency{
      +string Code
      +string Name
    }
    class Wallet{
        +string Name
        +Currency Currency
        +double Ballance
        +Incoming(double, CategoryIncome) void
        +Expensing(double, CategoryExpense) bool
    }
    Currency *-- Wallet

    class CategoryIncome{
        +string Name
    }
    CategoryIncome *-- Wallet

    class CategoryExpense{
        +string Name
    }
    CategoryExpense *-- Wallet
```
