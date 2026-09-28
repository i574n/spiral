program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple9000 = record
    v0: LongInt;
    v1: Double;
    v2: Double;
    v3: Double;
  end;

function TupleCreate9000(v0: LongInt; v1: Double; v2: Double; v3: Double): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
  Result.v3 := v3;
end;

function method2: LongInt;
var
  v0: Double;
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
begin
  v0 := (0.0 - 5.0);
  v1 := (5.0 * 0.0);
  v2 := (v1 * 0.0);
  v3 := (v2 * 1.0);
  v4 := (v0 * 1.0);
  v5 := (v4 * 0.0);
  v6 := (v5 * 1.0);
  v7 := (v3 - v6);
  v8 := (5.0 * 1.0);
  v9 := (v8 * 0.0);
  v10 := (v7 + v9);
  v11 := (v0 * 0.0);
  v12 := (v11 * 0.0);
  v13 := (v10 + v12);
  v14 := (5.0 * 1.0);
  v15 := (v14 * 1.0);
  v16 := (v13 + v15);
  v17 := (5.0 * 1.0);
  v18 := (v17 * 1.0);
  v19 := (v0 * 0.0);
  v20 := (v19 * 1.0);
  v21 := (v18 + v20);
  v22 := (5.0 * 0.0);
  v23 := (v22 * 0.0);
  v24 := (v23 * 0.0);
  v25 := (v21 - v24);
  v26 := (v0 * 1.0);
  v27 := (v26 * 0.0);
  v28 := (v27 * 0.0);
  v29 := (v25 + v28);
  v30 := (5.0 * 1.0);
  v31 := (v30 * 0.0);
  v32 := (v29 - v31);
  v33 := (v0 * 1.0);
  v34 := (v33 * 1.0);
  v35 := (5.0 * 0.0);
  v36 := (v35 * 1.0);
  v37 := (v34 - v36);
  v38 := (5.0 * 0.0);
  v39 := (v37 + v38);
  v40 := (v39 + 100.0);
  v41 := (1.0 / v40);
  v42 := (160.0 / 2.0);
  v43 := (v42 + 40.0);
  v44 := (40.0 * v41);
  v45 := (v44 * v16);
  v46 := (v45 * 2.0);
  v47 := (v43 + v46);
  v48 := (44.0 / 2.0);
  v49 := (40.0 * v41);
  v50 := (v49 * v32);
  v51 := (v48 + v50);
  v52 := (v47 >= 0.0);
  if v52 then begin
    v53 := (v47 < 160.0);
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
    v61 := TupleCreate9000(1, v47, v51, v41);
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
      Exit(14);
    end else begin
      Exit(0);
    end;
  end else begin
    Exit(0);
  end;
end;

function method1: LongInt;
var
  v0: Double;
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
  v71: LongInt;
  v62: Double;
  v63: Double;
  v64: Double;
  v65: Boolean;
  v67: Boolean;
  v66: Boolean;
  v69: Boolean;
  v68: Boolean;
  v72: LongInt;
  v73: LongInt;
begin
  v0 := (0.0 - 10.0);
  v1 := (10.0 * 0.0);
  v2 := (v1 * 0.0);
  v3 := (v2 * 1.0);
  v4 := (v0 * 1.0);
  v5 := (v4 * 0.0);
  v6 := (v5 * 1.0);
  v7 := (v3 - v6);
  v8 := (10.0 * 1.0);
  v9 := (v8 * 0.0);
  v10 := (v7 + v9);
  v11 := (v0 * 0.0);
  v12 := (v11 * 0.0);
  v13 := (v10 + v12);
  v14 := (10.0 * 1.0);
  v15 := (v14 * 1.0);
  v16 := (v13 + v15);
  v17 := (10.0 * 1.0);
  v18 := (v17 * 1.0);
  v19 := (v0 * 0.0);
  v20 := (v19 * 1.0);
  v21 := (v18 + v20);
  v22 := (10.0 * 0.0);
  v23 := (v22 * 0.0);
  v24 := (v23 * 0.0);
  v25 := (v21 - v24);
  v26 := (v0 * 1.0);
  v27 := (v26 * 0.0);
  v28 := (v27 * 0.0);
  v29 := (v25 + v28);
  v30 := (10.0 * 1.0);
  v31 := (v30 * 0.0);
  v32 := (v29 - v31);
  v33 := (v0 * 1.0);
  v34 := (v33 * 1.0);
  v35 := (10.0 * 0.0);
  v36 := (v35 * 1.0);
  v37 := (v34 - v36);
  v38 := (10.0 * 0.0);
  v39 := (v37 + v38);
  v40 := (v39 + 100.0);
  v41 := (1.0 / v40);
  v42 := (160.0 / 2.0);
  v43 := (v42 + 10.0);
  v44 := (40.0 * v41);
  v45 := (v44 * v16);
  v46 := (v45 * 2.0);
  v47 := (v43 + v46);
  v48 := (44.0 / 2.0);
  v49 := (40.0 * v41);
  v50 := (v49 * v32);
  v51 := (v48 + v50);
  v52 := (v47 >= 0.0);
  if v52 then begin
    v53 := (v47 < 160.0);
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
    v61 := TupleCreate9000(1, v47, v51, v41);
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
      v71 := 14;
    end else begin
      v71 := 0;
    end;
  end else begin
    v71 := 0;
  end;
  v72 := method2();
  v73 := (v71 + v72);
  Exit(v73);
end;

function method0: LongInt;
var
  v0: Double;
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
  v52: Double;
  v53: Boolean;
  v55: Boolean;
  v54: Boolean;
  v57: Boolean;
  v56: Boolean;
  v59: Boolean;
  v58: Boolean;
  v62: Tuple9000;
  v72: LongInt;
  v63: Double;
  v64: Double;
  v65: Double;
  v66: Boolean;
  v68: Boolean;
  v67: Boolean;
  v70: Boolean;
  v69: Boolean;
  v73: LongInt;
  v74: LongInt;
begin
  v0 := (0.0 - 40.0);
  v1 := (0.0 - 20.0);
  v2 := (20.0 * 0.0);
  v3 := (v2 * 0.0);
  v4 := (v3 * 1.0);
  v5 := (v1 * 1.0);
  v6 := (v5 * 0.0);
  v7 := (v6 * 1.0);
  v8 := (v4 - v7);
  v9 := (20.0 * 1.0);
  v10 := (v9 * 0.0);
  v11 := (v8 + v10);
  v12 := (v1 * 0.0);
  v13 := (v12 * 0.0);
  v14 := (v11 + v13);
  v15 := (20.0 * 1.0);
  v16 := (v15 * 1.0);
  v17 := (v14 + v16);
  v18 := (20.0 * 1.0);
  v19 := (v18 * 1.0);
  v20 := (v1 * 0.0);
  v21 := (v20 * 1.0);
  v22 := (v19 + v21);
  v23 := (20.0 * 0.0);
  v24 := (v23 * 0.0);
  v25 := (v24 * 0.0);
  v26 := (v22 - v25);
  v27 := (v1 * 1.0);
  v28 := (v27 * 0.0);
  v29 := (v28 * 0.0);
  v30 := (v26 + v29);
  v31 := (20.0 * 1.0);
  v32 := (v31 * 0.0);
  v33 := (v30 - v32);
  v34 := (v1 * 1.0);
  v35 := (v34 * 1.0);
  v36 := (20.0 * 0.0);
  v37 := (v36 * 1.0);
  v38 := (v35 - v37);
  v39 := (20.0 * 0.0);
  v40 := (v38 + v39);
  v41 := (v40 + 100.0);
  v42 := (1.0 / v41);
  v43 := (160.0 / 2.0);
  v44 := (v43 + v0);
  v45 := (40.0 * v42);
  v46 := (v45 * v17);
  v47 := (v46 * 2.0);
  v48 := (v44 + v47);
  v49 := (44.0 / 2.0);
  v50 := (40.0 * v42);
  v51 := (v50 * v33);
  v52 := (v49 + v51);
  v53 := (v48 >= 0.0);
  if v53 then begin
    v54 := (v48 < 160.0);
    v55 := v54;
  end else begin
    v55 := False;
  end;
  if v55 then begin
    v56 := (v52 >= 0.0);
    v57 := v56;
  end else begin
    v57 := False;
  end;
  if v57 then begin
    v58 := (v52 < 44.0);
    v59 := v58;
  end else begin
    v59 := False;
  end;
  if v59 then begin
    v62 := TupleCreate9000(1, v48, v52, v42);
  end else begin
    v62 := TupleCreate9000(0, 0.0, 0.0, 0.0);
  end;
  if (v62.v0 = 1) then begin
    v63 := v62.v1;
    v64 := v62.v2;
    v65 := v62.v3;
    v66 := (v63 >= 0.0);
    if v66 then begin
      v67 := (v64 >= 0.0);
      v68 := v67;
    end else begin
      v68 := False;
    end;
    if v68 then begin
      v69 := (v65 > 0.0);
      v70 := v69;
    end else begin
      v70 := False;
    end;
    if v70 then begin
      v72 := 14;
    end else begin
      v72 := 0;
    end;
  end else begin
    v72 := 0;
  end;
  v73 := method1();
  v74 := (v72 + v73);
  Exit(v74);
end;

function SpiralMain: LongInt;
begin
  Exit(method0());
end;

begin
  Halt(SpiralMain);
end.
