program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array1Data = array of LongInt;
  Array1 = class
    RefCount: LongInt;
    Length: LongInt;
    Capacity: LongInt;
    Data: Array1Data;
  end;
  Array0 = array of Array1;
  Tuple9000 = record
    v0: LongInt;
    v1: Array0;
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
procedure DynamicArraySet1(data: Array1; index: LongInt; value: LongInt);
begin
  if data = nil then raise EAccessViolation.Create('nil Spiral array');
  if (index < 0) or (index >= data.Length) then raise ERangeError.Create('Spiral array index out of bounds');
  data.Data[index] := value;
end;
function DynamicArrayGet1(data: Array1; index: LongInt): LongInt;
begin
  if data = nil then raise EAccessViolation.Create('nil Spiral array');
  if (index < 0) or (index >= data.Length) then raise ERangeError.Create('Spiral array index out of bounds');
  Result := data.Data[index];
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
      data.Data[i] := Default(LongInt);
  if len > data.Capacity then
  begin
    newCapacity := data.Capacity;
    if newCapacity < 1 then newCapacity := 1;
    while newCapacity < len do
    begin
      if newCapacity > High(LongInt) div 2 then
      begin
        newCapacity := len;
        Break;
      end;
      newCapacity := newCapacity * 2;
    end;
    SetLength(data.Data, newCapacity);
    data.Capacity := newCapacity;
  end;
  data.Length := len;
end;
procedure DynamicArrayReserve1(data: Array1; capacity: LongInt);
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

function ArrayCreate0(len: LongInt; init_at_zero: Boolean): Array0;
begin
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  SetLength(Result, len);
  if not init_at_zero then begin end;
end;
procedure DynamicArraySet0(var data: Array0; index: LongInt; value: Array1);
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  DynamicArrayClone1(value);
  DynamicArrayDrop1(data[index]);
  data[index] := value;
end;
function DynamicArrayGet0(const data: Array0; index: LongInt): Array1;
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  Result := data[index];
end;
function DynamicArrayLen0(const data: Array0): LongInt;
begin
  Result := Length(data);
end;
procedure DynamicArrayClone0(const data: Array0);
var
  i: LongInt;
begin
  for i := 0 to Length(data) - 1 do
    DynamicArrayClone1(data[i]);
end;
procedure DynamicArrayDrop0(var data: Array0);
var
  i: LongInt;
  item: Array1;
begin
  for i := 0 to Length(data) - 1 do
  begin
    item := data[i];
    DynamicArrayDrop1(item);
  end;
  SetLength(data, 0);
end;

function TupleCreate9000(v0: LongInt; v1: Array0): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

procedure method1(v0: Array1);
var
  v1: LongInt;
begin
  v1 := 3;
  DynamicArrayReserve1(v0, v1);
  DynamicArrayDrop1(v0);
  Exit;
end;

procedure method2(v0: Array1);
var
  v1: LongInt;
begin
  v1 := 1;
  DynamicArrayResize1(v0, v1);
  DynamicArrayDrop1(v0);
  Exit;
end;

procedure method3(v0: Array1);
var
  v1: LongInt;
begin
  v1 := 2;
  DynamicArrayResize1(v0, v1);
  DynamicArrayDrop1(v0);
  Exit;
end;

function method4(v0: Array1): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity1(v0);
  DynamicArrayDrop1(v0);
  Exit(v1);
end;

function score0(v0: Tuple9000): LongInt;
var
  v1: Array0;
  v2: Array1;
  v3: Array1;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
  v13: LongInt;
  v14: LongInt;
begin
  if (v0.v0 = 0) then begin
    if (v0.v0 = 1) then begin
      DynamicArrayDrop0(v0.v1);
    end;
    Exit(0);
  end else begin
    v1 := v0.v1;
    DynamicArrayClone0(v1);
    if (v0.v0 = 1) then begin
      DynamicArrayDrop0(v0.v1);
    end;
    v2 := DynamicArrayGet0(v1, 0);
    DynamicArrayClone1(v2);
    v3 := DynamicArrayGet0(v1, 1);
    DynamicArrayClone1(v2);
    DynamicArrayClone1(v3);
    method1(v2);
    DynamicArrayClone1(v3);
    method2(v3);
    DynamicArrayClone1(v3);
    method3(v3);
    DynamicArraySet1(v3, 1, 8);
    DynamicArrayClone1(v2);
    v4 := method4(v2);
    v5 := DynamicArrayLen0(v1);
    DynamicArrayDrop0(v1);
    v6 := (v5 + v4);
    v7 := DynamicArrayGet1(v2, 0);
    v8 := (v6 + v7);
    v9 := DynamicArrayGet1(v2, 1);
    DynamicArrayDrop1(v2);
    v10 := (v8 + v9);
    v11 := DynamicArrayGet1(v3, 0);
    v12 := (v10 + v11);
    v13 := DynamicArrayGet1(v3, 1);
    DynamicArrayDrop1(v3);
    v14 := (v12 + v13);
    Exit(v14);
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: Array1;
  v3: Array1;
  v4: Tuple9000;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 2;
  v1 := ArrayCreate0(v0, True);
  v2 := ArrayCreate1(v0, False);
  v3 := ArrayCreate1(v0, False);
  DynamicArraySet1(v2, 0, 3);
  DynamicArraySet1(v2, 1, 4);
  DynamicArraySet1(v3, 0, 5);
  DynamicArraySet1(v3, 1, 6);
  DynamicArraySet0(v1, 0, v2);
  DynamicArrayDrop1(v2);
  DynamicArraySet0(v1, 1, v3);
  DynamicArrayClone0(v1);
  DynamicArrayDrop1(v3);
  v4 := TupleCreate9000(1, v1);
  if (v4.v0 = 1) then begin
    DynamicArrayClone0(v4.v1);
  end;
  DynamicArrayDrop0(v1);
  v5 := score0(v4);
  if (v4.v0 = 1) then begin
    DynamicArrayDrop0(v4.v1);
  end;
  v6 := (v5 - 26);
  Exit(v6);
end;

begin
  Halt(SpiralMain);
end.
