# In case of 'Could not find file ... bin\roslyn\csc.exe' problem the quick fix is to use the package manager, Tools > Nuget Package Manager > Package Manager Console, to run
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
