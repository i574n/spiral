program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: THeap0; end;
  TArray0 = array of THeap1;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: THeap0): THeap1;
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
  v7: TArray0;
  tmp8: TArray0;
  v8: THeap1;
  v9: THeap0;
  v10: THeap0;
  v11: LongInt;
  v12: AnsiString;
  v13: LongInt;
  v14: AnsiString;
  v15: Boolean;
  v17: Boolean;
  v16: Boolean;
  v19: Boolean;
  v18: Boolean;
  v21: Boolean;
  v20: Boolean;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 4;
  v4 := 'yo';
  v5 := HeapCreate0(v3, v4);
  v6 := HeapCreate1(v2, v5);
  tmp8 := nil;
  SetLength(tmp8, 1);
  v7 := tmp8;
  v7[0] := v6;
  v8 := v7[0];
  v9 := v8.l0;
  v10 := v8.l1;
  v11 := v9.l0;
  v12 := v9.l1;
  v13 := v10.l0;
  v14 := v10.l1;
  v15 := v11 = 7;
  if v15 then begin
      v16 := v12 = 'hi';
      v17 := v16;
  end else begin
      v17 := False;
  end;
  if v17 then begin
      v18 := v13 = 4;
      v19 := v18;
  end else begin
      v19 := False;
  end;
  if v19 then begin
      v20 := v14 = 'yo';
      v21 := v20;
  end else begin
      v21 := False;
  end;
  if v21 then begin
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
