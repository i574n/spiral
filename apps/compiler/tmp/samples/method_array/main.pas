program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
function method0(v0: LongInt): TArray0; forward;
function method0(v0: LongInt): TArray0;
var
  v1: TArray0;
  tmp1: TArray0;
begin
  tmp1 := nil;
  SetLength(tmp1, 1);
  v1 := tmp1;
  v1[0] := v0;
  Result := v1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  v2: LongInt;
  v3: Boolean;
begin
  v0 := 7;
  v1 := method0(v0);
  v2 := v1[0];
  v3 := v2 = 7;
  if v3 then begin
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
