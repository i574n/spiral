program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple0 = record
    v0: LongInt;
    v1: LongInt;
    v2: Boolean;
  end;

function TupleCreate0(v0: LongInt; v1: LongInt; v2: Boolean): Tuple0;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
end;

function method0(v0: LongInt): Tuple0;
var
  v1: LongInt;
  v2: Boolean;
begin
  v1 := (v0 + 2);
  v2 := (v0 > 0);
  Exit(TupleCreate0(v0, v1, v2));
end;

function method1(v0: LongInt; v1: LongInt; v2: Boolean): LongInt;
var
  v3: LongInt;
  v4: LongInt;
begin
  if v2 then begin
    v3 := (v0 + v1);
    v4 := (v3 - 4);
    Exit(v4);
  end else begin
    Exit(1);
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: Boolean;
  tmp0: Tuple0;
begin
  v0 := 1;
  tmp0 := method0(v0);
  v1 := tmp0.v0;
  v2 := tmp0.v1;
  v3 := tmp0.v2;
  Exit(method1(v1, v2, v3));
end;

begin
  Halt(SpiralMain);
end.
