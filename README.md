# Architecture records

## Solution design

This solution was built with the hexagonal architecture design.
You can find out a quick description of hexagonal architecture [here](http://blog.xebia.fr/2016/03/16/perennisez-votre-metier-avec-larchitecture-hexagonale/).

![hexagonal architecture representation](http://blog.xebia.fr/wp-content/uploads/2016/03/adapters2.png)

### Projects Structure
As this API might be deploy as a "block" we could avoid creating several project and seperate layers 
logically (by folder) rather than physicaly (by csproj).
But to avoid too much confusion with developpers that are not aware of this project structure, we
decide to have at least those projects : API, MODULE, REPOSITORY, TESTS.
The less you have project, the more it can be readable and understandable. 
Plus the solution loads and compiles faster ;).

__*TIPS*__
Remember Module projet should have no dependency with any projects. Module is the business core, effort should be made here first!


### Domain Driven Design
As we want to align the business with the code, we choose to try to use Domain Driven Design (DDD).
So according to the Sarenza Guidelines, the domain is inside the **Module** project.

#### Scratchy things
Reading the module project you might see some things that are unusual with the *standard* application design.
Before moving everything, please read carefully the following paragraphs and try to understand the concepts.

##### Ports
Inside the *Ports* folder you will find every Module dependencies.
Those are external components needed by the module to work.
This way, you can apply easily the hexagonal architecture.

##### Entities And Values
Here we apply the [DDD building blocks](https://dzone.com/articles/ddd-part-ii-ddd-building-blocks). Please do not confuse SQL entities and DDD Entities

Summary:
1. Entities
An entity is a plain object that has an identity (ID) and is potentially mutable. Each entity is uniquely identified by an ID rather than by an attribute; therefore, two entities can be considered equal (identifier equality) if both of them have the same ID even though they have different attributes. This means that the state of the entity can be changed anytime, but as long as two entities have the same ID, both are considered equal regardless what attributes they have.

2. Value Objects
Value objects are immutable. They have no identity (ID) like we found in entity. Two value objects can be considered equal if both of them have the same type and the same attributes (applied to all of its attributes). 