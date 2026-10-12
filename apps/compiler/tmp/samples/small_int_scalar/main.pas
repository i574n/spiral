program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: ShortInt;
  v1: ShortInt;
  v2: Byte;
  v3: Byte;
  v4: Byte;
  v5: ShortInt;
  v6: ShortInt;
  v7: Byte;
  v8: SmallInt;
  v9: SmallInt;
  v10: Word;
  v11: Word;
  v12: LongInt;
  v13: ShortInt;
  v14: ShortInt;
  v15: LongInt;
  v16: Boolean;
  v18: Boolean;
  v17: Boolean;
  v20: Boolean;
  v19: Boolean;
  v22: Boolean;
  v21: Boolean;
  v24: Boolean;
  v23: Boolean;
  v26: Boolean;
  v25: Boolean;
  v28: Boolean;
  v27: Boolean;
  v30: Boolean;
  v29: Boolean;
begin
  v0 := 100;
  v1 := v0 + v0;
  v2 := 200;
  v3 := 100;
  v4 := v2 + v3;
  v5 := (-8);
  v6 := SarShortint(v5, 1);
  v7 := v2 shr 1;
  v8 := 20000;
  v9 := v8 + v8;
  v10 := 40000;
  v11 := v10 + v10;
  v12 := 7;
  v13 := ShortInt(v12);
  v14 := 9;
  v15 := LongInt(v14);
  v16 := v1 = (-56);
  if v16 then begin
      v17 := v4 = 44;
      v18 := v17;
  end else begin
      v18 := False;
  end;
  if v18 then begin
      v19 := v6 = (-4);
      v20 := v19;
  end else begin
      v20 := False;
  end;
  if v20 then begin
      v21 := v7 = 100;
      v22 := v21;
  end else begin
      v22 := False;
  end;
  if v22 then begin
      v23 := v9 = (-25536);
      v24 := v23;
  end else begin
      v24 := False;
  end;
  if v24 then begin
      v25 := v11 = 14464;
      v26 := v25;
  end else begin
      v26 := False;
  end;
  if v26 then begin
      v27 := v13 = 7;
      v28 := v27;
  end else begin
      v28 := False;
  end;
  if v28 then begin
      v29 := v15 = 9;
      v30 := v29;
  end else begin
      v30 := False;
  end;
  if v30 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
