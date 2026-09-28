program SpiralGenerated;
{$mode objfpc}{$H+}

type
  ClosureValue0 = record
    variant: LongInt;
  end;

function ClosureValueCreate0(variant: LongInt): ClosureValue0;
begin
  Result.variant := variant;
end;

function ClosureInvoke0(x: ClosureValue0; v0: LongInt): LongInt;
var
  closure0_v1: LongInt;
  closure1_v1: LongInt;
begin
  if (x.variant = 0) then begin
    closure0_v1 := (v0 + 2);
    Exit(closure0_v1);
  end else begin
    closure1_v1 := (v0 + 3);
    Exit(closure1_v1);
  end;
end;

function method0(v0: ClosureValue0): LongInt;
begin
  Exit(ClosureInvoke0(v0, 40));
end;

function SpiralMain: LongInt;
var
  v0: Boolean;
  v3: ClosureValue0;
begin
  v0 := True;
  if v0 then begin
    v3 := ClosureValueCreate0(0);
  end else begin
    v3 := ClosureValueCreate0(1);
  end;
  Exit(method0(v3));
end;

begin
  Halt(SpiralMain);
end.
