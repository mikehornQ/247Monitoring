@ECHO OFF

@REM setup environment
SET JENKINS_HOME=http://localhost:8080
SET PYTHON_HOME=C:\Python27\python.exe
SET SCRIPT_PATH=C:\Workspaces\247 Monitoring\jenkins
SET SCRIPT_HOME=scripts\start_test.py
SET OUT_HOME=scripts\start_test.out

@REM eggPlant Performance Test Controller Parameters
SET WS="247 Monitoring"
SET PROJECT="novo"
SET TEST="scratch"
SET SERIES="S3auto"

@REM execute test
CD %SCRIPT_PATH%
%PYTHON_HOME% %SCRIPT_HOME% %WS% %PROJECT% %TEST% %SERIES% > %OUT_HOME%

ECHO Logging_Start
ECHO.

IF %ERRORLEVEL% NEQ 0 (
  REM do something here to address the error
  ECHO Test Failed  
  ECHO.
  FINDSTR ERROR: %OUT_HOME%
  ECHO.  
) ELSE (  
  ECHO Test Passed
  ECHO.
)
ECHO Logging_End
ECHO.

