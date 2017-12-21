@SET PATH=%PATH%;packages\NuGet.CommandLine.4.4.1\tools

@rmdir nugets /s /q

@if NOT ["%errorlevel%"]==["0"] (
    exit /b %errorlevel%
)

@mkdir nugets

@if NOT ["%errorlevel%"]==["0"] (
    exit /b %errorlevel%
)

@nuget.exe Pack Immersive.Winforms\Immersive.Winforms.csproj -Build -Properties Configuration=Release -OutputDirectory nugets

@if NOT ["%errorlevel%"]==["0"] (
    exit /b %errorlevel%
)