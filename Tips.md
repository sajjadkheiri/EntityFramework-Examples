# Entity framework tips

### what's difference between Find() and FirstOrDefualt()?

First, Find() tries to read from DbContex like a cache. If it could not be able to fetch data
go to the database. However, FirstOrDefualt() directly goes to the database without any cache

### what's difference between SingleOrDefualt() and FirstOrDefualt()?

The Single (and SingleOrDefault) was fastest for database access
and better than using First, as Single will throw an exception if your Where
clause returns more than one result. Single and

### Dependent and Principal entity?

**Principal entity:** Contains a primary key that the dependent relationship refer
to via a foreign key

**Dependent entity:** Contains the foreign key that refers to the principal entity’s
primary key

** An entity class can be both a principal and a dependent entity at the same time. **

### What is the AsNoTracking

**AsNoTracking:**
**AsNoTrackingWithIdentityResolution:**

### Constructor in EF  

If you want to use a constructor in an entity, you just have to add parameters from
added properties.

**Note:** If you want to change the value of the property, you have to obtain data from
input constructor's parameter like

```c#
public class Person
{
    public Person(string firstName)
    {
        FirstName = $"Hello"+firstName;
    }

    public int Id { get; set; }
    public int FirstName { get; set; }
    public int LastName { get; set; }
}
```
