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
  Array1Data = array of Array0;
  Array1 = class
    RefCount: LongInt;
    Length: LongInt;
    Capacity: LongInt;
    Data: Array1Data;
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

function ArrayCreate1(len: LongInt; init_at_zero: Boolean): Array1;
begin
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  Result := Array1.Create;
  Result.RefCount := 1;
  Result.Length := len;
  Result.Capacity := len;
  SetLength(Result.Data, len);
  if not init_at_zero then begin end;
end;
procedure DynamicArraySet1(data: Array1; index: LongInt; value: Array0);
begin
  if data = nil then raise EAccessViolation.Create('nil Spiral array');
  if (index < 0) or (index >= data.Length) then raise ERangeError.Create('Spiral array index out of bounds');
  DynamicArrayClone0(value);
  DynamicArrayDrop0(data.Data[index]);
  data.Data[index] := value;
end;
function DynamicArrayGet1(data: Array1; index: LongInt): Array0;
begin
  if data = nil then raise EAccessViolation.Create('nil Spiral array');
  if (index < 0) or (index >= data.Length) then raise ERangeError.Create('Spiral array index out of bounds');
  Result := data.Data[index];
  DynamicArrayClone0(Result);
end;
function DynamicArrayLen1(data: Array1): LongInt;
begin
  if data = nil then Exit(0);
  Result := data.Length;
end;
procedure DynamicArrayResize1(data: Array1; len: LongInt);
var
  newCapacity: LongInt;
  i: LongInt;
begin
  if data = nil then raise EAccessViolation.Create('nil Spiral array');
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  if len < data.Length then
    for i := len to data.Length - 1 do
      DynamicArrayDrop0(data.Data[i]);
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
function DynamicArrayCapacity1(data: Array1): LongInt;
begin
  if data = nil then Exit(0);
  Result := data.Capacity;
end;
procedure DynamicArrayClone1(data: Array1);
begin
  if data <> nil then Inc(data.RefCount);
end;
procedure DynamicArrayDrop1(var data: Array1);
var
  i: LongInt;
begin
  if data = nil then Exit;
  Dec(data.RefCount);
  if data.RefCount = 0 then
  begin
    for i := 0 to data.Capacity - 1 do
      DynamicArrayDrop0(data.Data[i]);
    SetLength(data.Data, 0);
    data.Free;
  end;
  data := nil;
end;

procedure method0(v0: Array1);
var
  v1: LongInt;
begin
  v1 := 0;
  DynamicArrayResize1(v0, v1);
  DynamicArrayDrop1(v0);
  Exit;
end;

procedure method1(v0: Array1);
var
  v1: LongInt;
begin
  v1 := 1;
  DynamicArrayResize1(v0, v1);
  DynamicArrayDrop1(v0);
  Exit;
end;

procedure method2(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 0;
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

procedure method3(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 1;
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

function method5(v0: Array0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  DynamicArrayDrop0(v0);
  Exit(v1);
end;

function method4(v0: Array0; v1: Array1): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v2 := DynamicArrayCapacity1(v1);
  DynamicArrayDrop1(v1);
  DynamicArrayClone0(v0);
  v3 := method5(v0);
  DynamicArrayDrop0(v0);
  v4 := (v2 + v3);
  Exit(v4);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: Array1;
  v3: Array0;
  v4: Array0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
begin
  v0 := 1;
  v1 := ArrayCreate0(v0, False);
  DynamicArraySet0(v1, 0, 7);
  v2 := ArrayCreate1(v0, True);
  DynamicArraySet1(v2, 0, v1);
  v3 := DynamicArrayGet1(v2, 0);
  DynamicArrayClone1(v2);
  method0(v2);
  DynamicArrayClone1(v2);
  method1(v2);
  DynamicArraySet1(v2, 0, v3);
  DynamicArrayClone0(v1);
  method2(v1);
  DynamicArrayClone0(v3);
  method3(v3);
  DynamicArrayDrop0(v3);
  DynamicArraySet0(v1, 0, 9);
  v4 := DynamicArrayGet1(v2, 0);
  v5 := DynamicArrayGet0(v4, 0);
  v6 := DynamicArrayLen0(v4);
  DynamicArrayDrop0(v4);
  v7 := (v5 + v6);
  v8 := DynamicArrayLen1(v2);
  v9 := (v7 + v8);
  DynamicArrayClone0(v1);
  DynamicArrayClone1(v2);
  v10 := method4(v1, v2);
  DynamicArrayDrop0(v1);
  DynamicArrayDrop1(v2);
  v11 := (v9 + v10);
  v12 := (v11 - 13);
  Exit(v12);
end;

begin
  Halt(SpiralMain);
end.
