program SpiralGenerated;
{$mode objfpc}{$H+}

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v0 := 'qwe';
  v1 := Length(v0);
  v2 := (v1 + v1);
  v3 := (v2 - 6);
  Exit(v3);
end;

begin
  Halt(SpiralMain);
end.
