program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: LongInt; end;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: LongInt): THeap1;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: THeap1;
  v5: THeap0;
  v6: LongInt;
  v7: LongInt;
  v8: AnsiString;
  v9: Boolean;
  v11: Boolean;
  v10: Boolean;
  v13: Boolean;
  v12: Boolean;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 1;
  v4 := HeapCreate1(v2, v3);
  v5 := v4.l0;
  v6 := v4.l1;
  v7 := v5.l0;
  v8 := v5.l1;
  v9 := v7 = 7;
  if v9 then begin
      v10 := v8 = 'hi';
      v11 := v10;
  end else begin
      v11 := False;
  end;
  if v11 then begin
      v12 := v6 = 1;
      v13 := v12;
  end else begin
      v13 := False;
  end;
  if v13 then begin
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
