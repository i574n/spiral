program SpiralGenerated;
{$mode objfpc}{$H+}

function choose0(v0: Boolean): AnsiString;
var
  v1: AnsiString;
  v2: AnsiString;
begin
  if v0 then begin
    v1 := 'alpha';
    Exit(v1);
  end else begin
    v2 := 'beta';
    Exit(v2);
  end;
end;

function measure1(v0: AnsiString): LongInt;
var
  v1: LongInt;
begin
  v1 := Length(v0);
  Exit(v1);
end;

function SpiralMain: LongInt;
var
  v0: Boolean;
  v1: AnsiString;
  v2: Boolean;
  v3: AnsiString;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
begin
  v0 := True;
  v1 := choose0(v0);
  v2 := False;
  v3 := choose0(v2);
  v4 := measure1(v1);
  v5 := measure1(v1);
  v6 := (v4 + v5);
  v7 := measure1(v3);
  v8 := (v6 + v7);
  v9 := (v8 - 14);
  Exit(v9);
end;

begin
  Halt(SpiralMain);
end.
