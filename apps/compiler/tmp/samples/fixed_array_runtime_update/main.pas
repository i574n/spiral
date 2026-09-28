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
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
begin
  tmp1 := nil;
  SetLength(tmp1, 4);
  v0 := tmp1;
  v0[0] := 2;
  v0[1] := 3;
  v0[2] := 5;
  v0[3] := 7;
  v1 := 1;
  v0[v1] := 11;
  v2 := v0[0];
  v3 := v0[1];
  v4 := v0[2];
  v5 := v0[3];
  v6 := v2 + v3;
  v7 := v6 + v4;
  v8 := v7 + v5;
  v9 := v8 - 25;
  Result := v9;
end;
begin
  Halt(SpiralMain);
end.
