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
  v4: Double;
  v5: Double;
  v6: Double;
  v7: Double;
  v8: LongInt;
  v9: Double;
  v10: Double;
  v11: Double;
  v12: LongInt;
  v13: LongInt;
  v14: Single;
  v15: Double;
  v16: Boolean;
  v18: Boolean;
  v17: Boolean;
  v21: Boolean;
  v19: Double;
  v20: Boolean;
  v23: Boolean;
  v22: Boolean;
  v25: Boolean;
  v24: Boolean;
  v27: Boolean;
  v26: Boolean;
  v29: Boolean;
  v28: Boolean;
begin
  v0 := 1.5;
  v1 := (-2.0);
  v2 := v0 / v1;
  v3 := 1000000.0;
  v4 := v3 * v3;
  v5 := v4 * v3;
  v6 := v5 * 10000.0;
  v7 := v6 * v6;
  v8 := 3;
  v9 := v8;
  v10 := 2.9;
  v11 := (-1.9);
  v12 := LongInt(Trunc(v10));
  v13 := LongInt(Trunc(v11));
  v14 := 1.5;
  v15 := v14;
  v16 := v2 = (-0.75);
  if v16 then begin
      v17 := v7 > v6;
      v18 := v17;
  end else begin
      v18 := False;
  end;
  if v18 then begin
      v19 := v7 * v6;
      v20 := v7 < v19;
      v21 := v20;
  end else begin
      v21 := False;
  end;
  if v21 then begin
      v22 := v9 = 3.0;
      v23 := v22;
  end else begin
      v23 := False;
  end;
  if v23 then begin
      v24 := v12 = 2;
      v25 := v24;
  end else begin
      v25 := False;
  end;
  if v25 then begin
      v26 := v13 = (-1);
      v27 := v26;
  end else begin
      v27 := False;
  end;
  if v27 then begin
      v28 := v15 = 1.5;
      v29 := v28;
  end else begin
      v29 := False;
  end;
  if v29 then begin
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
