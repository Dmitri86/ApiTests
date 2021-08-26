Feature: GetPost
	Test GET posts operation

@mytag
Scenario: Verify author of the post 1
	Given I perform GET operation for "posts/{postid}" 
	And I perform operation "postid" for post "1"
	Then I should see the "author" name as "typicode"