program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

function SpiralStringIndex(const value: AnsiString; index: LongInt): Byte;
begin
  if (index < 0) or (index >= Length(value)) then raise ERangeError.Create('Spiral string index out of bounds');
  Result := Ord(value[index + 1]);
end;

function SpiralStringSlice(const value: AnsiString; fromIndex, toIndex: LongInt): AnsiString;
begin
  if (fromIndex < 0) or (fromIndex > Length(value)) or (toIndex < fromIndex - 1) or (toIndex >= Length(value)) then raise ERangeError.Create('Spiral string slice out of bounds');
  if (toIndex >= fromIndex) and ((((Ord(value[fromIndex + 1])) and $C0) = $80) or ((toIndex + 1 < Length(value)) and (((Ord(value[toIndex + 2])) and $C0) = $80))) then raise ERangeError.Create('Spiral string slice must preserve UTF-8 codepoint boundaries');
  if toIndex < fromIndex then Result := ''
  else Result := Copy(value, fromIndex + 1, toIndex - fromIndex + 1);
end;

function runtime_byte0(v0: AnsiString; v1: LongInt): Byte;
var
  v2: Byte;
begin
  v2 := SpiralStringIndex(v0, v1);
  Exit(v2);
end;

function codepoint_length_loop1(v0: AnsiString; v1: Byte; v2: Byte; v3: LongInt; v4: LongInt; v5: LongInt): LongInt;
var
  v6: Boolean;
  v7: Byte;
  v8: Boolean;
  v10: Boolean;
  v9: Boolean;
  v12: LongInt;
  v11: LongInt;
  v13: LongInt;
  __spiral_tail_arg0: AnsiString;
  __spiral_tail_arg1: Byte;
  __spiral_tail_arg2: Byte;
  __spiral_tail_arg3: LongInt;
  __spiral_tail_arg4: LongInt;
  __spiral_tail_arg5: LongInt;
begin
  while True do begin
    v6 := (v3 = v5);
    if v6 then begin
      Exit(v4);
    end else begin
      v7 := SpiralStringIndex(v0, v3);
      v8 := (v7 < v1);
      if v8 then begin
        v10 := False;
      end else begin
        v9 := (v7 < v2);
        v10 := v9;
      end;
      if v10 then begin
        v12 := v4;
      end else begin
        v11 := (v4 + 1);
        v12 := v11;
      end;
      v13 := (v3 + 1);
      __spiral_tail_arg0 := v0;
      __spiral_tail_arg1 := v1;
      __spiral_tail_arg2 := v2;
      __spiral_tail_arg3 := v13;
      __spiral_tail_arg4 := v12;
      __spiral_tail_arg5 := v5;
      v0 := __spiral_tail_arg0;
      v1 := __spiral_tail_arg1;
      v2 := __spiral_tail_arg2;
      v3 := __spiral_tail_arg3;
      v4 := __spiral_tail_arg4;
      v5 := __spiral_tail_arg5;
      Continue;
    end;
  end;
end;

function codepoint_byte_offset_loop2(v0: AnsiString; v1: Byte; v2: Byte; v3: LongInt; v4: LongInt; v5: LongInt; v6: LongInt): LongInt;
var
  v7: Boolean;
  v8: Byte;
  v9: Boolean;
  v11: Boolean;
  v10: Boolean;
  v12: LongInt;
  v14: Boolean;
  v15: LongInt;
  v16: LongInt;
  __spiral_tail_arg0: AnsiString;
  __spiral_tail_arg1: Byte;
  __spiral_tail_arg2: Byte;
  __spiral_tail_arg3: LongInt;
  __spiral_tail_arg4: LongInt;
  __spiral_tail_arg5: LongInt;
  __spiral_tail_arg6: LongInt;
begin
  while True do begin
    v7 := (v4 = v6);
    if v7 then begin
      Exit(v6);
    end else begin
      v8 := SpiralStringIndex(v0, v4);
      v9 := (v8 < v1);
      if v9 then begin
        v11 := False;
      end else begin
        v10 := (v8 < v2);
        v11 := v10;
      end;
      if v11 then begin
        v12 := (v4 + 1);
        __spiral_tail_arg0 := v0;
        __spiral_tail_arg1 := v1;
        __spiral_tail_arg2 := v2;
        __spiral_tail_arg3 := v3;
        __spiral_tail_arg4 := v12;
        __spiral_tail_arg5 := v5;
        __spiral_tail_arg6 := v6;
        v0 := __spiral_tail_arg0;
        v1 := __spiral_tail_arg1;
        v2 := __spiral_tail_arg2;
        v3 := __spiral_tail_arg3;
        v4 := __spiral_tail_arg4;
        v5 := __spiral_tail_arg5;
        v6 := __spiral_tail_arg6;
        Continue;
      end else begin
        v14 := (v5 = v3);
        if v14 then begin
          Exit(v4);
        end else begin
          v15 := (v4 + 1);
          v16 := (v5 + 1);
          __spiral_tail_arg0 := v0;
          __spiral_tail_arg1 := v1;
          __spiral_tail_arg2 := v2;
          __spiral_tail_arg3 := v3;
          __spiral_tail_arg4 := v15;
          __spiral_tail_arg5 := v16;
          __spiral_tail_arg6 := v6;
          v0 := __spiral_tail_arg0;
          v1 := __spiral_tail_arg1;
          v2 := __spiral_tail_arg2;
          v3 := __spiral_tail_arg3;
          v4 := __spiral_tail_arg4;
          v5 := __spiral_tail_arg5;
          v6 := __spiral_tail_arg6;
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
  v2: Byte;
  v3: AnsiString;
  v4: LongInt;
  v5: Byte;
  v6: AnsiString;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: Byte;
  v13: LongInt;
  v14: Byte;
  v15: LongInt;
  v16: LongInt;
  v17: LongInt;
  v18: LongInt;
  v19: LongInt;
  v20: LongInt;
  v21: LongInt;
  v22: Byte;
  v23: LongInt;
  v24: Byte;
  v25: LongInt;
  v26: LongInt;
  v27: LongInt;
  v28: LongInt;
  v29: LongInt;
  v30: AnsiString;
  v31: LongInt;
  v32: Byte;
  v33: LongInt;
  v34: Byte;
  v35: LongInt;
  v36: LongInt;
  v37: LongInt;
  v38: LongInt;
  v39: LongInt;
  v40: LongInt;
  v41: LongInt;
  v42: Byte;
  v43: LongInt;
  v44: Byte;
  v45: LongInt;
  v46: LongInt;
  v47: LongInt;
  v48: LongInt;
  v49: LongInt;
  v50: AnsiString;
  v51: LongInt;
  v52: Byte;
  v53: LongInt;
  v54: Byte;
  v55: LongInt;
  v56: LongInt;
  v57: LongInt;
  v58: LongInt;
  v59: LongInt;
  v60: LongInt;
  v61: LongInt;
  v62: Byte;
  v63: LongInt;
  v64: Byte;
  v65: LongInt;
  v66: LongInt;
  v67: LongInt;
  v68: LongInt;
  v69: LongInt;
  v70: AnsiString;
  v71: LongInt;
  v72: Byte;
  v73: LongInt;
  v74: Byte;
  v75: LongInt;
  v76: LongInt;
  v77: LongInt;
  v78: LongInt;
  v79: LongInt;
  v80: LongInt;
  v81: Byte;
  v82: AnsiString;
  v83: LongInt;
  v84: Byte;
  v85: LongInt;
  v86: Byte;
  v87: AnsiString;
  v88: LongInt;
  v89: Byte;
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
  v0 := 'À';
  v1 := 1;
  v2 := runtime_byte0(v0, v1);
  v3 := '©';
  v4 := 0;
  v5 := runtime_byte0(v3, v4);
  v6 := 'Aéλ🙂Z';
  v7 := 0;
  v8 := 0;
  v9 := 10;
  v10 := codepoint_length_loop1(v6, v2, v5, v7, v8, v9);
  v11 := 1;
  v12 := runtime_byte0(v0, v11);
  v13 := 0;
  v14 := runtime_byte0(v3, v13);
  v15 := 1;
  v16 := 0;
  v17 := 0;
  v18 := 10;
  v19 := codepoint_byte_offset_loop2(v6, v12, v14, v15, v16, v17, v18);
  v20 := (1 + 1);
  v21 := 1;
  v22 := runtime_byte0(v0, v21);
  v23 := 0;
  v24 := runtime_byte0(v3, v23);
  v25 := 0;
  v26 := 0;
  v27 := 10;
  v28 := codepoint_byte_offset_loop2(v6, v22, v24, v20, v25, v26, v27);
  v29 := (v28 - 1);
  v30 := SpiralStringSlice('Aéλ🙂Z', v19, v29);
  v31 := 1;
  v32 := runtime_byte0(v0, v31);
  v33 := 0;
  v34 := runtime_byte0(v3, v33);
  v35 := 3;
  v36 := 0;
  v37 := 0;
  v38 := 10;
  v39 := codepoint_byte_offset_loop2(v6, v32, v34, v35, v36, v37, v38);
  v40 := (3 + 1);
  v41 := 1;
  v42 := runtime_byte0(v0, v41);
  v43 := 0;
  v44 := runtime_byte0(v3, v43);
  v45 := 0;
  v46 := 0;
  v47 := 10;
  v48 := codepoint_byte_offset_loop2(v6, v42, v44, v40, v45, v46, v47);
  v49 := (v48 - 1);
  v50 := SpiralStringSlice('Aéλ🙂Z', v39, v49);
  v51 := 1;
  v52 := runtime_byte0(v0, v51);
  v53 := 0;
  v54 := runtime_byte0(v3, v53);
  v55 := 1;
  v56 := 0;
  v57 := 0;
  v58 := 10;
  v59 := codepoint_byte_offset_loop2(v6, v52, v54, v55, v56, v57, v58);
  v60 := (3 + 1);
  v61 := 1;
  v62 := runtime_byte0(v0, v61);
  v63 := 0;
  v64 := runtime_byte0(v3, v63);
  v65 := 0;
  v66 := 0;
  v67 := 10;
  v68 := codepoint_byte_offset_loop2(v6, v62, v64, v60, v65, v66, v67);
  v69 := (v68 - 1);
  v70 := SpiralStringSlice('Aéλ🙂Z', v59, v69);
  v71 := 1;
  v72 := runtime_byte0(v0, v71);
  v73 := 0;
  v74 := runtime_byte0(v3, v73);
  v75 := 3;
  v76 := 0;
  v77 := 0;
  v78 := 10;
  v79 := codepoint_byte_offset_loop2(v6, v72, v74, v75, v76, v77, v78);
  v80 := 0;
  v81 := runtime_byte0(v30, v80);
  v82 := 'é';
  v83 := 0;
  v84 := runtime_byte0(v82, v83);
  v85 := 3;
  v86 := runtime_byte0(v50, v85);
  v87 := '🙂';
  v88 := 3;
  v89 := runtime_byte0(v87, v88);
  v90 := (v10 = 5);
  if v90 then begin
    v91 := Length(v30);
    v92 := (v91 = 2);
    if v92 then begin
      v93 := (v81 = v84);
      if v93 then begin
        v94 := Length(v50);
        v95 := (v94 = 4);
        if v95 then begin
          v96 := (v86 = v89);
          if v96 then begin
            v97 := Length(v70);
            v98 := (v97 = 8);
            if v98 then begin
              v99 := (v79 = 5);
              if v99 then begin
                Exit(0);
              end else begin
                Exit(1);
              end;
            end else begin
              Exit(2);
            end;
          end else begin
            Exit(3);
          end;
        end else begin
          Exit(4);
        end;
      end else begin
        Exit(5);
      end;
    end else begin
      Exit(6);
    end;
  end else begin
    Exit(7);
  end;
end;

begin
  Halt(SpiralMain);
end.
