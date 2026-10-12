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
begin
  tmp1 := nil;
  SetLength(tmp1, 3);
  v0 := tmp1;
  v0[0] := 2;
  v0[1] := 3;
  v0[2] := 5;
  v1 := v0[0];
  v2 := v0[1];
  v3 := v0[2];
  v4 := v1 + v2;
  v5 := v4 + v3;
  v6 := v5 - 10;
  Result := v6;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
