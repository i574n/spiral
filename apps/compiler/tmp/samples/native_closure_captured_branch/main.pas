program SpiralGenerated;
{$mode objfpc}{$H+}

type
  ClosureValue0 = record
    v0: LongInt;
    variant: LongInt;
  end;

function ClosureValueCreate0(v0: LongInt; variant: LongInt): ClosureValue0;
begin
  Result.v0 := v0;
  Result.variant := variant;
end;

function ClosureInvoke0(x: ClosureValue0; v1: LongInt): LongInt;
var
  v0: LongInt;
  closure0_v2: LongInt;
  closure1_v2: LongInt;
begin
  if (x.variant = 0) then begin
    v0 := x.v0;
    closure0_v2 := (v1 + v0);
    Exit(closure0_v2);
  end else begin
    v0 := x.v0;
    closure1_v2 := (v1 + v0);
    Exit(closure1_v2);
  end;
end;

function method0(v0: ClosureValue0): LongInt;
begin
  Exit(ClosureInvoke0(v0, 40));
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: Boolean;
  v5: ClosureValue0;
begin
  v0 := 2;
  v1 := 3;
  v2 := True;
  if v2 then begin
    v5 := ClosureValueCreate0(v0, 0);
  end else begin
    v5 := ClosureValueCreate0(v1, 1);
  end;
  Exit(method0(v5));
end;

begin
  Halt(SpiralMain);
end.
