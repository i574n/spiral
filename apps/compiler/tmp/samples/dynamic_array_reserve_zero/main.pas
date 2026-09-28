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
procedure DynamicArrayReserve0(data: Array0; capacity: LongInt);
begin
  if data = nil then raise EAccessViolation.Create('nil Spiral array');
  if capacity < 0 then raise ERangeError.Create('negative Spiral array capacity');
  if capacity > data.Capacity then
  begin
    SetLength(data.Data, capacity);
    data.Capacity := capacity;
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

procedure method2(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 2;
  DynamicArrayReserve0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

function method3(v0: Array0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  DynamicArrayDrop0(v0);
  Exit(v1);
end;

procedure method4(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 3;
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

procedure method5(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 0;
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

procedure method6(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 3;
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

function SpiralMain: LongInt;
var
  v0: Array0;
  v1: LongInt;
  v2: Boolean;
  v3: LongInt;
  v4: Boolean;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
begin
  v0 := ArrayCreate0(0, False);
  DynamicArrayClone0(v0);
  method0(v0);
  DynamicArrayClone0(v0);
  v1 := method1(v0);
  v2 := (v1 < 3);
  if v2 then begin
    DynamicArrayDrop0(v0);
    Exit(10);
  end else begin
    DynamicArrayClone0(v0);
    method2(v0);
    DynamicArrayClone0(v0);
    v3 := method3(v0);
    v4 := (v3 = v1);
    if v4 then begin
      DynamicArrayClone0(v0);
      method4(v0);
      DynamicArraySet0(v0, 0, 4);
      DynamicArraySet0(v0, 1, 5);
      DynamicArraySet0(v0, 2, 6);
      DynamicArrayClone0(v0);
      method5(v0);
      DynamicArrayClone0(v0);
      method6(v0);
      v5 := DynamicArrayLen0(v0);
      v6 := DynamicArrayGet0(v0, 0);
      v7 := (v5 + v6);
      v8 := DynamicArrayGet0(v0, 1);
      v9 := (v7 + v8);
      v10 := DynamicArrayGet0(v0, 2);
      DynamicArrayDrop0(v0);
      v11 := (v9 + v10);
      v12 := (v11 - 3);
      Exit(v12);
    end else begin
      DynamicArrayDrop0(v0);
      Exit(11);
    end;
  end;
end;

begin
  Halt(SpiralMain);
end.
