program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut2 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: LongInt; end;
  TMut2 = class l0: THeap1; end;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: LongInt): THeap1;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function MutCreate2(a0: THeap1): TMut2;
begin
  Result := TMut2.Create; Result.l0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: THeap1;
  v5: TMut2;
  v6: LongInt;
  v7: AnsiString;
  v8: THeap0;
  v9: LongInt;
  v10: THeap1;
  v11: THeap1;
  v12: THeap0;
  v13: LongInt;
  v14: LongInt;
  v15: AnsiString;
  v16: Boolean;
  v18: Boolean;
  v17: Boolean;
  v20: Boolean;
  v19: Boolean;
begin
  v0 := 3;
  v1 := 'no';
  v2 := HeapCreate0(v0, v1);
  v3 := 1;
  v4 := HeapCreate1(v2, v3);
  v5 := MutCreate2(v4);
  v6 := 7;
  v7 := 'hi';
  v8 := HeapCreate0(v6, v7);
  v9 := 4;
  v10 := HeapCreate1(v8, v9);
  v5.l0 := v10;
  v11 := v5.l0;
  v12 := v11.l0;
  v13 := v11.l1;
  v14 := v12.l0;
  v15 := v12.l1;
  v16 := v14 = 7;
  if v16 then begin
      v17 := v15 = 'hi';
      v18 := v17;
  end else begin
      v18 := False;
  end;
  if v18 then begin
      v19 := v13 = 4;
      v20 := v19;
  end else begin
      v20 := False;
  end;
  if v20 then begin
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
