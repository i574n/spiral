program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: Int64;
  v1: Int64;
  v2: Int64;
  v3: Int64;
  v4: Int64;
  v5: Int64;
  v6: Int64;
  v7: LongInt;
  v8: Int64;
  v9: Int64;
  v10: LongInt;
  v11: QWord;
  v12: QWord;
  v13: QWord;
  v14: QWord;
  v15: Boolean;
  v17: Boolean;
  v16: Boolean;
  v19: Boolean;
  v18: Boolean;
  v21: Boolean;
  v20: Boolean;
  v23: Boolean;
  v22: Boolean;
  v25: Boolean;
  v24: Boolean;
  v27: Boolean;
  v26: Boolean;
  v29: Boolean;
  v28: Boolean;
begin
  v0 := 5000000000;
  v1 := (-4);
  v2 := v0 div v1;
  v3 := 1000000;
  v4 := v3 * v3;
  v5 := (-8);
  v6 := SarInt64(v5, 1);
  v7 := 7;
  v8 := Int64(v7);
  v9 := 9;
  v10 := LongInt(v9);
  v11 := 4294967296;
  v12 := v11 + 1;
  v13 := v11 shr 1;
  v14 := QWord(v7);
  v15 := v2 = (-1250000000);
  if v15 then begin
      v16 := v4 = 1000000000000;
      v17 := v16;
  end else begin
      v17 := False;
  end;
  if v17 then begin
      v18 := v6 = (-4);
      v19 := v18;
  end else begin
      v19 := False;
  end;
  if v19 then begin
      v20 := v8 = 7;
      v21 := v20;
  end else begin
      v21 := False;
  end;
  if v21 then begin
      v22 := v10 = 9;
      v23 := v22;
  end else begin
      v23 := False;
  end;
  if v23 then begin
      v24 := v12 = 4294967297;
      v25 := v24;
  end else begin
      v25 := False;
  end;
  if v25 then begin
      v26 := v13 = 2147483648;
      v27 := v26;
  end else begin
      v27 := False;
  end;
  if v27 then begin
      v28 := v14 = 7;
      v29 := v28;
  end else begin
      v29 := False;
  end;
  if v29 then begin
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
