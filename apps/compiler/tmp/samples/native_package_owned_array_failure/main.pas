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
    v1: LongInt;
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

function TupleCreate0(v0: Array0; v1: LongInt): Tuple0;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

function fail0(v0: Tuple0): LongInt;
var
  v1: Array0;
begin
  v1 := v0.v0;
  DynamicArrayDrop0(v1);
  raise Exception.Create('package-owned managed array failure');
end;

function method0(v0: Tuple0): LongInt;
begin
  Exit(fail0(v0));
end;

function SpiralMain: LongInt;
var
  v0: Array0;
  v2: LongInt;
  v1: Tuple0;
begin
  v0 := ArrayCreate0(1, False);
  DynamicArraySet0(v0, 0, 7);
  v2 := DynamicArrayRefCount0(v0);
  DynamicArrayClone0(v0);
  v1 := TupleCreate0(v0, (40 + v2));
  DynamicArrayDrop0(v0);
  Exit(method0(v1));
end;

begin
  Halt(SpiralMain);
end.
