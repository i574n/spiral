program SpiralGenerated;
{$mode objfpc}{$H+}

function SpiralMain: LongInt;
var
  v0_0: LongInt;
  v0_1: LongInt;
  v0_2: LongInt;
  v0_3: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
begin
  v0_0 := 2;
  v0_1 := 3;
  v0_2 := 5;
  v0_3 := 7;
  v1 := 1;
  if (v1 = 0) then begin
    v0_0 := 11;
  end;
  if (v1 = 1) then begin
    v0_1 := 11;
  end;
  if (v1 = 2) then begin
    v0_2 := 11;
  end;
  if (v1 = 3) then begin
    v0_3 := 11;
  end;
  v2 := v0_0;
  v3 := v0_1;
  v4 := v0_2;
  v5 := v0_3;
  v6 := (v2 + v3);
  v7 := (v6 + v4);
  v8 := (v7 + v5);
  v9 := (v8 - 25);
  Exit(v9);
end;

begin
  Halt(SpiralMain);
end.
