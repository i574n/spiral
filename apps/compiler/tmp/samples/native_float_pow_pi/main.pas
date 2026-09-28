program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: Single;
  v2: Double;
  v3: Double;
  v4: Single;
  v5: Double;
  v6: Single;
  v7: Boolean;
  v10: Boolean;
  v8: Double;
  v9: Boolean;
  v12: Boolean;
  v11: Boolean;
  v14: Boolean;
  v13: Boolean;
  v16: Boolean;
  v15: Boolean;
  v18: Boolean;
  v17: Boolean;
begin
  v0 := 2.0;
  v1 := 3.0;
  v2 := 2.0;
  v3 := 3.0;
  v4 := 3.1415927;
  v5 := 3.141592653589793;
  v6 := Power(v0, v1);
  v7 := v6 = 8.0;
  if v7 then begin
      v8 := Power(v2, v3);
      v9 := v8 = 8.0;
      v10 := v9;
  end else begin
      v10 := False;
  end;
  if v10 then begin
      v11 := v4 > 3.0;
      v12 := v11;
  end else begin
      v12 := False;
  end;
  if v12 then begin
      v13 := v4 < 4.0;
      v14 := v13;
  end else begin
      v14 := False;
  end;
  if v14 then begin
      v15 := v5 > 3.0;
      v16 := v15;
  end else begin
      v16 := False;
  end;
  if v16 then begin
      v17 := v5 < 4.0;
      v18 := v17;
  end else begin
      v18 := False;
  end;
  if v18 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
begin
  Halt(SpiralMain);
end.
