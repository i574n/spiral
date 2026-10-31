program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; c1_0: LongInt; c1_1: LongInt; end;
function US0_Circle(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Rect(a0: LongInt; a1: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function US0_Empty: TUS0;
begin
  Result.tag := 2; 
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TUS0;
  v2: LongInt;
  v3: LongInt;
  v4: TUS0;
  v5: TUS0;
  v6: LongInt;
  v7: TUS0;
  v18: Boolean;
  tmp9: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: Boolean;
  v11: LongInt;
  v12: LongInt;
  v13: LongInt;
  v14: LongInt;
  v15: Boolean;
  v16: Boolean;
  v19: LongInt;
  v28: LongInt;
  v20: LongInt;
  v21: LongInt;
  v22: LongInt;
  v23: LongInt;
  v24: LongInt;
  v25: LongInt;
  v37: LongInt;
  v29: LongInt;
  v30: LongInt;
  v31: LongInt;
  v32: LongInt;
  v33: LongInt;
  v34: LongInt;
  v38: LongInt;
  v47: LongInt;
  v39: LongInt;
  v40: LongInt;
  v41: LongInt;
  v42: LongInt;
  v43: LongInt;
  v44: LongInt;
  v48: LongInt;
  v49: LongInt;
begin
  v0 := 2;
  v1 := US0_Circle(v0);
  v2 := 3;
  v3 := 4;
  v4 := US0_Rect(v2, v3);
  v5 := US0_Empty;
  v6 := 2;
  v7 := US0_Circle(v6);
  if (v1.tag = v7.tag) then tmp9 := v1.tag else tmp9 := -1;
  case tmp9 of
      0: begin
          v8 := v1.c0_0;
          v9 := v7.c0_0;
          v10 := v8 = v9;
          v18 := v10;
      end;
      2: begin
          v18 := True;
      end;
      1: begin
          v11 := v1.c1_0;
          v12 := v1.c1_1;
          v13 := v7.c1_0;
          v14 := v7.c1_1;
          v15 := v11 = v13;
          if v15 then begin
              v16 := v12 = v14;
              v18 := v16;
          end else begin
              v18 := False;
          end;
      end;
      else begin
          v18 := False;
      end;
  end;
  if v18 then begin
      v19 := 100;
  end else begin
      v19 := 0;
  end;
  case v1.tag of
      0: begin
          v20 := v1.c0_0;
          v21 := 3 * v20;
          v22 := v21 * v20;
          v28 := v22;
      end;
      2: begin
          v28 := 0;
      end;
      1: begin
          v23 := v1.c1_0;
          v24 := v1.c1_1;
          v25 := v23 * v24;
          v28 := v25;
      end;
  end;
  case v4.tag of
      0: begin
          v29 := v4.c0_0;
          v30 := 3 * v29;
          v31 := v30 * v29;
          v37 := v31;
      end;
      2: begin
          v37 := 0;
      end;
      1: begin
          v32 := v4.c1_0;
          v33 := v4.c1_1;
          v34 := v32 * v33;
          v37 := v34;
      end;
  end;
  v38 := v28 + v37;
  case v5.tag of
      0: begin
          v39 := v5.c0_0;
          v40 := 3 * v39;
          v41 := v40 * v39;
          v47 := v41;
      end;
      2: begin
          v47 := 0;
      end;
      1: begin
          v42 := v5.c1_0;
          v43 := v5.c1_1;
          v44 := v42 * v43;
          v47 := v44;
      end;
  end;
  v48 := v38 + v47;
  v49 := v48 + v19;
  Result := v49;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
