program SpiralGenerated;
{$mode objfpc}{$H+}

function method0(v0: LongInt; v1: LongInt): Boolean;
var
  v2: LongInt;
  v3: Boolean;
  v4: LongInt;
  v5: LongInt;
  v6: Boolean;
  v7: Boolean;
begin
  v2 := (-v0);
  v3 := (v2 <= 0);
  if v3 then begin
    v4 := (v1 * 2);
    v5 := (v0 + v4);
    v6 := (v5 >= 9);
    if v6 then begin
      Exit(True);
    end else begin
      v7 := (v1 = 0);
      Exit(v7);
    end;
  end else begin
    Exit(False);
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: Boolean;
begin
  v0 := 3;
  v1 := 3;
  v2 := method0(v0, v1);
  if v2 then begin
    Exit(0);
  end else begin
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
