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
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 'abc';
  v1 := ClosureValueCreate0(v0);
  v2 := ClosureInvoke0(v1, 10);
  v3 := ClosureInvoke0(v1, 20);
  v4 := ClosureInvoke0(v1, 3);
  v5 := (v2 + v3);
  v6 := (v5 + v4);
  Exit(v6);
end;

begin
  Halt(SpiralMain);
end.
