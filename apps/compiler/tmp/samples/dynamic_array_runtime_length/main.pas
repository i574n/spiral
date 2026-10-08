program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
function method0(v0: LongInt): LongInt; forward;
function method0(v0: LongInt): LongInt;
var
  v1: TArray0;
  tmp1: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  tmp1 := nil;
  SetLength(tmp1, v0);
  v1 := tmp1;
  v1[0] := 2;
  v1[1] := 3;
  v1[2] := 5;
  v1[3] := 7;
  v2 := 2;
  v3 := v1[v2];
  v4 := LongInt(Length(v1));
  v5 := v3 + v4;
  v6 := v5 - 9;
  Result := v6;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := 4;
  Result := method0(v0);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
