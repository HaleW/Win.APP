 @echo off
 
 ::Э���ļ�·��, ���Ҫ����\������
 set SOURCE_FOLDER=Proto
 
 ::C#������·��
 set CS_COMPILER_PATH=protoc.exe
 ::C#�ļ�����·��, ���Ҫ����\������
 set CS_TARGET_PATH=Msg
 
 ::���������ļ�
 for /f "delims=" %%i in ('dir /b "%SOURCE_FOLDER%\*.proto"') do (
     ::���� C# ����
     %CS_COMPILER_PATH% --proto_path=%SOURCE_FOLDER% --csharp_out=%CS_TARGET_PATH% %%i
     echo %%i �������
 )
 
 pause