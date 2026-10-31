program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; c0_1: LongInt; end;
  TArray0 = array of TUS0;
function US0_Living(a0: LongInt; a1: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0; Result.c0_1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
begin
  v0 := 3;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  Result := 0;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
