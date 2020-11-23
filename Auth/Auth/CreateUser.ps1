Write-Host "Username:"
$User = Read-Host
Write-Host "Password:"
$Password = Read-Host -AsSecureString
New-LocalUser -Name $User -Password $Password