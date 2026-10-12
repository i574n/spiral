program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: THeap0; l2: THeap0; end;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: THeap0; a2: THeap0): THeap1;
begin
  Result.l0 := a0; Result.l1 := a1; Result.l2 := a2;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: AnsiString;
  v5: THeap0;
  v6: LongInt;
  v7: AnsiString;
  v8: THeap0;
  v9: THeap1;
  v10: THeap0;
  v11: THeap0;
  v12: THeap0;
  v13: LongInt;
  v14: AnsiString;
  v15: LongInt;
  v16: AnsiString;
  v17: LongInt;
  v18: AnsiString;
  v19: Boolean;
  v21: Boolean;
  v20: Boolean;
  v23: Boolean;
  v22: Boolean;
  v25: Boolean;
  v24: Boolean;
  v27: Boolean;
  v26: Boolean;
  v29: Boolean;
  v28: Boolean;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 4;
  v4 := 'yo';
  v5 := HeapCreate0(v3, v4);
  v6 := 9;
  v7 := 'ok';
  v8 := HeapCreate0(v6, v7);
  v9 := HeapCreate1(v2, v5, v8);
  v10 := v9.l0;
  v11 := v9.l1;
  v12 := v9.l2;
  v13 := v10.l0;
  v14 := v10.l1;
  v15 := v11.l0;
  v16 := v11.l1;
  v17 := v12.l0;
  v18 := v12.l1;
  v19 := v13 = 7;
  if v19 then begin
      v20 := v14 = 'hi';
      v21 := v20;
  end else begin
      v21 := False;
  end;
  if v21 then begin
      v22 := v15 = 4;
      v23 := v22;
  end else begin
      v23 := False;
  end;
  if v23 then begin
      v24 := v16 = 'yo';
      v25 := v24;
  end else begin
      v25 := False;
  end;
  if v25 then begin
      v26 := v17 = 9;
      v27 := v26;
  end else begin
      v27 := False;
  end;
  if v27 then begin
      v28 := v18 = 'ok';
      v29 := v28;
  end else begin
      v29 := False;
  end;
  if v29 then begin
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
