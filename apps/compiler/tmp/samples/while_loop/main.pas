program SpiralGenerated;
{$mode objfpc}{$H+}

function method_while0(v0: LongInt): Boolean;
var
  v1: Boolean;
begin
  v1 := (v0 < 10);
  Exit(v1);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v0 := 0;
  v1 := 0;
  while method_while0(v0) do begin
    v3 := (v1 + v0);
    v1 := v3;
    v4 := (v0 + 1);
    v0 := v4;
  end;
  v5 := (v1 - 45);
  Exit(v5);
end;

begin
  Halt(SpiralMain);
end.
