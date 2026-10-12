program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongWord;
  v3: Single;
  v4: Single;
  v5: Single;
  v6: Single;
  v7: LongWord;
  v8: Boolean;
  v10: Boolean;
  v9: Boolean;
  v12: Boolean;
  v11: Boolean;
  v14: Boolean;
  v13: Boolean;
begin
  v0 := 3;
  v1 := (-2);
  v2 := 7;
  v3 := 2.9;
  v4 := v0;
  v5 := v1;
  v6 := v2;
  v7 := LongWord(Trunc(v3));
  v8 := v4 = 3.0;
  if v8 then begin
      v9 := v5 = (-2.0);
      v10 := v9;
  end else begin
      v10 := False;
  end;
  if v10 then begin
      v11 := v6 = 7.0;
      v12 := v11;
  end else begin
      v12 := False;
  end;
  if v12 then begin
      v13 := v7 = 2;
      v14 := v13;
  end else begin
      v14 := False;
  end;
  if v14 then begin
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
