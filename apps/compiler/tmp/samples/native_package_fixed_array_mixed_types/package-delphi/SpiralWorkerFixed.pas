unit SpiralWorkerFixed;
{$mode objfpc}{$H+}

interface



function method0(valueIndex: LongInt; flagIndex: LongInt): LongInt;

implementation

function ArrayGet9000(index: LongInt; v0: LongInt; v1: LongInt): LongInt;
begin
  if (index = 0) then begin
    Exit(v0);
  end;
  Exit(v1);
end;

function ArrayGet9001(index: LongInt; v0: Boolean; v1: Boolean): Boolean;
begin
  if (index = 0) then begin
    Exit(v0);
  end;
  Exit(v1);
end;

function method0(valueIndex: LongInt; flagIndex: LongInt): LongInt;
var
  v0_0: LongInt;
  v0_1: LongInt;
  v1_0: Boolean;
  v1_1: Boolean;
  v2: LongInt;
begin
  v0_0 := 40;
  v0_1 := 10;
  v1_0 := False;
  v1_1 := True;
  if ArrayGet9001(flagIndex, v1_0, v1_1) then begin
    v2 := (ArrayGet9000(valueIndex, v0_0, v0_1) + 2);
  end else begin
    v2 := ArrayGet9000(valueIndex, v0_0, v0_1);
  end;
  Exit(v2);
end;

end.
