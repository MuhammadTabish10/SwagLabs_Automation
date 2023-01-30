@ECHO OFF
ECHO Automation Executed Started.

set debugPath=C:\Users\muham\source\repos\SwagLabs_Automation\SwagLabs_Automation\bin\Debug\

call "C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\Tools\VsDevCmd.bat"
VSTest.Console.exe "%debugPath%SwagLabs_Automation.dll" /Logger:"trx;LogFileName=C:\Users\muham\source\repos\SwagLabs_Automation\SwagLabs_Automation\Results\TestReports\SwagLabs_AutomationReport.trx"

cd %debugPath%
TrxToHTML.exe "C:\Users\muham\source\repos\SwagLabs_Automation\SwagLabs_Automation\Results\TestReports"

PAUSE