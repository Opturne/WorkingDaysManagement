# Working Days Management

A library to manage working days and do simple operations with it.

## Usage

### Installation

For now, the library is only available by branching and compile.

### Instantiation

* You can invoke it as is

```csharp
var helper = new WorkingDayHelper();
```

* With a list of Holidays

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

* With a list of off-work days of the week

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
Is dateReference a working day?

##### Get The closest working day

```csharp
DateTime GetLast(DateTime dateReference)
```
Return the last working day closest to dateReference (including it)

```csharp
DateTime GetNext(DateTime dateReference)
```
Return the next working day closest to dateReference (including it)

##### Get The next working day
```csharp
DateTime GetTomorrow(DateTime dateReference)
```
Return the next working day after dateReference

##### Get The previous working day
```csharp
DateTime GetYesterday(DateTime dateReference)
```
Return the last working day before dateReference

##### Get x working days in the past
```csharp
DateTime PastWorkingDays(DateTime dateReference, int days)
```
Get the date x working days in the past

##### Get x working days in the futur
```csharp
DateTime FuturWorkingDays(DateTime dateReference, int days)
```
Get the date x working days in the futur

##### Get the list of working days from a reference
```csharp
List<DateTime> GetSpanDates(DateTime dateReference, int days)
```
Return a list of working days to the dateReference.
If days is negative, then it's the days before.

#### Working with TimeSpan
TODO