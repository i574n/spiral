program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function sum_0(v0: LongInt): LongInt; forward;
function sum_0(v0: LongInt): LongInt;
var
  v1: Boolean;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v1 := v0 < 1;
  if v1 then begin
      Result := 0;
  end else begin
      v2 := v0 - 1;
      v3 := sum_0(v2);
      v4 := v0 + v3;
      Result := v4;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: Boolean;
begin
  v0 := 4;
  v1 := sum_0(v0);
  v2 := v1 = 10;
  if v2 then begin
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
