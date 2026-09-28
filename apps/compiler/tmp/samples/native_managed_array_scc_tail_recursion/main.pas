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
  v1 := 4;
  DynamicArrayReserve0(v0, v1);
  DynamicArrayDrop0(v0);
  Exit;
end;

function __spiral_scc_method3_method2(__spiral_tail_state: LongInt; v0: LongInt; v1: Array0): LongInt;
var
  v2: LongInt;
  v3: Boolean;
  v4: Boolean;
  v5: LongInt;
  __spiral_scc_arg0: LongInt;
  __spiral_scc_arg1: Array0;
begin
  while True do begin
    if (__spiral_tail_state = 0) then begin
      v2 := (v0 - 1);
      v3 := (v2 = 0);
      if v3 then begin
        v4 := (7 = 7);
        if v4 then begin
          v5 := DynamicArrayGet0(v1, 0);
          DynamicArrayDrop0(v1);
          Exit(v5);
        end else begin
          DynamicArrayDrop0(v1);
          Exit(99);
        end;
      end else begin
        __spiral_scc_arg0 := v2;
        __spiral_scc_arg1 := v1;
        v0 := __spiral_scc_arg0;
        DynamicArrayClone0(__spiral_scc_arg1);
        DynamicArrayDrop0(v1);
        v1 := __spiral_scc_arg1;
        __spiral_tail_state := 1;
        Continue;
      end;
    end else begin
      v2 := (v0 - 1);
      v3 := (v2 = 0);
      if v3 then begin
        v4 := (11 = 7);
        if v4 then begin
          v5 := DynamicArrayGet0(v1, 0);
          DynamicArrayDrop0(v1);
          Exit(v5);
        end else begin
          DynamicArrayDrop0(v1);
          Exit(99);
        end;
      end else begin
        __spiral_scc_arg0 := v2;
        __spiral_scc_arg1 := v1;
        v0 := __spiral_scc_arg0;
        DynamicArrayClone0(__spiral_scc_arg1);
        DynamicArrayDrop0(v1);
        v1 := __spiral_scc_arg1;
        __spiral_tail_state := 0;
        Continue;
      end;
    end;
  end;
end;

function method3(v0: LongInt; v1: Array0): LongInt;
begin
  Exit(__spiral_scc_method3_method2(0, v0, v1));
end;

function method2(v0: LongInt; v1: Array0): LongInt;
begin
  Exit(__spiral_scc_method3_method2(1, v0, v1));
end;

function method1(v0: Array0): LongInt;
var
  v1: LongInt;
  v2: Boolean;
  v3: Boolean;
  v4: LongInt;
begin
  v1 := 1000000;
  v2 := (v1 = 0);
  if v2 then begin
    v3 := (7 = 7);
    if v3 then begin
      v4 := DynamicArrayGet0(v0, 0);
      DynamicArrayDrop0(v0);
      Exit(v4);
    end else begin
      DynamicArrayDrop0(v0);
      Exit(99);
    end;
  end else begin
    Exit(method2(v1, v0));
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: LongInt;
  v3: Boolean;
  v4: LongInt;
  v5: Boolean;
begin
  v0 := 1;
  v1 := ArrayCreate0(v0, False);
  DynamicArraySet0(v1, 0, 7);
  DynamicArrayClone0(v1);
  method0(v1);
  DynamicArrayClone0(v1);
  v2 := method1(v1);
  DynamicArraySet0(v1, 0, 13);
  v3 := (v2 = 7);
  if v3 then begin
    v4 := DynamicArrayGet0(v1, 0);
    DynamicArrayDrop0(v1);
    v5 := (v4 = 13);
    if v5 then begin
      Exit(0);
    end else begin
      Exit(2);
    end;
  end else begin
    DynamicArrayDrop0(v1);
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
