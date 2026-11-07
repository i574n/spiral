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
  v3: Boolean;
  v5: Boolean;
  v4: Boolean;
  v8: Boolean;
  v6: Boolean;
  v7: Boolean;
  v11: Boolean;
  v9: Boolean;
  v10: Boolean;
  v13: Boolean;
  v12: Boolean;
begin
  v0 := (-2.0);
  v1 := (-1.0);
  v2 := 0.0;
  v3 := v0 < v1;
  if v3 then begin
      v4 := v1 < v2;
      v5 := v4;
  end else begin
      v5 := False;
  end;
  if v5 then begin
      v6 := v0 > v1;
      v7 := v6 = False;
      v8 := v7;
  end else begin
      v8 := False;
  end;
  if v8 then begin
      v9 := v0 >= v1;
      v10 := v9 = False;
      v11 := v10;
  end else begin
      v11 := False;
  end;
  if v11 then begin
      v12 := v1 <= v2;
      v13 := v12;
  end else begin
      v13 := False;
  end;
  if v13 then begin
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
