# Homework
In the Pizza Hut project from class: 
* Finish the controller for User model.
* Create crud operation for User in UserRepository using already created AppDbContext.

 **Bonus** Create new PizzaDbContext class that will and replace the current AppDbContext 

## AspNet Core Add DbContext

* Add class AppDbContext + DB sets.
```
		public AppDbContext(DbContextOptions<AppDbContext> options) 
			: base(options)
		{
		}
		public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaType> PizzaTypes { get; set; }
	...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PizzaType>().HasData(
                new PizzaType { ID = 1, Name = "Capri", Description = "dough, ham, mashrums" },
                new PizzaType { ID = 2, Name = "Quatro", Description = "dough, cheese, mashrums" },
                new PizzaType { ID = 3, Name = "Vege", Description = "dough, vegetables, mashrums" }
                );
        }
```
* Create SQL repository class and add the DB context inside.
```
		private readonly AppDbContext _context;
        public SQLPizzaRepository(AppDbContext context)
        {
            _context = context;
        }
```
* Add record in the appsettings.json config file.
```
"ConnectionStrings": {
			"PizzaDbConnection": "server = (localdb)\\MSSQLlocalDB; database=PizzaDB"
		  }	
```

* Register the SQL repository
```
services.AddDbContextPool<AppDbContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("PizzaDbConnection")));
	
services.AddScoped<IPizzaRepository, SQLPizzaRepository>();
```

* Add migrations
 ```
 Add-Migration CreateDB
Update-Database
 ```
