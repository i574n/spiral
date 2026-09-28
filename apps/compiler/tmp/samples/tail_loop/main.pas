program SpiralGenerated;
{$mode objfpc}{$H+}

function method1(v0: LongInt; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: Boolean;
  __spiral_tail_arg0: LongInt;
  __spiral_tail_arg1: LongInt;
begin
  while True do begin
    v2 := (v0 - 1);
    v3 := (v1 + v0);
    v4 := (v2 = 0);
    if v4 then begin
      Exit(v3);
    end else begin
      __spiral_tail_arg0 := v2;
      __spiral_tail_arg1 := v3;
      v0 := __spiral_tail_arg0;
      v1 := __spiral_tail_arg1;
      Continue;
    end;
  end;
end;

function method0(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: Boolean;
  v4: LongInt;
  v5: LongInt;
begin
  v1 := 0;
  v2 := (v0 = 0);
  if v2 then begin
    v4 := v1;
  end else begin
    v4 := method1(v0, v1);
  end;
  v5 := (v4 - 55);
  Exit(v5);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := 10;
  Exit(method0(v0));
end;

begin
  Halt(SpiralMain);
end.
