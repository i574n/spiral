program SpiralGenerated;
{$mode objfpc}{$H+}

type
  ClosureValue0 = record
    v0: AnsiString;
  end;

function ClosureValueCreate0(v0: AnsiString): ClosureValue0;
begin
  Result.v0 := v0;
end;

function ClosureInvoke0(x: ClosureValue0; v1: LongInt): LongInt;
var
  v0: AnsiString;
  v2: LongInt;
  v3: LongInt;
begin
  v0 := x.v0;
  v2 := Length(v0);
  v3 := (v2 + v1);
  Exit(v3);
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: ClosureValue0;
begin
  v0 := 'abc';
  v1 := ClosureValueCreate0(v0);
  Exit(ClosureInvoke0(v1, 39));
end;

begin
  Halt(SpiralMain);
end.
