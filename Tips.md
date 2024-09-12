# Entity framework tips

### what's difference between Find() and FirstOrDefualt()?

First, Find() tries to read from DbContex like a cache. If it could not be able to fetch data
go to the database. However, FirstOrDefualt() directly goes to the database without any cache

<br />

### what's difference between SingleOrDefualt() and FirstOrDefualt()?

The Single (and SingleOrDefault) was fastest for database access
and better than using First, as Single will throw an exception if your Where
clause returns more than one result. Single and

<br />

### Dependent and Principal entity?

**Principal entity:** Contains a primary key that the dependent relationship refer
to via a foreign key

**Dependent entity:** Contains the foreign key that refers to the principal entity’s
primary key

** An entity class can be both a principal and a dependent entity at the same time. **

<br />

### What is the AsNoTracking

**AsNoTracking:**
**AsNoTrackingWithIdentityResolution:**

<br />

### Constructor in EF

If you want to use a constructor in an entity, you just have to add parameters from
added properties.

> [!Note]
> If you want to change the value of the property, you have to obtain data from
> input constructor's parameter like

<br />

```c#
public class Person
{
    public Person(string firstName)
    {
        FirstName = $"Hello"+firstName;
        LastName = "Kheiri"
    }

    public int Id { get; set; }
    public int FirstName { get; set; }
    public int LastName { get; set; }
}
```

<br />

### Three ways of configuring EF :

**1. By convention :**

When you follow simple rules on property types and names, EF
Core will autoconfigure many of the software and database features. The By
Convention approach is quick and easy, but it can’t handle every eventuality.

**2. Data Annotation :**

A range of .NET attributes known as Data Annotations can be
added to entity classes and/or properties to provide extra configuration information.
These attributes can also be useful for data validation.

**3. Fluent Api :**

EF Core has a method called OnModelCreating that’s run when the
EF context is first used. You can override this method and add commands,
known as the Fluent API, to provide extra information to EF Core in its modeling
stage. The Fluent API is the most comprehensive form of configuration
information, and some features are available only via that API.

<br />

> [!Note]
> Most real applications need to use all three approaches to configure
> EF Core and the database in exactly the way they need. Some configuration
> features are available via two or even all three approaches

<br />

### Convention for entity classes:

EF Core requires entity classes to have the following features:

- The class must be of public access
- The class can’t be a static class, as EF Core must be able to create a new instance of the class.
- The class must have a constructor that EF Core can use.

<br />

### Convention for Properties in an entity class:

EF Core will look for public properties in an entity class that have a
public getter and a setter of any access mode

> [!Tip]
> EF core can handle read-only properties or properties only have getter.
> However,in this case,By convention approach wont work.

<br />

### Configuring data annotation

Data Annotations are a specific type of .NET attribute used for validation and database
features. These attributes can be applied to an entity class or property and provide
configuration information to EF Core.

<br />

### Excluding propertise and class from the database

- **NotMapped attribute:**

EF Core will exclude a property or a class that has a NotMapped data attribute applied to it.

<br />

```c#
[NotMapped]
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; private set; }
    public int Age { get; set; }

    [NotMapped]
    public List<Contact> Contacts { get; set; }
}
```

<br />

- **Ignore:**

you can exclude properties and classes by using the Fluent API configuration command Ignore().

<br />

```c#
public class ConfigContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ignore property
        modelBuilder.Entity<Person>().Ignore(x => x.Contacts);
        // Ignore class
        modelBuilder.Ignore<Contact>();
    }
}
```

<br />

> [!Tip]
> Instead of configuring at OnModelCreating() method, you should have a configuration class peer each
> entity and inherited from **IEntityTypeConfiguration**. Eventually, implement all related configuration
> in that class. Furthermore, you must initiate at OnModelCreating() in DbContext.

<br />

```c#
public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Ignore(x => x.Contacts);
        builder.Property(x => x.FirstName).HasMaxLength(50);
    }
}
```

```c#
public class ConfigContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Intial configuration peer each config class
        modelBuilder.ApplyConfiguration(new PersonConfig());

        // Intial configuration peer assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfig).Assembly);
    }
}
```

<br />

### Setting database column type, size, and nullability

- **[IsRequired] / IsRequired**

- **[MaxLength(5)] / HasMaxLength(5)**

- **[Column(TypeName = "")]**

- **[Unicode()] / IsUnicode()**

- **UseCollation()**

- **[Precision(14,4)] / HasPrecision(14,4) :**
  Sets the number of digits and how many of the digits are after the decimal point

<br />

### Shadow Properties in EF Core

Shadow properties in Entity Framework Core are properties that are not defined in your .NET entity class but are defined in the EF Core model. These properties are mapped to database columns and can be used to store and retrieve values without explicitly declaring them in your class model.

#### Definition:

Configured in the EF Core model, typically in the `Configure` method of your entity configuration class:

<br />

```c#

internal class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property<DateTime>("CreatedDateTime");
        builder.Property<DateTime>("EditDateTime");
    }
}

```

<br />

#### Usage:

Useful for storing metadata or audit information (like timestamp) without cluttering your entity classes. This method ensures that every time an entity is added or modified, the `CreatedDateTime` or `EditDateTime` properties are automatically updated with the current timestamp. This is useful for maintaining audit trails in your database.

<br />

```c#

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

        AddedEntities.ForEach(E =>
        {
            E.Property("CreatedDateTime").CurrentValue = DateTime.Now;
        });

        var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

        EditedEntities.ForEach(E =>
        {
            E.Property("EditDateTime").CurrentValue = DateTime.Now;
        });

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

```

<br />

#### Access:

Shadow properties using the `ChangeTracker` API.
<br />

> [!Tip]
> Shadow properties can be referenced in LINQ queries via the `EF.Property` static method.
> <br />

```c#

internal class ShadowPropertyUsage
    {
        private readonly ShadowPropertyContext _context;

        public ShadowPropertyUsage(ShadowPropertyContext context)
        {
            _context = context;
        }

        public Person GetLatestPerson()
        {
            return _context.People.OrderBy(contact => Property<DateTime>(contact, "CreatedDateTime")).FirstOrDefault();
        }
    }

```

<br />

### Value Conversion:

value conversions allows you to change data when reading and writing
a property to the database. Typical uses are

- Saving Enum type properties as a string (instead of a number)

- Fixing the problem of DateTime losing its UTC (Coordinated Universal Time)
  setting when read back from the database

- Encrypting a property written to the database and decrypting on reading back

- **Default converter:**

```c#
public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        // Convert Enumt to string
        builder.Property(x => x.EmployeeType).HasConversion<string>();

        //OR

        // Convert String to int
        builder.Property(x => x.Age).HasConversion(e => e.ToString(), e => int.Parse(e));
    }
}
```

- **Establish converter:**

```c#
 public class EmployeeTypeEnumToStringConverter : ValueConverter<EmployeeTypeEnum, string>
{
    public EmployeeTypeEnumToStringConverter() : base(x => x.ToString(), c => (EmployeeTypeEnum)int.Parse(c))
    {
    }
}
```

### Primary key:

- [Key]
- HasKey():

```c#
public class PrimaryKeyConfig : IEntityTypeConfiguration<PrimaryKey>
{
    public void Configure(EntityTypeBuilder<PrimaryKey> builder)
    {
        builder.HasKey(x=> new {c.Key1,Key2});
    }
}
```

### Read-only attribute:

- [KeyLess]

- HasNoKey():

```c#
public class ReadOnlyFluentConfig : IEntityTypeConfiguration<ReadOnlyFluent>
{
    public void Configure(EntityTypeBuilder<ReadOnlyFluent> builder)
    {
        builder.Entity<ReadOnlyFluent>().HasNoKey();
    }
}
```
