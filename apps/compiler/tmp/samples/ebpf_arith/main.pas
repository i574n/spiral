program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongWord;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: Boolean;
  v10: LongInt;
  v11: Boolean;
  v12: LongInt;
  v13: Boolean;
  v14: LongInt;
  v15: Boolean;
  v16: LongWord;
  v17: Boolean;
  v18: LongWord;
  v19: Boolean;
  v20: LongWord;
  v21: Boolean;
begin
  v0 := 7;
  v1 := 2;
  v2 := 4294967295;
  v3 := -v0;
  v4 := (-3);
  v5 := (-12);
  v6 := (-4);
  v7 := (-1);
  v8 := v3 div v1;
  v9 := v8 = v4;
  if v9 then begin
      v10 := v3 mod v1;
      v11 := v10 = v7;
      if v11 then begin
          v12 := SarLongint(v3, 1);
          v13 := v12 = v6;
          if v13 then begin
              v14 := v4 shl 2;
              v15 := v14 = v5;
              if v15 then begin
                  v16 := v2 + 1;
                  v17 := v16 = 0;
                  if v17 then begin
                      v18 := v2 * v2;
                      v19 := v18 = 1;
                      if v19 then begin
                          v20 := v2 shr 28;
                          v21 := v20 = 15;
                          if v21 then begin
                              Result := 0;
                          end else begin
                              Result := 7;
                          end;
                      end else begin
                          Result := 6;
                      end;
                  end else begin
                      Result := 5;
                  end;
              end else begin
                  Result := 4;
              end;
          end else begin
              Result := 3;
          end;
      end else begin
          Result := 2;
      end;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
