program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
procedure method0(v0: TArray0); forward;
function method1(v0: TArray0): LongInt; forward;
function method2(v0: TArray0): LongInt; forward;
procedure method0(v0: TArray0);
var
  v1: LongInt;
  v2: LongInt;
begin
  v1 := 1;
  v2 := 9;
  v0[v1] := v2;
end;
function method1(v0: TArray0): LongInt;
var
  v1: LongInt;
  v2: LongInt;
begin
  v1 := 0;
  v2 := v0[v1];
  Result := v2;
end;
function method2(v0: TArray0): LongInt;
var
  v1: LongInt;
  v2: LongInt;
begin
  v1 := 1;
  v2 := v0[v1];
  Result := v2;
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
  v1[0] := 1;
  v1[1] := 2;
  method0(v1);
  v2 := method1(v1);
  v3 := method2(v1);
  v4 := v2 + v3;
  v5 := v4 - 10;
  Result := v5;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
