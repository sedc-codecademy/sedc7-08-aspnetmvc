# Homework ✏
Create a ToDo application that keeps track ToDo tasks. The application should have 4 screens. One with all the tasks that are not done, one with all the tasks that are in progress, one with all the tasks that are done. The application should have a header with navigation to all the pages and footer with contact information and email to contact support.
### Todo Task 🔸
A task should have:
* Title
* Description explaining the task
* Priority that states the task importance from 1 to 3 
	* 1 is important
	* 2 is medium importance
	* 3 is not important
* Status that states if the task is not done, in progress or done
* Type that represents what type of task it is
	* Work
	* Personal
	* Hobby
* List of sub-tasks that have
	* Title
	* Description
	* Status ( Done or Not Done )


### What to do 🔸
Here is what should be done:
1. Create an ASP.NET Core application
2. Create models and structure for the application
3. All the data should be saved in database
4. Create a layout with navigation that works
5. Create the first page with a table where all the tasks that are still not done shown
6. Add a button above the table with tasks that says: Add Task
7. The button should redirect to a view that will take the needed information for a task and save the task in some static list
8. After the info is filled the view should redirect back to the first view where the new task is visible in the table
9. Create a multi architecture organization for the project
11. Create repositories for the models
12. Create the In progress page, where all tasks that are in progress are shown
13. Create the Done page, where all tasks that are done are shown
14. Create a task details page where details of a task are shown
15. In the details page the information shown should be in inputs ( and status in dropdown ) so that the person can change the details if they want or change status and save
15. Create a button after every task that is shown in every view that when clicked, will redirect you  to the details view of that task
