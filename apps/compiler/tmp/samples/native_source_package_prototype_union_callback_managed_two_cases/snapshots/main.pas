program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple9000 = record
    v0: LongInt;
    v1: AnsiString;
    v2: AnsiString;
  end;
  ClosureValue0 = record
  end;

function TupleCreate9000(v0: LongInt; v1: AnsiString; v2: AnsiString): Tuple9000;
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
  v2: AnsiString;
  v4: AnsiString;
begin
  v1 := (v0 = 1);
  if v1 then begin
    v2 := 'alpha';
    Exit(TupleCreate9000(1, v2, ''));
  end else begin
    v4 := 'beta';
    Exit(TupleCreate9000(2, '', v4));
  end;
end;

function method0(v0: ClosureValue0): Tuple9000;
begin
  Exit(ClosureInvoke0(v0, 1));
end;

function method1(v0: ClosureValue0): Tuple9000;
begin
  Exit(ClosureInvoke0(v0, 2));
end;

function SpiralMain: LongInt;
var
  v0: ClosureValue0;
  v1: Tuple9000;
  v6: LongInt;
  v7: Tuple9000;
  v12: LongInt;
  v13: LongInt;
  v14: LongInt;
begin
  v0 := ClosureValueCreate0();
  v1 := method0(v0);
  if (v1.v0 = 0) then begin
    v6 := 3;
  end else begin
    if (v1.v0 = 2) then begin
      v6 := 6;
    end else begin
      v6 := 5;
    end;
  end;
  if (v1.v0 = 1) then begin
    Finalize(v1.v1);
  end;
  if (v1.v0 = 2) then begin
    Finalize(v1.v2);
  end;
  v7 := method1(v0);
  if (v7.v0 = 0) then begin
    v12 := 3;
  end else begin
    if (v7.v0 = 2) then begin
      v12 := 6;
    end else begin
      v12 := 5;
    end;
  end;
  if (v7.v0 = 1) then begin
    Finalize(v7.v1);
  end;
  if (v7.v0 = 2) then begin
    Finalize(v7.v2);
  end;
  v13 := (v6 + v12);
  v14 := (v13 + 31);
  Exit(v14);
end;

begin
  Halt(SpiralMain);
end.
