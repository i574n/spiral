program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple9000 = record
    v0: LongInt;
    v1: AnsiString;
    v2: LongInt;
  end;
  ClosureValue0 = record
  end;

function TupleCreate9000(v0: LongInt; v1: AnsiString; v2: LongInt): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
end;

function ClosureValueCreate0(): ClosureValue0;
begin
end;

function ClosureInvoke0(_x: ClosureValue0; v0: LongInt): Tuple9000;
var
  v1: Boolean;
  v3: AnsiString;
begin
  v1 := (v0 = 0);
  if v1 then begin
    Exit(TupleCreate9000(0, '', 0));
  end else begin
    v3 := 'managed';
    Exit(TupleCreate9000(1, v3, 32));
  end;
end;

function method0(v0: ClosureValue0): Tuple9000;
begin
  Exit(ClosureInvoke0(v0, 0));
end;

function method1(v0: ClosureValue0): Tuple9000;
begin
  Exit(ClosureInvoke0(v0, 1));
end;

function SpiralMain: LongInt;
var
  v0: ClosureValue0;
  v1: Tuple9000;
  v7: LongInt;
  v2: AnsiString;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v8: Tuple9000;
  v14: LongInt;
  v9: AnsiString;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
  v15: LongInt;
begin
  v0 := ClosureValueCreate0();
  v1 := method0(v0);
  if (v1.v0 = 0) then begin
    v7 := 3;
  end else begin
    v2 := v1.v1;
    v3 := v1.v2;
    v4 := Length(v2);
    v5 := (v4 + v3);
    v7 := v5;
  end;
  if (v1.v0 = 1) then begin
    Finalize(v1.v1);
  end;
  v8 := method1(v0);
  if (v8.v0 = 0) then begin
    v14 := 3;
  end else begin
    v9 := v8.v1;
    v10 := v8.v2;
    v11 := Length(v9);
    v12 := (v11 + v10);
    v14 := v12;
  end;
  if (v8.v0 = 1) then begin
    Finalize(v8.v1);
  end;
  v15 := (v7 + v14);
  Exit(v15);
end;

begin
  Halt(SpiralMain);
end.
