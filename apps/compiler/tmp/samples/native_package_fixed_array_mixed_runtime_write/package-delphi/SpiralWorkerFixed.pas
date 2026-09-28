unit SpiralWorkerFixed;
{$mode objfpc}{$H+}

interface



function method0(valueWriteIndex: LongInt; flagWriteIndex: LongInt; valueReadIndex: LongInt; flagReadIndex: LongInt; scalarBias: LongInt): LongInt;

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

function method0(valueWriteIndex: LongInt; flagWriteIndex: LongInt; valueReadIndex: LongInt; flagReadIndex: LongInt; scalarBias: LongInt): LongInt;
var
  v0_0: LongInt;
  v0_1: LongInt;
  v1_0: Boolean;
  v1_1: Boolean;
  spiralWriteValue0_v0_0: LongInt;
  spiralWriteValue1_v1_0: Boolean;
  v2: LongInt;
begin
  v0_0 := 10;
  v0_1 := 20;
  v1_0 := False;
  v1_1 := False;
  if ((valueWriteIndex = 0) or (valueWriteIndex = 1)) then begin
    spiralWriteValue0_v0_0 := (ArrayGet9000(valueReadIndex, v0_0, v0_1) + scalarBias);
    if (valueWriteIndex = 0) then begin
      v0_0 := spiralWriteValue0_v0_0;
    end else begin
      v0_1 := spiralWriteValue0_v0_0;
    end;
  end else begin
    Exit((-1));
  end;
  if ((flagWriteIndex = 0) or (flagWriteIndex = 1)) then begin
    spiralWriteValue1_v1_0 := (ArrayGet9000(valueReadIndex, v0_0, v0_1) = 40);
    if (flagWriteIndex = 0) then begin
      v1_0 := spiralWriteValue1_v1_0;
    end else begin
      v1_1 := spiralWriteValue1_v1_0;
    end;
  end else begin
    Exit((-2));
  end;
  if ArrayGet9001(flagReadIndex, v1_0, v1_1) then begin
    v2 := (ArrayGet9000(valueReadIndex, v0_0, v0_1) + 2);
  end else begin
    v2 := ArrayGet9000(valueReadIndex, v0_0, v0_1);
  end;
  Exit(v2);
end;

end.
