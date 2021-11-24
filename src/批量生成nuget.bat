@echo off
set nowPath=%cd%
cd \
cd %nowPath%
echo ��ʼ����

echo ��ʼ����SyZero.Blog.IApplication
cd SyZero.Blog.IApplication
del /f /s /q %USERPROFILE%\.nuget\packages\SyZero.Blog.IApplication
del /f /s /q bin\Debug\*.nupkg
dotnet pack
copy /y bin\Debug\*.nupkg ..\..\..\SYZERO\nuget\*.nupkg
cd %nowPath%

echo ���
Pause


