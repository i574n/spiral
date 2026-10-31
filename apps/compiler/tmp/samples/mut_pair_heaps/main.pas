program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut1 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  TMut1 = class l0: THeap0; l1: THeap0; end;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function MutCreate1(a0: THeap0; a1: THeap0): TMut1;
begin
  Result := TMut1.Create; Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: AnsiString;
  v5: THeap0;
  v6: TMut1;
  v7: LongInt;
  v8: AnsiString;
  v9: THeap0;
  v10: LongInt;
  v11: AnsiString;
  v12: THeap0;
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
begin
  v0 := 1;
  v1 := 'no';
  v2 := HeapCreate0(v0, v1);
  v3 := 2;
  v4 := 'zz';
  v5 := HeapCreate0(v3, v4);
  v6 := MutCreate1(v2, v5);
  v7 := 7;
  v8 := 'hi';
  v9 := HeapCreate0(v7, v8);
  v10 := 4;
  v11 := 'yo';
  v12 := HeapCreate0(v10, v11);
  v6.l0 := v9;
  v6.l1 := v12;
  v13 := v6.l0;
  v14 := v6.l1;
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
