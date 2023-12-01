# QuizApp Readme

## Overview

Welcome to QuizApp, a versatile quiz application built on the ASP.NET Blazor WebAssembly (hosted) framework, utilizing .NET 7. This project was developed as a school assignment to meet specific requirements, outlined below:

## School Assignment Requirements

1. **Quiz Creation:**
   - Users can create quizzes.
   - Each quiz has a title.

2. **Question Structure:**
   - A quiz can have any number of questions.
   - Each question has an image or video and accompanying text uploaded or created by the user (quiz creator can choose image or video for each question, supporting both).

3. **Question Options:**
   - Questions may have a time limit to answer (set by the creator of the quiz).
   - The answer to the question can be multiple-choice or free text (set by the creator of the quiz).

4. **Quiz Accessibility:**
   - It should be possible to link directly to a quiz.

5. **Quiz Management:**
   - Users can see a list of quizzes they have created.
   - Users can see which other users answered their quiz and view the corresponding points.

6. **Quiz Participation:**
   - Users must be able to answer a quiz they received a link to.

## Technology Stack

- **ASP.NET Blazor WebAssembly:**
  - A modern, single-page application (SPA) framework for building interactive web applications.

- **.NET 7:**
  - The latest version of the .NET platform, offering performance improvements and new features.

- **Entity Framework Core:**
  - A lightweight, extensible, and cross-platform Object-Relational Mapping (ORM) framework for .NET.

- **Database:**
  - Configured with a connection string to interact seamlessly with the chosen database.

- **API Controllers:**
  - Utilized for CRUD operations, providing a structured way to handle data on the server.

- **Bootstrap:**
  - Used for styling and responsiveness on both the client and server sides.

## Database ER-model

The relationships between entities are as following:
- One user has many quizzes,
- One quiz has one user and many questions,
- One question has one quiz
- Then there is a Scoretable that has a LinkId (publicId, also using this in the URL) to a quiz,
  the score table also contains the UserId, Correct answers and AuthorId (original creator of quiz).

### Below is a picture of the ER-model
![QuizApp-ER-Model](https://github.com/Danilo-Acosta5389/QuizAppBlazor/assets/113366808/b5fcc15b-b403-45c5-be0a-0746aea2cd24)


## NuGet Packages

### Client Side:

- **Microsoft.AspNetCore.Components.WebAssembly (7.0.11)**
- **Microsoft.AspNetCore.Components.WebAssembly.Authentication (7.0.11)**
- **Microsoft.AspNetCore.Components.WebAssembly.DevServer (7.0.11)**
- **Microsoft.Extensions.Http (7.0.0)**

### Server Side:

- **Microsoft.AspNetCore.ApiAuthorization.IdentityServer (7.0.11)**
- **Microsoft.AspNetCore.Components.WebAssembly.Server (7.0.11)**
- **Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore (7.0.11)**
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore (7.0.12)**
- **Microsoft.AspNetCore.Identity.UI (7.0.12)**
- **Microsoft.EntityFrameworkCore.Sqlite (7.0.12)**
- **Microsoft.EntityFrameworkCore.SqlServer (7.0.12)**
- **Microsoft.EntityFrameworkCore.Tools (7.0.12)**
- **Microsoft.VisualStudio.Web.CodeGeneration.Design (7.0.11)**

Note: Some of these packages are default, while others, especially the ones related to Identity and Entity Framework Core, may require user installation.

## How to Use

1. **Installation:**
   - Clone the repository to your local machine.
   - Ensure you have the necessary NuGet packages installed.

2. **Configuration:**
   - Set up your database connection.
   - The connectionString is .gitignored, you may handle this any way you wish, 
        but if you want to do it like me, follow these steps: 
        - create a new class file in the root directory of the server project, name it CString.cs.
        - Make sure the class is public and input your connection string in a string property field called connectionString.
        - That's it.
```C#

namespace QuizAppBlazor.Server
{
    public class CString
    {
        public static string connectionString = "[your conectionString goes here]";
    }
}

```
   - Configure any necessary environment variables, if necessary.

3. **Run the App:**
   - Launch the QuizApp application.
   - Access the app through your preferred web browser.

4. **Usage:**
   - Register or log in as a user.
   - No actual e-mail adress is required upon registratioin, just make one up.
   - Password must be 6 characters and does not require numbers or special characters.
   - Create quizzes according to the specified requirements.
   - Share quiz links with others.
   - Manage and view quiz statistics on the profile page.


### Additional

It is unlikely i will work any further on this project.
however, if i would, here are some thigs i would consider doing:

- Edit and delete functionality.
- More statistics, like:
    - user score on all quizzes,
    - user score on quizzes made by others,
    - user with the highest score,
    - and perhaps time stamp.
    - perhaps latest quiz played aswell...
- Profile info,
    - display nickname,
    - profile picture,
    - total score,
    - link to profile
- On server side:
    - tighter security,
    - better design pattern
- On client side:
    - more use of components,
    - C# code should go as a subfile to the razor page
    - CSS should too ^.
 
There are a lot of things that could be done better. It was definitely a fun project. I would like to continue improving it, but if don't, that's all right. :)


### Some pictures of the app
![Skärmbild 2023-12-01 035012](https://github.com/Danilo-Acosta5389/QuizAppBlazor/assets/113366808/bd354223-56d3-4412-bfd3-181ddfdd189f)
![Skärmbild 2023-12-01 035154](https://github.com/Danilo-Acosta5389/QuizAppBlazor/assets/113366808/37ec3c46-759d-4db4-aadc-d0db5d3c1447)
![Skärmbild 2023-12-01 034914](https://github.com/Danilo-Acosta5389/QuizAppBlazor/assets/113366808/ec888baa-ffe3-459d-8925-e72535206ab7)
![Skärmbild 2023-12-01 035358](https://github.com/Danilo-Acosta5389/QuizAppBlazor/assets/113366808/80133966-d82a-4b8d-b881-9c3a66e9a422)


https://github.com/Danilo-Acosta5389/QuizAppBlazor/assets/113366808/b44b2056-4201-4dad-a1b6-081b8cd391af



![Skärmbild 2023-12-01 041236](https://github.com/Danilo-Acosta5389/QuizAppBlazor/assets/113366808/16e03ea1-6b6f-4790-8d23-af42bc10ad2f)

