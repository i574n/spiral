program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: ShortInt;
  v1: ShortInt;
  v2: ShortInt;
  v3: ShortInt;
  v4: ShortInt;
  v5: ShortInt;
  v6: ShortInt;
  v7: ShortInt;
  v8: ShortInt;
  v9: Byte;
  v10: Byte;
  v11: Byte;
  v12: Byte;
  v13: Byte;
  v14: Byte;
  v15: Byte;
  v16: Byte;
  v17: Byte;
  v18: SmallInt;
  v19: SmallInt;
  v20: SmallInt;
  v21: SmallInt;
  v22: SmallInt;
  v23: Word;
  v24: Word;
  v25: Boolean;
  v27: Boolean;
  v26: Boolean;
  v29: Boolean;
  v28: Boolean;
  v31: Boolean;
  v30: Boolean;
  v33: Boolean;
  v32: Boolean;
  v35: Boolean;
  v34: Boolean;
  v37: Boolean;
  v36: Boolean;
  v39: Boolean;
  v38: Boolean;
  v41: Boolean;
  v40: Boolean;
  v43: Boolean;
  v42: Boolean;
  v45: Boolean;
  v44: Boolean;
  v47: Boolean;
  v46: Boolean;
  v49: Boolean;
  v48: Boolean;
  v51: Boolean;
  v50: Boolean;
  v53: Boolean;
  v52: Boolean;
begin
  v0 := 100;
  v1 := 3;
  v2 := v0 * v1;
  v3 := (-8);
  v4 := 2;
  v5 := v3 div v4;
  v6 := v3 mod v1;
  v7 := -v1;
  v8 := v0 shl 1;
  v9 := 200;
  v10 := 3;
  v11 := v9 div v10;
  v12 := v9 mod v10;
  v13 := 15;
  v14 := v9 and v13;
  v15 := v9 or v13;
  v16 := v9 xor v13;
  v17 := not v13;
  v18 := 20000;
  v19 := 7;
  v20 := v18 div v19;
  v21 := v18 mod v19;
  v22 := -v18;
  v23 := 40000;
  v24 := v23 shl 1;
  v25 := v2 = 44;
  if v25 then begin
      v26 := v5 = (-4);
      v27 := v26;
  end else begin
      v27 := False;
  end;
  if v27 then begin
      v28 := v6 = (-2);
      v29 := v28;
  end else begin
      v29 := False;
  end;
  if v29 then begin
      v30 := v7 = (-3);
      v31 := v30;
  end else begin
      v31 := False;
  end;
  if v31 then begin
      v32 := v8 = (-56);
      v33 := v32;
  end else begin
      v33 := False;
  end;
  if v33 then begin
      v34 := v11 = 66;
      v35 := v34;
  end else begin
      v35 := False;
  end;
  if v35 then begin
      v36 := v12 = 2;
      v37 := v36;
  end else begin
      v37 := False;
  end;
  if v37 then begin
      v38 := v14 = 8;
      v39 := v38;
  end else begin
      v39 := False;
  end;
  if v39 then begin
      v40 := v15 = 207;
      v41 := v40;
  end else begin
      v41 := False;
  end;
  if v41 then begin
      v42 := v16 = 199;
      v43 := v42;
  end else begin
      v43 := False;
  end;
  if v43 then begin
      v44 := v17 = 240;
      v45 := v44;
  end else begin
      v45 := False;
  end;
  if v45 then begin
      v46 := v20 = 2857;
      v47 := v46;
  end else begin
      v47 := False;
  end;
  if v47 then begin
      v48 := v21 = 1;
      v49 := v48;
  end else begin
      v49 := False;
  end;
  if v49 then begin
      v50 := v22 = (-20000);
      v51 := v50;
  end else begin
      v51 := False;
  end;
  if v51 then begin
      v52 := v24 = 14464;
      v53 := v52;
  end else begin
      v53 := False;
  end;
  if v53 then begin
      Result := 0;
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
