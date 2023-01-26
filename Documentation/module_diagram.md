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
