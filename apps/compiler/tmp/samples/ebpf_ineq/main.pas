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
  v5: LongWord;
  v6: Single;
  v7: Single;
  v8: Single;
  v9: Boolean;
  v10: Boolean;
  v11: Boolean;
  v12: Boolean;
  v13: Boolean;
  v14: Boolean;
  v15: Boolean;
  v16: Boolean;
begin
  v0 := (-3);
  v1 := (-4);
  v2 := (-3);
  v3 := 4294967295;
  v4 := 0;
  v5 := 4294967295;
  v6 := (-1.5);
  v7 := (-0.5);
  v8 := (-1.5);
  v9 := v0 <> v1;
  v10 := v0 <> v2;
  v11 := v3 <> v4;
  v12 := v3 <> v5;
  v13 := v6 <> v7;
  v14 := v6 <> v8;
  v15 := v9 and v11;
  v16 := v15 and v13;
  if v16 then begin
      if v10 then begin
          Result := 1;
      end else begin
          if v12 then begin
              Result := 2;
          end else begin
              if v14 then begin
                  Result := 3;
              end else begin
                  Result := 0;
              end;
          end;
      end;
  end else begin
      Result := 4;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
