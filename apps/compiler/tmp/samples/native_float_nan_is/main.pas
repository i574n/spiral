program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v3: Single;
  v7: Double;
  v8: Single;
  v9: Double;
  v10: Boolean;
  v12: Boolean;
  v11: Boolean;
  v13: Boolean;
  v15: Boolean;
  v14: Boolean;
begin
  v3 := NaN;
  v7 := NaN;
  v8 := 1.0;
  v9 := 1.0;
  v10 := IsNan(v3);
  if v10 then begin
      v11 := IsNan(v7);
      v12 := v11;
  end else begin
      v12 := False;
  end;
  if v12 then begin
      v13 := IsNan(v8);
      if v13 then begin
          v15 := True;
      end else begin
          v14 := IsNan(v9);
          v15 := v14;
      end;
      if v15 then begin
          Result := 2;
      end else begin
          Result := 0;
      end;
  end else begin
      Result := 1;
  end;
end;
begin
  Halt(SpiralMain);
end.
