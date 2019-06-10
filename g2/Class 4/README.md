# Routing 🚪

## What is Routing 🔹
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

## Extra Materials 📘
* [Routing in MVC](https://www.tutorialsteacher.com/mvc/routing-in-mvc)
* [Attribute Routing in ASP.NET MVC 5](https://devblogs.microsoft.com/aspnet/attribute-routing-in-asp-net-mvc-5/)
