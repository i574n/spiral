program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut3 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: THeap0; end;
  THeap2 = record l0: THeap1; l1: LongInt; end;
  TMut3 = class l0: THeap2; end;
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
function MutCreate3(a0: THeap2): TMut3;
begin
  Result := TMut3.Create; Result.l0 := a0;
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
  v9: TMut3;
  v10: LongInt;
  v11: AnsiString;
  v12: THeap0;
  v13: LongInt;
  v14: AnsiString;
  v15: THeap0;
  v16: THeap1;
  v17: LongInt;
  v18: THeap2;
  v19: THeap2;
  v20: THeap1;
  v21: LongInt;
  v22: THeap0;
  v23: THeap0;
  v24: LongInt;
  v25: AnsiString;
  v26: LongInt;
  v27: AnsiString;
  v28: Boolean;
  v30: Boolean;
  v29: Boolean;
  v32: Boolean;
  v31: Boolean;
  v34: Boolean;
  v33: Boolean;
  v36: Boolean;
  v35: Boolean;
begin
  v0 := 1;
  v1 := 'no';
  v2 := HeapCreate0(v0, v1);
  v3 := 2;
  v4 := 'zz';
  v5 := HeapCreate0(v3, v4);
  v6 := HeapCreate1(v2, v5);
  v7 := 3;
  v8 := HeapCreate2(v6, v7);
  v9 := MutCreate3(v8);
  v10 := 7;
  v11 := 'hi';
  v12 := HeapCreate0(v10, v11);
  v13 := 4;
  v14 := 'yo';
  v15 := HeapCreate0(v13, v14);
  v16 := HeapCreate1(v12, v15);
  v17 := 2;
  v18 := HeapCreate2(v16, v17);
  v9.l0 := v18;
  v19 := v9.l0;
  v20 := v19.l0;
  v21 := v19.l1;
  v22 := v20.l0;
  v23 := v20.l1;
  v24 := v22.l0;
  v25 := v22.l1;
  v26 := v23.l0;
  v27 := v23.l1;
  v28 := v24 = 7;
  if v28 then begin
      v29 := v25 = 'hi';
      v30 := v29;
  end else begin
      v30 := False;
  end;
  if v30 then begin
      v31 := v26 = 4;
      v32 := v31;
  end else begin
      v32 := False;
  end;
  if v32 then begin
      v33 := v27 = 'yo';
      v34 := v33;
  end else begin
      v34 := False;
  end;
  if v34 then begin
      v35 := v21 = 2;
      v36 := v35;
  end else begin
      v36 := False;
  end;
  if v36 then begin
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
