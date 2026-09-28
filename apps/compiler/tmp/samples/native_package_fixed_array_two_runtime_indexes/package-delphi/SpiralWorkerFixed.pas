unit SpiralWorkerFixed;
{$mode objfpc}{$H+}

interface



function method0(leftIndex: LongInt; rightIndex: LongInt): LongInt;

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

function ArrayGet9001(index: LongInt; v0: LongInt; v1: LongInt): LongInt;
begin
  if (index = 0) then begin
    Exit(v0);
  end;
  Exit(v1);
end;

function method0(leftIndex: LongInt; rightIndex: LongInt): LongInt;
var
  v0_0: LongInt;
  v0_1: LongInt;
  v0_2: LongInt;
  v1_0: LongInt;
  v1_1: LongInt;
  v2: LongInt;
begin
  v0_0 := 40;
  v0_1 := 10;
  v0_2 := 20;
  v1_0 := 1;
  v1_1 := 2;
  v2 := (ArrayGet9000(leftIndex, v0_0, v0_1, v0_2) + ArrayGet9001(rightIndex, v1_0, v1_1));
  Exit(v2);
end;

end.
