program SpiralGenerated;
{$mode delphi}{$H+}
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
  v13: Boolean;
  v14: AnsiChar;
  v15: Boolean;
  v16: Boolean;
  v17: LongInt;
  v18: Boolean;
  v19: Boolean;
  v20: LongInt;
  v21: Boolean;
  v22: Boolean;
  v23: AnsiChar;
  v24: Boolean;
  v25: Boolean;
  v26: LongInt;
  v27: Boolean;
  v28: Boolean;
  v29: AnsiChar;
  v30: Boolean;
  v31: Boolean;
  v32: AnsiChar;
  v33: Boolean;
  v34: Boolean;
  v35: AnsiChar;
  v36: Boolean;
  v37: Boolean;
  v38: AnsiChar;
  v39: Boolean;
  v40: Boolean;
  v41: AnsiChar;
  v42: Boolean;
  v43: Boolean;
  v44: AnsiChar;
  v45: Boolean;
  v46: Boolean;
  v47: LongInt;
  v48: Boolean;
  v49: Boolean;
  v50: AnsiChar;
  v51: Boolean;
  v52: Boolean;
  v53: AnsiChar;
  v54: Boolean;
  v55: Boolean;
  v56: Boolean;
  v57: Boolean;
  v58: LongInt;
  v59: Boolean;
  v60: Boolean;
  v61: LongInt;
  v62: Boolean;
  v63: Boolean;
  v64: AnsiChar;
  v65: Boolean;
  v66: Boolean;
  v67: LongInt;
  v68: Boolean;
  v69: Boolean;
  v70: AnsiChar;
  v71: Boolean;
  v72: Boolean;
  v73: LongInt;
  v74: Boolean;
  v75: Boolean;
  v76: AnsiChar;
  v77: Boolean;
  v78: Boolean;
  v79: AnsiChar;
  v80: Boolean;
  v81: Boolean;
  v82: AnsiChar;
  v83: Boolean;
  v84: Boolean;
  v85: AnsiChar;
  v86: Boolean;
  v87: Boolean;
  v88: LongInt;
  v89: Boolean;
  v90: Boolean;
  v91: AnsiChar;
  v92: Boolean;
  v93: Boolean;
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
  v12 := v11 = 7;
  v13 := v12 <> True;
  if v13 then begin
      Result := 1;
  end else begin
      v14 := v6[2 + 1];
      v15 := v14 = '"';
      v16 := v15 <> True;
      if v16 then begin
          Result := 2;
      end else begin
          v17 := LongInt(Length(v7));
          v18 := v17 = 0;
          v19 := v18 <> True;
          if v19 then begin
              Result := 3;
          end else begin
              v20 := LongInt(Length(v8));
              v21 := v20 = 4;
              v22 := v21 <> True;
              if v22 then begin
                  Result := 4;
              end else begin
                  v23 := v8[1 + 1];
                  v24 := v23 = '\';
                  v25 := v24 <> True;
                  if v25 then begin
                      Result := 5;
                  end else begin
                      v26 := LongInt(Length(v9));
                      v27 := v26 = 83;
                      v28 := v27 <> True;
                      if v28 then begin
                          Result := 6;
                      end else begin
                          v29 := v9[5 + 1];
                          v30 := v29 = #10;
                          v31 := v30 <> True;
                          if v31 then begin
                              Result := 7;
                          end else begin
                              v32 := v9[37 + 1];
                              v33 := v32 = #10;
                              v34 := v33 <> True;
                              if v34 then begin
                                  Result := 8;
                              end else begin
                                  v35 := v9[38 + 1];
                                  v36 := v35 = #10;
                                  v37 := v36 <> True;
                                  if v37 then begin
                                      Result := 9;
                                  end else begin
                                      v38 := v9[39 + 1];
                                      v39 := v38 = '$';
                                      v40 := v39 <> True;
                                      if v40 then begin
                                          Result := 10;
                                      end else begin
                                          v41 := v9[57 + 1];
                                          v42 := v41 = 'i';
                                          v43 := v42 <> True;
                                          if v43 then begin
                                              Result := 11;
                                          end else begin
                                              v44 := v9[82 + 1];
                                              v45 := v44 = 'd';
                                              v46 := v45 <> True;
                                              if v46 then begin
                                                  Result := 12;
                                              end else begin
                                                  v47 := LongInt(Length(v10));
                                                  v48 := v47 = 11;
                                                  v49 := v48 <> True;
                                                  if v49 then begin
                                                      Result := 13;
                                                  end else begin
                                                      v50 := v10[0 + 1];
                                                      v51 := v50 = #10;
                                                      v52 := v51 <> True;
                                                      if v52 then begin
                                                          Result := 14;
                                                      end else begin
                                                          v53 := v10[5 + 1];
                                                          v54 := v53 = #10;
                                                          v55 := v54 <> True;
                                                          if v55 then begin
                                                              Result := 15;
                                                          end else begin
                                                              v56 := v0 = 16;
                                                              v57 := v56 <> True;
                                                              if v57 then begin
                                                                  Result := 16;
                                                              end else begin
                                                                  v58 := LongInt(Length(v1));
                                                                  v59 := v58 = 3;
                                                                  v60 := v59 <> True;
                                                                  if v60 then begin
                                                                      Result := 17;
                                                                  end else begin
                                                                      v61 := LongInt(Length(v2));
                                                                      v62 := v61 = 8;
                                                                      v63 := v62 <> True;
                                                                      if v63 then begin
                                                                          Result := 18;
                                                                      end else begin
                                                                          v64 := v2[7 + 1];
                                                                          v65 := v64 = '"';
                                                                          v66 := v65 <> True;
                                                                          if v66 then begin
                                                                              Result := 19;
                                                                          end else begin
                                                                              v67 := LongInt(Length(v3));
                                                                              v68 := v67 = 7;
                                                                              v69 := v68 <> True;
                                                                              if v69 then begin
                                                                                  Result := 20;
                                                                              end else begin
                                                                                  v70 := v3[4 + 1];
                                                                                  v71 := v70 = '"';
                                                                                  v72 := v71 <> True;
                                                                                  if v72 then begin
                                                                                      Result := 21;
                                                                                  end else begin
                                                                                      v73 := LongInt(Length(v4));
                                                                                      v74 := v73 = 23;
                                                                                      v75 := v74 <> True;
                                                                                      if v75 then begin
                                                                                          Result := 22;
                                                                                      end else begin
                                                                                          v76 := v4[6 + 1];
                                                                                          v77 := v76 = ' ';
                                                                                          v78 := v77 <> True;
                                                                                          if v78 then begin
                                                                                              Result := 23;
                                                                                          end else begin
                                                                                              v79 := v4[10 + 1];
                                                                                              v80 := v79 = 's';
                                                                                              v81 := v80 <> True;
                                                                                              if v81 then begin
                                                                                                  Result := 24;
                                                                                              end else begin
                                                                                                  v82 := v4[17 + 1];
                                                                                                  v83 := v82 = #10;
                                                                                                  v84 := v83 <> True;
                                                                                                  if v84 then begin
                                                                                                      Result := 25;
                                                                                                  end else begin
                                                                                                      v85 := v4[22 + 1];
                                                                                                      v86 := v85 = 'd';
                                                                                                      v87 := v86 <> True;
                                                                                                      if v87 then begin
                                                                                                          Result := 26;
                                                                                                      end else begin
                                                                                                          v88 := LongInt(Length(v5));
                                                                                                          v89 := v88 = 5;
                                                                                                          v90 := v89 <> True;
                                                                                                          if v90 then begin
                                                                                                              Result := 27;
                                                                                                          end else begin
                                                                                                              v91 := v5[3 + 1];
                                                                                                              v92 := v91 = 'c';
                                                                                                              v93 := v92 <> True;
                                                                                                              if v93 then begin
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
  Halt(SpiralMain);
end.
