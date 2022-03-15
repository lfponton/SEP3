# SEP3
Semester Project 3
This project is an attempt at building a distributed system, with server to server communication, using REST and sockets.\
\
The system includes a GUI for two types of clients built in C# using .NET.\
\
The web service server is built in Java using Spring.\
\
The backend server is implemented in C# and uses Entity Framework Core and connects to a Postgresql database.\
\
For more information about architecure, domain model, ER diagram, see the folder "diagrams".

# Project Description
The owner of several restaurants in Horsens is experiencing issues with managing orders and table bookings in her restaurants.\
In particular, in one of her sushi restaurants customers can call or drop by the restaurant to make their orders or book tables. This is creating long queues at the restaurant and the large amount of phone calls is overburdening the staff. Furthemore, their order management is based on pen and paper and many orders and bookings are starting to get lost and mixed up. The restaurant does not want to hire an order and delivery service (such as Wolt or Just Eat), because they have their own delivery staff
and want to avoid paying the high fees.\
\
The restaurant offers menus to their customers. The restaurant changes their menus once in a while. Customers can order these menus by dropping by the restaurant or calling. When a customer has ordered more than 10 times, then they will receive a discount of 50 percent. To keep track of this, the restaurant gives out cards that they stamp every time a customer orders. To manage these cards, the restaurant saves the customer’s information in a spreadsheet. The information saved is: customer name, email, phone number, address, number of orders. When the customer has ordered more than 10 times, they receive a new card and the staff changes the number of orders to 0 in the spreadsheet. The restaurant also offers a 10 percent discount on orders worth more than 1000 kr.\
\
When the restaurant receives an order, the staff takes note on paper and checks with the kitchen and approves the order. Normally, it takes an average of 40 min to deliver
an order. As a rule, the restaurant does not accept orders with more than 20 menus of the same kind, because of the way their inventory works and the impossibility of
producing so many menus for one order.\
\
The restaurant staff collects all the orders written down during the day on paper, and they enter the information into a spreadsheet. Orders have an id, order time, delivery
time, customer id and name, emailr, number of customers, delivery address, menu name, type, quantity and price. The restaurant uses this information to audit their business, keeping track of orders and income.\
\
Regarding the current system to book tables, customers call the restaurant to make reservations. They let the employees know if there is any specific data the restaurant
needs to know, like if it is a birthday celebration, someone has allergies, among others. Thus, the restaurant can bring a better service: it could be the kitchen adapting the regular menu or simply setting some Danish flags to receive the birthday person. This process helps to add extra work to the employees, having to answer the phone while,
maybe, there are people waiting in the queue to pay or pick up food. In order to decide if the booking can be accepted or not, the employees take in consideration two aspects: capacity and time. Capacity refers to checking if the restaurant can host the new booking at the required time.\
\
The restaurant can host around 50 people at the time so if 45 people have already booked and 10 people want to reserve, this is not possible. Usually people stay at the restaurant up to 2 hours, so the availability is reconsidered after that time. Time refers to the booking that needs to be done at least 2 hours before. After that time, only spontaneous tables are accepted. It has happened in the past that some people make a large reservation and then cancel at the very last minute, causing waste of time and possible customers to the restaurant. Due to this reason, bookings bigger than 20 people are accepted only if the customer is known by the staff.

