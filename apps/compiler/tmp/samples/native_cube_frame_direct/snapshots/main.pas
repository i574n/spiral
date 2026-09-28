program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array0 = array of LongInt;
  Tuple9000 = record
    v0: LongInt;
    v1: Double;
    v2: Double;
    v3: Double;
  end;

function SpiralStringIndex(const value: AnsiString; index: LongInt): Byte;
begin
  if (index < 0) or (index >= Length(value)) then raise ERangeError.Create('Spiral string index out of bounds');
  Result := Ord(value[index + 1]);
end;

function SpiralStringConcat(const left, right: AnsiString): AnsiString;
begin
  Result := left + right;
end;

function ArrayCreate0(len: LongInt; init_at_zero: Boolean): Array0;
begin
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  SetLength(Result, len);
  if not init_at_zero then begin end;
end;
procedure DynamicArraySet0(var data: Array0; index: LongInt; value: LongInt);
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  data[index] := value;
end;
function DynamicArrayGet0(const data: Array0; index: LongInt): LongInt;
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  Result := data[index];
end;
function DynamicArrayLen0(const data: Array0): LongInt;
begin
  Result := Length(data);
end;
procedure DynamicArrayClone0(const data: Array0);
begin
end;
procedure DynamicArrayDrop0(var data: Array0);
begin
  SetLength(data, 0);
end;

function TupleCreate9000(v0: LongInt; v1: Double; v2: Double; v3: Double): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
  Result.v3 := v3;
end;

function method_while0(v0: LongInt; v1: LongInt): Boolean;
var
  v2: Boolean;
begin
  v2 := (v1 < v0);
  Exit(v2);
end;

function method0(v0: LongInt): Array0;
var
  v1: Array0;
  v2: LongInt;
  v4: LongInt;
begin
  v1 := ArrayCreate0(v0, False);
  v2 := 0;
  while method_while0(v0, v2) do begin
    DynamicArraySet0(v1, v2, 46);
    v4 := (v2 + 1);
    v2 := v4;
  end;
  Exit(v1);
end;

function method1(v0: Array0): LongInt;
var
  v1: Double;
  v2: Double;
  v3: Double;
  v4: Double;
  v5: Double;
  v6: Double;
  v7: Double;
  v8: Double;
  v9: Double;
  v10: Double;
  v11: Double;
  v12: Double;
  v13: Double;
  v14: Double;
  v15: Double;
  v16: Double;
  v17: Double;
  v18: Double;
  v19: Double;
  v20: Double;
  v21: Double;
  v22: Double;
  v23: Double;
  v24: Double;
  v25: Double;
  v26: Double;
  v27: Double;
  v28: Double;
  v29: Double;
  v30: Double;
  v31: Double;
  v32: Double;
  v33: Double;
  v34: Double;
  v35: Double;
  v36: Double;
  v37: Double;
  v38: Double;
  v39: Double;
  v40: Double;
  v41: Double;
  v42: Double;
  v43: Double;
  v44: Double;
  v45: Double;
  v46: Double;
  v47: Double;
  v48: Double;
  v49: Double;
  v50: Double;
  v51: Double;
  v52: Boolean;
  v54: Boolean;
  v53: Boolean;
  v56: Boolean;
  v55: Boolean;
  v58: Boolean;
  v57: Boolean;
  v61: Tuple9000;
  v62: Double;
  v63: Double;
  v64: Double;
  v65: Boolean;
  v67: Boolean;
  v66: Boolean;
  v69: Boolean;
  v68: Boolean;
  v70: LongInt;
  v71: LongInt;
  v72: LongInt;
  v73: LongInt;
begin
  v1 := (0.0 - 40.0);
  v2 := (0.0 - 20.0);
  v3 := (20.0 * 0.0);
  v4 := (v3 * 0.0);
  v5 := (v4 * 1.0);
  v6 := (v2 * 1.0);
  v7 := (v6 * 0.0);
  v8 := (v7 * 1.0);
  v9 := (v5 - v8);
  v10 := (20.0 * 1.0);
  v11 := (v10 * 0.0);
  v12 := (v9 + v11);
  v13 := (v2 * 0.0);
  v14 := (v13 * 0.0);
  v15 := (v12 + v14);
  v16 := (20.0 * 1.0);
  v17 := (v16 * 1.0);
  v18 := (v15 + v17);
  v19 := (20.0 * 1.0);
  v20 := (v19 * 1.0);
  v21 := (v2 * 0.0);
  v22 := (v21 * 1.0);
  v23 := (v20 + v22);
  v24 := (20.0 * 0.0);
  v25 := (v24 * 0.0);
  v26 := (v25 * 0.0);
  v27 := (v23 - v26);
  v28 := (v2 * 1.0);
  v29 := (v28 * 0.0);
  v30 := (v29 * 0.0);
  v31 := (v27 + v30);
  v32 := (20.0 * 1.0);
  v33 := (v32 * 0.0);
  v34 := (v31 - v33);
  v35 := (v2 * 1.0);
  v36 := (v35 * 1.0);
  v37 := (20.0 * 0.0);
  v38 := (v37 * 1.0);
  v39 := (v36 - v38);
  v40 := (20.0 * 0.0);
  v41 := (v39 + v40);
  v42 := (v41 + 100.0);
  v43 := (1.0 / v42);
  v44 := (80.0 + v1);
  v45 := (40.0 * v43);
  v46 := (v45 * v18);
  v47 := (v46 * 2.0);
  v48 := (v44 + v47);
  v49 := (40.0 * v43);
  v50 := (v49 * v34);
  v51 := (22.0 + v50);
  v52 := (v48 >= 0.0);
  if v52 then begin
    v53 := (v48 < 160.0);
    v54 := v53;
  end else begin
    v54 := False;
  end;
  if v54 then begin
    v55 := (v51 >= 0.0);
    v56 := v55;
  end else begin
    v56 := False;
  end;
  if v56 then begin
    v57 := (v51 < 44.0);
    v58 := v57;
  end else begin
    v58 := False;
  end;
  if v58 then begin
    v61 := TupleCreate9000(1, v48, v51, v43);
  end else begin
    v61 := TupleCreate9000(0, 0.0, 0.0, 0.0);
  end;
  if (v61.v0 = 1) then begin
    v62 := v61.v1;
    v63 := v61.v2;
    v64 := v61.v3;
    v65 := (v62 >= 0.0);
    if v65 then begin
      v66 := (v63 >= 0.0);
      v67 := v66;
    end else begin
      v67 := False;
    end;
    if v67 then begin
      v68 := (v64 > 0.0);
      v69 := v68;
    end else begin
      v69 := False;
    end;
    if v69 then begin
      v70 := LongInt(Trunc(v62));
      v71 := LongInt(Trunc(v63));
      v72 := (v71 * 160);
      v73 := (v70 + v72);
      DynamicArraySet0(v0, v73, 35);
      DynamicArrayDrop0(v0);
      Exit(v73);
    end else begin
      DynamicArrayDrop0(v0);
      Exit(0);
    end;
  end else begin
    DynamicArrayDrop0(v0);
    Exit(0);
  end;
end;

function method2(v0: Array0): LongInt;
var
  v1: Double;
  v2: Double;
  v3: Double;
  v4: Double;
  v5: Double;
  v6: Double;
  v7: Double;
  v8: Double;
  v9: Double;
  v10: Double;
  v11: Double;
  v12: Double;
  v13: Double;
  v14: Double;
  v15: Double;
  v16: Double;
  v17: Double;
  v18: Double;
  v19: Double;
  v20: Double;
  v21: Double;
  v22: Double;
  v23: Double;
  v24: Double;
  v25: Double;
  v26: Double;
  v27: Double;
  v28: Double;
  v29: Double;
  v30: Double;
  v31: Double;
  v32: Double;
  v33: Double;
  v34: Double;
  v35: Double;
  v36: Double;
  v37: Double;
  v38: Double;
  v39: Double;
  v40: Double;
  v41: Double;
  v42: Double;
  v43: Double;
  v44: Double;
  v45: Double;
  v46: Double;
  v47: Double;
  v48: Double;
  v49: Double;
  v50: Double;
  v51: Boolean;
  v53: Boolean;
  v52: Boolean;
  v55: Boolean;
  v54: Boolean;
  v57: Boolean;
  v56: Boolean;
  v60: Tuple9000;
  v61: Double;
  v62: Double;
  v63: Double;
  v64: Boolean;
  v66: Boolean;
  v65: Boolean;
  v68: Boolean;
  v67: Boolean;
  v69: LongInt;
  v70: LongInt;
  v71: LongInt;
  v72: LongInt;
begin
  v1 := (0.0 - 10.0);
  v2 := (10.0 * 0.0);
  v3 := (v2 * 0.0);
  v4 := (v3 * 1.0);
  v5 := (v1 * 1.0);
  v6 := (v5 * 0.0);
  v7 := (v6 * 1.0);
  v8 := (v4 - v7);
  v9 := (10.0 * 1.0);
  v10 := (v9 * 0.0);
  v11 := (v8 + v10);
  v12 := (v1 * 0.0);
  v13 := (v12 * 0.0);
  v14 := (v11 + v13);
  v15 := (10.0 * 1.0);
  v16 := (v15 * 1.0);
  v17 := (v14 + v16);
  v18 := (10.0 * 1.0);
  v19 := (v18 * 1.0);
  v20 := (v1 * 0.0);
  v21 := (v20 * 1.0);
  v22 := (v19 + v21);
  v23 := (10.0 * 0.0);
  v24 := (v23 * 0.0);
  v25 := (v24 * 0.0);
  v26 := (v22 - v25);
  v27 := (v1 * 1.0);
  v28 := (v27 * 0.0);
  v29 := (v28 * 0.0);
  v30 := (v26 + v29);
  v31 := (10.0 * 1.0);
  v32 := (v31 * 0.0);
  v33 := (v30 - v32);
  v34 := (v1 * 1.0);
  v35 := (v34 * 1.0);
  v36 := (10.0 * 0.0);
  v37 := (v36 * 1.0);
  v38 := (v35 - v37);
  v39 := (10.0 * 0.0);
  v40 := (v38 + v39);
  v41 := (v40 + 100.0);
  v42 := (1.0 / v41);
  v43 := (80.0 + 10.0);
  v44 := (40.0 * v42);
  v45 := (v44 * v17);
  v46 := (v45 * 2.0);
  v47 := (v43 + v46);
  v48 := (40.0 * v42);
  v49 := (v48 * v33);
  v50 := (22.0 + v49);
  v51 := (v47 >= 0.0);
  if v51 then begin
    v52 := (v47 < 160.0);
    v53 := v52;
  end else begin
    v53 := False;
  end;
  if v53 then begin
    v54 := (v50 >= 0.0);
    v55 := v54;
  end else begin
    v55 := False;
  end;
  if v55 then begin
    v56 := (v50 < 44.0);
    v57 := v56;
  end else begin
    v57 := False;
  end;
  if v57 then begin
    v60 := TupleCreate9000(1, v47, v50, v42);
  end else begin
    v60 := TupleCreate9000(0, 0.0, 0.0, 0.0);
  end;
  if (v60.v0 = 1) then begin
    v61 := v60.v1;
    v62 := v60.v2;
    v63 := v60.v3;
    v64 := (v61 >= 0.0);
    if v64 then begin
      v65 := (v62 >= 0.0);
      v66 := v65;
    end else begin
      v66 := False;
    end;
    if v66 then begin
      v67 := (v63 > 0.0);
      v68 := v67;
    end else begin
      v68 := False;
    end;
    if v68 then begin
      v69 := LongInt(Trunc(v61));
      v70 := LongInt(Trunc(v62));
      v71 := (v70 * 160);
      v72 := (v69 + v71);
      DynamicArraySet0(v0, v72, 64);
      DynamicArrayDrop0(v0);
      Exit(v72);
    end else begin
      DynamicArrayDrop0(v0);
      Exit(0);
    end;
  end else begin
    DynamicArrayDrop0(v0);
    Exit(0);
  end;
end;

function method3(v0: Array0): LongInt;
var
  v1: Double;
  v2: Double;
  v3: Double;
  v4: Double;
  v5: Double;
  v6: Double;
  v7: Double;
  v8: Double;
  v9: Double;
  v10: Double;
  v11: Double;
  v12: Double;
  v13: Double;
  v14: Double;
  v15: Double;
  v16: Double;
  v17: Double;
  v18: Double;
  v19: Double;
  v20: Double;
  v21: Double;
  v22: Double;
  v23: Double;
  v24: Double;
  v25: Double;
  v26: Double;
  v27: Double;
  v28: Double;
  v29: Double;
  v30: Double;
  v31: Double;
  v32: Double;
  v33: Double;
  v34: Double;
  v35: Double;
  v36: Double;
  v37: Double;
  v38: Double;
  v39: Double;
  v40: Double;
  v41: Double;
  v42: Double;
  v43: Double;
  v44: Double;
  v45: Double;
  v46: Double;
  v47: Double;
  v48: Double;
  v49: Double;
  v50: Double;
  v51: Boolean;
  v53: Boolean;
  v52: Boolean;
  v55: Boolean;
  v54: Boolean;
  v57: Boolean;
  v56: Boolean;
  v60: Tuple9000;
  v61: Double;
  v62: Double;
  v63: Double;
  v64: Boolean;
  v66: Boolean;
  v65: Boolean;
  v68: Boolean;
  v67: Boolean;
  v69: LongInt;
  v70: LongInt;
  v71: LongInt;
  v72: LongInt;
begin
  v1 := (0.0 - 5.0);
  v2 := (5.0 * 0.0);
  v3 := (v2 * 0.0);
  v4 := (v3 * 1.0);
  v5 := (v1 * 1.0);
  v6 := (v5 * 0.0);
  v7 := (v6 * 1.0);
  v8 := (v4 - v7);
  v9 := (5.0 * 1.0);
  v10 := (v9 * 0.0);
  v11 := (v8 + v10);
  v12 := (v1 * 0.0);
  v13 := (v12 * 0.0);
  v14 := (v11 + v13);
  v15 := (5.0 * 1.0);
  v16 := (v15 * 1.0);
  v17 := (v14 + v16);
  v18 := (5.0 * 1.0);
  v19 := (v18 * 1.0);
  v20 := (v1 * 0.0);
  v21 := (v20 * 1.0);
  v22 := (v19 + v21);
  v23 := (5.0 * 0.0);
  v24 := (v23 * 0.0);
  v25 := (v24 * 0.0);
  v26 := (v22 - v25);
  v27 := (v1 * 1.0);
  v28 := (v27 * 0.0);
  v29 := (v28 * 0.0);
  v30 := (v26 + v29);
  v31 := (5.0 * 1.0);
  v32 := (v31 * 0.0);
  v33 := (v30 - v32);
  v34 := (v1 * 1.0);
  v35 := (v34 * 1.0);
  v36 := (5.0 * 0.0);
  v37 := (v36 * 1.0);
  v38 := (v35 - v37);
  v39 := (5.0 * 0.0);
  v40 := (v38 + v39);
  v41 := (v40 + 100.0);
  v42 := (1.0 / v41);
  v43 := (80.0 + 40.0);
  v44 := (40.0 * v42);
  v45 := (v44 * v17);
  v46 := (v45 * 2.0);
  v47 := (v43 + v46);
  v48 := (40.0 * v42);
  v49 := (v48 * v33);
  v50 := (22.0 + v49);
  v51 := (v47 >= 0.0);
  if v51 then begin
    v52 := (v47 < 160.0);
    v53 := v52;
  end else begin
    v53 := False;
  end;
  if v53 then begin
    v54 := (v50 >= 0.0);
    v55 := v54;
  end else begin
    v55 := False;
  end;
  if v55 then begin
    v56 := (v50 < 44.0);
    v57 := v56;
  end else begin
    v57 := False;
  end;
  if v57 then begin
    v60 := TupleCreate9000(1, v47, v50, v42);
  end else begin
    v60 := TupleCreate9000(0, 0.0, 0.0, 0.0);
  end;
  if (v60.v0 = 1) then begin
    v61 := v60.v1;
    v62 := v60.v2;
    v63 := v60.v3;
    v64 := (v61 >= 0.0);
    if v64 then begin
      v65 := (v62 >= 0.0);
      v66 := v65;
    end else begin
      v66 := False;
    end;
    if v66 then begin
      v67 := (v63 > 0.0);
      v68 := v67;
    end else begin
      v68 := False;
    end;
    if v68 then begin
      v69 := LongInt(Trunc(v61));
      v70 := LongInt(Trunc(v62));
      v71 := (v70 * 160);
      v72 := (v69 + v71);
      DynamicArraySet0(v0, v72, 43);
      DynamicArrayDrop0(v0);
      Exit(v72);
    end else begin
      DynamicArrayDrop0(v0);
      Exit(0);
    end;
  end else begin
    DynamicArrayDrop0(v0);
    Exit(0);
  end;
end;

function frame_text_loop4(v0: Array0; v1: LongInt; v2: LongInt; v3: LongInt; v4: AnsiString): AnsiString;
var
  v5: Boolean;
  v6: LongInt;
  v7: Boolean;
  v16: AnsiString;
  v8: AnsiString;
  v9: Boolean;
  v10: AnsiString;
  v11: Boolean;
  v12: AnsiString;
  v13: AnsiString;
  v17: AnsiString;
  v18: LongInt;
  v19: LongInt;
  v20: LongInt;
  v21: Boolean;
  v23: Boolean;
  v22: Boolean;
  v24: AnsiString;
  __spiral_tail_arg0: Array0;
  __spiral_tail_arg1: LongInt;
  __spiral_tail_arg2: LongInt;
  __spiral_tail_arg3: LongInt;
  __spiral_tail_arg4: AnsiString;
begin
  while True do begin
    v5 := (v3 = v2);
    if v5 then begin
      DynamicArrayDrop0(v0);
      Exit(v4);
    end else begin
      v6 := DynamicArrayGet0(v0, v3);
      v7 := (v6 = 35);
      if v7 then begin
        v8 := '#';
        v16 := v8;
      end else begin
        v9 := (v6 = 43);
        if v9 then begin
          v10 := '+';
          v16 := v10;
        end else begin
          v11 := (v6 = 64);
          if v11 then begin
            v12 := '@';
            v16 := v12;
          end else begin
            v13 := '.';
            v16 := v13;
          end;
        end;
      end;
      v17 := SpiralStringConcat(v4, v16);
      v18 := (v3 + 1);
      v19 := (v3 mod v1);
      v20 := (v1 - 1);
      v21 := (v19 = v20);
      if v21 then begin
        v22 := (v18 < v2);
        v23 := v22;
      end else begin
        v23 := False;
      end;
      if v23 then begin
        v24 := SpiralStringConcat(v17, #10);
        __spiral_tail_arg0 := v0;
        __spiral_tail_arg1 := v1;
        __spiral_tail_arg2 := v2;
        __spiral_tail_arg3 := v18;
        __spiral_tail_arg4 := v24;
        DynamicArrayClone0(__spiral_tail_arg0);
        DynamicArrayDrop0(v0);
        v0 := __spiral_tail_arg0;
        v1 := __spiral_tail_arg1;
        v2 := __spiral_tail_arg2;
        v3 := __spiral_tail_arg3;
        v4 := __spiral_tail_arg4;
        Continue;
      end else begin
        __spiral_tail_arg0 := v0;
        __spiral_tail_arg1 := v1;
        __spiral_tail_arg2 := v2;
        __spiral_tail_arg3 := v18;
        __spiral_tail_arg4 := v17;
        DynamicArrayClone0(__spiral_tail_arg0);
        DynamicArrayDrop0(v0);
        v0 := __spiral_tail_arg0;
        v1 := __spiral_tail_arg1;
        v2 := __spiral_tail_arg2;
        v3 := __spiral_tail_arg3;
        v4 := __spiral_tail_arg4;
        Continue;
      end;
    end;
  end;
end;

function runtime_byte7(v0: AnsiString; v1: LongInt): Byte;
var
  v2: Byte;
begin
  v2 := SpiralStringIndex(v0, v1);
  Exit(v2);
end;

function utf8_scalar_at_byte_offset6(v0: AnsiString; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: Boolean;
  v5: Boolean;
  v7: Byte;
  v8: LongInt;
  v9: Boolean;
  v10: Boolean;
  v12: Boolean;
  v13: LongInt;
  v14: Boolean;
  v16: LongInt;
  v17: Byte;
  v18: LongInt;
  v19: Boolean;
  v21: Boolean;
  v20: Boolean;
  v22: LongInt;
  v23: LongInt;
  v24: LongInt;
  v25: LongInt;
  v29: Boolean;
  v30: LongInt;
  v31: Boolean;
  v33: LongInt;
  v34: Byte;
  v35: LongInt;
  v36: LongInt;
  v37: Byte;
  v38: LongInt;
  v39: Boolean;
  v41: Boolean;
  v40: Boolean;
  v42: Boolean;
  v44: Boolean;
  v43: Boolean;
  v45: LongInt;
  v46: LongInt;
  v47: LongInt;
  v48: LongInt;
  v49: LongInt;
  v50: LongInt;
  v51: LongInt;
  v52: Boolean;
  v54: Boolean;
  v55: Boolean;
  v65: Boolean;
  v66: LongInt;
  v67: Boolean;
  v69: LongInt;
  v70: Byte;
  v71: LongInt;
  v72: LongInt;
  v73: Byte;
  v74: LongInt;
  v75: LongInt;
  v76: Byte;
  v77: LongInt;
  v78: Boolean;
  v80: Boolean;
  v79: Boolean;
  v81: Boolean;
  v83: Boolean;
  v82: Boolean;
  v84: Boolean;
  v86: Boolean;
  v85: Boolean;
  v87: LongInt;
  v88: LongInt;
  v89: LongInt;
  v90: LongInt;
  v91: LongInt;
  v92: LongInt;
  v93: LongInt;
  v94: LongInt;
  v95: LongInt;
  v96: LongInt;
  v97: Boolean;
  v99: Boolean;
begin
  v2 := Length(v0);
  v3 := (v1 < 0);
  if v3 then begin
    raise Exception.Create('UTF-8 byte offset is negative.');
  end else begin
    v5 := (v1 >= v2);
    if v5 then begin
      raise Exception.Create('UTF-8 byte offset is outside the string.');
    end else begin
      v7 := runtime_byte7(v0, v1);
      v8 := LongInt(Byte(v7));
      v9 := (v8 < 128);
      if v9 then begin
        Exit(v8);
      end else begin
        v10 := (v8 < 194);
        if v10 then begin
          raise Exception.Create('UTF-8 scalar starts with an invalid lead byte.');
        end else begin
          v12 := (v8 < 224);
          if v12 then begin
            v13 := (v1 + 1);
            v14 := (v13 >= v2);
            if v14 then begin
              raise Exception.Create('UTF-8 sequence is truncated.');
            end else begin
              v16 := (v1 + 1);
              v17 := runtime_byte7(v0, v16);
              v18 := LongInt(Byte(v17));
              v19 := (v18 < 128);
              if v19 then begin
                v21 := False;
              end else begin
                v20 := (v18 < 192);
                v21 := v20;
              end;
              if v21 then begin
                v22 := (v8 - 192);
                v23 := (v22 * 64);
                v24 := (v18 - 128);
                v25 := (v23 + v24);
                Exit(v25);
              end else begin
                raise Exception.Create('UTF-8 sequence has an invalid continuation byte.');
              end;
            end;
          end else begin
            v29 := (v8 < 240);
            if v29 then begin
              v30 := (v1 + 2);
              v31 := (v30 >= v2);
              if v31 then begin
                raise Exception.Create('UTF-8 sequence is truncated.');
              end else begin
                v33 := (v1 + 1);
                v34 := runtime_byte7(v0, v33);
                v35 := LongInt(Byte(v34));
                v36 := (v1 + 2);
                v37 := runtime_byte7(v0, v36);
                v38 := LongInt(Byte(v37));
                v39 := (v35 < 128);
                if v39 then begin
                  v41 := False;
                end else begin
                  v40 := (v35 < 192);
                  v41 := v40;
                end;
                if v41 then begin
                  v42 := (v38 < 128);
                  if v42 then begin
                    v44 := False;
                  end else begin
                    v43 := (v38 < 192);
                    v44 := v43;
                  end;
                  if v44 then begin
                    v45 := (v8 - 224);
                    v46 := (v45 * 4096);
                    v47 := (v35 - 128);
                    v48 := (v47 * 64);
                    v49 := (v46 + v48);
                    v50 := (v38 - 128);
                    v51 := (v49 + v50);
                    v52 := (v51 < 2048);
                    if v52 then begin
                      raise Exception.Create('UTF-8 sequence is overlong.');
                    end else begin
                      v54 := (v51 >= 55296);
                      if v54 then begin
                        v55 := (v51 <= 57343);
                        if v55 then begin
                          raise Exception.Create('UTF-8 sequence encodes a surrogate.');
                        end else begin
                          Exit(v51);
                        end;
                      end else begin
                        Exit(v51);
                      end;
                    end;
                  end else begin
                    raise Exception.Create('UTF-8 sequence has an invalid continuation byte.');
                  end;
                end else begin
                  raise Exception.Create('UTF-8 sequence has an invalid continuation byte.');
                end;
              end;
            end else begin
              v65 := (v8 < 245);
              if v65 then begin
                v66 := (v1 + 3);
                v67 := (v66 >= v2);
                if v67 then begin
                  raise Exception.Create('UTF-8 sequence is truncated.');
                end else begin
                  v69 := (v1 + 1);
                  v70 := runtime_byte7(v0, v69);
                  v71 := LongInt(Byte(v70));
                  v72 := (v1 + 2);
                  v73 := runtime_byte7(v0, v72);
                  v74 := LongInt(Byte(v73));
                  v75 := (v1 + 3);
                  v76 := runtime_byte7(v0, v75);
                  v77 := LongInt(Byte(v76));
                  v78 := (v71 < 128);
                  if v78 then begin
                    v80 := False;
                  end else begin
                    v79 := (v71 < 192);
                    v80 := v79;
                  end;
                  if v80 then begin
                    v81 := (v74 < 128);
                    if v81 then begin
                      v83 := False;
                    end else begin
                      v82 := (v74 < 192);
                      v83 := v82;
                    end;
                    if v83 then begin
                      v84 := (v77 < 128);
                      if v84 then begin
                        v86 := False;
                      end else begin
                        v85 := (v77 < 192);
                        v86 := v85;
                      end;
                      if v86 then begin
                        v87 := (v8 - 240);
                        v88 := (v87 * 262144);
                        v89 := (v71 - 128);
                        v90 := (v89 * 4096);
                        v91 := (v88 + v90);
                        v92 := (v74 - 128);
                        v93 := (v92 * 64);
                        v94 := (v91 + v93);
                        v95 := (v77 - 128);
                        v96 := (v94 + v95);
                        v97 := (v96 < 65536);
                        if v97 then begin
                          raise Exception.Create('UTF-8 sequence is overlong.');
                        end else begin
                          v99 := (v96 > 1114111);
                          if v99 then begin
                            raise Exception.Create('UTF-8 scalar is above U+10FFFF.');
                          end else begin
                            Exit(v96);
                          end;
                        end;
                      end else begin
                        raise Exception.Create('UTF-8 sequence has an invalid continuation byte.');
                      end;
                    end else begin
                      raise Exception.Create('UTF-8 sequence has an invalid continuation byte.');
                    end;
                  end else begin
                    raise Exception.Create('UTF-8 sequence has an invalid continuation byte.');
                  end;
                end;
              end else begin
                raise Exception.Create('UTF-8 scalar starts with an invalid lead byte.');
              end;
            end;
          end;
        end;
      end;
    end;
  end;
end;

function loop5(v0: AnsiString; v1: LongInt; v2: LongInt; v3: LongInt): LongInt;
var
  v4: Boolean;
  v5: Boolean;
  v7: LongInt;
  v8: Boolean;
  v13: LongInt;
  v9: Boolean;
  v10: Boolean;
  v14: LongInt;
  v15: LongInt;
  __spiral_tail_arg0: AnsiString;
  __spiral_tail_arg1: LongInt;
  __spiral_tail_arg2: LongInt;
  __spiral_tail_arg3: LongInt;
begin
  while True do begin
    v4 := (v2 = v1);
    if v4 then begin
      Exit(v3);
    end else begin
      v5 := (v2 > v1);
      if v5 then begin
        raise Exception.Create('UTF-8 scalar width exceeds the string.');
      end else begin
        v7 := utf8_scalar_at_byte_offset6(v0, v2);
        v8 := (v7 < 128);
        if v8 then begin
          v13 := 1;
        end else begin
          v9 := (v7 < 2048);
          if v9 then begin
            v13 := 2;
          end else begin
            v10 := (v7 < 65536);
            if v10 then begin
              v13 := 3;
            end else begin
              v13 := 4;
            end;
          end;
        end;
        v14 := (v2 + v13);
        v15 := (v3 + v7);
        __spiral_tail_arg0 := v0;
        __spiral_tail_arg1 := v1;
        __spiral_tail_arg2 := v14;
        __spiral_tail_arg3 := v15;
        v0 := __spiral_tail_arg0;
        v1 := __spiral_tail_arg1;
        v2 := __spiral_tail_arg2;
        v3 := __spiral_tail_arg3;
        Continue;
      end;
    end;
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: AnsiString;
  v13: AnsiString;
  v14: LongInt;
  v15: LongInt;
  v16: LongInt;
  v17: LongInt;
  v18: LongInt;
  v19: LongInt;
  v20: LongInt;
  v21: LongInt;
  v22: LongInt;
  v23: LongInt;
  v24: LongInt;
  v25: LongInt;
  v26: LongInt;
  v27: LongInt;
  v28: LongInt;
  v29: LongInt;
  v30: Boolean;
  v32: Boolean;
  v31: Boolean;
  v34: Boolean;
  v33: Boolean;
  v36: Boolean;
  v35: Boolean;
  v38: Boolean;
  v37: Boolean;
  v40: Boolean;
  v39: Boolean;
  v42: Boolean;
  v41: Boolean;
  v44: Boolean;
  v43: Boolean;
  v46: Boolean;
  v45: Boolean;
  v48: Boolean;
  v47: Boolean;
  v50: Boolean;
  v49: Boolean;
  v52: Boolean;
  v51: Boolean;
  v54: Boolean;
  v53: Boolean;
  v56: Boolean;
  v55: Boolean;
  v58: Boolean;
  v57: Boolean;
begin
  v0 := (160 * 44);
  v1 := method0(v0);
  DynamicArrayClone0(v1);
  v2 := method1(v1);
  DynamicArrayClone0(v1);
  v3 := method2(v1);
  DynamicArrayClone0(v1);
  v4 := method3(v1);
  v5 := DynamicArrayGet0(v1, 0);
  v6 := DynamicArrayGet0(v1, 5180);
  v7 := DynamicArrayGet0(v1, 4258);
  v8 := DynamicArrayGet0(v1, 3964);
  v9 := 160;
  v10 := (160 * 44);
  v11 := 0;
  v12 := '';
  DynamicArrayClone0(v1);
  v13 := frame_text_loop4(v1, v9, v10, v11, v12);
  DynamicArrayDrop0(v1);
  v14 := Length(v13);
  v15 := 0;
  v16 := 0;
  v17 := loop5(v13, v14, v15, v16);
  v18 := 0;
  v19 := utf8_scalar_at_byte_offset6(v13, v18);
  v20 := 160;
  v21 := utf8_scalar_at_byte_offset6(v13, v20);
  v22 := 3988;
  v23 := utf8_scalar_at_byte_offset6(v13, v22);
  v24 := 4284;
  v25 := utf8_scalar_at_byte_offset6(v13, v24);
  v26 := 5212;
  v27 := utf8_scalar_at_byte_offset6(v13, v26);
  v28 := 7082;
  v29 := utf8_scalar_at_byte_offset6(v13, v28);
  v30 := (v2 = 5180);
  if v30 then begin
    v31 := (v3 = 4258);
    v32 := v31;
  end else begin
    v32 := False;
  end;
  if v32 then begin
    v33 := (v4 = 3964);
    v34 := v33;
  end else begin
    v34 := False;
  end;
  if v34 then begin
    v35 := (v5 = 46);
    v36 := v35;
  end else begin
    v36 := False;
  end;
  if v36 then begin
    v37 := (v6 = 35);
    v38 := v37;
  end else begin
    v38 := False;
  end;
  if v38 then begin
    v39 := (v7 = 64);
    v40 := v39;
  end else begin
    v40 := False;
  end;
  if v40 then begin
    v41 := (v8 = 43);
    v42 := v41;
  end else begin
    v42 := False;
  end;
  if v42 then begin
    v43 := (v14 = 7083);
    v44 := v43;
  end else begin
    v44 := False;
  end;
  if v44 then begin
    v45 := (v17 = 324274);
    v46 := v45;
  end else begin
    v46 := False;
  end;
  if v46 then begin
    v47 := (v19 = 46);
    v48 := v47;
  end else begin
    v48 := False;
  end;
  if v48 then begin
    v49 := (v21 = 10);
    v50 := v49;
  end else begin
    v50 := False;
  end;
  if v50 then begin
    v51 := (v23 = 43);
    v52 := v51;
  end else begin
    v52 := False;
  end;
  if v52 then begin
    v53 := (v25 = 64);
    v54 := v53;
  end else begin
    v54 := False;
  end;
  if v54 then begin
    v55 := (v27 = 35);
    v56 := v55;
  end else begin
    v56 := False;
  end;
  if v56 then begin
    v57 := (v29 = 46);
    v58 := v57;
  end else begin
    v58 := False;
  end;
  if v58 then begin
    Exit(42);
  end else begin
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
