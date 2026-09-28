program SpiralGenerated;
{$mode objfpc}{$H+}

function is_answer1(v0: LongInt): Boolean;
var
  v1: Boolean;
begin
  v1 := (v0 = 42);
  Exit(v1);
end;

function method0(v0: LongInt): Boolean;
begin
  Exit(is_answer1(v0));
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
begin
  v0 := 42;
  v1 := method0(v0);
  if v1 then begin
    Exit(0);
  end else begin
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
