@ECHO OFF
SETLOCAL ENABLEDELAYEDEXPANSION
SET CONFIGURATION=%1
SET PROJECTDIR=%CD%
SET TARGETDIR=%PROJECTDIR%\bin\%CONFIGURATION%

PUSHD ..\..
ECHO %CD%
SET ROOTDIR=%CD%
POPD

:STEP1
ECHO Step 1/4: Copying language files...
XCOPY /S /Y /F "%PROJECTDIR%\Translations\*" "%TARGETDIR%\freelauncher-langs\"

IF NOT %CONFIGURATION% == Release (
	ECHO Detected non-release configuration.
	GOTO FINISH
)

:STEP2
ECHO Step 2/4: Cleaning-up TARGETDIR...
DEL /Q "%TARGETDIR%\*.?db" "%TARGETDIR%\*.xml" "%TARGETDIR%\zip\"

:STEP3
SET SKIPPACKED=
IF NOT EXIST "%ROOTDIR%\reactor.exe" (
	ECHO .NET Reactor not found. Skipping to step 4...
	SET SKIPPACKED=TRUE
	GOTO STEP4
)
ECHO Step 3/4: Merging assemblies...
SET DLLS=
FOR %%I IN ("%TARGETDIR%\*.DLL") DO (
	SET DLLS=!DLLS!/%%I
)
"%ROOTDIR%\reactor.exe" -file "%TARGETDIR%\FreeLauncher.exe" -merge 1 -satellite_assemblies "%DLLS:~1%" -targetfile "%TARGETDIR%\FreeLauncher-%2.exe" -q

:STEP4
WHERE 7z >nul 2>nul
IF %ERRORLEVEL% NEQ 0 (
	ECHO 7z not found being installed.
	GOTO FINISH
)
ECHO Step 4/4: Creating zip archives...
IF NOT %SKIPPACKED% == TRUE (
	7z a "%TARGETDIR%\zip\FreeLauncher-%2-packed.zip" "%TARGETDIR%\FreeLauncher-%2.exe" "%TARGETDIR%\freelauncher-langs\" -r
	7z rn "%TARGETDIR%\zip\FreeLauncher-%2-packed.zip" "FreeLauncher-%2.exe" "FreeLauncher.exe"
)
7z a "%TARGETDIR%\zip\FreeLauncher-%2.zip" "%TARGETDIR%\FreeLauncher.exe" "%TARGETDIR%\*.dll" "%TARGETDIR%\freelauncher-langs\" -r

:FINISH
ECHO Finishing script...
