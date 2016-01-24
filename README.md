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
    -Home page - list all projects. On click - the project details are shown on separate page (available only for logged in users)
    -  Freelancer page - list all freelancers. On click - the freelancer profile is shown including the average freelancer rating and the comments of the freelancer given by the different employers (Freelancer Details)
   - Employer page -  list all employers. Only if the user is logged in the user can see details about the employer(company)
    - (Private part) if the user is logged in a button "Hire" is shown on the freelancer profile page and the employer hires the freelancer for a specific project. This happens on a separate page where the employer chooses the project(all projects of the employer are shown) and adds the freelancer to it
2. Private part:
a) Freelancer 
    - has access to his/her profile. Can change his/her profile information
    (The freelancer profile is the user profile which is different from the freelancer page in the public part)
    - can give rating and comments about another freelancer
b) Employer 
    -  has access to his/her profile. Can change his/her profile information
    - can give rating and comments about the freelancer
    -  can publish new project (Add project page)
 * The rating and the comment controls are shown on the freelancer profile only if the user is logged in.
3. Admin
   - can delete employer/freelancer/comments from the system
   - can add country/ tag/ category to the system

* Ако някой иска да се регистрира преди да се покаже формата за рефгистрацуя да се покаже пръво друга форма, в която user да избере дали да се регистрира като employer или freelancer. В зависимост от посочения избор да се извика custom page, където освен email и password да се покажат останалите полета!




