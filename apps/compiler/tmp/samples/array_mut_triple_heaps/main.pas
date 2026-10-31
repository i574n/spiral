program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut1 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  TMut1 = class l0: THeap0; l1: THeap0; l2: THeap0; end;
  TArray0 = array of TMut1;
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
  v10: TArray0;
  tmp11: TArray0;
  v11: LongInt;
  v12: AnsiString;
  v13: THeap0;
  v14: LongInt;
  v15: AnsiString;
  v16: THeap0;
  v17: LongInt;
  v18: AnsiString;
  v19: THeap0;
  v20: TMut1;
  v21: THeap0;
  v22: THeap0;
  v23: THeap0;
  v24: LongInt;
  v25: AnsiString;
  v26: LongInt;
  v27: AnsiString;
  v28: LongInt;
  v29: AnsiString;
  v30: Boolean;
  v32: Boolean;
  v31: Boolean;
  v34: Boolean;
  v33: Boolean;
  v36: Boolean;
  v35: Boolean;
  v38: Boolean;
  v37: Boolean;
  v40: Boolean;
  v39: Boolean;
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
  tmp11 := nil;
  SetLength(tmp11, 1);
  v10 := tmp11;
  v10[0] := v9;
  v11 := 7;
  v12 := 'hi';
  v13 := HeapCreate0(v11, v12);
  v14 := 4;
  v15 := 'yo';
  v16 := HeapCreate0(v14, v15);
  v17 := 9;
  v18 := 'ok';
  v19 := HeapCreate0(v17, v18);
  v20 := v10[0];
  v20.l0 := v13;
  v20.l1 := v16;
  v20.l2 := v19;
  v21 := v20.l0;
  v22 := v20.l1;
  v23 := v20.l2;
  v24 := v21.l0;
  v25 := v21.l1;
  v26 := v22.l0;
  v27 := v22.l1;
  v28 := v23.l0;
  v29 := v23.l1;
  v30 := v24 = 7;
  if v30 then begin
      v31 := v25 = 'hi';
      v32 := v31;
  end else begin
      v32 := False;
  end;
  if v32 then begin
      v33 := v26 = 4;
      v34 := v33;
  end else begin
      v34 := False;
  end;
  if v34 then begin
      v35 := v27 = 'yo';
      v36 := v35;
  end else begin
      v36 := False;
  end;
  if v36 then begin
      v37 := v28 = 9;
      v38 := v37;
  end else begin
      v38 := False;
  end;
  if v38 then begin
      v39 := v29 = 'ok';
      v40 := v39;
  end else begin
      v40 := False;
  end;
  if v40 then begin
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
