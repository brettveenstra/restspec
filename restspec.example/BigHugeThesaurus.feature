Feature: BigHugeThesaurus
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: JSON response from Big Huge Labs Thesaurus API
	When I issue a 'GET' request to '/apisample.php?v=2&format=json'
	Then the result should be '200'
	And the response should be valid JSON
