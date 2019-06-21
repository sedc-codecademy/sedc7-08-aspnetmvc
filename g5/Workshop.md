# Exercise 🛠
## Create Menu feature
Create a Menu view that can be accessed from the navigation bar and that will show all the pizzas available by type. ( not by size )
You will need:
- Action
- View Model
- View
- Map the pizzas to view model
- We need to show only image, name and price ( Hint: There is a partial view )
## Create Details feature
Create a details feature, that will show an order details to the user. When a person adds the address to the browser /order/details/{ id } it should show him a view that has details for an order ( id is a number )
You will need:
- Action that accepts a parameter id
- View Model
- View
- Map the pizzas to view model
- We need to show Full Name, Price of order and pizzas ( Hint: There is partial view )
- If there is no id like that show the error view
## Create Saving Feedback feature
- Create Feedback Domain Model
- Create Repository for Feedback ( Hint: it is similar to our other repositories )
- Register the repository in the dependency injection module ( Hint: It's the same like the other configurations there )
- Create methods in the UserService for saving feedback
- Add code in the Post Feedback Action in the Home controller ( Hint: We can call the method that we created in the UserService )
