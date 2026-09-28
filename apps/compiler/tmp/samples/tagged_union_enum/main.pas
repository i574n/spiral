program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple9000 = record
    v0: LongInt;
  end;

function TupleCreate9000(v0: LongInt): Tuple9000;
begin
  Result.v0 := v0;
end;

function score0(v0: Tuple9000): LongInt;
begin
  if (v0.v0 = 0) then begin
    Exit(1);
  end else begin
    if (v0.v0 = 3) then begin
      Exit(4);
    end else begin
      if (v0.v0 = 2) then begin
        Exit(3);
      end else begin
        Exit(2);
      end;
    end;
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
  v10: Tuple9000;
  v3: Boolean;
  v5: Boolean;
  v11: LongInt;
  v12: LongInt;
begin
  v0 := 3;
  v1 := (v0 = 0);
  if v1 then begin
    v10 := TupleCreate9000(0);
  end else begin
    v3 := (v0 = 1);
    if v3 then begin
      v10 := TupleCreate9000(1);
    end else begin
      v5 := (v0 = 2);
      if v5 then begin
        v10 := TupleCreate9000(2);
      end else begin
        v10 := TupleCreate9000(3);
      end;
    end;
  end;
  v11 := score0(v10);
  v12 := (v11 - 4);
  Exit(v12);
end;

begin
  Halt(SpiralMain);
end.
