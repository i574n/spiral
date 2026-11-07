program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; end;
function US0_Some(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_None: TUS0;
begin
  Result.tag := 1; 
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
  v2: AnsiString;
  v3: LongInt;
  v4: AnsiString;
  v5: LongInt;
  v6: AnsiString;
  v7: Boolean;
  v8: Int64;
  v9: LongInt;
  v13: Boolean;
  v10: Boolean;
  v11: Boolean;
  v16: TUS0;
  v18: AnsiString;
  v17: LongInt;
  v19: AnsiString;
  v20: Boolean;
  v21: Int64;
  v22: LongInt;
  v26: Boolean;
  v23: Boolean;
  v24: Boolean;
  v29: TUS0;
  v31: AnsiString;
  v30: LongInt;
  v32: AnsiString;
  v33: Boolean;
  v34: Int64;
  v35: LongInt;
  v39: Boolean;
  v36: Boolean;
  v37: Boolean;
  v42: TUS0;
  v44: AnsiString;
  v43: LongInt;
  v45: AnsiString;
  v46: Boolean;
  v47: Int64;
  v48: LongInt;
  v52: Boolean;
  v49: Boolean;
  v50: Boolean;
  v55: TUS0;
  v57: AnsiString;
  v56: LongInt;
begin
  v0 := 'ff';
  v1 := StrToInt(#36 + v0);
  Writeln(v1);
  v2 := '1011';
  v3 := StrToInt(#37 + v2);
  Writeln(v3);
  v4 := '-42';
  v5 := StrToInt(v4);
  Writeln(v5);
  v6 := ' 123 ';
  v7 := (StrToInt64Def(Trim(v6), 0) = StrToInt64Def(Trim(v6), 1));
  v8 := StrToInt64Def(Trim(v6), 0);
  v9 := LongInt(v8);
  if v7 then begin
      v10 := v8 >= (-2147483648);
      if v10 then begin
          v11 := v8 <= 2147483647;
          v13 := v11;
      end else begin
          v13 := False;
      end;
  end else begin
      v13 := False;
  end;
  if v13 then begin
      v16 := US0_Some(v9);
  end else begin
      v16 := US0_None;
  end;
  case v16.tag of
      1: begin
          v18 := 'none';
          Writeln(v18);
      end;
      0: begin
          v17 := v16.c0_0;
          Writeln(v17);
      end;
  end;
  v19 := '12x';
  v20 := (StrToInt64Def(Trim(v19), 0) = StrToInt64Def(Trim(v19), 1));
  v21 := StrToInt64Def(Trim(v19), 0);
  v22 := LongInt(v21);
  if v20 then begin
      v23 := v21 >= (-2147483648);
      if v23 then begin
          v24 := v21 <= 2147483647;
          v26 := v24;
      end else begin
          v26 := False;
      end;
  end else begin
      v26 := False;
  end;
  if v26 then begin
      v29 := US0_Some(v22);
  end else begin
      v29 := US0_None;
  end;
  case v29.tag of
      1: begin
          v31 := 'none';
          Writeln(v31);
      end;
      0: begin
          v30 := v29.c0_0;
          Writeln(v30);
      end;
  end;
  v32 := '';
  v33 := (StrToInt64Def(Trim(v32), 0) = StrToInt64Def(Trim(v32), 1));
  v34 := StrToInt64Def(Trim(v32), 0);
  v35 := LongInt(v34);
  if v33 then begin
      v36 := v34 >= (-2147483648);
      if v36 then begin
          v37 := v34 <= 2147483647;
          v39 := v37;
      end else begin
          v39 := False;
      end;
  end else begin
      v39 := False;
  end;
  if v39 then begin
      v42 := US0_Some(v35);
  end else begin
      v42 := US0_None;
  end;
  case v42.tag of
      1: begin
          v44 := 'none';
          Writeln(v44);
      end;
      0: begin
          v43 := v42.c0_0;
          Writeln(v43);
      end;
  end;
  v45 := '+7';
  v46 := (StrToInt64Def(Trim(v45), 0) = StrToInt64Def(Trim(v45), 1));
  v47 := StrToInt64Def(Trim(v45), 0);
  v48 := LongInt(v47);
  if v46 then begin
      v49 := v47 >= (-2147483648);
      if v49 then begin
          v50 := v47 <= 2147483647;
          v52 := v50;
      end else begin
          v52 := False;
      end;
  end else begin
      v52 := False;
  end;
  if v52 then begin
      v55 := US0_Some(v48);
  end else begin
      v55 := US0_None;
  end;
  case v55.tag of
      1: begin
          v57 := 'none';
          Writeln(v57);
      end;
      0: begin
          v56 := v55.c0_0;
          Writeln(v56);
      end;
  end;
  Result := 0;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
