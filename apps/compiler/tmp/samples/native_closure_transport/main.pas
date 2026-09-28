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

function apply0(v0: ClosureValue0; v1: LongInt): LongInt;
begin
  Exit(ClosureInvoke0(v0, v1));
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: ClosureValue0;
  v2: LongInt;
begin
  v0 := 'abc';
  v1 := ClosureValueCreate0(v0);
  v2 := 39;
  Exit(apply0(v1, v2));
end;

begin
  Halt(SpiralMain);
end.
