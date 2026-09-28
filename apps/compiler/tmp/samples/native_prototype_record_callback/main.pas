program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple0 = record
    v0: LongInt;
    v1: LongInt;
  end;
  ClosureValue0 = record
    v0: LongInt;
  end;

function TupleCreate0(v0: LongInt; v1: LongInt): Tuple0;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

function ClosureValueCreate0(v0: LongInt): ClosureValue0;
begin
  Result.v0 := v0;
end;

function ClosureInvoke0(x: ClosureValue0; v1: LongInt; v2: LongInt): Tuple0;
var
  v0: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v0 := x.v0;
  v3 := (v1 - 8);
  v4 := (v3 + v0);
  v5 := (v2 - 18);
  Exit(TupleCreate0(v4, v5));
end;

function method0(v0: ClosureValue0): Tuple0;
begin
  Exit(ClosureInvoke0(v0, 10, 20));
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: ClosureValue0;
  v2: LongInt;
  v3: LongInt;
  tmp0: Tuple0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  v0 := 1;
  v1 := ClosureValueCreate0(v0);
  tmp0 := method0(v1);
  v2 := tmp0.v0;
  v3 := tmp0.v1;
  v4 := (10 + v2);
  v5 := (20 + v3);
  v6 := (v4 + v5);
  v7 := (v6 + 7);
  Exit(v7);
end;

begin
  Halt(SpiralMain);
end.
