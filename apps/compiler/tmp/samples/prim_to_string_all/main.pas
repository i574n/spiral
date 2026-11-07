program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: ShortInt;
  v1: SmallInt;
  v2: LongInt;
  v3: Int64;
  v4: Byte;
  v5: Word;
  v6: LongWord;
  v7: QWord;
  v8: Boolean;
  v9: Boolean;
  v10: AnsiChar;
  v11: AnsiString;
  v12: Boolean;
  v13: LongInt;
  v14: AnsiString;
  v15: Boolean;
  v16: LongInt;
  v17: LongInt;
  v18: AnsiString;
  v19: Boolean;
  v20: LongInt;
  v21: LongInt;
  v22: AnsiString;
  v23: Boolean;
  v24: LongInt;
  v25: LongInt;
  v26: AnsiString;
  v27: Boolean;
  v28: LongInt;
  v29: LongInt;
  v30: AnsiString;
  v31: Boolean;
  v32: LongInt;
  v33: LongInt;
  v34: AnsiString;
  v35: Boolean;
  v36: LongInt;
  v37: LongInt;
  v38: AnsiString;
  v39: Boolean;
  v40: LongInt;
  v41: LongInt;
  v42: AnsiString;
  v43: Boolean;
  v44: LongInt;
  v45: LongInt;
  v46: AnsiString;
  v47: Boolean;
  v48: LongInt;
  v49: LongInt;
  v50: AnsiString;
  v51: Boolean;
  v52: LongInt;
  v53: LongInt;
  v54: AnsiString;
  v55: Boolean;
  v56: LongInt;
  v57: LongInt;
  v58: AnsiString;
  v59: Boolean;
  v60: LongInt;
  v61: LongInt;
  v62: AnsiString;
  v63: Boolean;
  v64: LongInt;
  v65: LongInt;
  v66: AnsiString;
  v67: Boolean;
  v68: LongInt;
  v69: LongInt;
begin
  v0 := (-128);
  v1 := (-32768);
  v2 := (-5);
  v3 := (-1234567890123);
  v4 := 255;
  v5 := 65535;
  v6 := 4294967295;
  v7 := 18446744073709551615;
  v8 := True;
  v9 := False;
  v10 := 'a';
  v11 := IntToStr(Int64(v0));
  v12 := v11 = '-128';
  if v12 then begin
      v13 := 0;
  end else begin
      v13 := 1;
  end;
  v14 := IntToStr(Int64(v1));
  v15 := v14 = '-32768';
  if v15 then begin
      v16 := 0;
  end else begin
      v16 := 1;
  end;
  v17 := v13 + v16;
  v18 := IntToStr(Int64(v2));
  v19 := v18 = '-5';
  if v19 then begin
      v20 := 0;
  end else begin
      v20 := 1;
  end;
  v21 := v17 + v20;
  v22 := IntToStr(Int64(v3));
  v23 := v22 = '-1234567890123';
  if v23 then begin
      v24 := 0;
  end else begin
      v24 := 1;
  end;
  v25 := v21 + v24;
  v26 := UIntToStr(QWord(v4));
  v27 := v26 = '255';
  if v27 then begin
      v28 := 0;
  end else begin
      v28 := 1;
  end;
  v29 := v25 + v28;
  v30 := UIntToStr(QWord(v5));
  v31 := v30 = '65535';
  if v31 then begin
      v32 := 0;
  end else begin
      v32 := 1;
  end;
  v33 := v29 + v32;
  v34 := UIntToStr(QWord(v6));
  v35 := v34 = '4294967295';
  if v35 then begin
      v36 := 0;
  end else begin
      v36 := 1;
  end;
  v37 := v33 + v36;
  v38 := UIntToStr(QWord(v7));
  v39 := v38 = '18446744073709551615';
  if v39 then begin
      v40 := 0;
  end else begin
      v40 := 1;
  end;
  v41 := v37 + v40;
  v42 := LowerCase(BoolToStr(v8, True));
  v43 := v42 = 'true';
  if v43 then begin
      v44 := 0;
  end else begin
      v44 := 1;
  end;
  v45 := v41 + v44;
  v46 := LowerCase(BoolToStr(v9, True));
  v47 := v46 = 'false';
  if v47 then begin
      v48 := 0;
  end else begin
      v48 := 1;
  end;
  v49 := v45 + v48;
  v50 := string(v10);
  v51 := v50 = 'a';
  if v51 then begin
      v52 := 0;
  end else begin
      v52 := 1;
  end;
  v53 := v49 + v52;
  v54 := UIntToStr(QWord(7));
  v55 := v54 = '7';
  if v55 then begin
      v56 := 0;
  end else begin
      v56 := 1;
  end;
  v57 := v53 + v56;
  v58 := LowerCase(BoolToStr(False, True));
  v59 := v58 = 'false';
  if v59 then begin
      v60 := 0;
  end else begin
      v60 := 1;
  end;
  v61 := v57 + v60;
  v62 := string('z');
  v63 := v62 = 'z';
  if v63 then begin
      v64 := 0;
  end else begin
      v64 := 1;
  end;
  v65 := v61 + v64;
  v66 := IntToStr(Int64((-3)));
  v67 := v66 = '-3';
  if v67 then begin
      v68 := 0;
  end else begin
      v68 := 1;
  end;
  v69 := v65 + v68;
  Result := v69;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
