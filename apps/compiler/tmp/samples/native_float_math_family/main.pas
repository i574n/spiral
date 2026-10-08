program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: Single;
  v2: Double;
  v3: Double;
  v4: Single;
  v5: Boolean;
  v8: Boolean;
  v6: Double;
  v7: Boolean;
  v11: Boolean;
  v9: Single;
  v10: Boolean;
  v14: Boolean;
  v12: Double;
  v13: Boolean;
  v17: Boolean;
  v15: Single;
  v16: Boolean;
  v20: Boolean;
  v18: Double;
  v19: Boolean;
  v23: Boolean;
  v21: Single;
  v22: Boolean;
  v26: Boolean;
  v24: Double;
  v25: Boolean;
  v29: Boolean;
  v27: Single;
  v28: Boolean;
  v32: Boolean;
  v30: Double;
  v31: Boolean;
begin
  v0 := 0.0;
  v1 := 1.0;
  v2 := 0.0;
  v3 := 1.0;
  v4 := Ln(v1);
  v5 := v4 = v0;
  if v5 then begin
      v6 := Ln(v3);
      v7 := v6 = v2;
      v8 := v7;
  end else begin
      v8 := False;
  end;
  if v8 then begin
      v9 := Exp(v0);
      v10 := v9 = v1;
      v11 := v10;
  end else begin
      v11 := False;
  end;
  if v11 then begin
      v12 := Exp(v2);
      v13 := v12 = v3;
      v14 := v13;
  end else begin
      v14 := False;
  end;
  if v14 then begin
      v15 := Tanh(v0);
      v16 := v15 = v0;
      v17 := v16;
  end else begin
      v17 := False;
  end;
  if v17 then begin
      v18 := Tanh(v2);
      v19 := v18 = v2;
      v20 := v19;
  end else begin
      v20 := False;
  end;
  if v20 then begin
      v21 := Sin(v0);
      v22 := v21 = v0;
      v23 := v22;
  end else begin
      v23 := False;
  end;
  if v23 then begin
      v24 := Sin(v2);
      v25 := v24 = v2;
      v26 := v25;
  end else begin
      v26 := False;
  end;
  if v26 then begin
      v27 := Cos(v0);
      v28 := v27 = v1;
      v29 := v28;
  end else begin
      v29 := False;
  end;
  if v29 then begin
      v30 := Cos(v2);
      v31 := v30 = v3;
      v32 := v31;
  end else begin
      v32 := False;
  end;
  if v32 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
