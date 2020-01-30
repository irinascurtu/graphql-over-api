## Querying the api

```
talks {
    title
    description 
  }

```

```

	speakers {
		title
		description 
	  }


```
```
	query {
	  speakers{
		companyName
		description
		id
		lastName
		firstName
		position 
	  }
	}
```

### Include related objects defined
speaker will be either, included with .Include() or loaded with a DataLoader

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


## Mutations

```
    mutation($talk: talkInput!) {
      createTalk(talkInput: $talk) {
        title
        description
        speakerId
      }
    }
```
And define the variable
```

    {
     "talk": {
         "title" :"Awesome .Net Core",
          "description" :"we'll talk about how cool it is .Net Core",
          "speakerId": 2
      }
    }

 ```
 
 //demo adding a new mutation
 //variable to be added
     mutation($speaker: speakerInput!) {
      createSpeaker(speakerInput: $speaker) {
        linkedIn
        firstName
        lastName
      }
    }

{
     "speaker": {
     "firstName" :"Bond",
      "lastName":"James",
      "position":"Spy",
      "companyName": "Secret",
      "description": "secret description",
      "gitHub":"https://github.com",
      "email":"bond@secret.com",
      "linkedIn":"https://LinkedIn.com/james-bond"      
      }
    }





## Data Loader in action demo

```
query {
  talks {
    description
    title
    feedbacks {
      comments
      content
    }
  }
}
```

Or complete values with speakers

the  cool thing is that 'speakers' is different depending on the context
```

`query	{
  talks{
    description
    title
    feedbacks{
      comments
      delivery
    }
    speakers{
      companyName
    }
  }
}
```
will call different things depending on their definition in the schema
```
query	{
    speakers{
      companyName
      description
      lastName
    }  
}
```



