program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: THeap0; end;
  THeap2 = record l0: THeap1; l1: LongInt; end;
  TArray0 = array of THeap2;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: THeap0): THeap1;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate2(a0: THeap1; a1: LongInt): THeap2;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: AnsiString;
  v5: THeap0;
  v6: THeap1;
  v7: LongInt;
  v8: THeap2;
  v9: TArray0;
  tmp10: TArray0;
  v10: THeap2;
  v11: THeap1;
  v12: LongInt;
  v13: THeap0;
  v14: THeap0;
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
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 4;
  v4 := 'yo';
  v5 := HeapCreate0(v3, v4);
  v6 := HeapCreate1(v2, v5);
  v7 := 2;
  v8 := HeapCreate2(v6, v7);
  tmp10 := nil;
  SetLength(tmp10, 1);
  v9 := tmp10;
  v9[0] := v8;
  v10 := v9[0];
  v11 := v10.l0;
  v12 := v10.l1;
  v13 := v11.l0;
  v14 := v11.l1;
  v15 := v13.l0;
  v16 := v13.l1;
  v17 := v14.l0;
  v18 := v14.l1;
  v19 := v15 = 7;
  if v19 then begin
      v20 := v16 = 'hi';
      v21 := v20;
  end else begin
      v21 := False;
  end;
  if v21 then begin
      v22 := v17 = 4;
      v23 := v22;
  end else begin
      v23 := False;
  end;
  if v23 then begin
      v24 := v18 = 'yo';
      v25 := v24;
  end else begin
      v25 := False;
  end;
  if v25 then begin
      v26 := v12 = 2;
      v27 := v26;
  end else begin
      v27 := False;
  end;
  if v27 then begin
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
