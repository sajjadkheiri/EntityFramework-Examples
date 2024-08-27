# Entity framework tips

### what's difference between Find() and FirstOrDefualt()?

##### First of all, Find() tries to read from DbContex like a cache. If it could not be able to fetch data
##### go to the database.However, FirstOrDefualt() directly go to the database without any cache

### what's difference between SingleOrDefualt() and FirstOrDefualt()?

#### The Single (and SingleOrDefault) was fastest for a database access,
#### and also better than using First, as Single will throw an exception if your Where
#### clause returns more than one result. Single and


### Dependent and Principal entity?

#### Principal entity : Contains a primary key that the dependent relationship refer
#### to via a foreign key

#### Dependent entity—Contains the foreign key that refers to the principal entity’s
#### primary key

** An entity class can be both a principal and a dependent entity at the same time. **
