program SpiralGenerated;
{$mode objfpc}{$H+}

uses Math;

function SpiralMain: LongInt;
var
  v0: Single;
  v1: Double;
  v2: Single;
  v3: Double;
  v4: Single;
  v5: Double;
  v6: Boolean;
  v8: Boolean;
  v7: Boolean;
  v9: Boolean;
  v11: Boolean;
  v10: Boolean;
  v12: Boolean;
  v14: Boolean;
  v13: Boolean;
begin
  v0 := Infinity;
  v1 := Infinity;
  v2 := (0.0 - v0);
  v3 := (0.0 - v1);
  v4 := 1.0;
  v5 := 1.0;
  v6 := IsNan(v4);
  if v6 then begin
    v8 := True;
  end else begin
    v7 := IsNan(v5);
    v8 := v7;
  end;
  if v8 then begin
    Exit(3);
  end else begin
    v9 := (v0 > v4);
    if v9 then begin
      v10 := (v1 > v5);
      v11 := v10;
    end else begin
      v11 := False;
    end;
    if v11 then begin
      v12 := (v2 < 0.0);
      if v12 then begin
        v13 := (v3 < 0.0);
        v14 := v13;
      end else begin
        v14 := False;
      end;
      if v14 then begin
        Exit(0);
      end else begin
        Exit(2);
      end;
    end else begin
      Exit(1);
    end;
  end;
end;

begin
  Halt(SpiralMain);
end.
