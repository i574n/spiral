program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple0 = record
    v0: LongInt;
    v1: LongInt;
    v2: LongInt;
    v3: LongInt;
  end;

function TupleCreate0(v0: LongInt; v1: LongInt; v2: LongInt; v3: LongInt): Tuple0;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
  Result.v3 := v3;
end;

function method0(v0: LongInt): Tuple0;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v1 := (v0 + 1);
  v2 := (v0 + 2);
  v3 := (v0 + 3);
  Exit(TupleCreate0(v0, v1, v2, v3));
end;

function method1(v0: LongInt; v1: LongInt; v2: LongInt; v3: LongInt): LongInt;
var
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  v4 := (v0 + v1);
  v5 := (v4 + v2);
  v6 := (v5 + v3);
  v7 := (v6 - 10);
  Exit(v7);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  tmp0: Tuple0;
begin
  v0 := 1;
  tmp0 := method0(v0);
  v1 := tmp0.v0;
  v2 := tmp0.v1;
  v3 := tmp0.v2;
  v4 := tmp0.v3;
  Exit(method1(v1, v2, v3, v4));
end;

begin
  Halt(SpiralMain);
end.
