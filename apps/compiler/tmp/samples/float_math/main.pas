program SpiralGenerated;
{$mode objfpc}{$H+}

function method0(v0: Single; v1: Single): Single;
var
  v2: Single;
  v3: Single;
begin
  v2 := (v0 * v1);
  v3 := (v2 + 0.5);
  Exit(v3);
end;

function SpiralMain: LongInt;
var
  v0: Single;
  v1: Single;
  v2: Single;
  v3: Boolean;
begin
  v0 := 1.5;
  v1 := 2.0;
  v2 := method0(v0, v1);
  v3 := (v2 >= 3.5);
  if v3 then begin
    Exit(0);
  end else begin
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
