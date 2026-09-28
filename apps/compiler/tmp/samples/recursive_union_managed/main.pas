program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array0 = array of LongInt;
  Recursive0 = class
    RefCount: LongInt;
    Tag: LongInt;
    v0: Array0;
    v1: Recursive0;
  end;

function RecursiveCreate0_0: Recursive0;
begin
  Result := Recursive0.Create;
  Result.RefCount := 1;
  Result.Tag := 0;
end;
function RecursiveCreate0_1(v0: Array0; v1: Recursive0): Recursive0;
begin
  Result := Recursive0.Create;
  Result.RefCount := 1;
  Result.Tag := 1;
  Result.v0 := v0;
  Result.v1 := v1;
end;
function RecursiveTag0(value: Recursive0): LongInt;
begin
  Result := value.Tag;
end;
function RecursiveField0_0(value: Recursive0): Array0;
begin
  if value.Tag <> 1 then raise EVariantError.Create('recursive union field requested from wrong case');
  Result := value.v0;
end;
function RecursiveField0_1(value: Recursive0): Recursive0;
begin
  if value.Tag <> 1 then raise EVariantError.Create('recursive union field requested from wrong case');
  Result := value.v1;
end;
procedure RecursiveClone0(value: Recursive0);
begin
  if value <> nil then Inc(value.RefCount);
end;
procedure RecursiveDrop0(var value: Recursive0);
var
  child: Recursive0;
begin
  if value = nil then Exit;
  Dec(value.RefCount);
  if value.RefCount = 0 then
  begin
    child := nil;
    if value.Tag = 1 then child := value.v1;
    value.Free;
    value := nil;
    if child <> nil then RecursiveDrop0(child);
  end
  else value := nil;
end;

function ArrayCreate0(len: LongInt; init_at_zero: Boolean): Array0;
begin
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  SetLength(Result, len);
  if not init_at_zero then begin end;
end;
procedure DynamicArraySet0(var data: Array0; index: LongInt; value: LongInt);
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  data[index] := value;
end;
function DynamicArrayGet0(const data: Array0; index: LongInt): LongInt;
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  Result := data[index];
end;
function DynamicArrayLen0(const data: Array0): LongInt;
begin
  Result := Length(data);
end;
procedure DynamicArrayClone0(const data: Array0);
begin
end;
procedure DynamicArrayDrop0(var data: Array0);
begin
  SetLength(data, 0);
end;

function sum0(v0: Recursive0): LongInt;
var
  v1: Array0;
  v2: Recursive0;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  if (RecursiveTag0(v0) = 1) then begin
    v1 := RecursiveField0_0(v0);
    v2 := RecursiveField0_1(v0);
    DynamicArrayClone0(v1);
    RecursiveClone0(v2);
    RecursiveDrop0(v0);
    v3 := DynamicArrayLen0(v1);
    RecursiveClone0(v2);
    DynamicArrayDrop0(v1);
    v4 := sum0(v2);
    RecursiveDrop0(v2);
    v5 := (v3 + v4);
    Exit(v5);
  end else begin
    RecursiveDrop0(v0);
    Exit(0);
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: Recursive0;
  v3: Recursive0;
  v4: Recursive0;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 2;
  v1 := ArrayCreate0(v0, False);
  v2 := RecursiveCreate0_0();
  DynamicArrayClone0(v1);
  RecursiveClone0(v2);
  v3 := RecursiveCreate0_1(v1, v2);
  DynamicArrayClone0(v1);
  RecursiveClone0(v3);
  RecursiveDrop0(v2);
  v4 := RecursiveCreate0_1(v1, v3);
  RecursiveClone0(v4);
  DynamicArrayDrop0(v1);
  RecursiveDrop0(v3);
  v5 := sum0(v4);
  RecursiveDrop0(v4);
  v6 := (v5 - 4);
  Exit(v6);
end;

begin
  Halt(SpiralMain);
end.
