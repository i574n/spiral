program SpiralGenerated;
{$mode objfpc}{$H+}

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: Boolean;
begin
  v0 := 6;
  v1 := 7;
  v2 := (v0 * v1);
  v3 := (v2 = 42);
  if v3 then begin
    Exit(0);
  end else begin
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
