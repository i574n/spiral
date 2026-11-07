program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
  v7: AnsiString;
  v8: AnsiString;
  v9: AnsiString;
  v10: AnsiString;
  v11: LongInt;
  v12: Boolean;
  v13: AnsiChar;
  v14: Boolean;
  v15: LongInt;
  v16: Boolean;
  v17: LongInt;
  v18: Boolean;
  v19: AnsiChar;
  v20: Boolean;
  v21: LongInt;
  v22: Boolean;
  v23: AnsiChar;
  v24: Boolean;
  v25: AnsiChar;
  v26: Boolean;
  v27: AnsiChar;
  v28: Boolean;
  v29: AnsiChar;
  v30: Boolean;
  v31: AnsiChar;
  v32: Boolean;
  v33: AnsiChar;
  v34: Boolean;
  v35: LongInt;
  v36: Boolean;
  v37: AnsiChar;
  v38: Boolean;
  v39: AnsiChar;
  v40: Boolean;
  v41: Boolean;
  v42: LongInt;
  v43: Boolean;
  v44: LongInt;
  v45: Boolean;
  v46: AnsiChar;
  v47: Boolean;
  v48: LongInt;
  v49: Boolean;
  v50: AnsiChar;
  v51: Boolean;
  v52: LongInt;
  v53: Boolean;
  v54: AnsiChar;
  v55: Boolean;
  v56: AnsiChar;
  v57: Boolean;
  v58: AnsiChar;
  v59: Boolean;
  v60: AnsiChar;
  v61: Boolean;
  v62: LongInt;
  v63: Boolean;
  v64: AnsiChar;
  v65: Boolean;
begin
  v0 := 16;
  v1 := 'x'#10'y';
  v2 := 'say "hi"';
  v3 := 'a """ b';
  v4 := 'first'#10'    second'#10#10'third';
  v5 := 'ab'#10'cd';
  v6 := 'a "b" c';
  v7 := '';
  v8 := 'a\nb';
  v9 := 'first'#10'(* not a comment *)'#10'// nor this'#10#10'$"not a macro" !x'#10'inl fake () = 1'#10'  indented';
  v10 := #10'top'#10#10'level';
  v11 := LongInt(Length(v6));
  v12 := v11 <> 7;
  if v12 then begin
      Result := 1;
  end else begin
      v13 := v6[2 + 1];
      v14 := v13 <> '"';
      if v14 then begin
          Result := 2;
      end else begin
          v15 := LongInt(Length(v7));
          v16 := v15 <> 0;
          if v16 then begin
              Result := 3;
          end else begin
              v17 := LongInt(Length(v8));
              v18 := v17 <> 4;
              if v18 then begin
                  Result := 4;
              end else begin
                  v19 := v8[1 + 1];
                  v20 := v19 <> '\';
                  if v20 then begin
                      Result := 5;
                  end else begin
                      v21 := LongInt(Length(v9));
                      v22 := v21 <> 83;
                      if v22 then begin
                          Result := 6;
                      end else begin
                          v23 := v9[5 + 1];
                          v24 := v23 <> #10;
                          if v24 then begin
                              Result := 7;
                          end else begin
                              v25 := v9[37 + 1];
                              v26 := v25 <> #10;
                              if v26 then begin
                                  Result := 8;
                              end else begin
                                  v27 := v9[38 + 1];
                                  v28 := v27 <> #10;
                                  if v28 then begin
                                      Result := 9;
                                  end else begin
                                      v29 := v9[39 + 1];
                                      v30 := v29 <> '$';
                                      if v30 then begin
                                          Result := 10;
                                      end else begin
                                          v31 := v9[57 + 1];
                                          v32 := v31 <> 'i';
                                          if v32 then begin
                                              Result := 11;
                                          end else begin
                                              v33 := v9[82 + 1];
                                              v34 := v33 <> 'd';
                                              if v34 then begin
                                                  Result := 12;
                                              end else begin
                                                  v35 := LongInt(Length(v10));
                                                  v36 := v35 <> 11;
                                                  if v36 then begin
                                                      Result := 13;
                                                  end else begin
                                                      v37 := v10[0 + 1];
                                                      v38 := v37 <> #10;
                                                      if v38 then begin
                                                          Result := 14;
                                                      end else begin
                                                          v39 := v10[5 + 1];
                                                          v40 := v39 <> #10;
                                                          if v40 then begin
                                                              Result := 15;
                                                          end else begin
                                                              v41 := v0 <> 16;
                                                              if v41 then begin
                                                                  Result := 16;
                                                              end else begin
                                                                  v42 := LongInt(Length(v1));
                                                                  v43 := v42 <> 3;
                                                                  if v43 then begin
                                                                      Result := 17;
                                                                  end else begin
                                                                      v44 := LongInt(Length(v2));
                                                                      v45 := v44 <> 8;
                                                                      if v45 then begin
                                                                          Result := 18;
                                                                      end else begin
                                                                          v46 := v2[7 + 1];
                                                                          v47 := v46 <> '"';
                                                                          if v47 then begin
                                                                              Result := 19;
                                                                          end else begin
                                                                              v48 := LongInt(Length(v3));
                                                                              v49 := v48 <> 7;
                                                                              if v49 then begin
                                                                                  Result := 20;
                                                                              end else begin
                                                                                  v50 := v3[4 + 1];
                                                                                  v51 := v50 <> '"';
                                                                                  if v51 then begin
                                                                                      Result := 21;
                                                                                  end else begin
                                                                                      v52 := LongInt(Length(v4));
                                                                                      v53 := v52 <> 23;
                                                                                      if v53 then begin
                                                                                          Result := 22;
                                                                                      end else begin
                                                                                          v54 := v4[6 + 1];
                                                                                          v55 := v54 <> ' ';
                                                                                          if v55 then begin
                                                                                              Result := 23;
                                                                                          end else begin
                                                                                              v56 := v4[10 + 1];
                                                                                              v57 := v56 <> 's';
                                                                                              if v57 then begin
                                                                                                  Result := 24;
                                                                                              end else begin
                                                                                                  v58 := v4[17 + 1];
                                                                                                  v59 := v58 <> #10;
                                                                                                  if v59 then begin
                                                                                                      Result := 25;
                                                                                                  end else begin
                                                                                                      v60 := v4[22 + 1];
                                                                                                      v61 := v60 <> 'd';
                                                                                                      if v61 then begin
                                                                                                          Result := 26;
                                                                                                      end else begin
                                                                                                          v62 := LongInt(Length(v5));
                                                                                                          v63 := v62 <> 5;
                                                                                                          if v63 then begin
                                                                                                              Result := 27;
                                                                                                          end else begin
                                                                                                              v64 := v5[3 + 1];
                                                                                                              v65 := v64 <> 'c';
                                                                                                              if v65 then begin
                                                                                                                  Result := 28;
                                                                                                              end else begin
                                                                                                                  Result := 0;
                                                                                                              end;
                                                                                                          end;
                                                                                                      end;
                                                                                                  end;
                                                                                              end;
                                                                                          end;
                                                                                      end;
                                                                                  end;
                                                                              end;
                                                                          end;
                                                                      end;
                                                                  end;
                                                              end;
                                                          end;
                                                      end;
                                                  end;
                                              end;
                                          end;
                                      end;
                                  end;
                              end;
                          end;
                      end;
                  end;
              end;
          end;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
