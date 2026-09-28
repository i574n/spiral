program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple9000 = record
    v0: LongInt;
    v1: LongInt;
  end;

function TupleCreate9000(v0: LongInt; v1: LongInt): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

function score0(v0: Tuple9000): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  if (v0.v0 = 0) then begin
    v1 := v0.v1;
    Exit(v1);
  end else begin
    v2 := v0.v1;
    v3 := (0 - v2);
    Exit(v3);
  end;
end;

function SpiralMain: LongInt;
var
  v0: Boolean;
  v3: Tuple9000;
  v4: LongInt;
  v5: LongInt;
begin
  v0 := True;
  if v0 then begin
    v3 := TupleCreate9000(0, 7);
  end else begin
    v3 := TupleCreate9000(1, 3);
  end;
  v4 := score0(v3);
  v5 := (v4 - 7);
  Exit(v5);
end;

begin
  Halt(SpiralMain);
end.
