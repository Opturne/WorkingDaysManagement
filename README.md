# Working Days Management

A library to manage working days and do simple operations with it.

## Usage

### Installation

To install Working Days Management, run the following command in the Package Manager Console

    PM> Install-Package WorkingDaysManagement

### Instantiation

* You can invoke it as is

```csharp
var helper = new WorkingDayHelper();
```

* With a list of Holidays (Default : none)

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

* With a list of days off (Default : Saturday and Sunday)

```csharp
var listWeekEnd = new List<DayOfWeek>
{
    DayOfWeek.Sunday,
    DayOfWeek.Monday
}

var helper = new WorkingDayHelper(listWeekEnd);
```

* Or both
```csharp
var listHolidays = new List<DateTime>
{
    new DateTime(2016,01,01),
    new DateTime(2016,03,25),
    new DateTime(2016,03,28),
    new DateTime(2016,12,26)
};

var listWeekEnd = new List<DayOfWeek>
{
    DayOfWeek.Sunday,
    DayOfWeek.Monday
}

var helper = new WorkingDayHelper(listHolidays, listWeekEnd);
```
## Methods

##### Is it a working day?
```csharp
bool IsWorkingDay(DateTime dateReference)
```

##### Get The closest working day

```csharp
DateTime GetLast(DateTime dateReference)
```

```csharp
DateTime GetNext(DateTime dateReference)
```

##### Get The next working day
```csharp
DateTime GetTomorrow(DateTime dateReference)
```

##### Get The previous working day
```csharp
DateTime GetYesterday(DateTime dateReference)
```

##### Get x working days in the past
```csharp
DateTime PastWorkingDays(DateTime dateReference, int days)
```

##### Get x working days in the futur
```csharp
DateTime FuturWorkingDays(DateTime dateReference, int days)
```

##### Get the list of working days from a reference
```csharp
List<DateTime> GetSpanDates(DateTime dateReference, int days)
```

#### Working with TimeSpan

##### Get the numbers of days between the first date and the last working day
```csharp
int GetSpanDays(DateTime dateReference, TimeSpan span)
```

##### Get the last working day
```csharp
DateTime GetSpanEnd(DateTime dateReference, TimeSpan span)
```

##### Get the first working day
```csharp
DateTime GetSpanStart(DateTime dateReference, TimeSpan span)
```