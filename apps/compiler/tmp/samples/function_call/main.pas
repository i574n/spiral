program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method0(v0: LongInt; v1: LongInt): LongInt; forward;
function method0(v0: LongInt; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := v0 + v1;
  v3 := v2 - 42;
  Result := v3;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
begin
  v0 := 20;
  v1 := 22;
  Result := method0(v0, v1);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
