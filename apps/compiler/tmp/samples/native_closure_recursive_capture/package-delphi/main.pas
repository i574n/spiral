program SpiralGenerated;
{$mode objfpc}{$H+}

uses SpiralGeneratedUnit;

function SpiralMain: LongInt;
var
  v0: Recursive0;
  v1: LongInt;
  v2: Recursive0;
  v3: ClosureValue0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := RecursiveCreate0_0();
  v1 := 2;
  RecursiveClone0(v0);
  RecursiveClone0(v0);
  v2 := RecursiveCreate0_1(v1, v0, v0);
  RecursiveClone0(v2);
  RecursiveDrop0(v0);
  v3 := ClosureValueCreate0(v2);
  ClosureValueClone0(v3);
  RecursiveDrop0(v2);
  v4 := ClosureInvoke0(v3, 19);
  ClosureValueClone0(v3);
  v5 := ClosureInvoke0(v3, 19);
  ClosureValueDrop0(v3);
  v6 := (v4 + v5);
  Exit(v6);
end;

begin
  Halt(SpiralMain);
end.
