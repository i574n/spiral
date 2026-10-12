program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
begin
  v0 := (-42);
  v1 := spiral_abi_libc_abs(v0);
  Result := v1;
end;
begin
  Halt(SpiralMain);
end.
