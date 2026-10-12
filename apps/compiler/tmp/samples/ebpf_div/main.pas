program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongWord;
  v4: LongWord;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongWord;
  v10: LongWord;
  v11: Boolean;
  v13: Boolean;
  v12: Boolean;
  v15: Boolean;
  v14: Boolean;
  v17: Boolean;
  v16: Boolean;
  v19: Boolean;
  v18: Boolean;
  v21: Boolean;
  v20: Boolean;
begin
  v0 := 7;
  v1 := (-2);
  v2 := (-7);
  v3 := 100;
  v4 := 7;
  v5 := v0 div v1;
  v6 := v0 mod v1;
  v7 := v2 div v1;
  v8 := v2 mod v1;
  v9 := v3 div v4;
  v10 := v3 mod v4;
  v11 := v5 = (-3);
  if v11 then begin
      v12 := v6 = 1;
      v13 := v12;
  end else begin
      v13 := False;
  end;
  if v13 then begin
      v14 := v7 = 3;
      v15 := v14;
  end else begin
      v15 := False;
  end;
  if v15 then begin
      v16 := v8 = (-1);
      v17 := v16;
  end else begin
      v17 := False;
  end;
  if v17 then begin
      v18 := v9 = 14;
      v19 := v18;
  end else begin
      v19 := False;
  end;
  if v19 then begin
      v20 := v10 = 2;
      v21 := v20;
  end else begin
      v21 := False;
  end;
  if v21 then begin
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
