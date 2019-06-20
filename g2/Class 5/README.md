# UI and Forms 🍰 & Filters ✂️ 
## HTML Helpers 🔹
HTML Helpers are helper methods from the razor engine that we can call with a few parameters. After calling these methods, they generate HTML code tailored to the data passed as a parameter. With these methods we can do almost anything in our HTML view within a function call. There are HTML helpers for almost everything such as generic lings to other routes, binding labels to our model, binding input fields to our model, creating forms with submit functionality to the right address etc. 
### Links 🔽
The link html helper is a helper that lets us create links to our routes in our MVC application by adding our action and even controller name as parameters. The razor engine will generate an HTML element that represents link and that in the attributes has the right address to the action in question.
##### Razor View
```csharp cshtml
// Calling an action in the same controller
@Html.ActionLink("Back To Home", "Index")
// Calling an action in a different controller and action
@Html.ActionLink("Back to Home","Index","Home")
// Calling an action with parameters
@Html.ActionLink("To First Item", "Order", "Orders", new { id = 0 })
```
##### When rendered in HTML
```html
<!-- First/Second example -->
<a href="/Orders">Back To Home</a>
<!-- Third example -->
<a href="/Orders/Order/0">To First Item</a>
```
### Display 🔽
For displaying things from the model we can also use Html Helpers. The display HTML helper lets us display a string in our views by requesting the name as a string ( loosely typed ) or requesting it by a lambda ( strongly typed )
##### Razor View
```csharp cshtml
// Displaying a property of the Model passed loosely typed
@Html.Display("Name")
// Displaying a property of the Model passed strongly typed
@Html.DisplayFor(x => x.Name)
```
##### When rendered in HTML
```html
<!-- Only text is printed -->
Bob Bobsky
```
### Label 🔽
When adding a label for a property we use the Label HTML helper. This helper creates a label html tag with the content of the name of the property. Unlike Display Html Helper this helper creates a HTML element. The default value will always be the name of the property, but this can be changed by adding annotation to the properties in the class. 
##### Razor View
```csharp cshtml
// Displaying a property name loosely typed
@Html.Label("Name")
// Displaying a property name strongly typed
@Html.LabelFor(x => x.Name)
```
##### When rendered in HTML
```html
<label for="Name">Name</label>
```
### TextBox 🔽
The TextBox helper is the helper for creating and binding input fields with values. This helper is used when we want to create an input and the value that will be added in that input to be bound to some property of the model. This helper creates an input parameter with all the attributes automatically to bind the property that was added. This means that if that property has a value on the start of the page, that value will be written in the input field. If the input field is changed and the data is posted back to the back-end the value of that property will also be changed. 
##### Razor View
```csharp cshtml
// Creating an input for a property loosely typed
@Html.TextBox("Name")
// Creating an input for a property strongly typed
@Html.TextBoxFor(x => x.Name)
```
##### When rendered in HTML
```html
<!-- If there is a value for the property -->
<input id="Name" name="Name" type="text" value="Bob Bobsky">
<!-- If there is no value for the property -->
<input id="Name" name="Name" type="text" value="">
```
### DropDownList 🔽
Drop down lists can also be created with a Html Helper. There are two ways of creating a drop down list. The hard way is to create a SelectList with SelectListItems ( like a dictionary with the values and keys for the drop down ) and send that to the view. The easier way is to just send an enum to the view and all the values from the enum will be generated with the html helper. 
##### Razor View
```csharp cshtml
// Creating a dropdown for all the values of the enum and mapping it to a property
@Html.DropDownListFor(x => x.Size, Html.GetEnumSelectList(Model.Size.GetType()))
// Creating a dropdown for all the values of the enum and mapping it to a property with a starting choice/label
@Html.DropDownListFor(x => x.Size, Html.GetEnumSelectList(Model.Size.GetType()), "Select a pizza")
```
##### When rendered in HTML
```html
<!-- Values are what maps the value clicked back to an enum -->
<select id="Size" name="Size">
	<option value="1">Medium</option>
	<option value="2">Large</option>
	<option value="3">Family</option>
</select>

<!-- Example 2 -->
<select id="Size" name="Size">
	<option value="">Select a pizza</option>
	<option value="1">Medium</option>
	<option value="2">Large</option>
	<option value="3">Family</option>
</select>
```
### HiddenField 🔽
The hidden field helper is used a lot and it's main objective is to send data that the user does not need to see on the screen. Since the back-end does not know from where the model came from, we must send data to identify models that we send to views. The properties that we send for identifying the model later are stored in these hidden fields. Data like this is an Id of some object or some status that we need to keep and send back to the back-end application with the model. Hidden fields is basically an input that is not displayed.
##### Razor View
```csharp cshtml
// Creating an input field that is hidden for a property loosely typed
@Html.Hidden("Name")
// Creating an input field that is hidden for a property strongly typed
@Html.HiddenFor(x => x.Name)
```
##### When rendered in HTML
```html
<!-- Will not show for the user. No need for extra css or js -->
<input id="FirstName" name="FirstName" type="hidden" value="Dragan">
```
## Forms 🔹
In order to send some data back to the back-end we need to add all our data in to a form. Basically all the TextBoxes that are bound to some properties need to be in a form so we can send them back. There is a HTML helper for a form that automatically knows which path to post to and detects the inputs that are bound with the model. When using this helper we just write TextBoxes in it that are bound to the model properties and a submit button or input. The rest is already set by the helper. The helper posts back to an action in the current controller that has the same name as the action that called the view and has the [HttpPost] attribute
#### With Helper
##### Razor View
```csharp cshtml
@using(Html.BeginForm())
{
	@Html.LabelFor(x => x.FirstName)
    @Html.TextBoxFor(x => x.FirstName)
    <br/>
    @Html.LabelFor(x => x.LastName)
    @Html.TextBoxFor(x => x.LastName)
    <br/>
    <button type="submit"> Submit </button>
}
```
##### When rendered in HTML
```html
<form action="/order/order" method="post">
	<label for="FirstName">First Name</label>
	<input id="FirstName" name="FirstName" type="text" value="Dragan">    
	<br/>
	<label for="LastName">Last Name</label>
	<input id="LastName" name="LastName" type="text" value="">    
	<br/>
	<button type="submit"> Submit </button>
</form>
```
## Model attributes 🔹
In the model we can decorate the properties with attributes to get an extra layer of data for our properties. This means that we can add some extra significance on the properties and the razor engine will treat them differently or add some extra data when necessary. These attributes are added above the properties and can be used for validating, displaying different names and pointing out how to be mapped in a database.

### Display attribute 🔽
The display attribute basically changes the name of the property so that every time the name of the property is used, instead of the code name ( Ex. FirstName ) we get a different name ( Ex. First name of user ). This helps us when putting labels for our properties. If we decorate our properties with a Display property the label will be displayed in the way we wanted, but the name of the property in the code will stay the same. Attributes related to the database are usually added in the domain models and the ones that affect how the properties are displayed are added in the view models
##### In model 
```csharp
public class RegisterViewModel
{
	[Display(Name="First name of user")]
	public string FirstName { get; set; }
	[Display(Name="Last name of user")]
	public string LastName { get; set; }
}
```
##### In view
```csharp cshtml
	@Html.LabelFor(x => x.FirstName)
    @Html.TextBoxFor(x => x.FirstName)
    <br/>
    @Html.LabelFor(x => x.LastName)
    @Html.TextBoxFor(x => x.LastName)
```
#####  When rendered in HTML
```html
<label for="FirstName">First name of user</label>
<input id="FirstName" name="FirstName" type="text" value="">
<br/>
<label for="LastName">Last name of user</label>
<input id="LastName" name="LastName" type="text" value="">
```
## Sending form data to controller 🔹
Sending data from controller to a view is pretty easy. We just return a View() and add the model as a parameter. But in order to return data from the view to a controller back we need a few extra steps. First we need to create an action with the same name as the action that returned the view in the first place. This new action will accept the model that we are sending to the view ( the same model that we will return back from the view ) and has the [HttpPost] attribute. If we have a form and a submit button on the view, ASP.NET will know how to connect and submit the form to the Post action that we created by the name of the actions being the same
##### In model
```csharp
// Domain Model
public class User 
{
	public int Id {get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public bool IsActive { get; set; }
}
```
```csharp
// View Model
public class RegisterViewModel
{
	[Display(Name="First name of user")]
	public string FirstName { get; set; }
	[Display(Name="Last name of user")]
	public string LastName { get; set; }
}
```
##### In controller
```csharp
// Code will first hit here and render the view with an empty view model
[HttpGet]
public IActionResult Register()
{
	// We send an empty view model because if the model is null we will not be able to access and bind our values
    RegisterViewModel model = new RegisterViewModel();
    return View(model);
}

// Code will hit here when the form is submited
[HttpPost]
public IActionResult Register(RegisterViewModel model)
{
	// We create a domain model from the view model
    User user = new User()
    {
		Id = Db.GetId(), // Fictional method, imagine that it generates a new id
		FirstName = model.FirstName,
		LastName = model.LastName,
		IsActive = true
	}
	// We add the new user in to our database
	Db.Add(user);
	// We redirect to some other action since this action does is not bound to any view
    return RedirectToAction("Index");
}
```
##### In View
```csharp cshtml
<h1> Register </h1>
@using(Html.BeginForm())
{
	@H`tml.LabelFor(x => x.FirstName)
    @Html.TextBoxFor(x => x.FirstName)
    <br/>
    @Html.LabelFor(x => x.LastName)
    @Html.TextBoxFor(x => x.LastName)
    <br/>
    <button type="submit"> Submit </button>
}
```

# Building Web Applications 🎂
## Building vs Coding 🔹
Web applications are built by writing code. But writing code is not the same as building the web application. The code is just a tool for building our application. The building part is much more then just coding. It's thinking about the product now and the future. It's organizing and structuring all the parts. It's dividing the user from the sensitive data. It's thinking about the ease of implementation of new features. Basically when we build an application we make a whole plan to build a complex system of ideas and practices that will be easy to use, make changes fast, be secure and stand the test of time. For this reason there are a lot of concepts, ideas and practices that exist and that we can implement and use to build a good application

## Architecture 🔹
The way we build, organize and structure a software application is called Architecture. We build software by using some sort of organization and with that some architecture. This means that the code needs to be divided in multiple projects, files and folders. These must me created with some logic in mind and be connected in a certain way to follow the rules of the architecture that we are trying to implement. There are already types of architectures that exist and that have proven successful in the industry. 
### Multi Tier ( N-Tier ) Architecture 🔽
Multi tier architecture is a system of structuring an application in to layers or logic groups. These layers keep code that is similar and does a similar job usually in different project inside our solution. It is called multi tier or N tier because N stands for a number of layers. This means that we can have 2-Tier, 3-Tier, 4-Tier applications, depending on how we divide our application. Some times a tier can have multiple projects that have the same logic inside them if that makes it easier for us to connect or to organize the code.
#### 3-Tier
3-Tier architecture is one of the most common. It  divides our code on to 3 fundamental parts: 
* Data Access Layer - A layer that has everything to communicate and connect to the database. This layer is the only layer that communicates to the database. It houses the models, the systems for communication as well as the methods for reading or writing to the database. ( Class Library )
* Business Logic Layer - A layer that has all the business logic that we need for our application. In this layer we write all the code that is connected to our application business logic and this is the only layer that can access and request stuff from the Data Access Layer. After it processes the information from the Data Access Layer it sends them to the presentation layer. ( Class Library )
* Presentation Layer - The presentation layer is the layer that the users interact with. This layer is basically the application that we are building, the views, styles and scripts. This layer does not host any business logic or database access methods. It just worries about how the user interacts with the application. If the presentation layer needs anything, it asks from the Business Layer which can make a call if it needs to the Data Access Layer that can get something from the database.  ( Web Application, ASP.NET )

#### Diagram
![Architecture Diagram](https://github.com/sedc-codecademy/sedc7-08-aspnetmvc/blob/master/g5/Class%206/img/Architecture.png?raw=true)

#### ASP.NET Web Application Example
![Architecture Example](https://github.com/sedc-codecademy/sedc7-08-aspnetmvc/blob/master/g5/Class%206/img/ntier.PNG?raw=true)

## Extra Materials 📘
* [Filters in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.2)
* [HTTP request methods](https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods)
* [Purpose Of ValidateAntiForgeryToken In MVC Application](https://www.c-sharpcorner.com/article/purpose-of-validateantiforgerytoken-in-mvc-application/)
* [Prevent Cross-Site Scripting (XSS) in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/cross-site-scripting?view=aspnetcore-2.2)
