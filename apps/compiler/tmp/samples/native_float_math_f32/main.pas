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
  v10: Boolean;
  v8: Single;
  v9: Boolean;
  v13: Boolean;
  v11: Single;
  v12: Boolean;
  v16: Boolean;
  v14: Single;
  v15: Boolean;
  v19: Boolean;
  v17: Single;
  v18: Boolean;
  v22: Boolean;
  v20: Single;
  v21: Boolean;
  v25: Boolean;
  v23: Single;
  v24: Boolean;
  v27: Boolean;
  v26: Boolean;
  v28: Boolean;
begin
  v0 := 0.0;
  v1 := 1.0;
  v2 := 4.0;
  v3 := 3.0;
  v4 := Infinity;
  v5 := v4 - v4;
  v6 := Sqrt(v2);
  v7 := v6 = 2.0;
  if v7 then begin
      v8 := Exp(v0);
      v9 := v8 = v1;
      v10 := v9;
  end else begin
      v10 := False;
  end;
  if v10 then begin
      v11 := Ln(v1);
      v12 := v11 = v0;
      v13 := v12;
  end else begin
      v13 := False;
  end;
  if v13 then begin
      v14 := Sin(v0);
      v15 := v14 = v0;
      v16 := v15;
  end else begin
      v16 := False;
  end;
  if v16 then begin
      v17 := Cos(v0);
      v18 := v17 = v1;
      v19 := v18;
  end else begin
      v19 := False;
  end;
  if v19 then begin
      v20 := Tanh(v0);
      v21 := v20 = v0;
      v22 := v21;
  end else begin
      v22 := False;
  end;
  if v22 then begin
      v23 := Power(v3, v1);
      v24 := v23 = v3;
      v25 := v24;
  end else begin
      v25 := False;
  end;
  if v25 then begin
      v26 := IsNan(v5);
      v27 := v26;
  end else begin
      v27 := False;
  end;
  if v27 then begin
      v28 := IsNan(v1);
      if v28 then begin
          Result := 2;
      end else begin
          Result := 0;
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
