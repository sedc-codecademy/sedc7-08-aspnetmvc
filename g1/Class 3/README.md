# Models 🍦
In order for one application to be dynamic it needs to show and change data constantly depending on the users needs. This brings a need for data management and manipulation. That is why the concept of the model is created and why it's really important for the MVC pattern. The Model is basically an entity that keeps data that is ready for use and change if necessary. Another key point about the Model is that it must be within the business logic and domain of the application. This means that the business logic dictates how the model will be structured as well as how many models do we need to create. In ASP.NET Core MVC applications where we use C# as our language of choice, models are represented by a class. So if we create a class with properties, that is actually the model and the properties are the data storage units. If this model was mapped to a data structure such as a database the class would be a table and the properties columns. The main models that contain our logic, often called Domain or Core models stay in a separate place, usually in a separated project or in a separate folder.
```csharp
public class Order
{
	public int Id { get; set; }
	public User User { get; set; }
	public string Pizza { get; set; }
	public double Price { get; set; }
}
```
```csharp
public class User
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Address { get; set; }
	public long Phone { get; set; }
}
```
## Sending a model to view 🔹
Models are basically classes and objects created from those classes hold our data in them as properties. We can send these models to our views and with that send data to the view. We can only send one model to any one particular view at a time. 
### Sending ( Controller ) 🔽
In order to send a model to a view we create an object from the class representing our model or get an object from somewhere else. Then we add it to the View result as a parameter. The view result can only pass one model. To get around this and pass multiple models we can either create a list of models or create a view model.
```csharp
public IActionResult Index()
{
	User person = new User() { FirstName = "Bob", LastName = "Bobsky", Address = "Bob Street", Phone = 0800234234 };
	Order order = new Order(){ Id = 12, User = person, Pizza = "Kapri", Price = 10.5 };
	return View(order);
}
```
### Intercepting ( View ) 🔽
In order to intercept the model in our view we need to first add a line of code that indicates that the view is expecting some kind of model and add the type of the model that we are expecting. After the model is sent from a controller and added to a view we can use it by typing @Model and using it as the object that we are expecting.
```csharp.cshtml
// We write the whole namespace to our model ( class )
@model Sedc.App.Models.DomainModels.Order
...
<h1> Order </h1>
<ul>
	<li>Name: @Model.User.FirstName</li>
	<li>Name: @Model.Pizza</li>
	<li>Name: @Model.Price</li>
</ul>
```
## Sending data to view without model 🔹
Usually when we work with the MVC pattern we tend to send model from a controller to the view with all the information that we need. But there are a few entities that can send data to the view as well separately from the model. These are ViewBag and ViewData. Both of them are their own entity and can be used separately from the model and them selves. ViewBag and ViewData are not to be used as a replacement or in place of the models. They are only another way to pass a value besides the model it self which is the main source of logic to our view.
### ViewData 🔽
ViewData is a special Dictionary that can be accessed in the controller as well as the view. There is no need for prior configuration, it just exists in both places. ViewData works the same as a dictionary and we can add items as a key value pair and use methods and properties that a normal dictionary uses such as Count, Keys, Values etc. One important thing to mention is that the key part of the ViewData dictionary must always be a string. The value can be whatever we choose since it is of type object.
```csharp
// Controller
public IActionResult Index()
{
	User person = new User() { FirstName = "Bob", LastName = "Bobsky", Address = "Bob Street", Phone = 0800234234 };
	Order order = new Order(){ Id = 12, User = person, Pizza = "Kapri", Price = 10.5 };
	ViewData.Add("Title", "Home Page");
	ViewData.Add("Order", order);
	return View();
}
```
```csharp.cshtml
// View
<h1>@ViewData["Title"]</h1> // Will show up in our view
<ul>
	// Will break on build time
	<li>Name: @ViewData["Order"].User.FirstName</li>
	<li>Pizza: @ViewData["Order"].Pizza</li>
	<li>Price: @ViewData["Order"].Price</li>
<ul>
```
### ViewBag 🔽
ViewBag is a new and dynamic version of the ViewData object. ViewBag lets you dynamically add values and those values as properties and access them in the view. Unlike the ViewData object, if we add an object from a class as a value, we can access it's properties in the view ( We don't have intellisense in the view ). If we do not access the correct name of a property we will get a runtime error.
```csharp
// Controller
public IActionResult Index()
{
	User person = new User() { FirstName = "Bob", LastName = "Bobsky", Address = "Bob Street", Phone = 0800234234 };
	Order order = new Order(){ Id = 12, User = person, Pizza = "Kapri", Price = 10.5 };
	ViewBag.Title = "Home Page";
	ViewBag.Order = order;
	return View();
}
```
```csharp.cshtml
// View
<h1>@ViewBag.Title</h1> // Will show up in our view
<ul>
	// Will show up in our view
	<li>Name: @ViewBag.Order.User.FirstName</li>
	<li>Pizza: @ViewBag.Order.Pizza</li>
	<li>Price: @ViewBag.Order.Price</li>
	<li>Delivery: @ViewBag.Order.Delviery</li> // Will break at runtime
<ul>
```
## Other types of models 🔹
In an MVC application we can find different types of models depending on the architecture and patterns that we use to organize the code. These models all exist for a particular purpose, either to abstract some data, transfer or bundle some data together. When multiple types of models exist in an application, the data is mapped from one type to the other so that it can flow through the application. The mapping can be done manually, just making a new model and initializing it to the values of some other model, or a library for mapping called a mapper can be used. 
### View Model 🔽
When creating models, we design them to fit the business logic of the application that we are building. This is great, but a view can only accept one model and some times we need data from two different models to show up in one view, or we just want a few properties from a particular model. This is why View Models exist. View models are classes that contain all the information that one view needs. This means that this class can have properties from multiple models or part of one model, tailored to the view needs. This View Model is only used for the view and nothing else. The data first comes in the multiple domain models ( core, main models ) and then we map it to the view model to create a specific set of data needed for a view. After we are done with the view, the data is sent back as a view model and that view model is mapped back in to the domain models so they can go back to our application. We must always mark down our view models by writing ViewModel at the end of the model name.
```csharp
// A view model
public class OrderDetailsViewModel
{
	public int Id { get; set; }
	public string FullName { get; set; }
	public string Address { get; set; }
	public long Contact { get; set; }
	public string Pizza { get; set; }
	public double Price { get; set; }
}
```
```csharp
// The domain models
User person = new User() { FirstName = "Bob", LastName = "Bobsky", Address = "Bob Street", Phone = 0800234234 };
Order order = new Order(){ Id = 12, User = person, Pizza = "Kapri", Price = 10.5 };

// Creating and mapping the view model manually
OrderDetailsViewModel orderDetails = new OrderDetailsViewModel()
{
	Id = order.Id,
	FullName = $"{person.FirstName} {person.LastNAme}",
	Address = person.Address,
	Contact = person.Phone,
	Pizza = order.Pizza,
	Price = order.Price
}
```
# Views 🍰
The views in ASP.NET MVC are the main and only interface from which a user can interact with the application. Views in ASP.NET are basically HTML pages with an integrated engine that helps manipulate, integrate and bind the view and it's contents with the back-end part of  the application using C# code. This is why the extension to the views is cshtml. Views are always added in the Views folder of the ASP.NET application, views for certain controllers are added in a folder with the controller name ( without controller ) and views that are shared between multiple controllers and actions are added in a folder named Shared. The application can easily find it's way to the views if they are properly named and in the correctly positioned and named folder. 
## Razor Engine 🔹
The Razor View Engine is the engine that allows us to write C# in our HTML page directly and help us build and connect pages to the back-end of our application quickly and easily. The Razor View Engine has a lot of features. To access the Razor syntax we use the @ sign. We can access that way
### Using C# in an HTML View 🔽
To use C# in a view all we have to do is place an @ sign. After the @ sign we can write c# code. The code can be written in one line, multiple lines ( block of code ) and can be mixed back and forward between HTML and C# depending on the logic. 
- @code		- for executing C# values and methods
- @(code)	- for adding expressions result directly to html
- @{code}	- for executing multiple lines of c# code ( block )
- @using 	- for referencing some import 

With this we can write if statements, for statements and almost all features C# covers in the view with the HTML interchangeably. This feature allows us to build dynamic and complex views with C# logic. 
> Note that Razor generates an HTML view from the CSHTML file. C# does not render on the client machine it self
#### One line value
```csharp cshtml
@using SEDC.PizzApp.Models
@model Order

<h2>Order:</h2>
<ul>
    <li>@Model.Id</li>
    <li>@Model.Name</li>
    <li>@Model.Pizza</li>
    <li>@Model.Price</li>
</ul>
<h4>Time:</h4>
<p>@DateTime.Now</p>
```
#### One line expression
```csharp cshtml
@using SEDC.PizzApp.Models
@model Order

<h2>Order:</h2>
<ul>
    <li>Id: @Model.Id</li>
    <li>Name: @("Mr./Ms. " + Model.Name)</li>
    <li>Pizza: @Model.Pizza</li>
    <li>Price + Delivery: @(Model.Price + 40)</li>
</ul>

<h4>Time:</h4>
<p>@DateTime.Now</p>
```
#### Block of code
```csharp cshtml
@using SEDC.PizzApp.Models
@model Order
@{ 
    string status = "Not yet delivered";
    if(Model.Delivered)
    {
        status = "Delivered!";
    }
}
<h2>Order:</h2>
<ul>
    <li>Id: @Model.Id</li>
    <li>Name: @("Mr./Ms. " + Model.Name)</li>
    <li>Pizza: @Model.Pizza</li>
    <li>Price + Delivery: @(Model.Price + 40)</li>
    <li>Status: @status</li>
</ul>

<h4>Time:</h4>
<p>@DateTime.Now</p>
```
#### If statement in a View
```csharp cshtml
@if (!Model.Delivered)
{
    <p>Your delivery is on the way! For long delays contact: 070123456</p>
}
```
#### For loop in a View
```csharp cshtml
@using SEDC.PizzApp.Models
@model List<Order>
<h2>Orders:</h2>
@for (int i = 0; i < Model.Count; i++)
{
    <h4>Order no @i</h4>
    <ul>
        <li>Id: @Model[i].Id</li>
        <li>Name: @("Mr./Ms. " + Model[i].Name)</li>
        <li>Pizza: @Model[i].Pizza</li>
        <li>Price + Delivery: @(Model[i].Price + 40)</li>
        <li>Status: @Model[i].Delivered</li>
    </ul>
}
```
## Types of Views 🔹
Besides the standard views in the ASP.NET MVC projects there are special types of views that are automatically detected by the framework if they are present. These views have some specific features and uses in the application. The framework detect these views by their name and by their position in the folder structure of the project. Special views that affect all the views no matter what or where they are are placed directly in the Views folder. The views that need to be used or imported, but that can be shared by multiple views if they are imported must be stored in a folder inside the Views folder called Shared. Views that are not intended to be accessed directly are written with an **_** before the name. 
### Layout 🔽
A layout view is exactly what the name suggests, a view that is basically the layout of the page. The layout can be used by views and this makes all views have the same layout, but the contents of the page change. The benefits of having one layout are huge. There is only one code for the layout, meaning that if you change something about the layout all the views get the change. It also simplifies the boilerplate html code like the head, body, title as well as imports such as css and scripts. This makes the views much cleaner and simpler. Layout views are added in the Shared folder and are marked by an **_** before the name. To position the view that will go in the layout, @RenderBody is used. Whenever that is used, that place is where the code from the view generating will go.
#### In the _Layout.cshtml
```csharp cshtml
<!DOCTYPE html>
<html>
<head>
	// Whatever title is passed to ViewBag, it will render here, in the Layout
    <title>@ViewBag.Title - PizzaApp</title>
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
    <link rel="stylesheet" href="~/css/site.css" />
</head>
<body>
    <div class="container body-content">
	    // On the line where @RenderBody() is will be the view that we open
        @RenderBody()
        <hr />
        <footer>
            <p>&copy;PizzaApp</p>
        </footer>
    </div>
    <script src="~/lib/jquery/dist/jquery.js"></script>
    <script src="~/lib/bootstrap/dist/js/bootstrap.js"></script>
    <script src="~/js/site.js"></script>
</body>
</html>
```
#### In the view
```csharp cshtml
@{  
ViewBag.Title  =  "Home"; // Changing the ViewBag.Title (shows in the layout)
Layout  =  "~/Views/Shared/_Layout.cshtml"; // Using the layout to this view
}
```
### ViewStart and ViewImports 🔽
ViewStart and ViewImports are views that affect all the views that we create in our ASP.NET application. They are not imported or used. If the framework finds them it uses them automatically. They are placed directly in the Views folder. Both of these views start with an **_** before their names. 
#### ViewStart
When we want to use the same code in every view that we create we use the ViewStart view. In it we can write some code and the razor engine will execute that code upon every loading of any view. Usually in this view we write code that is repeating on every view such as adding a layout.
```csharp cshtml
@{
	// setting the layout for all the views
    Layout = "~/Views/Shared/_Layout.cshtml";
}
```
#### ViewImports
As by the name, ViewImports is a view where we store all our imports for every view that we create. This is a view where we usually write using statements that we need in all of our views. For instance if we need a using statement to our models we create a using statement in the ViewImports to the folder Models so that we don't have to write the whole namespace when importing models in our views.
```csharp cshtml
using SEDC.PizzApp.Models
```
### Partial 🔽
Partial views are basically view within a view. If a component in our application is repeating or if it is changing on multiple places we can use a partial view. This means that we can create a view with HTML that is only for that feature or component. After that we can import it in our view once or multiple times with different data depending on the case. Partial views usually have an **_** before their name as a convention, to indicate that they can be used multiple times and that they must not be used by them selves. Partial views can also require a Model and we can also pass data to a partial view just like a normal one. Since the partial view is used from another view, that parent view must have the needed data and pass it to the partial in order for the partial to have its data.
#### Partial view called _OrderItem
```csharp cshtml
// This view is stored in the Shared folder
// It can also accept a Model and use it
@model Order
@{ 
    string status = "Not delivered yet";
    if (Model.Delivered)
    {
        status = "Delviered";
    }
}
<h4>Order no. @Model.Id</h4>
<ul>
    <li>Name: @("Mr./Ms. " + Model.Name)</li>
    <li>Pizza: @Model.Pizza</li>
    <li>Price + Delivery: @(Model.Price + 40)</li>
    <li>Status: @status</li>
</ul>
```
#### Parent view that uses the partial view _OrderItem
```csharp cshtml
// This is the view that uses the partial view
// The data must be passed from this view to the partial
@using SEDC.PizzApp.Models
@model List<Order>
<h2>Orders:</h2>
@for (int i = 0; i < Model.Count; i++)
{
	// Here we add the relative path as well as the data required
    @Html.Partial("~/Views/Shared/_OrderItem.cshtml", Model[i])
}
```
### Other shared Views 🔽
We can create our own shared views if we need them. All views that can be used multiple times on different places and occasions are added in the Shared folder. These views can then be accessed whenever we need them. Usually these views are connected to some general that all view have in common such as an Error or a Thank You page. 
## HTML Helpers 🔹
HTML Helpers are helper methods from the razor engine that we can call with a few parameters. After calling these methods, they generate HTML code tailored to the data passed as a parameter. With these methods we can do almost anything in our HTML view within a function call. There are HTML helpers for almost everything such as generic lings to other routes, binding labels to our model, binding input fields to our model, creating forms with submit functionality to the right address etc. 
### Links 🔽
The link html helper is a helper that lets us create links to our routes in our MVC application by adding our action and even controller name as parameters. The razor engine will generate an HTML element that represents link and that in the attributes has the right address to the action in question.
```csharp cshtml
// Calling an action in the same controller
@Html.ActionLink("Back To Home", "Index")
// Calling an action in a different controller and action
@Html.ActionLink("Back to Home","Index","Home")
// Calling an action with parameters
@Html.ActionLink("To First Item", "Order", "Orders", new { id = 0 })
```
### Display 🔽
For displaying things from the model we can also use Html Helpers. The display HTML helper lets us display a string in our views by requesting the name as a string ( loosely typed ) or requesting it by a lambda ( strongly typed )
```csharp cshtml
// Displaying a property of the Model passed loosely typed
@Html.Display("Name")
// Displaying a property of the Model passed strongly typed
@Html.DisplayFor(x => x.Name)
```
## Extra Materials 📘
* [When to use ViewBag and ViewData](https://rachelappel.com/2014/01/02/when-to-use-viewbag-viewdata-or-tempdata-in-asp-net-mvc-3-applications/)
* [Model and ViewModel](https://www.tektutorialshub.com/asp-net-core/asp-net-core-model-and-viewmodel/)
* [Passing data from controller to view](https://www.tektutorialshub.com/asp-net-core/asp-net-core-passing-data-from-controller-to-view/)
* TutorialsPoint Articles on Views
  * [Layout](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_layout_views.htm)
  * [ViewStart](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_view_start.htm)
  * [ViewImport](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_view_import.htm)
* [Microsoft on Partial Views](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/partial?view=aspnetcore-2.1)
* [Quick Refference to Razor Syntax](https://haacked.com/archive/2011/01/06/razor-syntax-quick-reference.aspx/)