# Lab14, Lab15, Lab16-Intro to Entity Framework, Entity Framework and Seeding, Dependaency Injection
Repository for my first EF core application - a mock implementation of an asset management system for a hotel chain called "Async Inn".

#### Requirements
For part four, this site must include:
1.Add a layout that will be inherited/utilized on all of your pages (if you haven’t already).
1.Implement a “search box” or filter on all of your model landing pages (Hotels, Rooms, and Amenities)
1.Allow the functionality on your HotelController to display all the possible hotels, as well as the number of Rooms that each hotel has.
1.Allow the functionality in your RoomController to see the number of Amenities that each room has
1.At the top of all 3 of your base controllers (Hotel, Room, Amenities) include a total count of the asset. For instance, if you have a total of 5 Hotels, the top of your Hotel home page should say that you have 5 total hotels in the system.

For part three, this site must include:
1. 3 new interfaces
2. All services registered in your Startup.cs class
3. 3 new “services” that implement each of the interfaces
4. DbContext injected into each of the interfaces
5. Your interfaces injected into your controllers
6. Functionality of all Create and Index actions
7. Functionality of the Edit and Delete actions in your Hotels Rooms and Amenities pages.

For part two, this site must include:
1. Data annotations to your existing models to validate basic user input fields as appropriate.
2. Seed your database with at least:
	-- 5 default Hotel Locations
	-- 6 Room Types
	-- 5 Amenities.
3. Do not make any seeded associations with HotelRoom or RoomAmenities.
4. Update the dropdown lists to include the Layout enum, and associations between the Room and Hotel, as well as the Room and Amenities. Be sure to display user friendly information in your views (example: display string names instead of ids).
5. Based off of the readings from day 14, either utilize bootstrap (download it into your project from NuGet), or remove all bootstrap specific classes in your HTML. (clean it up!)
6. Add your own styling to the Hotel creation page, Room Creation Page, and Amenities creation page.
7. On the Home Page, create a navigation to the “Create Hotel” page, “Create Room” page, “Create Amenity” page, as well as pages for the “HotelRoom” association and “RoomAmenity” association. Each of these pages (excluding HotelRoom and Room Amenity (see below)) should allow the user to edit/remove existing data. All pages should allow to view the data.

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
