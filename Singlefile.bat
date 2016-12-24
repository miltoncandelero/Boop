@echo off
title NetworkPunch
echo.
echo Welcome to NetworkPunch ver. 0.1.Potato
echo This was made on december 24th in 2 hours.
echo Keep that in mind.
echo.
IF EXIST %1 GOTO found

Echo Your file was not found.
echo Drag and drop 1 .cia or .tik to the icon of this program.
echo OR drag a folder with all the .cia you want inside.

pause > nul
exit

:found
echo Write the IP adress that the FBI shows:
SET /P "IP=ip adress: "
echo.
echo running servefiles.exe, make sure to press "YES" on your 3ds...
echo.
servefiles.exe %ip% %1


echo.
echo servefiles is done. Everything should be installed now.
pause