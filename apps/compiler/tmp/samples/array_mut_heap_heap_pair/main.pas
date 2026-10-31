program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut3 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: THeap0; end;
  THeap2 = record l0: THeap1; l1: LongInt; end;
  TMut3 = class l0: THeap2; end;
  TArray0 = array of TMut3;
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
  v10: TArray0;
  tmp11: TArray0;
  v11: LongInt;
  v12: AnsiString;
  v13: THeap0;
  v14: LongInt;
  v15: AnsiString;
  v16: THeap0;
  v17: THeap1;
  v18: LongInt;
  v19: THeap2;
  v20: TMut3;
  v21: THeap2;
  v22: THeap1;
  v23: LongInt;
  v24: THeap0;
  v25: THeap0;
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
  v17 := HeapCreate1(v13, v16);
  v18 := 2;
  v19 := HeapCreate2(v17, v18);
  v20 := v10[0];
  v20.l0 := v19;
  v21 := v20.l0;
  v22 := v21.l0;
  v23 := v21.l1;
  v24 := v22.l0;
  v25 := v22.l1;
  v26 := v24.l0;
  v27 := v24.l1;
  v28 := v25.l0;
  v29 := v25.l1;
  v30 := v26 = 7;
  if v30 then begin
      v31 := v27 = 'hi';
      v32 := v31;
  end else begin
      v32 := False;
  end;
  if v32 then begin
      v33 := v28 = 4;
      v34 := v33;
  end else begin
      v34 := False;
  end;
  if v34 then begin
      v35 := v29 = 'yo';
      v36 := v35;
  end else begin
      v36 := False;
  end;
  if v36 then begin
      v37 := v23 = 2;
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
