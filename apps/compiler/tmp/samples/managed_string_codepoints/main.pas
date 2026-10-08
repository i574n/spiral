program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function StringSlice(const value: AnsiString; from, upto: Int64): AnsiString;
var len: Int64;
begin
  len := Length(value);
  if (from < 0) or (from > len) or (upto < from - 1) or (upto >= len) then Halt(3);
  if upto < from then Exit('');
  if ((Ord(value[from + 1]) and $C0) = $80) or ((upto + 1 < len) and ((Ord(value[upto + 2]) and $C0) = $80)) then Halt(3);
  Result := Copy(value, from + 1, upto - from + 1);
end;
function runtime_byte_0(v0: AnsiString; v1: LongInt): AnsiChar; forward;
function codepoint_length_loop_1(v0: AnsiString; v1: AnsiChar; v2: AnsiChar; v3: LongInt; v4: LongInt; v5: LongInt): LongInt; forward;
function codepoint_byte_offset_loop_2(v0: AnsiString; v1: AnsiChar; v2: AnsiChar; v3: LongInt; v4: LongInt; v5: LongInt; v6: LongInt): LongInt; forward;
function runtime_byte_0(v0: AnsiString; v1: LongInt): AnsiChar;
var
  v2: AnsiChar;
begin
  v2 := v0[v1 + 1];
  Result := v2;
end;
function codepoint_length_loop_1(v0: AnsiString; v1: AnsiChar; v2: AnsiChar; v3: LongInt; v4: LongInt; v5: LongInt): LongInt;
var
  v6: Boolean;
  v7: AnsiChar;
  v8: Boolean;
  v10: Boolean;
  v9: Boolean;
  v12: LongInt;
  v11: LongInt;
  v13: LongInt;
  tmp8: AnsiString;
  tmp9: AnsiChar;
  tmp10: AnsiChar;
  tmp11: LongInt;
  tmp12: LongInt;
  tmp13: LongInt;
begin
  while True do begin
      v6 := v3 = v5;
      if v6 then begin
          Result := v4;
          Exit;
      end else begin
          v7 := v0[v3 + 1];
          v8 := v7 < v1;
          if v8 then begin
              v10 := False;
          end else begin
              v9 := v7 < v2;
              v10 := v9;
          end;
          if v10 then begin
              v12 := v4;
          end else begin
              v11 := v4 + 1;
              v12 := v11;
          end;
          v13 := v3 + 1;
          tmp8 := v0;
          tmp9 := v1;
          tmp10 := v2;
          tmp11 := v13;
          tmp12 := v12;
          tmp13 := v5;
          v0 := tmp8;
          v1 := tmp9;
          v2 := tmp10;
          v3 := tmp11;
          v4 := tmp12;
          v5 := tmp13;
          Continue;
      end;
  end;
end;
function codepoint_byte_offset_loop_2(v0: AnsiString; v1: AnsiChar; v2: AnsiChar; v3: LongInt; v4: LongInt; v5: LongInt; v6: LongInt): LongInt;
var
  v7: Boolean;
  v8: AnsiChar;
  v9: Boolean;
  v11: Boolean;
  v10: Boolean;
  v12: LongInt;
  tmp6: AnsiString;
  tmp7: AnsiChar;
  tmp8: AnsiChar;
  tmp9: LongInt;
  tmp10: LongInt;
  tmp11: LongInt;
  tmp12: LongInt;
  v14: Boolean;
  v15: LongInt;
  v16: LongInt;
  tmp16: AnsiString;
  tmp17: AnsiChar;
  tmp18: AnsiChar;
  tmp19: LongInt;
  tmp20: LongInt;
  tmp21: LongInt;
  tmp22: LongInt;
begin
  while True do begin
      v7 := v4 = v6;
      if v7 then begin
          Result := v6;
          Exit;
      end else begin
          v8 := v0[v4 + 1];
          v9 := v8 < v1;
          if v9 then begin
              v11 := False;
          end else begin
              v10 := v8 < v2;
              v11 := v10;
          end;
          if v11 then begin
              v12 := v4 + 1;
              tmp6 := v0;
              tmp7 := v1;
              tmp8 := v2;
              tmp9 := v3;
              tmp10 := v12;
              tmp11 := v5;
              tmp12 := v6;
              v0 := tmp6;
              v1 := tmp7;
              v2 := tmp8;
              v3 := tmp9;
              v4 := tmp10;
              v5 := tmp11;
              v6 := tmp12;
              Continue;
          end else begin
              v14 := v5 = v3;
              if v14 then begin
                  Result := v4;
                  Exit;
              end else begin
                  v15 := v4 + 1;
                  v16 := v5 + 1;
                  tmp16 := v0;
                  tmp17 := v1;
                  tmp18 := v2;
                  tmp19 := v3;
                  tmp20 := v15;
                  tmp21 := v16;
                  tmp22 := v6;
                  v0 := tmp16;
                  v1 := tmp17;
                  v2 := tmp18;
                  v3 := tmp19;
                  v4 := tmp20;
                  v5 := tmp21;
                  v6 := tmp22;
                  Continue;
              end;
          end;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
  v2: AnsiChar;
  v3: AnsiString;
  v4: LongInt;
  v5: AnsiChar;
  v6: AnsiString;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: AnsiChar;
  v13: LongInt;
  v14: AnsiChar;
  v15: LongInt;
  v16: LongInt;
  v17: LongInt;
  v18: LongInt;
  v19: LongInt;
  v20: LongInt;
  v21: AnsiChar;
  v22: LongInt;
  v23: AnsiChar;
  v24: LongInt;
  v25: LongInt;
  v26: LongInt;
  v27: LongInt;
  v28: LongInt;
  v29: LongInt;
  v30: AnsiString;
  v31: LongInt;
  v32: AnsiChar;
  v33: LongInt;
  v34: AnsiChar;
  v35: LongInt;
  v36: LongInt;
  v37: LongInt;
  v38: LongInt;
  v39: LongInt;
  v40: LongInt;
  v41: AnsiChar;
  v42: LongInt;
  v43: AnsiChar;
  v44: LongInt;
  v45: LongInt;
  v46: LongInt;
  v47: LongInt;
  v48: LongInt;
  v49: LongInt;
  v50: AnsiString;
  v51: LongInt;
  v52: AnsiChar;
  v53: LongInt;
  v54: AnsiChar;
  v55: LongInt;
  v56: LongInt;
  v57: LongInt;
  v58: LongInt;
  v59: LongInt;
  v60: LongInt;
  v61: AnsiChar;
  v62: LongInt;
  v63: AnsiChar;
  v64: LongInt;
  v65: LongInt;
  v66: LongInt;
  v67: LongInt;
  v68: LongInt;
  v69: LongInt;
  v70: AnsiString;
  v71: LongInt;
  v72: AnsiChar;
  v73: LongInt;
  v74: AnsiChar;
  v75: LongInt;
  v76: LongInt;
  v77: LongInt;
  v78: LongInt;
  v79: LongInt;
  v80: LongInt;
  v81: AnsiChar;
  v82: AnsiString;
  v83: LongInt;
  v84: AnsiChar;
  v85: LongInt;
  v86: AnsiChar;
  v87: AnsiString;
  v88: LongInt;
  v89: AnsiChar;
  v90: Boolean;
  v91: LongInt;
  v92: Boolean;
  v93: Boolean;
  v94: LongInt;
  v95: Boolean;
  v96: Boolean;
  v97: LongInt;
  v98: Boolean;
  v99: Boolean;
begin
  v0 := #195#128;
  v1 := 1;
  v2 := runtime_byte_0(v0, v1);
  v3 := #194#169;
  v4 := 0;
  v5 := runtime_byte_0(v3, v4);
  v6 := 'A'#195#169#206#187#240#159#153#130'Z';
  v7 := 0;
  v8 := 0;
  v9 := 10;
  v10 := codepoint_length_loop_1(v6, v2, v5, v7, v8, v9);
  v11 := 1;
  v12 := runtime_byte_0(v0, v11);
  v13 := 0;
  v14 := runtime_byte_0(v3, v13);
  v15 := 1;
  v16 := 0;
  v17 := 0;
  v18 := 10;
  v19 := codepoint_byte_offset_loop_2(v6, v12, v14, v15, v16, v17, v18);
  v20 := 1;
  v21 := runtime_byte_0(v0, v20);
  v22 := 0;
  v23 := runtime_byte_0(v3, v22);
  v24 := 2;
  v25 := 0;
  v26 := 0;
  v27 := 10;
  v28 := codepoint_byte_offset_loop_2(v6, v21, v23, v24, v25, v26, v27);
  v29 := v28 - 1;
  v30 := StringSlice('A'#195#169#206#187#240#159#153#130'Z', v19, v29);
  v31 := 1;
  v32 := runtime_byte_0(v0, v31);
  v33 := 0;
  v34 := runtime_byte_0(v3, v33);
  v35 := 3;
  v36 := 0;
  v37 := 0;
  v38 := 10;
  v39 := codepoint_byte_offset_loop_2(v6, v32, v34, v35, v36, v37, v38);
  v40 := 1;
  v41 := runtime_byte_0(v0, v40);
  v42 := 0;
  v43 := runtime_byte_0(v3, v42);
  v44 := 4;
  v45 := 0;
  v46 := 0;
  v47 := 10;
  v48 := codepoint_byte_offset_loop_2(v6, v41, v43, v44, v45, v46, v47);
  v49 := v48 - 1;
  v50 := StringSlice('A'#195#169#206#187#240#159#153#130'Z', v39, v49);
  v51 := 1;
  v52 := runtime_byte_0(v0, v51);
  v53 := 0;
  v54 := runtime_byte_0(v3, v53);
  v55 := 1;
  v56 := 0;
  v57 := 0;
  v58 := 10;
  v59 := codepoint_byte_offset_loop_2(v6, v52, v54, v55, v56, v57, v58);
  v60 := 1;
  v61 := runtime_byte_0(v0, v60);
  v62 := 0;
  v63 := runtime_byte_0(v3, v62);
  v64 := 4;
  v65 := 0;
  v66 := 0;
  v67 := 10;
  v68 := codepoint_byte_offset_loop_2(v6, v61, v63, v64, v65, v66, v67);
  v69 := v68 - 1;
  v70 := StringSlice('A'#195#169#206#187#240#159#153#130'Z', v59, v69);
  v71 := 1;
  v72 := runtime_byte_0(v0, v71);
  v73 := 0;
  v74 := runtime_byte_0(v3, v73);
  v75 := 3;
  v76 := 0;
  v77 := 0;
  v78 := 10;
  v79 := codepoint_byte_offset_loop_2(v6, v72, v74, v75, v76, v77, v78);
  v80 := 0;
  v81 := runtime_byte_0(v30, v80);
  v82 := #195#169;
  v83 := 0;
  v84 := runtime_byte_0(v82, v83);
  v85 := 3;
  v86 := runtime_byte_0(v50, v85);
  v87 := #240#159#153#130;
  v88 := 3;
  v89 := runtime_byte_0(v87, v88);
  v90 := v10 = 5;
  if v90 then begin
      v91 := LongInt(Length(v30));
      v92 := v91 = 2;
      if v92 then begin
          v93 := v81 = v84;
          if v93 then begin
              v94 := LongInt(Length(v50));
              v95 := v94 = 4;
              if v95 then begin
                  v96 := v86 = v89;
                  if v96 then begin
                      v97 := LongInt(Length(v70));
                      v98 := v97 = 8;
                      if v98 then begin
                          v99 := v79 = 5;
                          if v99 then begin
                              Result := 0;
                          end else begin
                              Result := 1;
                          end;
                      end else begin
                          Result := 2;
                      end;
                  end else begin
                      Result := 3;
                  end;
              end else begin
                  Result := 4;
              end;
          end else begin
              Result := 5;
          end;
      end else begin
          Result := 6;
      end;
  end else begin
      Result := 7;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
