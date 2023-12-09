SET OLDDIR=%CD%
dotnet build
cd bin/Debug/net6.0
xcopy SoulstoneTweaks.dll "../../../../BepInEx/plugins" /v /y
cd "C:\Program Files (x86)\Steam"
steam -applaunch 2066020
cd %OLDDIR%