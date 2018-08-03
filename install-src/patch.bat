@echo off

copy pcc\bin\loonLaunch.exe pcc\bin\loonLaunch.bak
del  pcc\bin\loonLaunch.exe
ren  pcc\bin\launcher.exe loonLaunch.exe

pcc\bin\loonLaunch.exe --setroot %CD%

del patch.bat