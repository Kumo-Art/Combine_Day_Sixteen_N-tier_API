### N-Tier API

-Tier means layer, and n means numbers. An N-Tier API splits the work into different layers that each do one job and only talk to the layer next to them


Controller (Presentation) -> Services (Business) -> Repository(Data Access) -> Database


## Controller

-Speaks HTTP, takes the request, asks the service, picks the status code


## Services


- Holds the rules AKA our business Logic



## Repository

- Stores and Fetches Data: get, add, update, delete (The only class that uses AppDbContext)




//-----------------Extra Notes----------------------//
Models are the shape of our Data and is created first in the Api