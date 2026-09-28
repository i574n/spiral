unit SpiralWorkerFixed;
{$mode objfpc}{$H+}

interface



function method0(base: LongInt; index: LongInt): LongInt;

implementation

function ArrayGet9000(index: LongInt; v0: LongInt; v1: LongInt; v2: LongInt): LongInt;
begin
  if (index = 0) then begin
    Exit(v0);
  end;
  if (index = 1) then begin
    Exit(v1);
  end;
  Exit(v2);
end;

function method0(base: LongInt; index: LongInt): LongInt;
var
  v0_0: LongInt;
  v0_1: LongInt;
  v0_2: LongInt;
  v1: LongInt;
begin
  v0_0 := base;
  v0_1 := 1;
  v0_2 := 2;
  v1 := (ArrayGet9000(index, v0_0, v0_1, v0_2) + v0_0);
  Exit(v1);
end;

end.
