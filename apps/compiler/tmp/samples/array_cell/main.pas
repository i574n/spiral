program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; end;
  TArray0 = array of THeap0;
function HeapCreate0(a0: LongInt): THeap0;
begin
  Result.l0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: THeap0;
  v5: THeap0;
  v6: THeap0;
  v7: LongInt;
  v8: THeap0;
  v9: LongInt;
  v10: LongInt;
  v11: Boolean;
begin
  v0 := 2;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v2 := 4;
  v3 := 6;
  v4 := HeapCreate0(v2);
  v1[0] := v4;
  v5 := HeapCreate0(v3);
  v1[1] := v5;
  v6 := v1[0];
  v7 := v6.l0;
  v8 := v1[1];
  v9 := v8.l0;
  v10 := v7 + v9;
  v11 := v10 = 10;
  if v11 then begin
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
