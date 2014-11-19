@echo off
call "%WINDIR%\system32\sc.exe" stop TimeObserverService
call "%WINDIR%\system32\sc.exe" delete TimeObserverService
cls