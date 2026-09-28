program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple9000 = record
    v0: LongInt;
    v1: LongInt;
    v2: Boolean;
  end;
  ClosureValue0 = record
    v0: Tuple9000;
  end;

function TupleCreate9000(v0: LongInt; v1: LongInt; v2: Boolean): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
end;

function ClosureValueCreate0(v0: Tuple9000): ClosureValue0;
begin
  Result.v0 := v0;
end;

function ClosureInvoke0(x: ClosureValue0; v1: LongInt): LongInt;
var
  v0: Tuple9000;
  v7: LongInt;
  v3: Boolean;
  v2: LongInt;
  v8: LongInt;
begin
  v0 := x.v0;
  if (v0.v0 = 2) then begin
    v3 := v0.v2;
    if v3 then begin
      v7 := 11;
    end else begin
      v7 := 5;
    end;
  end else begin
    if (v0.v0 = 1) then begin
      v2 := v0.v1;
      v7 := v2;
    end else begin
      v7 := 3;
    end;
  end;
  v8 := (v7 + v1);
  Exit(v8);
end;

function method0(v0: ClosureValue0): LongInt;
begin
  Exit(ClosureInvoke0(v0, 31));
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
  v7: Tuple9000;
  v3: Boolean;
  v8: ClosureValue0;
begin
  v0 := 2;
  v1 := (v0 = 0);
  if v1 then begin
    v7 := TupleCreate9000(0, 0, False);
  end else begin
    v3 := (v0 = 1);
    if v3 then begin
      v7 := TupleCreate9000(1, 7, False);
    end else begin
      v7 := TupleCreate9000(2, 0, True);
    end;
  end;
  v8 := ClosureValueCreate0(v7);
  Exit(method0(v8));
end;

begin
  Halt(SpiralMain);
end.
