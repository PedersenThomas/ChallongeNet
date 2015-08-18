ChallongeNet
============
# This project will have major breaking changes down the line.

Incomplete API wrapper for Challonge.com v1

## Example

### Create Tournament
```c#
var challonge = new Challonge("USERNAME", "APIKEY");
var Tournament = challonge.TournamentCreate("MyTournamentName", TournamentType.SingleElimination, "MyTournamentUrl");
```

## UnitTests
In order to run the tests is it necessary to first enter your credentials in the testprojects settings files.
In visual studio:

1. Right click testproject and click "Properties"
2. Navigate to the settings tab
3. Enter your credentials
