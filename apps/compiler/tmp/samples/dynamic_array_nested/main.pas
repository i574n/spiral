program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  TArray1 = array of TArray0;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray1;
  tmp2: TArray1;
  v2: TArray0;
  tmp4: TArray0;
  v3: TArray0;
  tmp6: TArray0;
  v4: TArray0;
  v5: TArray0;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
  v13: LongInt;
begin
  v0 := 2;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  tmp4 := nil;
  SetLength(tmp4, v0);
  v2 := tmp4;
  tmp6 := nil;
  SetLength(tmp6, v0);
  v3 := tmp6;
  v2[0] := 3;
  v2[1] := 4;
  v3[0] := 5;
  v3[1] := 6;
  v1[0] := v2;
  v1[1] := v3;
  v4 := v1[0];
  v5 := v1[1];
  v6 := v4[0];
  v7 := v4[1];
  v8 := v6 + v7;
  v9 := v5[0];
  v10 := v8 + v9;
  v11 := v5[1];
  v12 := v10 + v11;
  v13 := v12 - 18;
  Result := v13;
end;
begin
  Halt(SpiralMain);
end.
