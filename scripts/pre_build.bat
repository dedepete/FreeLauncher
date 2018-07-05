@ECHO OFF
SET VERSION=%~1
SET PROJECTDIR=%CD%

FOR /F "TOKENS=*" %%A IN ('git rev-parse --short HEAD') DO SET SHORTHASH=%%A
FOR /F "TOKENS=*" %%A IN ('git rev-parse --abbrev-ref HEAD') DO SET BRANCH=%%A

FOR /F "TOKENS=4 DELIMS=." %%A IN ("%VERSION%") DO SET REVISION=%%A
CALL SET REVISION=.%REVISION%

CALL SET VERSION=%%VERSION:%REVISION%=%%

ECHO Step 1/1: Patching AssemblyInfo.cs
CD %PROJECTDIR%\Properties\
COPY AssemblyInfo.cs AssemblyInfo.cs.tmp
ECHO [assembly: AssemblyInformationalVersion("%VERSION%_%BRANCH%.%SHORTHASH%")] >> AssemblyInfo.cs

ECHO Finishing script...