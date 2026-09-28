program SpiralGenerated;
{$mode objfpc}{$H+}

function fib0(v0: LongInt): LongInt;
var
  v1: Boolean;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v1 := (v0 <= 1);
  if v1 then begin
    Exit(v0);
  end else begin
    v2 := (v0 - 1);
    v3 := fib0(v2);
    v4 := (v0 - 2);
    v5 := fib0(v4);
    v6 := (v3 + v5);
    Exit(v6);
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
begin
  v0 := 10;
  v1 := fib0(v0);
  v2 := (v1 - 55);
  Exit(v2);
end;

begin
  Halt(SpiralMain);
end.
