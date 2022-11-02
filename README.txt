﻿Programmer name: Luis Rodriguez
Program purpose: To make a web app that showcases different books from vice city Miami
Program start: 25 10 2022 1115
Program end:
Last edited: 11/1/2022


25 10 2022 1120

Starting project beginning with the set up



25 10 2022 1134

configuring my project adding name: LuisBookStore
adding location: into my desktop
solution name will be the same as my project name


25 10 2022 1147
anabling razore runtime and checking off individual accounts
creating project after checking off individual accounts and choosing asp.net core web app (mvc)
project is finally being created.

25 10 2022 1156

commenting out the ssl in the json file under properties
following the tutorial, looking at the controllers , models, and views.

25 10 2022 1210

taking out the context in the parenthesis () in identity user under startup.cs



26 10 2022 1503


adding

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

{

if (env.IsDevelopment())

{

app.UseDeveloperExceptionPage();

app.UseMigrationsEndPoint();

}

else

{

app.UseExceptionHandler("/Home/Error");

// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

app.UseHsts();

}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>

{

endpoints.MapControllerRoute(

name: "default",

pattern: "{controller=Home}/{action=Index}/{id?}");

endpoints.MapRazorPages();

});

}


26 10 2022  1603

replacing things in the start up file.

Using quartz for my bootstrap

https://getbootstrap.com/docs/4.0/components/navbar/

28 10 2022 1040

to wwwroot > replace the existing bootstrap.css found in:
lib > bootstrap > dist > css

to wwwroot > replace the existing site.css file found in the main css folder
to Views > Shared > _Layout.cshtml, change the file name from bootstrap.min.css to bootstrap.css
Change the nav class from navbar-light to navbar dark and bg-white to bg-primary
Line 23 - remove text-dark
Add additional properties to the footer class

took out all dark text and added white text and then went to footer and adjusted its properties. with white text and background being the primary as the nav bar bootstrap

29 10 2022  1141

I will now begin and add 3 new projects 

29 10 2022 1150

having trouble adding the new projects looking at all the selections and cant find one to match the tutorial .....

2 11 2022 0945

FINALLY !  found the right projects to use that matches the tutorial just looked up in the search box for c# libraries.


2 11 2022 1044

copied data folder and added it to the LuisBooks.DataAccess project I then deleted the original.

2 11 2022 1100

Having trouble finding out where to find the packages to install


2 11 2022 1109

Found out how to install the packages go to project then manage nuget packages and there I searched for the microsoft.entityframeworkCore.Relational
and core.sqlserver packages.

YES !  I downloaded both and got it work out.

2 11 2022 1111

Next I will be deleting the migrations from the data folder in the DataAccess project.

2 11 2022 1117

Installed nuget pack : identity.EntityFramework core
modified the namespace to reflect my project.

2 11 1124

Move models in to LuisBooks.Models and deleted original

2 11 1125

Modified views > shared > error.cshtml 

2 11 1126

I then went into the project LuisBookStore add project reference - .dataaccess and .models checked off.

WOW!  all errors are now gone :)

2 11 1129

renamed models folder to viewmodels
changed the errorviewmodels.cs namespace to .models.viewmodels

2 11 2022 1151

Having a hard time with the error.cshtml renaming the namespace at the top @model....


2 11 2022 1200

Figured it out!!!  @model LuisBookStore.Models.ViewModels.ErrorViewModel
@{

2 11 2022 1201

4 more errors to knock out!

2 11 2022 1456

having a hard time getting the website to load finding out what I can do 

2 11 2022 1530

Got the website to run finally after hours and hours... wow I had to comment out the ssl for this new project.

// ssl

2 11 2022 1540

Move models into Luis.Books.Models and deleted original

2 11 2022 1541

modifeid views > shared > error.cshtml

2 11 2022 1544

Project - add - project reference - .data access and .models
renamed


2 11 2022 1546

Modified Startup.cs service ‘AddContext’ with the using statement


2 11 2022 1555
Ran the application and reviewed errors.

Removed the using statement

2 11 2022 1603
Corrected any default reference to ErrorViewModel to the new .Models.ViewModels.ErrorViewModels

When all errors are resolved run the application and review the browser presentation.

2 11 2022 1609

the Utility project, created a static details class called SD.cs
Modified the properties of the class

2 11 2022 1616

Added project reference to the main project
the DataAccess project add project references t o Models and Utility


