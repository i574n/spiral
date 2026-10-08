program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v4: Single;
  v9: Double;
  v10: Single;
  v11: Double;
  v12: Boolean;
  v14: Boolean;
  v13: Boolean;
  v15: Boolean;
  v17: Boolean;
  v16: Boolean;
begin
  v4 := NaN;
  v9 := NaN;
  v10 := 1.0;
  v11 := 1.0;
  v12 := IsNan(v4);
  if v12 then begin
      v13 := IsNan(v9);
      v14 := v13;
  end else begin
      v14 := False;
  end;
  if v14 then begin
      v15 := IsNan(v10);
      if v15 then begin
          v17 := True;
      end else begin
          v16 := IsNan(v11);
          v17 := v16;
      end;
      if v17 then begin
          Result := 2;
      end else begin
          Result := 0;
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
