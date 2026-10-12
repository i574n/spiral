program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; end;
  THeap1 = record l0: THeap0; end;
function HeapCreate0(a0: LongInt): THeap0;
begin
  Result.l0 := a0;
end;
function HeapCreate1(a0: THeap0): THeap1;
begin
  Result.l0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: THeap0;
  v2: THeap1;
  v3: THeap0;
  v4: LongInt;
  v5: Boolean;
begin
  v0 := 7;
  v1 := HeapCreate0(v0);
  v2 := HeapCreate1(v1);
  v3 := v2.l0;
  v4 := v3.l0;
  v5 := v4 = 7;
  if v5 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
