program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut3 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: LongInt; end;
  THeap2 = record l0: THeap1; l1: LongInt; end;
  TMut3 = class l0: THeap2; end;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: LongInt): THeap1;
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
  v4: THeap1;
  v5: LongInt;
  v6: THeap2;
  v7: TMut3;
  v8: LongInt;
  v9: AnsiString;
  v10: THeap0;
  v11: LongInt;
  v12: THeap1;
  v13: LongInt;
  v14: THeap2;
  v15: THeap2;
  v16: THeap1;
  v17: LongInt;
  v18: THeap0;
  v19: LongInt;
  v20: LongInt;
  v21: AnsiString;
  v22: Boolean;
  v24: Boolean;
  v23: Boolean;
  v26: Boolean;
  v25: Boolean;
  v28: Boolean;
  v27: Boolean;
begin
  v0 := 3;
  v1 := 'no';
  v2 := HeapCreate0(v0, v1);
  v3 := 1;
  v4 := HeapCreate1(v2, v3);
  v5 := 2;
  v6 := HeapCreate2(v4, v5);
  v7 := MutCreate3(v6);
  v8 := 7;
  v9 := 'hi';
  v10 := HeapCreate0(v8, v9);
  v11 := 4;
  v12 := HeapCreate1(v10, v11);
  v13 := 5;
  v14 := HeapCreate2(v12, v13);
  v7.l0 := v14;
  v15 := v7.l0;
  v16 := v15.l0;
  v17 := v15.l1;
  v18 := v16.l0;
  v19 := v16.l1;
  v20 := v18.l0;
  v21 := v18.l1;
  v22 := v20 = 7;
  if v22 then begin
      v23 := v21 = 'hi';
      v24 := v23;
  end else begin
      v24 := False;
  end;
  if v24 then begin
      v25 := v19 = 4;
      v26 := v25;
  end else begin
      v26 := False;
  end;
  if v26 then begin
      v27 := v17 = 5;
      v28 := v27;
  end else begin
      v28 := False;
  end;
  if v28 then begin
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
