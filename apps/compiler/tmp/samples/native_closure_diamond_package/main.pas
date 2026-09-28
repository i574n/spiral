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

function apply1(v0: ClosureValue0; v1: LongInt): LongInt;
begin
  Exit(ClosureInvoke0(v0, v1));
end;

function method0(v0: ClosureValue0; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := apply1(v0, v1);
  v3 := (v2 + 1);
  Exit(v3);
end;

function method2(v0: ClosureValue0; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := apply1(v0, v1);
  v3 := (v2 + 2);
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
  v2 := 16;
  v3 := method0(v1, v2);
  v4 := 17;
  v5 := method2(v1, v4);
  v6 := (v3 + v5);
  Exit(v6);
end;

begin
  Halt(SpiralMain);
end.
