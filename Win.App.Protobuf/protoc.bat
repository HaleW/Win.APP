 @echo off
 
 ::协议文件路径, 最后不要跟“\”符号
 set SOURCE_FOLDER=Proto
 
 ::C#编译器路径
 set CS_COMPILER_PATH=protoc.exe
 ::C#文件生成路径, 最后不要跟“\”符号
 set CS_TARGET_PATH=Msg
 
 ::遍历所有文件
 for /f "delims=" %%i in ('dir /b "%SOURCE_FOLDER%\*.proto"') do (
     ::生成 C# 代码
     %CS_COMPILER_PATH% --proto_path=%SOURCE_FOLDER% --csharp_out=%CS_TARGET_PATH% %%i
     echo %%i 生成完毕
 )
 
 pause