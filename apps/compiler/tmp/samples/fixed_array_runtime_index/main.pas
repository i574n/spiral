program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  tmp1 := nil;
  SetLength(tmp1, 4);
  v0 := tmp1;
  v0[0] := 2;
  v0[1] := 3;
  v0[2] := 5;
  v0[3] := 7;
  v1 := 2;
  v2 := v0[v1];
  v3 := v2 - 5;
  Result := v3;
end;
begin
  Halt(SpiralMain);
end.
