program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  THeap0 = record l0: TArray0; l1: LongInt; end;
function HeapCreate0(a0: TArray0; a1: LongInt): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TArray0;
  tmp3: TArray0;
  v3: THeap0;
  v4: TArray0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: Boolean;
begin
  v0 := 3;
  v1 := 4;
  tmp3 := nil;
  SetLength(tmp3, 1);
  v2 := tmp3;
  v2[0] := v0;
  v3 := HeapCreate0(v2, v1);
  v4 := v3.l0;
  v5 := v3.l1;
  v6 := v4[0];
  v7 := v6 + v5;
  v8 := v7 = 7;
  if v8 then begin
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
