@Call Package.cmd

@if NOT ["%errorlevel%"]==["0"] (
    exit /b %errorlevel%
)

@nuget.exe Push publish\*.nupkg

@if NOT ["%errorlevel%"]==["0"] (
    exit /b %errorlevel%
)
