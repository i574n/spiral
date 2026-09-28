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
  Tuple9000 = record
    v0: LongInt;
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

function TupleCreate9000(v0: LongInt; v1: Array0): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

procedure method0(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 1;
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
  DynamicArrayReserve0(v0, v1);
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

procedure method6(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 5;
  DynamicArrayReserve0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

function method7(v0: Array0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  DynamicArrayDrop0(v0);
  Exit(v1);
end;

procedure method8(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 9;
  DynamicArrayReserve0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

function method9(v0: Array0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  DynamicArrayDrop0(v0);
  Exit(v1);
end;

function method10(v0: Array0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayRefCount0(v0);
  DynamicArrayDrop0(v0);
  Exit(v1);
end;

function method13(v0: Array0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayRefCount0(v0);
  DynamicArrayDrop0(v0);
  Exit(v1);
end;

function method12(v0: Array0): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  DynamicArrayClone0(v0);
  v2 := method13(v0);
  DynamicArrayDrop0(v0);
  v3 := (v1 + v2);
  Exit(v3);
end;

function observe11(v0: Tuple9000): LongInt;
var
  v1: Array0;
begin
  if (v0.v0 = 0) then begin
    if (v0.v0 = 1) then begin
      DynamicArrayDrop0(v0.v1);
    end;
    Exit(70);
  end else begin
    v1 := v0.v1;
    DynamicArrayClone0(v1);
    if (v0.v0 = 1) then begin
      DynamicArrayDrop0(v0.v1);
    end;
    Exit(method12(v1));
  end;
end;

function method14(v0: Array0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayRefCount0(v0);
  DynamicArrayDrop0(v0);
  Exit(v1);
end;

function SpiralMain: LongInt;
var
  v0: Array0;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: Tuple9000;
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
  v19: LongInt;
  v20: LongInt;
  v21: LongInt;
  v22: LongInt;
  v23: LongInt;
  v24: LongInt;
begin
  v0 := ArrayCreate0(0, False);
  DynamicArrayClone0(v0);
  method0(v0);
  DynamicArrayClone0(v0);
  v1 := method1(v0);
  DynamicArrayClone0(v0);
  method2(v0);
  DynamicArrayClone0(v0);
  v2 := method3(v0);
  DynamicArrayClone0(v0);
  method4(v0);
  DynamicArrayClone0(v0);
  v3 := method5(v0);
  DynamicArrayClone0(v0);
  method6(v0);
  DynamicArrayClone0(v0);
  v4 := method7(v0);
  DynamicArrayClone0(v0);
  method8(v0);
  DynamicArrayClone0(v0);
  v5 := method9(v0);
  DynamicArrayClone0(v0);
  v6 := method10(v0);
  DynamicArrayClone0(v0);
  v7 := TupleCreate9000(1, v0);
  if (v7.v0 = 1) then begin
    DynamicArrayClone0(v7.v1);
  end;
  v8 := observe11(v7);
  DynamicArrayClone0(v0);
  if (v7.v0 = 1) then begin
    DynamicArrayDrop0(v7.v1);
  end;
  v9 := method14(v0);
  DynamicArrayDrop0(v0);
  v10 := (v1 - 1);
  v11 := (v2 - 2);
  v12 := (v10 + v11);
  v13 := (v3 - 4);
  v14 := (v12 + v13);
  v15 := (v4 - 8);
  v16 := (v14 + v15);
  v17 := (v5 - 16);
  v18 := (v16 + v17);
  v19 := (v6 - 2);
  v20 := (v18 + v19);
  v21 := (v8 - 20);
  v22 := (v20 + v21);
  v23 := (v9 - 2);
  v24 := (v22 + v23);
  Exit(v24);
end;

begin
  Halt(SpiralMain);
end.
