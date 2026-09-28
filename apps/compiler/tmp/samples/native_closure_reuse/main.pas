program SpiralGenerated;
{$mode objfpc}{$H+}

type
  ClosureValue0 = record
    v0: LongInt;
    v1: LongInt;
  end;

function ClosureValueCreate0(v0: LongInt; v1: LongInt): ClosureValue0;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

function ClosureInvoke0(x: ClosureValue0; v2: LongInt): LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v0 := x.v0;
  v1 := x.v1;
  v3 := (v0 + v1);
  v4 := (v3 + v2);
  Exit(v4);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: ClosureValue0;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  v0 := 1;
  v1 := 2;
  v2 := ClosureValueCreate0(v0, v1);
  v3 := ClosureInvoke0(v2, 10);
  v4 := ClosureInvoke0(v2, 20);
  v5 := ClosureInvoke0(v2, 3);
  v6 := (v3 + v4);
  v7 := (v6 + v5);
  Exit(v7);
end;

begin
  Halt(SpiralMain);
end.
