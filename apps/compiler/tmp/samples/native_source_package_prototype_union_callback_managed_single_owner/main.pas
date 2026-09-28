program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple9000 = record
    v0: LongInt;
    v1: AnsiString;
  end;
  ClosureValue0 = record
  end;

function TupleCreate9000(v0: LongInt; v1: AnsiString): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

function ClosureValueCreate0(): ClosureValue0;
begin
end;

function ClosureInvoke0(_x: ClosureValue0; v0: LongInt): Tuple9000;
var
  v1: AnsiString;
begin
  v1 := 'managed';
  Exit(TupleCreate9000(1, v1));
end;

function method0(v0: ClosureValue0): Tuple9000;
begin
  Exit(ClosureInvoke0(v0, 2));
end;

function SpiralMain: LongInt;
var
  v0: ClosureValue0;
  v1: Tuple9000;
  v4: LongInt;
  v5: LongInt;
begin
  v0 := ClosureValueCreate0();
  v1 := method0(v0);
  if (v1.v0 = 0) then begin
    v4 := 3;
  end else begin
    v4 := 11;
  end;
  if (v1.v0 = 1) then begin
    Finalize(v1.v1);
  end;
  v5 := (v4 + 31);
  Exit(v5);
end;

begin
  Halt(SpiralMain);
end.
