program SpiralGenerated;
{$mode objfpc}{$H+}

function measure0(v0: AnsiString): LongInt;
var
  v1: LongInt;
begin
  v1 := Length(v0);
  Exit(v1);
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v0 := 'qwe';
  v1 := measure0(v0);
  v2 := measure0(v0);
  v3 := (v1 + v2);
  v4 := (v3 - 6);
  Exit(v4);
end;

begin
  Halt(SpiralMain);
end.
