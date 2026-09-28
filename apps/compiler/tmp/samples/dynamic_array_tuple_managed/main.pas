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
  Tuple0 = record
    v0: Array0;
    v1: Array0;
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
function DynamicArrayRefCount0(data: Array0): LongInt;
begin
  if data = nil then Exit(0);
  Result := data.RefCount;
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

function TupleCreate0(v0: Array0; v1: Array0): Tuple0;
begin
  Result.v0 := v0;
  Result.v1 := v1;
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
  v1 := DynamicArrayRefCount0(v0);
  DynamicArrayDrop0(v0);
  Exit(v1);
end;

function method2(v0: Array0): Tuple0;
begin
  DynamicArrayClone0(v0);
  Exit(TupleCreate0(v0, v0));
end;

function method5(v0: Array0; v1: Array0): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v2 := DynamicArrayRefCount0(v0);
  v3 := DynamicArrayGet0(v1, 0);
  DynamicArrayDrop0(v1);
  v4 := (v2 + v3);
  v5 := DynamicArrayGet0(v0, 0);
  DynamicArrayDrop0(v0);
  v6 := (v4 + v5);
  Exit(v6);
end;

function method4(v0: Array0; v1: Array0): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v2 := DynamicArrayCapacity0(v1);
  DynamicArrayClone0(v0);
  DynamicArrayClone0(v1);
  v3 := method5(v0, v1);
  DynamicArrayDrop0(v0);
  DynamicArrayDrop0(v1);
  v4 := (v2 + v3);
  Exit(v4);
end;

function method3(v0: Array0; v1: Array0): LongInt;
begin
  Exit(method4(v1, v0));
end;

function method6(v0: Array0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayRefCount0(v0);
  DynamicArrayDrop0(v0);
  Exit(v1);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: LongInt;
  v3: Array0;
  v4: Array0;
  tmp0: Tuple0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
begin
  v0 := 1;
  v1 := ArrayCreate0(v0, False);
  DynamicArraySet0(v1, 0, 7);
  DynamicArrayClone0(v1);
  method0(v1);
  DynamicArrayClone0(v1);
  v2 := method1(v1);
  DynamicArrayClone0(v1);
  tmp0 := method2(v1);
  v3 := tmp0.v0;
  v4 := tmp0.v1;
  DynamicArrayClone0(v3);
  DynamicArrayClone0(v4);
  v5 := method3(v3, v4);
  DynamicArrayClone0(v1);
  DynamicArrayDrop0(v3);
  DynamicArrayDrop0(v4);
  v6 := method6(v1);
  DynamicArrayDrop0(v1);
  v7 := (v5 + v2);
  v8 := (v7 + v6);
  v9 := (v8 - 29);
  Exit(v9);
end;

begin
  Halt(SpiralMain);
end.
