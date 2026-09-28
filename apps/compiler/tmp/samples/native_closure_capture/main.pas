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
begin
  v0 := 1;
  v1 := 2;
  v2 := ClosureValueCreate0(v0, v1);
  Exit(ClosureInvoke0(v2, 39));
end;

begin
  Halt(SpiralMain);
end.
