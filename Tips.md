# Entity framework tips

### what's difference between Find() and FirstOrDefualt()?

#####

### what's difference between SingleOrDefualt() and FirstOrDefualt()?

#### The Single (and SingleOrDefault) was fastest for a database access,
#### and also better than using First, as Single will throw an exception if your Where
#### clause returns more than one result. Single and