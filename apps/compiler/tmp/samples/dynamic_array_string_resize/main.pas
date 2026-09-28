program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array0Data = array of AnsiString;
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
procedure DynamicArraySet0(data: Array0; index: LongInt; value: AnsiString);
begin
  if data = nil then raise EAccessViolation.Create('nil Spiral array');
  if (index < 0) or (index >= data.Length) then raise ERangeError.Create('Spiral array index out of bounds');
  data.Data[index] := value;
end;
function DynamicArrayGet0(data: Array0; index: LongInt): AnsiString;
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
      data.Data[i] := Default(AnsiString);
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

procedure method0(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 1;
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

procedure method1(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 8;
  DynamicArrayReserve0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

procedure method2(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 3;
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

function method3(v0: Array0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayRefCount0(v0);
  DynamicArrayDrop0(v0);
  Exit(v1);
end;

function method4(v0: Array0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  DynamicArrayDrop0(v0);
  Exit(v1);
end;

procedure method5(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 1;
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

function SpiralMain: LongInt;
var
  v0: Array0;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
  v13: LongInt;
  v14: LongInt;
  v15: LongInt;
  v16: LongInt;
  v17: LongInt;
  v18: LongInt;
begin
  v0 := ArrayCreate0(4, True);
  DynamicArrayClone0(v0);
  method0(v0);
  v1 := 'ab';
  DynamicArraySet0(v0, 0, v1);
  DynamicArrayClone0(v0);
  method1(v0);
  DynamicArrayClone0(v0);
  method2(v0);
  v2 := 'cde';
  DynamicArraySet0(v0, 1, v2);
  v3 := 'f';
  DynamicArraySet0(v0, 2, v3);
  v4 := DynamicArrayGet0(v0, 0);
  v5 := DynamicArrayGet0(v0, 1);
  v6 := DynamicArrayGet0(v0, 2);
  DynamicArrayClone0(v0);
  v7 := method3(v0);
  DynamicArrayClone0(v0);
  v8 := method4(v0);
  DynamicArrayClone0(v0);
  method5(v0);
  v9 := Length(v4);
  v10 := Length(v5);
  v11 := (v9 + v10);
  v12 := Length(v6);
  v13 := (v11 + v12);
  v14 := (v13 + v7);
  v15 := (v14 + v8);
  v16 := DynamicArrayLen0(v0);
  DynamicArrayDrop0(v0);
  v17 := (v15 + v16);
  v18 := (v17 - 17);
  Exit(v18);
end;

begin
  Halt(SpiralMain);
end.
