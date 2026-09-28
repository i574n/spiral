program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple0 = record
    v0: LongInt;
    v1: LongInt;
  end;

function TupleCreate0(v0: LongInt; v1: LongInt): Tuple0;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

function method0(v0: LongInt; v1: LongInt): Tuple0;
begin
  Exit(TupleCreate0(v0, v1));
end;

function method1(v0: LongInt; v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := (v0 + v1);
  Exit(v2);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  tmp0: Tuple0;
  v4: LongInt;
  v5: LongInt;
begin
  v0 := 20;
  v1 := 22;
  tmp0 := method0(v0, v1);
  v2 := tmp0.v0;
  v3 := tmp0.v1;
  v4 := method1(v2, v3);
  v5 := (v4 - 42);
  Exit(v5);
end;

begin
  Halt(SpiralMain);
end.
