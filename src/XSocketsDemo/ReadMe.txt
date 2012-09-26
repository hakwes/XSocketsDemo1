A log over the steps taken building this example.
The small notes I´ve written is nothing to care about, just small notes about how I ususally do this.

Pre Req;
Do run this you will need VS 2010 & SqlExpress

#############################################
# SETUP
#############################################
1:	Created a new MVC3 project in VS 2010

2:	Installed XSockets by opening PackageManagerConsole and running
		"Install-Package XSockets"
	
		This gave us two new projects in the solution.
		- XSocketHandler for writing XSockets plugins.
		- DevServer for being able to debug the plugins.

#############################################
# CREATE BACKEND
#############################################
3:	Created a new project for the Model and named it XSocketsDemo.Core
		Note: I usually use Repository Patterns and Unit Of Work, but for this to be simple we go right to the Context of EF

		3.1: Added a simple domainmodel to Core (Person, Color, Fruit)

4:	Created a new Project for EF and named it XSocketsDemo.Data
		Note: this would usually be the repository pattern, and then I would also use a Service project to protect Data from being exposed

		4.1: Added DataContext and DataSeeder classes
			Note:	This will create a database on the local sqlexpress, if you want to use a connectionstring
					add a connectstring with key XSocketsDemo.Data.EfContext and that connection will be used.
					If you use a connectionstring the user will have to have permission to do all EF stuff!

5:	Added references (XSocketsDemo.Core, XSocketsDemo.Data) to the XSocketsDemo (the webproject) since this is the process starting the XSockets server.
		Important:	This is easy so forget, you will not get any compilation errors if not referencing.. But you will get
					runtime errors when the plugin framework cant detect the Core/Data assemblies.

#############################################
# CREATE A REALTIME CONTROLLER (XSOCKETS)
#############################################
6:	Created a new XSocketHandler by scaffolding by running the line below in PackageManagerConsole
		Scaffold XSocketHandler DemoController

#############################################
# BUIDLING LOGIC IN THE CONTROLLER
#############################################
7:	Setting up basic stuff...
		7.1:	Created a Commands class for avoiding hard coded strings
		7.2:	Created partial class of DemoController for Person events
		7.3:	Created ViewModels for the EF model for sending as JSON (avoiding circular references)

8:	Implementing CRUD for Person class in DemoController.People

#############################################
# SETTING UP UX (WebProject)
#############################################
9:	Installed Twitter Bootstrap for nice looks

10: Installed knockoutjs

#############################################
# BUIDLING LOGIC IN THE UI
#############################################
11:	The MVC view Demo/Index will be used as a single page application

12:	Starting by listing all people in the default view

13:	Added ViewModel and Commands... Setting up XSockets publish/subscribe events

14:	Added Creating Person (both in plugin and in GUI)

15:	Added Deleting Person (both in plugin and in GUI)

16:	Added Edit/Update Person (both in plugin and in GUI)

#############################################
# ADDING WIJMO CHARTS
#############################################
17: Added references to wijmos knockoutjs stuff

18: Created 4 different charts...
	18.1:	Sorry, only had time for 1 type of chart :(	

#############################################
# ADDING LONGRUNNING PLUGIN/CONTROLLER
#############################################
19:	To get a better feeling of how it can look I added a longrunning plugin called LongRunningDemo ;)
	This one changes values in the EF randomly and then send the changes to the clients....
	This way you can see how several windows gets updated but you dont have to click around yourself.
	It´s set to tick at 8 sec right now...

This Demo was written in about 8 hours (included 4.5 liters of coffe) ;)
Obviously this is just a proof of concept and there is lots of stuff to fix in a "real" application

Regards

Uffe, Team XSockets.
@ulfbjo on Twitter