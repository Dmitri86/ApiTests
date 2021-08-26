Feature: PostNewPost
Test POST new post operation

    @mytag
    Scenario: Verify response status code after posting new post is Created
        Given I perform POST operation for "posts"
        Then The response status code "Created"

    @mytag
    Scenario: Verify new post add after perform POST operation
        Given I perform POST operation for "posts" with parameters title "Automation's Avengers" and "Broken Arrow"
        When  The response status code "Created"
        Then Last record for "posts" has title - "Automation's Avengers" and author - "Broken Arrow"