$baseUrl = "http://localhost:8080/Web"

# Randomize the order of the users
$users = @("eh13hd10102", "eirji41a1a3", "n1312uheeef", "8csondp1d1d5", "3nj13bbbb8", "usdfuh823a109", "ej14a4e", "wdj1e0febec", "dsjkfdsf213e0df", "123423dwe1e8", "0k01kfka7aa", "2dkwd0k1303a", "dkowdsk100a", "00owo30100", "kxsak01aab6", "kadsd0k10002", "z10I3414bfd0", "dwqerqw-er1a1a0", "d1d14334e2af")
$users = $users | Sort-Object { Get-Random }

# Randomize the order of the URLs
$urls = @("{0}", "{0}/healthcheck.aspx", "{0}/Home/About", ,"{0}/Home/Contact", "{0}/{1}/devices", "{0}/{1}/devices", "{0}/{1}/devices", "{0}/{1}/{2}/status", "{0}/{1}/{2}/status", "{0}/{1}/{2}/updatesettings", "{0}/{1}/{2}/settings")
$urls = $urls | Sort-Object { Get-Random }

Write-Host "Test"

while($true)
{
	foreach($user in $users)
	{
		foreach($url in $urls)
		{
			$test = [string]::Format($url,$baseUrl,$user,[Guid]::NewGuid())
			Write-Host $test
			Invoke-WebRequest $test
		}
	}
}