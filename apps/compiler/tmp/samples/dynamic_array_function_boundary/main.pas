program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
function method0(v0: TArray0; v1: LongInt): LongInt; forward;
function method0(v0: TArray0; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v2 := v0[v1];
  v3 := LongInt(Length(v0));
  v4 := v2 + v3;
  v5 := v4 - 10;
  Result := v5;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
begin
  v0 := 3;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 2;
  v1[1] := 5;
  v1[2] := 7;
  v2 := 2;
  Result := method0(v1, v2);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
