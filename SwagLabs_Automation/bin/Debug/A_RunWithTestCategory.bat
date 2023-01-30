@ECHO OFF
ECHO Automation Executed Started.

set testcategory=Login
set debugPath=C:\Users\muham\source\repos\SwagLabs_Automation\SwagLabs_Automation\bin\Debug\

call "C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\Tools\VsDevCmd.bat"
VSTest.Console.exe "%debugPath%SwagLabs_Automation.dll" /TestCaseFilter:"TestCategory=%testcategory%" /Logger:"trx;LogFileName=C:\Users\muham\source\repos\SwagLabs_Automation\SwagLabs_Automation\Results\TestReports\LoginTC.trx"

cd %debugPath%
TrxToHTML.exe "C:\Users\muham\source\repos\SwagLabs_Automation\SwagLabs_Automation\Results\TestReports"

PAUSE