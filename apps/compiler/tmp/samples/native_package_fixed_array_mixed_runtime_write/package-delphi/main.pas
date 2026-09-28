program SpiralGenerated;
{$mode objfpc}{$H+}

uses SpiralWorkerFixed;

function SpiralMain: LongInt;
begin
  Exit(method0(0, 1, 0, 1, 30));
end;

begin
  Halt(SpiralMain);
end.
