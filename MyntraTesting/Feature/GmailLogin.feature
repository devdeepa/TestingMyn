Feature: Linkedin
In order to check posts
As a user
I want to login

@LoginTest
Scenario: Logging in Linkedin
Given I go to "Linkedurl" on "<Browser>"
When  I enter "UserName_id" as "<Username>"
And I enter "Password_name" as "<Password>"
When I click on "LoginBtn_class"
Then login should be "<ExpectedResult>"


Examples:
| Browser | Username                | Password      | ExpectedResult |
| Mozilla | chopade.deepak@yahoo.in | Gurudatt@1359 | Success        |