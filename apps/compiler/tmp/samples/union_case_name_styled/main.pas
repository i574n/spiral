program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: Double; end;
  TArray0 = array of AnsiString;
function US0_DeepBlue: TUS0;
begin
  Result.tag := 0; 
end;
function US0_LightGreen(a0: Double): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function US0_Red: TUS0;
begin
  Result.tag := 2; 
end;
function SpiralMain: LongInt;
var
  v0: Double;
  v1: TUS0;
  v2: TUS0;
  v3: TUS0;
  v4: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
  v7: TArray0;
  tmp8: TArray0;
  v8: LongInt;
  v9: AnsiString;
  v10: Boolean;
  v17: Boolean;
  v11: AnsiString;
  v12: AnsiString;
  v13: TArray0;
  tmp16: TArray0;
  v14: LongInt;
  v15: AnsiString;
  v16: Boolean;
  v23: Boolean;
  v18: AnsiString;
  v19: AnsiString;
  v20: TArray0;
  tmp24: TArray0;
  v21: AnsiString;
  v22: Boolean;
  v28: Boolean;
  v24: TArray0;
  tmp29: TArray0;
  v25: LongInt;
  v26: AnsiString;
  v27: Boolean;
  v35: Boolean;
  v29: AnsiString;
  v30: AnsiString;
  v31: AnsiString;
  v32: TArray0;
  tmp38: TArray0;
  v33: AnsiString;
  v34: Boolean;
begin
  v0 := 0.5;
  v1 := US0_LightGreen(v0);
  v2 := US0_DeepBlue;
  v3 := US0_Red;
  v4 := 'deep_blue';
  v5 := 'light_green';
  v6 := 'red';
  SetLength(tmp8, 3);
  tmp8[0] := v4;
  tmp8[1] := v5;
  tmp8[2] := v6;
  v7 := tmp8;
  v8 := v1.tag;
  v9 := v7[v8];
  v10 := v9 = 'light_green';
  if v10 then begin
      v11 := 'deep-blue';
      v12 := 'light-green';
      SetLength(tmp16, 3);
      tmp16[0] := v11;
      tmp16[1] := v12;
      tmp16[2] := v6;
      v13 := tmp16;
      v14 := v2.tag;
      v15 := v13[v14];
      v16 := v15 = 'deep-blue';
      v17 := v16;
  end else begin
      v17 := False;
  end;
  if v17 then begin
      v18 := 'deepblue';
      v19 := 'lightgreen';
      SetLength(tmp24, 3);
      tmp24[0] := v18;
      tmp24[1] := v19;
      tmp24[2] := v6;
      v20 := tmp24;
      v21 := v20[v8];
      v22 := v21 = 'lightgreen';
      v23 := v22;
  end else begin
      v23 := False;
  end;
  if v23 then begin
      SetLength(tmp29, 3);
      tmp29[0] := v4;
      tmp29[1] := v5;
      tmp29[2] := v6;
      v24 := tmp29;
      v25 := v3.tag;
      v26 := v24[v25];
      v27 := v26 = 'red';
      v28 := v27;
  end else begin
      v28 := False;
  end;
  if v28 then begin
      v29 := 'DeepBlue';
      v30 := 'LightGreen';
      v31 := 'Red';
      SetLength(tmp38, 3);
      tmp38[0] := v29;
      tmp38[1] := v30;
      tmp38[2] := v31;
      v32 := tmp38;
      v33 := v32[v8];
      v34 := v33 = 'LightGreen';
      v35 := v34;
  end else begin
      v35 := False;
  end;
  if v35 then begin
      Result := 42;
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
