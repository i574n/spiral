program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongWord; l1: AnsiString; end;
function HeapCreate0(a0: LongWord; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: LongWord;
  v1: AnsiString;
  v2: THeap0;
  v3: LongWord;
  v4: AnsiString;
  v5: Boolean;
  v7: Boolean;
  v6: Boolean;
begin
  v0 := 4000000000;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := v2.l0;
  v4 := v2.l1;
  v5 := v3 = 4000000000;
  if v5 then begin
      v6 := v4 = 'hi';
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
