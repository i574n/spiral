program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: Double;
  v2: Single;
  v3: Double;
  v4: Boolean;
  v6: Boolean;
  v5: Boolean;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
begin
  v0 := NaN;
  v1 := NaN;
  v2 := 1.0;
  v3 := 1.0;
  v4 := IsNan(v0);
  if v4 then begin
      v5 := IsNan(v1);
      v6 := v5;
  end else begin
      v6 := False;
  end;
  if v6 then begin
      v7 := IsNan(v2);
      if v7 then begin
          v9 := True;
      end else begin
          v8 := IsNan(v3);
          v9 := v8;
      end;
      if v9 then begin
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
