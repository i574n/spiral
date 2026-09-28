program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils, Math;

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

function method_while0(v0: LongInt): Boolean;
var
  v1: Boolean;
begin
  v1 := (v0 < 3);
  Exit(v1);
end;

function method_while1(v0: LongInt; v1: LongInt): Boolean;
var
  v2: Boolean;
begin
  v2 := (v1 < v0);
  Exit(v2);
end;

function method0(v0: Array0; v1: Double; v2: Double; v3: Double): LongInt;
var
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
  v52: Double;
  v53: Double;
  v54: Double;
  v55: Double;
  v56: Double;
  v57: Double;
  v58: Double;
  v59: Double;
  v60: Double;
  v61: Boolean;
  v63: Boolean;
  v62: Boolean;
  v65: Boolean;
  v64: Boolean;
  v67: Boolean;
  v66: Boolean;
  v70: Tuple9000;
  v71: Double;
  v72: Double;
  v73: Double;
  v74: Boolean;
  v76: Boolean;
  v75: Boolean;
  v78: Boolean;
  v77: Boolean;
  v79: LongInt;
  v80: LongInt;
  v81: LongInt;
  v82: LongInt;
begin
  v4 := (0.0 - 40.0);
  v5 := (0.0 - 20.0);
  v6 := Sin(v1);
  v7 := (20.0 * v6);
  v8 := Sin(v2);
  v9 := (v7 * v8);
  v10 := Cos(v3);
  v11 := (v9 * v10);
  v12 := Cos(v1);
  v13 := (v5 * v12);
  v14 := (v13 * v8);
  v15 := (v14 * v10);
  v16 := (v11 - v15);
  v17 := (20.0 * v12);
  v18 := Sin(v3);
  v19 := (v17 * v18);
  v20 := (v16 + v19);
  v21 := (v5 * v6);
  v22 := (v21 * v18);
  v23 := (v20 + v22);
  v24 := Cos(v2);
  v25 := (20.0 * v24);
  v26 := (v25 * v10);
  v27 := (v23 + v26);
  v28 := (20.0 * v12);
  v29 := (v28 * v10);
  v30 := (v5 * v6);
  v31 := (v30 * v10);
  v32 := (v29 + v31);
  v33 := (20.0 * v6);
  v34 := (v33 * v8);
  v35 := (v34 * v18);
  v36 := (v32 - v35);
  v37 := (v5 * v12);
  v38 := (v37 * v8);
  v39 := (v38 * v18);
  v40 := (v36 + v39);
  v41 := (20.0 * v24);
  v42 := (v41 * v18);
  v43 := (v40 - v42);
  v44 := (v5 * v12);
  v45 := (v44 * v24);
  v46 := (20.0 * v6);
  v47 := (v46 * v24);
  v48 := (v45 - v47);
  v49 := (20.0 * v8);
  v50 := (v48 + v49);
  v51 := (v50 + 100.0);
  v52 := (1.0 / v51);
  v53 := (80.0 + v4);
  v54 := (40.0 * v52);
  v55 := (v54 * v27);
  v56 := (v55 * 2.0);
  v57 := (v53 + v56);
  v58 := (40.0 * v52);
  v59 := (v58 * v43);
  v60 := (22.0 + v59);
  v61 := (v57 >= 0.0);
  if v61 then begin
    v62 := (v57 < 160.0);
    v63 := v62;
  end else begin
    v63 := False;
  end;
  if v63 then begin
    v64 := (v60 >= 0.0);
    v65 := v64;
  end else begin
    v65 := False;
  end;
  if v65 then begin
    v66 := (v60 < 44.0);
    v67 := v66;
  end else begin
    v67 := False;
  end;
  if v67 then begin
    v70 := TupleCreate9000(1, v57, v60, v52);
  end else begin
    v70 := TupleCreate9000(0, 0.0, 0.0, 0.0);
  end;
  if (v70.v0 = 1) then begin
    v71 := v70.v1;
    v72 := v70.v2;
    v73 := v70.v3;
    v74 := (v71 >= 0.0);
    if v74 then begin
      v75 := (v72 >= 0.0);
      v76 := v75;
    end else begin
      v76 := False;
    end;
    if v76 then begin
      v77 := (v73 > 0.0);
      v78 := v77;
    end else begin
      v78 := False;
    end;
    if v78 then begin
      v79 := LongInt(Trunc(v71));
      v80 := LongInt(Trunc(v72));
      v81 := (v80 * 160);
      v82 := (v79 + v81);
      DynamicArraySet0(v0, v82, 35);
      DynamicArrayDrop0(v0);
      Exit(v82);
    end else begin
      DynamicArrayDrop0(v0);
      Exit(0);
    end;
  end else begin
    DynamicArrayDrop0(v0);
    Exit(0);
  end;
end;

function method1(v0: Array0; v1: Double; v2: Double; v3: Double): LongInt;
var
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
  v52: Double;
  v53: Double;
  v54: Double;
  v55: Double;
  v56: Double;
  v57: Double;
  v58: Double;
  v59: Double;
  v60: Boolean;
  v62: Boolean;
  v61: Boolean;
  v64: Boolean;
  v63: Boolean;
  v66: Boolean;
  v65: Boolean;
  v69: Tuple9000;
  v70: Double;
  v71: Double;
  v72: Double;
  v73: Boolean;
  v75: Boolean;
  v74: Boolean;
  v77: Boolean;
  v76: Boolean;
  v78: LongInt;
  v79: LongInt;
  v80: LongInt;
  v81: LongInt;
begin
  v4 := (0.0 - 10.0);
  v5 := Sin(v1);
  v6 := (10.0 * v5);
  v7 := Sin(v2);
  v8 := (v6 * v7);
  v9 := Cos(v3);
  v10 := (v8 * v9);
  v11 := Cos(v1);
  v12 := (v4 * v11);
  v13 := (v12 * v7);
  v14 := (v13 * v9);
  v15 := (v10 - v14);
  v16 := (10.0 * v11);
  v17 := Sin(v3);
  v18 := (v16 * v17);
  v19 := (v15 + v18);
  v20 := (v4 * v5);
  v21 := (v20 * v17);
  v22 := (v19 + v21);
  v23 := Cos(v2);
  v24 := (10.0 * v23);
  v25 := (v24 * v9);
  v26 := (v22 + v25);
  v27 := (10.0 * v11);
  v28 := (v27 * v9);
  v29 := (v4 * v5);
  v30 := (v29 * v9);
  v31 := (v28 + v30);
  v32 := (10.0 * v5);
  v33 := (v32 * v7);
  v34 := (v33 * v17);
  v35 := (v31 - v34);
  v36 := (v4 * v11);
  v37 := (v36 * v7);
  v38 := (v37 * v17);
  v39 := (v35 + v38);
  v40 := (10.0 * v23);
  v41 := (v40 * v17);
  v42 := (v39 - v41);
  v43 := (v4 * v11);
  v44 := (v43 * v23);
  v45 := (10.0 * v5);
  v46 := (v45 * v23);
  v47 := (v44 - v46);
  v48 := (10.0 * v7);
  v49 := (v47 + v48);
  v50 := (v49 + 100.0);
  v51 := (1.0 / v50);
  v52 := (80.0 + 10.0);
  v53 := (40.0 * v51);
  v54 := (v53 * v26);
  v55 := (v54 * 2.0);
  v56 := (v52 + v55);
  v57 := (40.0 * v51);
  v58 := (v57 * v42);
  v59 := (22.0 + v58);
  v60 := (v56 >= 0.0);
  if v60 then begin
    v61 := (v56 < 160.0);
    v62 := v61;
  end else begin
    v62 := False;
  end;
  if v62 then begin
    v63 := (v59 >= 0.0);
    v64 := v63;
  end else begin
    v64 := False;
  end;
  if v64 then begin
    v65 := (v59 < 44.0);
    v66 := v65;
  end else begin
    v66 := False;
  end;
  if v66 then begin
    v69 := TupleCreate9000(1, v56, v59, v51);
  end else begin
    v69 := TupleCreate9000(0, 0.0, 0.0, 0.0);
  end;
  if (v69.v0 = 1) then begin
    v70 := v69.v1;
    v71 := v69.v2;
    v72 := v69.v3;
    v73 := (v70 >= 0.0);
    if v73 then begin
      v74 := (v71 >= 0.0);
      v75 := v74;
    end else begin
      v75 := False;
    end;
    if v75 then begin
      v76 := (v72 > 0.0);
      v77 := v76;
    end else begin
      v77 := False;
    end;
    if v77 then begin
      v78 := LongInt(Trunc(v70));
      v79 := LongInt(Trunc(v71));
      v80 := (v79 * 160);
      v81 := (v78 + v80);
      DynamicArraySet0(v0, v81, 64);
      DynamicArrayDrop0(v0);
      Exit(v81);
    end else begin
      DynamicArrayDrop0(v0);
      Exit(0);
    end;
  end else begin
    DynamicArrayDrop0(v0);
    Exit(0);
  end;
end;

function method2(v0: Array0; v1: Double; v2: Double; v3: Double): LongInt;
var
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
  v52: Double;
  v53: Double;
  v54: Double;
  v55: Double;
  v56: Double;
  v57: Double;
  v58: Double;
  v59: Double;
  v60: Boolean;
  v62: Boolean;
  v61: Boolean;
  v64: Boolean;
  v63: Boolean;
  v66: Boolean;
  v65: Boolean;
  v69: Tuple9000;
  v70: Double;
  v71: Double;
  v72: Double;
  v73: Boolean;
  v75: Boolean;
  v74: Boolean;
  v77: Boolean;
  v76: Boolean;
  v78: LongInt;
  v79: LongInt;
  v80: LongInt;
  v81: LongInt;
begin
  v4 := (0.0 - 5.0);
  v5 := Sin(v1);
  v6 := (5.0 * v5);
  v7 := Sin(v2);
  v8 := (v6 * v7);
  v9 := Cos(v3);
  v10 := (v8 * v9);
  v11 := Cos(v1);
  v12 := (v4 * v11);
  v13 := (v12 * v7);
  v14 := (v13 * v9);
  v15 := (v10 - v14);
  v16 := (5.0 * v11);
  v17 := Sin(v3);
  v18 := (v16 * v17);
  v19 := (v15 + v18);
  v20 := (v4 * v5);
  v21 := (v20 * v17);
  v22 := (v19 + v21);
  v23 := Cos(v2);
  v24 := (5.0 * v23);
  v25 := (v24 * v9);
  v26 := (v22 + v25);
  v27 := (5.0 * v11);
  v28 := (v27 * v9);
  v29 := (v4 * v5);
  v30 := (v29 * v9);
  v31 := (v28 + v30);
  v32 := (5.0 * v5);
  v33 := (v32 * v7);
  v34 := (v33 * v17);
  v35 := (v31 - v34);
  v36 := (v4 * v11);
  v37 := (v36 * v7);
  v38 := (v37 * v17);
  v39 := (v35 + v38);
  v40 := (5.0 * v23);
  v41 := (v40 * v17);
  v42 := (v39 - v41);
  v43 := (v4 * v11);
  v44 := (v43 * v23);
  v45 := (5.0 * v5);
  v46 := (v45 * v23);
  v47 := (v44 - v46);
  v48 := (5.0 * v7);
  v49 := (v47 + v48);
  v50 := (v49 + 100.0);
  v51 := (1.0 / v50);
  v52 := (80.0 + 40.0);
  v53 := (40.0 * v51);
  v54 := (v53 * v26);
  v55 := (v54 * 2.0);
  v56 := (v52 + v55);
  v57 := (40.0 * v51);
  v58 := (v57 * v42);
  v59 := (22.0 + v58);
  v60 := (v56 >= 0.0);
  if v60 then begin
    v61 := (v56 < 160.0);
    v62 := v61;
  end else begin
    v62 := False;
  end;
  if v62 then begin
    v63 := (v59 >= 0.0);
    v64 := v63;
  end else begin
    v64 := False;
  end;
  if v64 then begin
    v65 := (v59 < 44.0);
    v66 := v65;
  end else begin
    v66 := False;
  end;
  if v66 then begin
    v69 := TupleCreate9000(1, v56, v59, v51);
  end else begin
    v69 := TupleCreate9000(0, 0.0, 0.0, 0.0);
  end;
  if (v69.v0 = 1) then begin
    v70 := v69.v1;
    v71 := v69.v2;
    v72 := v69.v3;
    v73 := (v70 >= 0.0);
    if v73 then begin
      v74 := (v71 >= 0.0);
      v75 := v74;
    end else begin
      v75 := False;
    end;
    if v75 then begin
      v76 := (v72 > 0.0);
      v77 := v76;
    end else begin
      v77 := False;
    end;
    if v77 then begin
      v78 := LongInt(Trunc(v70));
      v79 := LongInt(Trunc(v71));
      v80 := (v79 * 160);
      v81 := (v78 + v80);
      DynamicArraySet0(v0, v81, 43);
      DynamicArrayDrop0(v0);
      Exit(v81);
    end else begin
      DynamicArrayDrop0(v0);
      Exit(0);
    end;
  end else begin
    DynamicArrayDrop0(v0);
    Exit(0);
  end;
end;

function frame_text_loop3(v0: Array0; v1: LongInt; v2: LongInt; v3: LongInt; v4: AnsiString): AnsiString;
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

function runtime_byte6(v0: AnsiString; v1: LongInt): Byte;
var
  v2: Byte;
begin
  v2 := SpiralStringIndex(v0, v1);
  Exit(v2);
end;

function utf8_scalar_at_byte_offset5(v0: AnsiString; v1: LongInt): LongInt;
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
      v7 := runtime_byte6(v0, v1);
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
              v17 := runtime_byte6(v0, v16);
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
                v34 := runtime_byte6(v0, v33);
                v35 := LongInt(Byte(v34));
                v36 := (v1 + 2);
                v37 := runtime_byte6(v0, v36);
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
                  v70 := runtime_byte6(v0, v69);
                  v71 := LongInt(Byte(v70));
                  v72 := (v1 + 2);
                  v73 := runtime_byte6(v0, v72);
                  v74 := LongInt(Byte(v73));
                  v75 := (v1 + 3);
                  v76 := runtime_byte6(v0, v75);
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

function loop4(v0: AnsiString; v1: LongInt; v2: LongInt; v3: LongInt): LongInt;
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
        v7 := utf8_scalar_at_byte_offset5(v0, v2);
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

function method_while2(v0: LongInt): Boolean;
var
  v1: Boolean;
begin
  v1 := (v0 < 4096);
  Exit(v1);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: Array0;
  v3: LongInt;
  v4: LongInt;
  v6: Boolean;
  v11: Double;
  v12: Double;
  v13: Double;
  v7: Boolean;
  v14: LongInt;
  v15: LongInt;
  v17: LongInt;
  v18: LongInt;
  v19: LongInt;
  v20: LongInt;
  v21: LongInt;
  v22: LongInt;
  v23: LongInt;
  v24: AnsiString;
  v25: AnsiString;
  v26: LongInt;
  v27: LongInt;
  v28: LongInt;
  v29: LongInt;
  v30: AnsiString;
  v31: LongInt;
  v32: LongInt;
  v33: LongInt;
  v34: LongInt;
  v35: Boolean;
  v37: Boolean;
  v36: Boolean;
  v38: LongInt;
  v39: Boolean;
  v40: LongInt;
  v41: LongInt;
  v43: LongInt;
  v44: LongInt;
  v45: LongInt;
  v46: LongInt;
  v47: LongInt;
  v48: LongInt;
  v49: LongInt;
  v50: LongInt;
  v51: LongInt;
  v52: LongInt;
  v53: Boolean;
  v55: Boolean;
  v54: Boolean;
  v57: Boolean;
  v56: Boolean;
  v59: Boolean;
  v58: Boolean;
begin
  v0 := (160 * 44);
  v1 := ArrayCreate0(v0, False);
  v2 := ArrayCreate0(3, False);
  v3 := 0;
  v4 := 0;
  while method_while0(v4) do begin
    v6 := (v4 = 0);
    if v6 then begin
      v11 := 0.0;
      v12 := 0.0;
      v13 := 0.0;
    end else begin
      v7 := (v4 = 1);
      if v7 then begin
        v11 := 0.1;
        v12 := 0.05;
        v13 := 0.02;
      end else begin
        v11 := 0.2;
        v12 := 0.1;
        v13 := 0.04;
      end;
    end;
    v14 := (160 * 44);
    v15 := 0;
    while method_while1(v14, v15) do begin
      DynamicArraySet0(v1, v15, 46);
      v17 := (v15 + 1);
      v15 := v17;
    end;
    DynamicArrayClone0(v1);
    v18 := method0(v1, v11, v12, v13);
    DynamicArrayClone0(v1);
    v19 := method1(v1, v11, v12, v13);
    DynamicArrayClone0(v1);
    v20 := method2(v1, v11, v12, v13);
    v21 := 160;
    v22 := (160 * 44);
    v23 := 0;
    v24 := '';
    DynamicArrayClone0(v1);
    v25 := frame_text_loop3(v1, v21, v22, v23, v24);
    v26 := Length(v25);
    v27 := 0;
    v28 := 0;
    v29 := loop4(v25, v26, v27, v28);
    v30 := SpiralStringConcat('[H', v25);
    Write(v30);
    v31 := (v19 * 3);
    v32 := (v18 + v31);
    v33 := (v20 * 7);
    v34 := (v32 + v33);
    v35 := (v26 = 7083);
    if v35 then begin
      v36 := (v29 = 324274);
      v37 := v36;
    end else begin
      v37 := False;
    end;
    if v37 then begin
      v38 := v34;
    end else begin
      v38 := 0;
    end;
    DynamicArraySet0(v2, v4, v38);
    v39 := (v4 < 2);
    if v39 then begin
      v40 := 0;
      v41 := (v4 + 1);
      while method_while2(v40) do begin
        v43 := (v40 mod 17);
        v44 := (v41 + v43);
        v45 := (v44 + 1);
        v46 := (v45 mod 997);
        v41 := v46;
        v47 := (v40 + 1);
        v40 := v47;
      end;
      v48 := (v3 + v41);
      v3 := v48;
    end else begin
    end;
    v49 := (v4 + 1);
    v4 := v49;
  end;
  DynamicArrayDrop0(v1);
  v50 := DynamicArrayGet0(v2, 0);
  v51 := DynamicArrayGet0(v2, 1);
  v52 := DynamicArrayGet0(v2, 2);
  DynamicArrayDrop0(v2);
  v53 := (v50 = 45702);
  if v53 then begin
    v54 := (v51 = 43786);
    v55 := v54;
  end else begin
    v55 := False;
  end;
  if v55 then begin
    v56 := (v52 = 43631);
    v57 := v56;
  end else begin
    v57 := False;
  end;
  if v57 then begin
    v58 := (v3 = 1931);
    v59 := v58;
  end else begin
    v59 := False;
  end;
  if v59 then begin
    Exit(42);
  end else begin
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
