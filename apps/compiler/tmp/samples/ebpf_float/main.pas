program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: Single;
  v2: Single;
  v3: Single;
  v4: Single;
  v5: Single;
  v6: Single;
  v7: Boolean;
  v8: Boolean;
begin
  v0 := (-1.5);
  v1 := 2.0;
  v2 := v0 / v1;
  v3 := (-0.75);
  v4 := v0 * v1;
  v5 := v4 + 0.5;
  v6 := (-2.5);
  v7 := v2 = v3;
  if v7 then begin
      v8 := v5 = v6;
      if v8 then begin
          Result := 0;
      end else begin
          Result := 2;
      end;
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
