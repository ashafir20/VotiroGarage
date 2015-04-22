For designing a car garage that supports multiple car operations and more future operations I decided to use the Command design pattern. I Created an abstract base class (could have been an interface too)
Called “CarOperationBase” and I created implementations for it (“CarPaintOperation”, “FuelCarOperation”..)
I did not see any use of an “InitGarage” method so I didn’t create one.
When a client wants to use the garage he get the garage builder and adds new operations and then executes the operations. (Maybe an easier or more clean api for invoking operations on the garage itself without using a builder could have been made but I didn’t find any good solutions)
See Program class and the main method for client side usage of the garage and the builder.
(More design patterns included are: decorator (for logging) and the builder pattern)
