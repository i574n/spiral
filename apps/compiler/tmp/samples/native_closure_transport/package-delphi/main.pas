program SpiralGenerated;
{$mode objfpc}{$H+}

uses SpiralGeneratedUnit;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: ClosureValue0;
  v2: LongInt;
begin
  v0 := 'abc';
  v1 := ClosureValueCreate0(v0);
  v2 := 39;
  Exit(apply0(v1, v2));
end;

begin
  Halt(SpiralMain);
end.
