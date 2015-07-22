Feature: BigHugeThesaurus
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: JSON response from Big Huge Labs Thesaurus API
	Given an accept header of 'text/html, */*'
	And an accept encoding header of 'gzip, deflate'
	When I issue a 'GET' request to '/apisample.php?v=2&format=json'
	Then the status code should be '200'
	And the content encoding header should contain 'gzip'
	And the content type header should be 'text/plain'
	And the response should be 'gzip' compressed

Scenario: JSON response from Big Huge Labs Thesaurus API absolute URL
	Given an accept header of 'text/html, */*'
	And an accept encoding header of 'gzip, deflate'
	When I issue a 'GET' request to 'http://words.bighugelabs.com/apisample.php?v=2&format=json'
	Then the status code should be '200'
	And the content encoding header should contain 'gzip'
	And the content type header should be 'text/plain'
	And the response should be 'gzip' compressed
