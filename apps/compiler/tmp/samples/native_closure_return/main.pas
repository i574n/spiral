program SpiralGenerated;
{$mode objfpc}{$H+}

type
  ClosureValue1 = record
    v0: AnsiString;
  end;
  ClosureValue0 = record
  end;

function ClosureValueCreate1(v0: AnsiString): ClosureValue1;
begin
  Result.v0 := v0;
end;

function ClosureValueCreate0(): ClosureValue0;
begin
end;

function ClosureInvoke1(x: ClosureValue1; v1: LongInt): LongInt;
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

function ClosureInvoke0(_x: ClosureValue0; v0: AnsiString): ClosureValue1;
begin
  Exit(ClosureValueCreate1(v0));
end;

function method0(v0: ClosureValue1): LongInt;
begin
  Exit(ClosureInvoke1(v0, 39));
end;

function SpiralMain: LongInt;
var
  v0: ClosureValue0;
  v1: AnsiString;
  v2: ClosureValue1;
begin
  v0 := ClosureValueCreate0();
  v1 := 'abc';
  v2 := ClosureInvoke0(v0, v1);
  Exit(method0(v2));
end;

begin
  Halt(SpiralMain);
end.
