program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of Single;
  THeap0 = record l0: TArray0; l1: LongInt; end;
function HeapCreate0(a0: TArray0; a1: LongInt): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: Single;
  v2: LongInt;
  v3: THeap0;
  v4: TArray0;
  v5: LongInt;
  v6: Single;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
begin
  tmp1 := nil;
  SetLength(tmp1, 1);
  v0 := tmp1;
  v1 := 1.5;
  v0[0] := v1;
  v2 := 7;
  v3 := HeapCreate0(v0, v2);
  v4 := v3.l0;
  v5 := v3.l1;
  v6 := v4[0];
  v7 := v6 = 1.5;
  if v7 then begin
      v8 := v5 = 7;
      v9 := v8;
  end else begin
      v9 := False;
  end;
  if v9 then begin
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
