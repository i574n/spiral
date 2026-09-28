program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
begin
  v0 := 'spiral';
  v1 := spiral_abi_libc_strlen(v0);
  Result := v1;
end;
begin
  Halt(SpiralMain);
end.
