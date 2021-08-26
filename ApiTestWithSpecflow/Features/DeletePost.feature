Feature: DeletePost
	Test post deleting functionality

@mytag
Scenario: Verify no post with id exists after deleting this post
	Given I perform DELETE operation for "posts" and id - "7"
	When  The response status code "OK"
	Then No records for "posts" with id "7" exists