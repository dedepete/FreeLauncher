@ECHO OFF
SETLOCAL ENABLEDELAYEDEXPANSION
SET CONFIGURATION=%~1
SET VERSION=%~2
SET PROJECTDIR=%CD%
SET TARGETDIR=%PROJECTDIR%\bin\%CONFIGURATION%

PUSHD ..\..
ECHO %CD%
SET ROOTDIR=%CD%
POPD

:STEP1
ECHO Step 1/4: Copying language files...
XCOPY /S /Y /F "%PROJECTDIR%\Translations\*" "%TARGETDIR%\freelauncher-langs\"

IF NOT "%CONFIGURATION%" == "Release" (
	ECHO Detected non-release configuration.
	GOTO FINISH
)

:STEP2
ECHO Step 2/4: Cleaning-up TARGETDIR...
DEL /Q "%TARGETDIR%\*.?db" "%TARGETDIR%\*.xml" "%TARGETDIR%\zip\"

:STEP3
ECHO Step 3/4: Merging assemblies...
IF NOT EXIST "%ROOTDIR%\reactor.exe" (
	ECHO _.NET Reactor not found. Skipping to step 4...
	GOTO STEP4
)
SET DLLS=
FOR %%I IN ("%TARGETDIR%\*.DLL") DO (
	SET DLLS=!DLLS!/%%I
)
"%ROOTDIR%\reactor.exe" -file "%TARGETDIR%\FreeLauncher.exe" -merge 1 -satellite_assemblies "%DLLS:~1%" -targetfile "%TARGETDIR%\FreeLauncher-%VERSION%.exe" -obfuscation 0 -stringencryption 0 -suppressildasm 0 -q

:STEP4
ECHO Step 4/4: Creating zip archives...
WHERE 7z >nul 2>nul
IF %ERRORLEVEL% NEQ 0 (
	ECHO 7z not found being installed.
	GOTO FINISH
)
ECHO _Creating zip without merged assemblies...
7z a "%TARGETDIR%\zip\FreeLauncher-%VERSION%.zip" "%TARGETDIR%\FreeLauncher.exe" "%TARGETDIR%\*.dll" "%TARGETDIR%\freelauncher-langs\" -r
IF NOT DEFINED DLLS (
	GOTO FINISH
)
ECHO _Creating zip with merged assemblies...
7z a "%TARGETDIR%\zip\FreeLauncher-%VERSION%-packed.zip" "%TARGETDIR%\FreeLauncher-%VERSION%.exe" "%TARGETDIR%\freelauncher-langs\" -r
7z rn "%TARGETDIR%\zip\FreeLauncher-%VERSION%-packed.zip" "FreeLauncher-%VERSION%.exe" "FreeLauncher.exe"

:FINISH
ECHO Finishing script...
