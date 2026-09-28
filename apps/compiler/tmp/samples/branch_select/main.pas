program SpiralGenerated;
{$mode objfpc}{$H+}

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
begin
  v0 := 5;
  v1 := (v0 = 5);
  if v1 then begin
    Exit(0);
  end else begin
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
