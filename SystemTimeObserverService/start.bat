@echo off
for /r "%WINDIR%\Microsoft.NET\Framework\" %%a in (*) do if "%%~nxa"=="InstallUtil.exe" set util=%%~dpnxa
call %util% "%~dp0\STS.exe"
call "%WINDIR%\system32\sc.exe" start TimeObserverService
cls