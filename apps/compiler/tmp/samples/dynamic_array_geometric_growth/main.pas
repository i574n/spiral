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
procedure DynamicArrayReserve0(data: Array0; capacity: LongInt);
var
  newCapacity: LongInt;
begin
  if data = nil then raise EAccessViolation.Create('nil Spiral array');
  if capacity < 0 then raise ERangeError.Create('negative Spiral array capacity');
  if capacity > data.Capacity then
  begin
    newCapacity := data.Capacity;
    if newCapacity < 1 then newCapacity := 1;
    while newCapacity < capacity do
    begin
      if newCapacity > High(LongInt) div 2 then
      begin
        newCapacity := capacity;
        Break;
      end;
      newCapacity := newCapacity * 2;
    end;
    SetLength(data.Data, newCapacity);
    data.Capacity := newCapacity;
  end;
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
  v1 := 3;
  DynamicArrayReserve0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

function method1(v0: Array0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  DynamicArrayDrop0(v0);
  Exit(v1);
end;

function SpiralMain: LongInt;
var
  v0: Array0;
  v1: LongInt;
  v2: LongInt;
begin
  v0 := ArrayCreate0(0, False);
  DynamicArrayClone0(v0);
  method0(v0);
  DynamicArrayClone0(v0);
  v1 := method1(v0);
  DynamicArrayDrop0(v0);
  v2 := (v1 - 4);
  Exit(v2);
end;

begin
  Halt(SpiralMain);
end.
