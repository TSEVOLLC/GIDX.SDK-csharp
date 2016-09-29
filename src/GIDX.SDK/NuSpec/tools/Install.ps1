param($installPath, $toolsPath, $package, $project)

$url = "https://github.com/TSEVOLLC/GIDX.SDK-csharp"

<#
Nuget runs this script everytime a package is installed/updated in a project.
The goal is to open the project's Github page if:
	The package is being installed for the first time in this solution
	or
	The package is being updated to the latest version and no other project in this solution has already been updated
#>

# Get all GIDX.SDK packages installed in other projects in this solution
$installedPackages = @(
	Get-Project -All |
	where { $_.ProjectName -ne $project.ProjectName } |
	%{
		Get-Package -ProjectName $_.ProjectName |
		where { $_.Id -eq $package.Id }
	})

$maxVersion = $installedPackages | %{ $_.Version } | sort -desc | select -first 1

if ($maxVersion -eq $null -or $maxVersion -lt $package.Version) {
	start $url
}
