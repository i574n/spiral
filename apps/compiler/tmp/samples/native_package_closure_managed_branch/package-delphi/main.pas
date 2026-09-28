program SpiralGenerated;
{$mode objfpc}{$H+}

uses SpiralTypesCallable, SpiralSelectorSelect, SpiralConsumerUse;

function SpiralMain: LongInt;
var
  selected: ClosureValue0;
begin
  selected := select0(True);
  Exit(method0(selected));
end;

begin
  Halt(SpiralMain);
end.
