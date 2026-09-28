program SpiralGenerated;
{$mode objfpc}{$H+}

function SpiralMain: LongInt;
var
  v0_0: AnsiString;
  v0_1: AnsiString;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
begin
  v1 := 'ab';
  v0_0 := v1;
  v2 := 'cde';
  v0_1 := v2;
  v3 := v0_0;
  v4 := v0_1;
  v5 := Length(v3);
  v6 := Length(v4);
  v7 := (v5 + v6);
  v8 := (v7 - 5);
  Exit(v8);
end;

begin
  Halt(SpiralMain);
end.
