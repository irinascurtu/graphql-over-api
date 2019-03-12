## Querying the api

```
talks {
    title
    description 
  }
```

### Include related objects defined

```
talks {
    title
    description
    speaker {
      lastName
      firstName
      position
    }
  }
```


### Call with a parameter

```
query {
  talk(id: 1) {
    description
    title
    speaker{
      lastName
    }
  }
}
```

> todo: check what is generated while running ef include or without include

## Mutations