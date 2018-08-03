@echo off

set ROADSEND_ROOT=#put you Roadsend root directory here, e.g. C:\roadsend#
set SH=\bin\sh.exe
set IDE=\pcc\bin\loon.exe

if not exist %ROADSEND_ROOT%%SH% goto NOSH
if not exist %ROADSEND_ROOT%%IDE% goto NOIDE

echo Files OK.
echo Launch Roadsend IDE...
%ROADSEND_ROOT%%SH% --login -c "cd /pcc/bin && start loon"


:NOSH
	echo File %ROADSEND_ROOT%%SH% not found
	exit /b 1

:NOIDE
	echo File %ROADSEND_ROOT%%IDE% not found
	exit /b 1