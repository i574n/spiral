program SpiralGenerated;
{$mode objfpc}{$H+}

function method1(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: Boolean;
  __spiral_tail_arg0: LongInt;
begin
  while True do begin
    v1 := (v0 - 1);
    v2 := (v1 = 0);
    if v2 then begin
      Exit(0);
    end else begin
      __spiral_tail_arg0 := v1;
      v0 := __spiral_tail_arg0;
      Continue;
    end;
  end;
end;

function method0(v0: LongInt): LongInt;
var
  v1: Boolean;
begin
  v1 := (v0 = 0);
  if v1 then begin
    Exit(0);
  end else begin
    Exit(method1(v0));
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := 1000000;
  Exit(method0(v0));
end;

begin
  Halt(SpiralMain);
end.
