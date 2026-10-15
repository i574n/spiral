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
  v2: TArray0;
  tmp4: TArray0;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
begin
  tmp1 := nil;
  SetLength(tmp1, 4);
  v0 := tmp1;
  v0[0] := 7;
  v0[1] := 7;
  v0[2] := 7;
  v0[3] := 7;
  v1 := v0[3];
  tmp4 := nil;
  SetLength(tmp4, 4);
  v2 := tmp4;
  v2[0] := 5;
  v3 := v2[3];
  v4 := v2[0];
  v5 := v3 * 100;
  v6 := v5 + v4;
  v7 := v1 - 7;
  v8 := v6 + v7;
  Result := v8;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
