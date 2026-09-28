unit SpiralTypesCallable;
{$mode objfpc}{$H+}

interface

type
  ClosureValue0 = record
    v0: AnsiString;
    variant: LongInt;
  end;

function ClosureValueCreate0(v0: AnsiString; variant: LongInt): ClosureValue0;
function ClosureInvoke0(x: ClosureValue0; v1: LongInt): LongInt;

implementation

function ClosureValueCreate0(v0: AnsiString; variant: LongInt): ClosureValue0;
begin
  Result.v0 := v0;
  Result.variant := variant;
end;

function ClosureInvoke0(x: ClosureValue0; v1: LongInt): LongInt;
var
  v0: AnsiString;
  closure0_v2: LongInt;
  closure0_v3: LongInt;
  closure1_v2: LongInt;
  closure1_v3: LongInt;
begin
  if (x.variant = 0) then begin
    v0 := x.v0;
    closure0_v2 := Length(v0);
    closure0_v3 := (closure0_v2 + v1);
    Exit(closure0_v3);
  end else begin
    v0 := x.v0;
    closure1_v2 := Length(v0);
    closure1_v3 := ((closure1_v2 + v1) - 1);
    Exit(closure1_v3);
  end;
end;

end.
