# Katana Team / Telerik Academy 2016#
A repository containing our teamwork project for the course "ASP.NET Web Forms" 2016 @ TelerikAcademy

----------
## Requirements
The requirements for the project can be found [here](./Requirements.md).

##Contributors

* Boyana Tsvetkova ([TelerikAcademy](https://telerikacademy.com/Users/bo071992), [GitHub](https://github.com/boyanatsvetkova))
* Daniela Simeonova ([TelerikAcademy](https://telerikacademy.com/Users/danisio), [GitHub](https://github.com/danisio))
* Pavlina Dragneva ([TelerikAcademy](https://telerikacademy.com/Users/DragnevaPavlina), [GitHub](https://github.com/PavDragneva))

## Documentation
The documentation can be found [here](Documentation/Documentation.md).

1. Public part 
    -Home page - all top 10 projects and freelancers are shown. Statistics about the site participann are also available. On click - the project details are shown on separate page (available only for logged in users)
    -  Freelancers page - list all freelancers. On click - the freelancer profile is shown including the average freelancer rating and 
adding of rating and comment for the given freelancer is available
    - Projects page = all available projects in the system
   - Employer page -  list all employers. Only if the user is logged in the user can see details about the employer(company)    - (Private part) if the user is logged in a button "Hire" is shown on the freelancer profile page and the employer hires the freelancer for a specific project. This happens on a separate page where the employer chooses the project(all projects of the employer are shown) and adds the freelancer to it
2. Private part:
a) Freelancer 
    - has access to his/her profile. Can change his/her profile information
    (The freelancer profile is the user profile which is different from the freelancer page in the public part)
    - can view the projects they are part from
b) Employer 
    -  has access to his/her profile. Can change his/her profile information
    - can give rating and comments about the freelancer
    -  can publish new project (Add project page) and view his/her own projects and project details
 * The rating and the comment controls are shown on the freelancer profile only if the user is logged in.
3. Admin
   - can delete employer/freelancer/comments/projects/country/country from the system
   - can add country/category to the system
4. All input field have client-side and server-side validation and appropriate error or success messages are displayed to the user
5. AJAX with Update panel is implemented in several pages
6. File upload of a user picture is available
7. GridView like controls such as ListView, GridView and FormView are used to present data
8. Master page with SiteMap navigation are implemented
9. Registration of users in different roles is also available
10. A couple of ASCX user controls are present in the project
11. Statistics on the Home page is cached
12. Preventing XSS attacks is implemented 




