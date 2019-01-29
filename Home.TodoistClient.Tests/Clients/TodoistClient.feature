Feature: TodoistClient
	To have a helpful c# client wrapper around the Todoist API

@mytag
Scenario: Full Sync
	Given I have a Mocked TodoistClient
	And My Client can respond to a basic Sync
	When I execute a full sync
	Then I recieve a valid full sync response
	And My sync response contains data

Scenario: Test Command
	Given I have a Mocked TodoistClient
	And My Client can respond to a basic Command
	When I execute a command
	Then I recieve a valid command response
	And My command response is populated