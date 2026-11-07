program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongWord;
  v2: LongInt;
  v3: Single;
  v4: Single;
  v5: Single;
  v6: LongWord;
  v7: LongWord;
  v8: LongWord;
  v9: Single;
  v10: LongWord;
  v11: LongInt;
  v12: LongInt;
  v13: LongWord;
  v14: LongInt;
  v15: LongInt;
  v16: LongWord;
  v17: LongWord;
  v18: LongWord;
  v19: LongWord;
  v20: LongWord;
  v21: Boolean;
  v23: Boolean;
  v22: Boolean;
  v26: Boolean;
  v24: Boolean;
  v25: Boolean;
  v27: Boolean;
  v29: Boolean;
  v28: Boolean;
  v31: Boolean;
  v30: Boolean;
  v33: Boolean;
  v32: Boolean;
  v34: Boolean;
  v36: Boolean;
  v35: Boolean;
  v37: Boolean;
  v39: Boolean;
  v38: Boolean;
  v41: Boolean;
  v40: Boolean;
  v42: Boolean;
  v44: Boolean;
  v43: Boolean;
begin
  v0 := (-2147483648);
  v1 := 4294967295;
  v2 := (-1);
  v3 := 0.0;
  v4 := 1.9;
  v5 := 2.9;
  v6 := 4294967294;
  v7 := 5;
  v8 := 0;
  v9 := v3 - v4;
  v10 := LongWord(v0);
  v11 := LongInt(v10);
  v12 := LongInt(v1);
  v13 := LongWord(v2);
  v14 := LongInt(Trunc(v9));
  v15 := LongInt(Trunc(v5));
  v16 := v10 div 2;
  v17 := v6 div 2;
  v18 := v7 mod 3;
  v19 := not v8;
  v20 := v1 shr 31;
  v21 := v0 < (-1);
  if v21 then begin
      v22 := v0 <= v0;
      v23 := v22;
  end else begin
      v23 := False;
  end;
  if v23 then begin
      v24 := v0 > 0;
      v25 := v24 = False;
      v26 := v25;
  end else begin
      v26 := False;
  end;
  if v26 then begin
      v27 := v10 > 1;
      if v27 then begin
          v28 := v11 = v0;
          v29 := v28;
      end else begin
          v29 := False;
      end;
      if v29 then begin
          v30 := v12 = v2;
          v31 := v30;
      end else begin
          v31 := False;
      end;
      if v31 then begin
          v32 := v13 = v1;
          v33 := v32;
      end else begin
          v33 := False;
      end;
      if v33 then begin
          v34 := v14 = v2;
          if v34 then begin
              v35 := v15 = 2;
              v36 := v35;
          end else begin
              v36 := False;
          end;
          if v36 then begin
              v37 := v16 = 1073741824;
              if v37 then begin
                  v38 := v17 = 2147483647;
                  v39 := v38;
              end else begin
                  v39 := False;
              end;
              if v39 then begin
                  v40 := v18 = 2;
                  v41 := v40;
              end else begin
                  v41 := False;
              end;
              if v41 then begin
                  v42 := v19 = v1;
                  if v42 then begin
                      v43 := v20 = 1;
                      v44 := v43;
                  end else begin
                      v44 := False;
                  end;
                  if v44 then begin
                      Result := 0;
                  end else begin
                      Result := 5;
                  end;
              end else begin
                  Result := 4;
              end;
          end else begin
              Result := 3;
          end;
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
