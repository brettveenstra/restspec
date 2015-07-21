Feature: BigHugeThesaurus
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: JSON response from Big Huge Labs Thesaurus API
	Given I specify an accept header of 'text/html'
	And I specify an accept header of '*/*'
	And I specify an accept encoding header of 'gzip'
	When I issue a 'GET' request to '/apisample.php?v=2&format=json'
	Then the result should be '200'
	And the response content encoding header should contain 'gzip'
	And the response content type header should be 'text/plain'
	And the response should be 'gzip' compressed
