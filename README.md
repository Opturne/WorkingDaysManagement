# DateManagement

A library to manage working days and do simple operations with it.

## Installation

For now, the library is only available by branching and compile.

## Usage

### Instantiation

You can invoke it as is

```csharp
var helper = new WorkingDayHelper();
```

Or with a list of Holidays

```csharp
var listHolidays = new List<DateTime>
        {
            new DateTime(2016,01,01),
            new DateTime(2016,03,25),
            new DateTime(2016,03,28),
            new DateTime(2016,12,26)
        };

 var helper = new WorkingDayHelper(listHolidays);
```
### Methods


