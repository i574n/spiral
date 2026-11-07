program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: Double;
  v1: Double;
  v2: Double;
  v3: Double;
  v4: Boolean;
  v7: Boolean;
  v5: Double;
  v6: Boolean;
begin
  v0 := 7.5;
  v1 := 2.0;
  v2 := (-7.5);
  v3 := v0 mod v1;
  v4 := v3 = 1.5;
  if v4 then begin
      v5 := v2 mod v1;
      v6 := v5 = (-1.5);
      v7 := v6;
  end else begin
      v7 := False;
  end;
  if v7 then begin
      Result := 15;
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
