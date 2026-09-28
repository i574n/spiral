program SpiralGenerated;
{$mode objfpc}{$H+}

function SpiralMain: LongInt;
var
  v0_0: LongInt;
  v0_1: LongInt;
  v0_2: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0_0 := 2;
  v0_1 := 3;
  v0_2 := 5;
  v1 := v0_0;
  v2 := v0_1;
  v3 := v0_2;
  v4 := (v1 + v2);
  v5 := (v4 + v3);
  v6 := (v5 - 10);
  Exit(v6);
end;

begin
  Halt(SpiralMain);
end.
