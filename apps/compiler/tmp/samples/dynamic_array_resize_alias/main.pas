program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array0Data = array of LongInt;
  Array0 = class
    RefCount: LongInt;
    Length: LongInt;
    Capacity: LongInt;
    Data: Array0Data;
  end;

function ArrayCreate0(len: LongInt; init_at_zero: Boolean): Array0;
begin
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  Result := Array0.Create;
  Result.RefCount := 1;
  Result.Length := len;
  Result.Capacity := len;
  SetLength(Result.Data, len);
  if not init_at_zero then begin end;
end;
procedure DynamicArraySet0(data: Array0; index: LongInt; value: LongInt);
begin
  if data = nil then raise EAccessViolation.Create('nil Spiral array');
  if (index < 0) or (index >= data.Length) then raise ERangeError.Create('Spiral array index out of bounds');
  data.Data[index] := value;
end;
function DynamicArrayGet0(data: Array0; index: LongInt): LongInt;
begin
  if data = nil then raise EAccessViolation.Create('nil Spiral array');
  if (index < 0) or (index >= data.Length) then raise ERangeError.Create('Spiral array index out of bounds');
  Result := data.Data[index];
end;
function DynamicArrayLen0(data: Array0): LongInt;
begin
  if data = nil then Exit(0);
  Result := data.Length;
end;
procedure DynamicArrayResize0(data: Array0; len: LongInt);
var
  newCapacity: LongInt;
  i: LongInt;
begin
  if data = nil then raise EAccessViolation.Create('nil Spiral array');
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  if len < data.Length then
    for i := len to data.Length - 1 do
      data.Data[i] := Default(LongInt);
  if len > data.Capacity then
  begin
    newCapacity := data.Capacity;
    if newCapacity < 1 then newCapacity := 1;
    while newCapacity < len do newCapacity := newCapacity * 2;
    SetLength(data.Data, newCapacity);
    data.Capacity := newCapacity;
  end;
  data.Length := len;
end;
function DynamicArrayCapacity0(data: Array0): LongInt;
begin
  if data = nil then Exit(0);
  Result := data.Capacity;
end;
procedure DynamicArrayClone0(data: Array0);
begin
  if data <> nil then Inc(data.RefCount);
end;
procedure DynamicArrayDrop0(var data: Array0);
begin
  if data = nil then Exit;
  Dec(data.RefCount);
  if data.RefCount = 0 then
  begin
    SetLength(data.Data, 0);
    data.Free;
  end;
  data := nil;
end;

procedure method0(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 2;
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

procedure method1(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 4;
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

function method2(v0: Array0): LongInt;
var
  v1: LongInt;
  v2: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  DynamicArrayDrop0(v0);
  v2 := (v1 - 15);
  Exit(v2);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 4;
  v1 := ArrayCreate0(v0, False);
  DynamicArraySet0(v1, 0, 1);
  DynamicArraySet0(v1, 1, 2);
  DynamicArraySet0(v1, 2, 3);
  DynamicArraySet0(v1, 3, 4);
  DynamicArrayClone0(v1);
  method0(v1);
  DynamicArrayClone0(v1);
  method1(v1);
  DynamicArraySet0(v1, 3, 7);
  v2 := DynamicArrayLen0(v1);
  v3 := DynamicArrayGet0(v1, 3);
  v4 := (v2 + v3);
  DynamicArrayClone0(v1);
  v5 := method2(v1);
  DynamicArrayDrop0(v1);
  v6 := (v4 + v5);
  Exit(v6);
end;

begin
  Halt(SpiralMain);
end.
