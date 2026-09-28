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
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

procedure method2(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 8;
  DynamicArrayReserve0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

procedure method3(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 3;
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

procedure method4(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 2;
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

function mutate1(v0: Tuple9000): LongInt;
var
  v1: Array0;
  v2: AnsiString;
  v3: AnsiString;
begin
  if (v0.v0 = 0) then begin
    if (v0.v0 = 1) then begin
      DynamicArrayDrop0(v0.v1);
    end;
    Exit(90);
  end else begin
    v1 := v0.v1;
    DynamicArrayClone0(v1);
    DynamicArrayClone0(v1);
    if (v0.v0 = 1) then begin
      DynamicArrayDrop0(v0.v1);
    end;
    method2(v1);
    DynamicArrayClone0(v1);
    method3(v1);
    v2 := 'cde';
    DynamicArraySet0(v1, 1, v2);
    v3 := 'f';
    DynamicArraySet0(v1, 2, v3);
    DynamicArrayClone0(v1);
    method4(v1);
    Exit(method5(v1));
  end;
end;

function observe6(v0: Tuple9000): LongInt;
var
  v1: Array0;
  v2: LongInt;
  v3: AnsiString;
  v4: LongInt;
  v5: LongInt;
  v6: AnsiString;
  v7: LongInt;
  v8: LongInt;
begin
  if (v0.v0 = 0) then begin
    if (v0.v0 = 1) then begin
      DynamicArrayDrop0(v0.v1);
    end;
    Exit(91);
  end else begin
    v1 := v0.v1;
    DynamicArrayClone0(v1);
    if (v0.v0 = 1) then begin
      DynamicArrayDrop0(v0.v1);
    end;
    v2 := DynamicArrayLen0(v1);
    v3 := DynamicArrayGet0(v1, 0);
    v4 := Length(v3);
    v5 := (v2 + v4);
    v6 := DynamicArrayGet0(v1, 1);
    DynamicArrayDrop0(v1);
    v7 := Length(v6);
    v8 := (v5 + v7);
    Exit(v8);
  end;
end;

procedure method7(v0: Array0);
var
  v1: LongInt;
begin
  v1 := 0;
  DynamicArrayResize0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

procedure method8(v0: Array0);
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
  v2: Tuple9000;
  v3: LongInt;
  v4: Tuple9000;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
begin
  v0 := ArrayCreate0(4, True);
  DynamicArrayClone0(v0);
  method0(v0);
  v1 := 'ab';
  DynamicArraySet0(v0, 0, v1);
  DynamicArrayClone0(v0);
  v2 := TupleCreate9000(1, v0);
  if (v2.v0 = 1) then begin
    DynamicArrayClone0(v2.v1);
  end;
  v3 := mutate1(v2);
  DynamicArrayClone0(v0);
  if (v2.v0 = 1) then begin
    DynamicArrayDrop0(v2.v1);
  end;
  v4 := TupleCreate9000(1, v0);
  if (v4.v0 = 1) then begin
    DynamicArrayClone0(v4.v1);
  end;
  v5 := observe6(v4);
  DynamicArrayClone0(v0);
  if (v4.v0 = 1) then begin
    DynamicArrayDrop0(v4.v1);
  end;
  method7(v0);
  DynamicArrayClone0(v0);
  method8(v0);
  v6 := (v5 + v3);
  v7 := DynamicArrayLen0(v0);
  DynamicArrayDrop0(v0);
  v8 := (v6 + v7);
  v9 := (v8 - 16);
  Exit(v9);
end;

begin
  Halt(SpiralMain);
end.
