program SpiralGenerated;
{$mode objfpc}{$H+}

function method0(v0: LongInt; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := (v0 + v1);
  v3 := (v2 - 42);
  Exit(v3);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
begin
  v0 := 20;
  v1 := 22;
  Exit(method0(v0, v1));
end;

begin
  Halt(SpiralMain);
end.
