program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut1 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  TMut1 = class l0: THeap0; l1: THeap0; l2: THeap0; end;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function MutCreate1(a0: THeap0; a1: THeap0; a2: THeap0): TMut1;
begin
  Result := TMut1.Create; Result.l0 := a0; Result.l1 := a1; Result.l2 := a2;
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
  v9: TMut1;
  v10: LongInt;
  v11: AnsiString;
  v12: THeap0;
  v13: LongInt;
  v14: AnsiString;
  v15: THeap0;
  v16: LongInt;
  v17: AnsiString;
  v18: THeap0;
  v19: THeap0;
  v20: THeap0;
  v21: THeap0;
  v22: LongInt;
  v23: AnsiString;
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
  v38: Boolean;
  v37: Boolean;
begin
  v0 := 1;
  v1 := 'no';
  v2 := HeapCreate0(v0, v1);
  v3 := 2;
  v4 := 'zz';
  v5 := HeapCreate0(v3, v4);
  v6 := 3;
  v7 := 'aa';
  v8 := HeapCreate0(v6, v7);
  v9 := MutCreate1(v2, v5, v8);
  v10 := 7;
  v11 := 'hi';
  v12 := HeapCreate0(v10, v11);
  v13 := 4;
  v14 := 'yo';
  v15 := HeapCreate0(v13, v14);
  v16 := 9;
  v17 := 'ok';
  v18 := HeapCreate0(v16, v17);
  v9.l0 := v12;
  v9.l1 := v15;
  v9.l2 := v18;
  v19 := v9.l0;
  v20 := v9.l1;
  v21 := v9.l2;
  v22 := v19.l0;
  v23 := v19.l1;
  v24 := v20.l0;
  v25 := v20.l1;
  v26 := v21.l0;
  v27 := v21.l1;
  v28 := v22 = 7;
  if v28 then begin
      v29 := v23 = 'hi';
      v30 := v29;
  end else begin
      v30 := False;
  end;
  if v30 then begin
      v31 := v24 = 4;
      v32 := v31;
  end else begin
      v32 := False;
  end;
  if v32 then begin
      v33 := v25 = 'yo';
      v34 := v33;
  end else begin
      v34 := False;
  end;
  if v34 then begin
      v35 := v26 = 9;
      v36 := v35;
  end else begin
      v36 := False;
  end;
  if v36 then begin
      v37 := v27 = 'ok';
      v38 := v37;
  end else begin
      v38 := False;
  end;
  if v38 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
