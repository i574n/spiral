program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: LongInt; end;
function HeapCreate0(a0: LongInt; a1: LongInt): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: THeap0;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v0 := HeapCreate0(9, 10);
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
