program SpiralGenerated;
{$mode objfpc}{$H+}

function method0(v0: AnsiString): Boolean;
var
  v1: Boolean;
begin
  v1 := (v0 = v0);
  Exit(v1);
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: Boolean;
begin
  v0 := 'spiral';
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
