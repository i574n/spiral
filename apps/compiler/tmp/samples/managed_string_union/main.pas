program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple9000 = record
    v0: LongInt;
    v1: AnsiString;
    v2: LongInt;
  end;

function TupleCreate9000(v0: LongInt; v1: AnsiString; v2: LongInt): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
end;

function score0(v0: Tuple9000): LongInt;
var
  v3: LongInt;
  v1: AnsiString;
  v2: LongInt;
begin
  if (v0.v0 = 1) then begin
    v3 := v0.v2;
    Exit(v3);
  end else begin
    v1 := v0.v1;
    v2 := Length(v1);
    Exit(v2);
  end;
end;

function SpiralMain: LongInt;
var
  v0: Boolean;
  v4: Tuple9000;
  v2: AnsiString;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
begin
  v0 := False;
  if v0 then begin
    v4 := TupleCreate9000(1, NULL, 7);
  end else begin
    v2 := 'qwe';
    v4 := TupleCreate9000(0, v2, 0);
  end;
  v5 := score0(v4);
  v6 := score0(v4);
  v7 := (v5 + v6);
  v8 := (v7 - 6);
  Exit(v8);
end;

begin
  Halt(SpiralMain);
end.
