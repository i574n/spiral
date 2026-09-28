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
  if (v0.v0 = 2) then begin
    v2 := v0.v2;
    if v2 then begin
      Exit(11);
    end else begin
      Exit(5);
    end;
  end else begin
    if (v0.v0 = 1) then begin
      v1 := v0.v1;
      Exit(v1);
    end else begin
      Exit(3);
    end;
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
  v7: Tuple9000;
  v3: Boolean;
  v8: LongInt;
  v9: LongInt;
begin
  v0 := 2;
  v1 := (v0 = 0);
  if v1 then begin
    v7 := TupleCreate9000(0, 0, False);
  end else begin
    v3 := (v0 = 1);
    if v3 then begin
      v7 := TupleCreate9000(1, 7, False);
    end else begin
      v7 := TupleCreate9000(2, 0, True);
    end;
  end;
  v8 := score0(v7);
  v9 := (v8 - 11);
  Exit(v9);
end;

begin
  Halt(SpiralMain);
end.
