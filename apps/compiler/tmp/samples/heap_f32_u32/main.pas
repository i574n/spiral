program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: Single; l1: LongWord; end;
function HeapCreate0(a0: Single; a1: LongWord): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: LongWord;
  v2: THeap0;
  v3: Single;
  v4: LongWord;
  v5: Boolean;
  v7: Boolean;
  v6: Boolean;
begin
  v0 := 1.5;
  v1 := 4000000000;
  v2 := HeapCreate0(v0, v1);
  v3 := v2.l0;
  v4 := v2.l1;
  v5 := v3 = 1.5;
  if v5 then begin
      v6 := v4 = 4000000000;
      v7 := v6;
  end else begin
      v7 := False;
  end;
  if v7 then begin
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
