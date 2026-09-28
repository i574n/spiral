program SpiralGenerated;
{$mode objfpc}{$H+}

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
  v13: LongInt;
  v14: LongInt;
  v15: LongInt;
  v16: LongInt;
  v17: LongInt;
  v18: LongInt;
  v19: LongInt;
  v20: LongInt;
begin
  v0 := 43;
  v1 := 15;
  v2 := 2;
  v3 := 5;
  v4 := (v0 and v1);
  v5 := (v0 or v1);
  v6 := (v0 xor v1);
  v7 := (not v0);
  v8 := (v7 and 255);
  v9 := (1 shl v3);
  v10 := (168 shr v2);
  v11 := (v4 - 11);
  v12 := (v10 + v11);
  v13 := (v5 - 47);
  v14 := (v12 + v13);
  v15 := (v6 - 36);
  v16 := (v14 + v15);
  v17 := (v8 - 212);
  v18 := (v16 + v17);
  v19 := (v9 - 32);
  v20 := (v18 + v19);
  Exit(v20);
end;

begin
  Halt(SpiralMain);
end.
