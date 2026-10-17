program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
// m1
// a1
// c1
// a2
// b1
// m2
function leaf_c_1: LongInt; forward;
function slow_a_0: LongInt; forward;
function fast_b_2: LongInt; forward;
function leaf_c_1: LongInt;
begin
  Result := 0;
end;
function slow_a_0: LongInt;
var
  v0: LongInt;
begin
  v0 := leaf_c_1;
  Result := v0;
end;
function fast_b_2: LongInt;
begin
  Result := 0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
begin
  v0 := slow_a_0;
  v1 := fast_b_2;
  v2 := v0 + v1;
  Result := v2;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
