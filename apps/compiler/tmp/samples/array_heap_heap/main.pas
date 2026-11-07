program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: LongInt; end;
  TArray0 = array of THeap1;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: LongInt): THeap1;
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
  v5: TArray0;
  tmp6: TArray0;
  v6: THeap1;
  v7: THeap0;
  v8: LongInt;
  v9: LongInt;
  v10: AnsiString;
  v11: Boolean;
  v13: Boolean;
  v12: Boolean;
  v15: Boolean;
  v14: Boolean;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 1;
  v4 := HeapCreate1(v2, v3);
  tmp6 := nil;
  SetLength(tmp6, 1);
  v5 := tmp6;
  v5[0] := v4;
  v6 := v5[0];
  v7 := v6.l0;
  v8 := v6.l1;
  v9 := v7.l0;
  v10 := v7.l1;
  v11 := v9 = 7;
  if v11 then begin
      v12 := v10 = 'hi';
      v13 := v12;
  end else begin
      v13 := False;
  end;
  if v13 then begin
      v14 := v8 = 1;
      v15 := v14;
  end else begin
      v15 := False;
  end;
  if v15 then begin
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
