# Homework
In the Pizza Hut project do the following:
* Create IUserRepository interface with the same methods as there are in IPizzaRepository
* Create MockUserRepository class that implements IUserRepository:
	* Create a constructor in MockUserRepository class and add some records for User
	* Implement the methods: Add, Get, GetAll, Update and Delete in this class
* Create controller UserController:
	* Add a constructor to get the IUserRepository methods available in the controller.
	* Implement the actions in the User controller: Index, Details, Create, Edit, Delete (similarly as in the Pizza controller)
	* Create Views for each of the actions
	* Add a record in Startup.cs for this repository: services.AddSingleton<IUserRepository, MockUserRepository>(); 
* Add an item Users in the navigation bar to get availabe the work you've done. Run the actions from browser.