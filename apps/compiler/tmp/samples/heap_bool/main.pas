program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: Boolean; end;
function HeapCreate0(a0: Boolean): THeap0;
begin
  Result.l0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v1: THeap0;
  v2: Boolean;
begin
  v0 := True;
  v1 := HeapCreate0(v0);
  v2 := v1.l0;
  if v2 then begin
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
