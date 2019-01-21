param
(
  $token
)

$ver = (gci "$env:userprofile\.nuget\packages\codecov").Name
$cmd = "$env:userprofile\.nuget\packages\codecov\$ver\tools\codecov.exe";
$fName = ".\Home.OAuthClients.Tests\coverage.opencover.xml";
$arg1 = "-f ""$fName""";
$arg2 = "-t $token";
& $cmd $arg1 $arg2

$fName = ".\Home.TodoistClient.Tests\coverage.opencover.xml";
$arg1 = "-f ""$fName""";
& $cmd $arg1 $arg2