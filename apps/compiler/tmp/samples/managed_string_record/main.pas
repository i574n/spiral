program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple0 = record
    v0: AnsiString;
    v1: LongInt;
  end;

function TupleCreate0(v0: AnsiString; v1: LongInt): Tuple0;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

function method0(v0: AnsiString): Tuple0;
var
  v1: LongInt;
begin
  v1 := Length(v0);
  Exit(TupleCreate0(v0, v1));
end;

function score1(v0: LongInt; v1: AnsiString): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := Length(v1);
  v3 := (v2 + v0);
  Exit(v3);
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: LongInt;
  tmp0: Tuple0;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 'qwe';
  tmp0 := method0(v0);
  v1 := tmp0.v0;
  v2 := tmp0.v1;
  v3 := score1(v2, v1);
  v4 := score1(v2, v1);
  v5 := (v3 + v4);
  v6 := (v5 - 12);
  Exit(v6);
end;

begin
  Halt(SpiralMain);
end.
