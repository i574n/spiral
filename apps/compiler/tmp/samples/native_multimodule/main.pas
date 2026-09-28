program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
function method0(v0: LongInt; v1: LongInt; v2: LongInt): LongInt; forward;
function method0(v0: LongInt; v1: LongInt; v2: LongInt): LongInt;
var
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v3 := v0 * v1;
  v4 := v3 + v2;
  v5 := v4 - 42;
  Result := v5;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
begin
  v0 := 5;
  v1 := 8;
  v2 := 2;
  Result := method0(v0, v1, v2);
end;
begin
  Halt(SpiralMain);
end.
