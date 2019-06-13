# Controllers 🍪
Controllers in ASP.NET MVC are simply classes with methods (Actions) that represent the end-points or points from or to where we want to send data. The controller class you create must always inherit from an existing controller class from the asp.net framework and it must always be in a folder called controllers. We can always create our own class and inherit from the correct ASP.NET class and create the methods on our own, but Visual studio makes it easy for us by giving us an option to create a preset controller. This is done by right clicking on the **Controllers** folder -> Add -> Controller and choosing the MVC Empty template. Controllers are named with PascalCase and they ALWAYS HAVE **Controller** at the end. If they are not named in this way, the application might not work as intended.
#### Simple controller
```csharp
public class HomeController : Controller // Must inherit from Controller
{
	// A method ( Action )
    public IActionResult Index() // localhost:port/home/index
    {
        return View(); // When it is called it returns a view
    }
}
```
## Actions 🔹
Actions are basically the methods that we have in the controller. Actions are the main source of interaction in and out of the controller. Every action has an address and when that address is called, the action is executed. With this the action can execute some code and return a view or a view with some result in it. The actions can be annotated depending on the request they are waiting for. This means that we can have actions that wait for a GET request, POST request etc. In ASP.NET Core MVC applications if we don't annotate our actions, they are by default GET. If we want to explicitly mark an action with what kind of request it waits we can use the [HttpXXX] attribute. Ex: GET -> [HttpGet]
```csharp
public class HomeController : Controller
{
	[HttpGet]
    public IActionResult Index() // localhost:port/home/index
    {
        return View();
    }
}
```
### Views 🔽
An action can return a view. This means that if someone were to access the address of that action through the browser, they will get an HTML page back. Attaching a view to an action can be done by creating a folder with the controller name in the **Views** folder and inside create a file the same name as the action. Ex:
* we have **HomeController** and inside **Index** action
* we create **Home** folder in the **Views** folder and inside that folder we create a view called **Index**

That was the manual approach. Visual Studio offers a shorter and automatic way of doing this. If we click right click on the action it self ( the line of code where we declare it ) there is an option **Add View**. If we click that and click **OK** it will automatically create the folder structure if it does not exist and create the view with some default html. If we don't want to return a view by the same name as the action we can always pass a name (string) and tell the Action Result what view to return from that controller folder.
### Action Result🔽
The results that the action gives back to the browser whether it is a view or some other type of result is always packaged in an Action Result. That is why the controller returns IActionResult meaning it will return some action that inherits from IActionResult interface. There are multiple actions that we can return. Some of them are:
* ViewResult - A result used when we want to return some view
```csharp
// Empty View() will get the view corresponding with this action ( Index )
public IActionResult Index()
{
	return View(); // return type: ViewResult
}
```
```csharp
// A string parameter will return a view by that name from that controller
public IActionResult Index()
{
    return View("Home"); // return type: ViewResult
}
```
* EmptyResult - A result representing an empty result ( When we don't want to return anything but the browser expects a response )
```csharp
public IActionResult Alert()
{
    // Code that alerts someone
    return new EmptyResult(); // return type: EmptyResult
}
```
* RedirectResult - A result that redirects us on the browser to another action
```csharp
// RedirectToAction accepts an action name (string) and redirects to that action from the same controller
public IActionResult Order(int? id) 
{
	// Return type must be IActionResult to cover both return types
    if (id.HasValue) return View(); // return type: ViewResult
    return RedirectToAction("Index"); // return type: RedirectToActionResult
}
```
```csharp
// RedirectToAction accepts an action name(string) and a controller name(string) and redirects to that action from that controller
public IActionResult Order(int? id)
{
	// Return type must be IActionResult to cover both return types
    if (id.HasValue) return View(); // return type: ViewResult
    return RedirectToAction("Index", "Orders"); // return type: RedirectToActionResult
}
```
* JsonResult - A result containing a JSON string
```csharp
// JsonResult accepts an object, converts it to json automatically and returns it
public IActionResult OrderData()
{
    var order = new { Id = 12, IsDelivered = false }; // Dummy Order
    return new JsonResult(order); // return type: JsonResult
}
```
![How a Controller works](https://github.com/sedc-codecademy/sedc7-08-aspnetmvc/blob/master/g1/Class%202/img/class21.png?raw=true)
## Extra Materials 📘
* [ASP.NET Core Action Results In Depth](http://hamidmosalla.com/2017/03/29/asp-net-core-action-results-explained/)
