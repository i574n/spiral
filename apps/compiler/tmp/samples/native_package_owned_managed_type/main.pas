program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple0 = record
    v0: AnsiString;
    v1: LongInt;
  end;

function TupleCreate0(v0: AnsiString; v1: LongInt): Tuple0;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

function method0(v0: Tuple0): LongInt;
var
  v1: AnsiString;
  v2: LongInt;
  v3: LongInt;
begin
  v1 := v0.v0;
  v2 := Length(v1);
  v3 := (v2 + v0.v1);
  Exit(v3);
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: Tuple0;
begin
  v0 := 'abc';
  v1 := TupleCreate0(v0, 39);
  Exit(method0(v1));
end;

begin
  Halt(SpiralMain);
end.
