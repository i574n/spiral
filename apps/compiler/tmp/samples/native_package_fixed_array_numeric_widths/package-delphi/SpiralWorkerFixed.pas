unit SpiralWorkerFixed;
{$mode objfpc}{$H+}

interface



function method0(integerWriteIndex: LongInt; floatWriteIndex: LongInt; integerReadIndex: LongInt; floatReadIndex: LongInt; integerBias: Int64; floatBias: Double): LongInt;

implementation

function ArrayGet9000(index: LongInt; v0: Int64; v1: Int64): Int64;
begin
  if (index = 0) then begin
    Exit(v0);
  end;
  Exit(v1);
end;

function ArrayGet9001(index: LongInt; v0: Double; v1: Double): Double;
begin
  if (index = 0) then begin
    Exit(v0);
  end;
  Exit(v1);
end;

function method0(integerWriteIndex: LongInt; floatWriteIndex: LongInt; integerReadIndex: LongInt; floatReadIndex: LongInt; integerBias: Int64; floatBias: Double): LongInt;
var
  v0_0: Int64;
  v0_1: Int64;
  v1_0: Double;
  v1_1: Double;
  spiralWriteValue0_v0_0: Int64;
  spiralWriteValue1_v1_0: Double;
  v2: LongInt;
begin
  v0_0 := 10;
  v0_1 := 20;
  v1_0 := 1.5;
  v1_1 := 2.5;
  if ((integerWriteIndex = 0) or (integerWriteIndex = 1)) then begin
    spiralWriteValue0_v0_0 := (ArrayGet9000(integerReadIndex, v0_0, v0_1) + integerBias);
    if (integerWriteIndex = 0) then begin
      v0_0 := spiralWriteValue0_v0_0;
    end else begin
      v0_1 := spiralWriteValue0_v0_0;
    end;
  end else begin
    Exit((-1));
  end;
  if ((floatWriteIndex = 0) or (floatWriteIndex = 1)) then begin
    spiralWriteValue1_v1_0 := (ArrayGet9001(floatReadIndex, v1_0, v1_1) + floatBias);
    if (floatWriteIndex = 0) then begin
      v1_0 := spiralWriteValue1_v1_0;
    end else begin
      v1_1 := spiralWriteValue1_v1_0;
    end;
  end else begin
    Exit((-2));
  end;
  if ((ArrayGet9000(integerReadIndex, v0_0, v0_1) = 40) and (ArrayGet9001(floatWriteIndex, v1_0, v1_1) = 4.0)) then begin
    v2 := 42;
  end else begin
    v2 := (-3);
  end;
  Exit(v2);
end;

end.
