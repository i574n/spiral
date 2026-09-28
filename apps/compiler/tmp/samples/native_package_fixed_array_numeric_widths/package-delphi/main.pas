program SpiralGenerated;
{$mode objfpc}{$H+}

uses SpiralWorkerFixed;

function SpiralMain: LongInt;
begin
  Exit(method0(0, 1, 0, 0, 30, 2.5));
end;

begin
  Halt(SpiralMain);
end.
