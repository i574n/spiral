program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TMut0 = class l0: LongInt; l1: LongInt; end;
function MutCreate0(a0: LongInt; a1: LongInt): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: TMut0;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v0 := MutCreate0(1, 2);
  v0.l0 := 3;
  v0.l1 := 4;
  v1 := v0.l0;
  v2 := v0.l1;
  v3 := v1 + v2;
  Result := v3;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
