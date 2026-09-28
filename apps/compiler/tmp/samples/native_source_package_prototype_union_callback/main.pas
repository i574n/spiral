program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple9000 = record
    v0: LongInt;
    v1: LongInt;
    v2: Boolean;
  end;
  ClosureValue0 = record
    v0: LongInt;
  end;

function TupleCreate9000(v0: LongInt; v1: LongInt; v2: Boolean): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
end;

function ClosureValueCreate0(v0: LongInt): ClosureValue0;
begin
  Result.v0 := v0;
end;

function ClosureInvoke0(x: ClosureValue0; v1: LongInt): Tuple9000;
var
  v0: LongInt;
  v2: Boolean;
begin
  v0 := x.v0;
  v2 := (v1 = v0);
  Exit(TupleCreate9000(2, 0, v2));
end;

function method0(v0: ClosureValue0; v1: LongInt): Tuple9000;
begin
  Exit(ClosureInvoke0(v0, v1));
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: ClosureValue0;
  v2: Tuple9000;
  v8: LongInt;
  v4: Boolean;
  v3: LongInt;
  v9: LongInt;
begin
  v0 := 2;
  v1 := ClosureValueCreate0(v0);
  v2 := method0(v1, v0);
  if (v2.v0 = 2) then begin
    v4 := v2.v2;
    if v4 then begin
      v8 := 11;
    end else begin
      v8 := 5;
    end;
  end else begin
    if (v2.v0 = 1) then begin
      v3 := v2.v1;
      v8 := v3;
    end else begin
      v8 := 3;
    end;
  end;
  v9 := (v8 + 31);
  Exit(v9);
end;

begin
  Halt(SpiralMain);
end.
