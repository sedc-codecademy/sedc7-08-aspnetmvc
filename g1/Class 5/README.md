# Routing 🔹
To access our actions in our controllers from the browser we need an address. In our application, the handling of requests to addresses is called routing and the addresses to the actions are called routes. The routing is already set with the default setup of our ASP.NET MVC project. That is the default routing and there is no need for extra configuration. If we leave the routing by default the routes would look like this:
* website(localhost)/ControllerName/ActionName
* website(localhost)/ControllerName/ActionName/ExtraParameter

Keep in mind that the name of the controller should be written without the Controller suffix. If we want to add custom routes we can do that in two ways: By changing the router or by adding routing attributes to our action or controller depending on what we need to customize and change.
### The Router 🔽
The router can be found in **StartUp.cs** in the **Configure** method.
```csharp
app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");
});
```
There we can find the default settings for our router, the order in which the routes are accessed and the default values for the controller and action. There is also an id? parameter. The question mark indicates that this parameter is optional. We can also add new routes in the router. The default one is localhost:port/Home/Index and will be hit if we type that address or write the name of the page ( localhost:port ). The custom routes will have to be accessed by whatever we have in our template.
```csharp
app.UseMvc(routes =>
{
	// This route will be accessed through these addresses:
	// localhost:port ( default )
	// localhost:port/anyControllerName/anyActionFromThatController
	// localhost:port/anyControllerName/anyActionFromThatController/someParameter
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");
    // This is a custom route called orders and will be accessed through:
    // localhost:port/orders
    routes.MapRoute(
        name: "orders",
        template: "orders",
        defaults: new { controller = "Order", action = "Index" });
});
```
### Routing Attributes 🔽
Routing can be done with routing attributes as well. Attributes are rules that we add in **[ ]** brackets above methods or classes ( actions and controllers in our case ). With these routing attributes we can change and override the routing at the exact point where we need a custom route. This means that we can create custom route for a particular controller or an action by just annotating above that controller or action what the new route would be. We can do this with the **Route** annotation:
```csharp
// Custom route for the controller. Action names stay the same
[Route("App/[Action]")]
public class HomeController : Controller
{
    public IActionResult Index() // localhost:port/app/index
    {
        return View();
    }
    public IActionResult Contact() // localhost:port/app/contact
    {
        return View();
    }
}
```
```csharp
[Route("App")]
public class HomeController : Controller
{
    [Route("Start")]
    public IActionResult Index() // localhost:port/app/start
    {
        return View();
    }
    [Route("CallMe")]
    public IActionResult Contact() // localhost:port/app/callme
    {
        return View();
    }
}
```
A good thing to mention is that if we leave the route of the controller, but add custom routes to the actions, the actions can be accessed directly without typing the name of the controller in the address
```csharp
public class HomeController : Controller
{
    [Route("Start")]
    public IActionResult Index() // localhost:port/start
    {
        return View();
    }
    [Route("CallMe/Now")]
    public IActionResult Contact() // localhost:port/callme/now
    {
        return View();
    }
}
```
We can also create custom roots for actions by combining the **HttpGet** attribute and the **Route** attribute:
```csharp
[Route("App")]
public class HomeController : Controller
{
    [HttpGet("Start")]
    public IActionResult Index() // localhost:port/app/start
    {
        return View();
    }
    [HttpGet("CallMe")]
    public IActionResult Contact() // localhost:port/app/callme
    {
        return View();
    }
}
```
```csharp
public class HomeController : Controller
{
    [HttpGet("Start")]
    public IActionResult Index() // localhost:port/start
    {
        return View();
    }
    [HttpGet("CallMe")]
    public IActionResult Contact() // localhost:port/callme
    {
        return View();
    }
}
```
### Routing with extra paramters 🔽
As we can tell from the default router of an ASP.NET Core MVC application, we can access an action by writing the controller name first and then the action name. But we can add an extra parameter as well. This is optional. To use this optional parameter we need to create an action first that accepts a parameter to begin with. This is because C# as a language sees methods with same names but different parameters as different methods. This is why our method that does not wait for anything ( does not have a parameter ) can't catch the requests from the address when we pass in an extra parameter. 
```csharp
// id will get the number from the address ( 12 )
public IActionResult Contact(int? id) // localhost:port/home/contact/12
{
	return View();
}
```

# Views part 2 🍰
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
## Extra Materials 📘
* [Deep Dive in ASP.NET Core Routing](https://stormpath.com/blog/routing-in-asp-net-core)
* [ASP.NET Core MVC and Controllers](https://www.youtube.com/watch?v=2n7keI_E8tE)
* [Posting data from html to mvc core controller](https://jonhilton.net/2017/08/17/how-to-get-data-from-an-html-form-to-your-asp.net-mvc-core-controller/)
* [Good article on HTML Helpers](https://www.c-sharpcorner.com/article/html-helpers-in-Asp-Net-mvc/)