program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: LongInt;
  v6: Boolean;
  v7: Boolean;
  v8: AnsiChar;
  v9: Boolean;
  v10: Boolean;
  v11: LongInt;
  v12: Boolean;
  v13: Boolean;
  v14: LongInt;
  v15: Boolean;
  v16: Boolean;
  v17: AnsiChar;
  v18: Boolean;
  v19: Boolean;
  v20: LongInt;
  v21: Boolean;
  v22: Boolean;
  v23: AnsiChar;
  v24: Boolean;
  v25: Boolean;
  v26: AnsiChar;
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
  v41: LongInt;
  v42: Boolean;
  v43: Boolean;
  v44: AnsiChar;
  v45: Boolean;
  v46: Boolean;
  v47: AnsiChar;
  v48: Boolean;
  v49: Boolean;
begin
  v0 := 'a "b" c';
  v1 := '';
  v2 := 'a\nb';
  v3 := 'first'#10'(* not a comment *)'#10'// nor this'#10#10'$"not a macro" !x'#10'inl fake () = 1'#10'  indented';
  v4 := #10'top'#10#10'level';
  v5 := LongInt(Length(v0));
  v6 := v5 = 7;
  v7 := v6 <> True;
  if v7 then begin
      Result := 1;
  end else begin
      v8 := v0[2 + 1];
      v9 := v8 = '"';
      v10 := v9 <> True;
      if v10 then begin
          Result := 2;
      end else begin
          v11 := LongInt(Length(v1));
          v12 := v11 = 0;
          v13 := v12 <> True;
          if v13 then begin
              Result := 3;
          end else begin
              v14 := LongInt(Length(v2));
              v15 := v14 = 4;
              v16 := v15 <> True;
              if v16 then begin
                  Result := 4;
              end else begin
                  v17 := v2[1 + 1];
                  v18 := v17 = '\';
                  v19 := v18 <> True;
                  if v19 then begin
                      Result := 5;
                  end else begin
                      v20 := LongInt(Length(v3));
                      v21 := v20 = 83;
                      v22 := v21 <> True;
                      if v22 then begin
                          Result := 6;
                      end else begin
                          v23 := v3[5 + 1];
                          v24 := v23 = #10;
                          v25 := v24 <> True;
                          if v25 then begin
                              Result := 7;
                          end else begin
                              v26 := v3[37 + 1];
                              v27 := v26 = #10;
                              v28 := v27 <> True;
                              if v28 then begin
                                  Result := 8;
                              end else begin
                                  v29 := v3[38 + 1];
                                  v30 := v29 = #10;
                                  v31 := v30 <> True;
                                  if v31 then begin
                                      Result := 9;
                                  end else begin
                                      v32 := v3[39 + 1];
                                      v33 := v32 = '$';
                                      v34 := v33 <> True;
                                      if v34 then begin
                                          Result := 10;
                                      end else begin
                                          v35 := v3[57 + 1];
                                          v36 := v35 = 'i';
                                          v37 := v36 <> True;
                                          if v37 then begin
                                              Result := 11;
                                          end else begin
                                              v38 := v3[82 + 1];
                                              v39 := v38 = 'd';
                                              v40 := v39 <> True;
                                              if v40 then begin
                                                  Result := 12;
                                              end else begin
                                                  v41 := LongInt(Length(v4));
                                                  v42 := v41 = 11;
                                                  v43 := v42 <> True;
                                                  if v43 then begin
                                                      Result := 13;
                                                  end else begin
                                                      v44 := v4[0 + 1];
                                                      v45 := v44 = #10;
                                                      v46 := v45 <> True;
                                                      if v46 then begin
                                                          Result := 14;
                                                      end else begin
                                                          v47 := v4[5 + 1];
                                                          v48 := v47 = #10;
                                                          v49 := v48 <> True;
                                                          if v49 then begin
                                                              Result := 15;
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
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
