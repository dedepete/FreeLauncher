@ECHO OFF
SETLOCAL ENABLEDELAYEDEXPANSION
SET CONFIGURATION=%1
SET PROJECTDIR=%CD%
SET TARGETDIR=%PROJECTDIR%\bin\%CONFIGURATION%

PUSHD ..\..
ECHO %CD%
SET ROOTDIR=%CD%
POPD

XCOPY /S /Y /F "%PROJECTDIR%\Translations\*" "%TARGETDIR%\freelauncher-langs\"

IF NOT %CONFIGURATION% == Release (
	ECHO Detected non-release configuration. Exiting...
	EXIT 0
)

DEL /Q "%TARGETDIR%\*.?db" "%TARGETDIR%\*.xml" "%TARGETDIR%\zip\"

IF NOT EXIST "%ROOTDIR%\reactor.exe" (
	ECHO .NET Reactor not found. Exiting...
	EXIT 0
)
SET DLLS=
FOR %%I IN ("%TARGETDIR%\*.DLL") DO (
	SET DLLS=!DLLS!/%%I
)
"%ROOTDIR%\reactor.exe" -file "%TARGETDIR%\FreeLauncher.exe" -merge 1 -satellite_assemblies "%DLLS:~1%" -targetfile "%TARGETDIR%\FreeLauncher-%2.exe" -q

WHERE 7z >nul 2>nul
IF %ERRORLEVEL% NEQ 0 (
	ECHO 7z not found being installed. Exiting...
	EXIT 0
)
7z a "%TARGETDIR%\zip\FreeLauncher-%2-packed.zip" "%TARGETDIR%\FreeLauncher-%2.exe" "%TARGETDIR%\freelauncher-langs\" -r
7z a "%TARGETDIR%\zip\FreeLauncher-%2.zip" "%TARGETDIR%\FreeLauncher.exe" "%TARGETDIR%\*.dll" "%TARGETDIR%\freelauncher-langs\" -r
7z rn "%TARGETDIR%\zip\FreeLauncher-%2-packed.zip" "FreeLauncher-%2.exe" "FreeLauncher.exe"
