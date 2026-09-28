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

function TupleSum0(v0: Tuple0): LongInt;
begin
  Exit((v0.v0 + v0.v1));
end;

function method0(v0: Tuple0): LongInt;
begin
  Exit(TupleSum0(v0));
end;

function SpiralMain: LongInt;
var
  v0: Tuple0;
begin
  v0 := TupleCreate0(19, 23);
  Exit(method0(v0));
end;

begin
  Halt(SpiralMain);
end.
