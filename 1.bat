echo off
for %%f in (E:\Github\acesiddhu\roslyn\artifacts\TestResults\Debug\*.xml) do (
  echo "fullname: %%f"
C:\temp\tools\codecov.exe -f %%f -t 366dc8d3-f9ca-4344-9621-25c6c1cb83ef
)