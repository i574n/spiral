program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
begin
  v0 := 6;
  v1 := 7;
  v2 := v0 + v1;
  Result := v2;
end;
begin
  Halt(SpiralMain);
end.
