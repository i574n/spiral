program SpiralGenerated;
{$mode objfpc}{$H+}

function ArrayGet9000(index: LongInt; v0: LongInt; v1: LongInt; v2: LongInt; v3: LongInt): LongInt;
begin
  if (index = 0) then begin
    Exit(v0);
  end;
  if (index = 1) then begin
    Exit(v1);
  end;
  if (index = 2) then begin
    Exit(v2);
  end;
  Exit(v3);
end;

function SpiralMain: LongInt;
var
  v0_0: LongInt;
  v0_1: LongInt;
  v0_2: LongInt;
  v0_3: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v0_0 := 2;
  v0_1 := 3;
  v0_2 := 5;
  v0_3 := 7;
  v1 := 2;
  v2 := ArrayGet9000(v1, v0_0, v0_1, v0_2, v0_3);
  v3 := (v2 - 5);
  Exit(v3);
end;

begin
  Halt(SpiralMain);
end.
