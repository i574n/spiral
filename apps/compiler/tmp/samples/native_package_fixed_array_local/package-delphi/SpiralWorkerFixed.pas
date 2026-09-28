unit SpiralWorkerFixed;
{$mode objfpc}{$H+}

interface



function method0(base: LongInt): LongInt;

implementation

function method0(base: LongInt): LongInt;
var
  v0_0: LongInt;
  v0_1: LongInt;
  v0_2: LongInt;
  v1: LongInt;
begin
  v0_0 := base;
  v0_1 := 20;
  v0_2 := 2;
  v1 := ((v0_0 + v0_1) + v0_2);
  Exit(v1);
end;

end.
