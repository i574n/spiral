program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: LongInt; end;
  THeap2 = record l0: THeap1; l1: LongInt; end;
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
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: THeap1;
  v5: LongInt;
  v6: THeap2;
  v7: THeap1;
  v8: LongInt;
  v9: THeap0;
  v10: LongInt;
  v11: LongInt;
  v12: AnsiString;
  v13: Boolean;
  v15: Boolean;
  v14: Boolean;
  v17: Boolean;
  v16: Boolean;
  v19: Boolean;
  v18: Boolean;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 1;
  v4 := HeapCreate1(v2, v3);
  v5 := 2;
  v6 := HeapCreate2(v4, v5);
  v7 := v6.l0;
  v8 := v6.l1;
  v9 := v7.l0;
  v10 := v7.l1;
  v11 := v9.l0;
  v12 := v9.l1;
  v13 := v11 = 7;
  if v13 then begin
      v14 := v12 = 'hi';
      v15 := v14;
  end else begin
      v15 := False;
  end;
  if v15 then begin
      v16 := v10 = 1;
      v17 := v16;
  end else begin
      v17 := False;
  end;
  if v17 then begin
      v18 := v8 = 2;
      v19 := v18;
  end else begin
      v19 := False;
  end;
  if v19 then begin
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
