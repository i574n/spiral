program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple9000 = record
    v0: LongInt;
    v1: LongInt;
    v2: Boolean;
  end;

function TupleCreate9000(v0: LongInt; v1: LongInt; v2: Boolean): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
end;

function score0(v0: Tuple9000): LongInt;
var
  v2: Boolean;
  v1: LongInt;
begin
  if (v0.v0 = 1) then begin
    v2 := v0.v2;
    if v2 then begin
      Exit(9);
    end else begin
      Exit(4);
    end;
  end else begin
    v1 := v0.v1;
    Exit(v1);
  end;
end;

function SpiralMain: LongInt;
var
  v0: Boolean;
  v3: Tuple9000;
  v4: LongInt;
  v5: LongInt;
begin
  v0 := False;
  if v0 then begin
    v3 := TupleCreate9000(0, 7, False);
  end else begin
    v3 := TupleCreate9000(1, 0, True);
  end;
  v4 := score0(v3);
  v5 := (v4 - 9);
  Exit(v5);
end;

begin
  Halt(SpiralMain);
end.
