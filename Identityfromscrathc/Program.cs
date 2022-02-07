var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";  // koláèiky ktoré mi zabezpeèia prihlásenie :)
    options.AccessDeniedPath = "/Account/AccessDenied";
});
builder.Services.AddAuthorization(options => {
      options.AddPolicy("MustBelongToHRDepartment", 
          policy => policy.RequireClaim("Department", "HR"));
    options.AddPolicy("AdminOnly",
        policy => policy.RequireClaim("admin"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
