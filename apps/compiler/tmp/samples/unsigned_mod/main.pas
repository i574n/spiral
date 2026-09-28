program SpiralGenerated;
{$mode objfpc}{$H+}

function method0(v0: LongWord): Boolean;
var
  v1: LongWord;
  v2: LongWord;
  v3: Boolean;
begin
  v1 := (v0 + 5);
  v2 := (v1 mod 4);
  v3 := (v2 = 0);
  Exit(v3);
end;

function SpiralMain: LongInt;
var
  v0: LongWord;
  v1: Boolean;
begin
  v0 := 7;
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
