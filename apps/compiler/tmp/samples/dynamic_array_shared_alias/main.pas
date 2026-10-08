program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
function method0(v0: TArray0): LongInt; forward;
function method1(v0: TArray0): LongInt; forward;
function method0(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := v0[0];
  Result := v1;
end;
function method1(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := v0[0];
  Result := v1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v0 := 2;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 3;
  v1[1] := 4;
  v2 := method0(v1);
  v3 := method1(v1);
  v4 := v2 + v3;
  v5 := v4 - 6;
  Result := v5;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
