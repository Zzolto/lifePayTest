Feature: Login

@LoginTest
Scenario: Successful Login
	Given the user is on the login page
	When the user enters valid credentials
	And the user clicks the 'Login' button
	Then the user is successfully logged in
