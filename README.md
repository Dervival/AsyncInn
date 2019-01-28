# Lab11-Intro to Entity Framework
Repository for my first EF core application - a mock implementation of an asset management system for a hotel chain called "Async Inn".

#### Requirements
For part one, this site must include:
1. Startup File
	-- Explicit routing of MVC
	-- MVC dependency in ConfigureServices
	-- DBContext registered in ConfigureServices
	-- Use of static files accepted
2. Controller
	-- Home Controller
	-- Controllers for each of the pages described in the Design section (you do not have to scaffold if you don’t want to)
3. Data
	-- DBContext present and properly configured
	-- DB Tables for each entity model (DbSet<T>)
	-- Composite key association present in OnModelCreating override.
	-- appsettings.json file present with name of database updated
4. Models
	-- Each Entity from the DB Table converted into a Model
	-- Proper naming conventions of Primary keys, or utilization of the [Key] data annotation
	-- Navigation properties present in each Model where required
	-- Enum present in appropriate model
5. Views
	-- View for home page that matches default routing
6. Home Page
	-- stylesheet present in web application
	-- stylesheet referenced on home page.
7. Web application should build, compile, and redirect us to the home page upon launch. Scaffoldded controllers should be accessible through their default actions.

#### Setup/Running instructions
- Clone or download this repository into a folder of your choice.
- Open up the solution file in an IDE of your choice, preferably Visual Studio
- In the dropdown menu under the build button (top of the screen in the ribbon, second row, near the center, with the green triangle), make sure IIS express is selected.
- Click the build button, or hit F5.
- A page should launch, redirecting you to the home page of the asset management systems.
- The home page will display five links directing you to pages to manage hotel locations, room configurations, rooms in specific hotels, all amenities available, and amentities available in each room.
- Click on one of those links. An empty table should display, as well as an option to add a new entry.
- Click on the link below the table to return back to the home page.

#### Sample inputs:
- No inputs required at this stage.

#### Sample outputs:
- A basic MVC scaffold for an asset management system website, with links to related tables

#### Screen captures:
- ![Schema used for this project](https://github.com/Dervival/AsyncInn/blob/master/SchemaAsyncInn.PNG);
- ![Home page](https://github.com/Dervival/Lab11-IntroToMVC/blob/master/Home.PNG);
- ![Hotels page](https://github.com/Dervival/Lab11-IntroToMVC/blob/master/Hotel.PNG);
- ![Room configurations page](https://github.com/Dervival/Lab11-IntroToMVC/blob/master/RoomConfigs.PNG);
- ![Hotel room page](https://github.com/Dervival/Lab11-IntroToMVC/blob/master/HotelRooms.PNG);
- ![Amenities page](https://github.com/Dervival/Lab11-IntroToMVC/blob/master/Amenities.PNG);
- ![Room Amenities page](https://github.com/Dervival/Lab11-IntroToMVC/blob/master/RoomAmentities.PNG);
