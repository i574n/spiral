program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array1 = array of LongInt;
  Array0 = array of Array1;

function ArrayCreate1(len: LongInt; init_at_zero: Boolean): Array1;
begin
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  SetLength(Result, len);
  if not init_at_zero then begin end;
end;
procedure DynamicArraySet1(var data: Array1; index: LongInt; value: LongInt);
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  data[index] := value;
end;
function DynamicArrayGet1(const data: Array1; index: LongInt): LongInt;
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  Result := data[index];
end;
function DynamicArrayLen1(const data: Array1): LongInt;
begin
  Result := Length(data);
end;
procedure DynamicArrayDrop1(var data: Array1);
begin
  SetLength(data, 0);
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
procedure DynamicArrayDrop0(var data: Array0);
begin
  SetLength(data, 0);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: Array1;
  v3: Array1;
  v4: Array1;
  v5: Array1;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
  v13: LongInt;
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
  DynamicArrayDrop1(v3);
  v4 := DynamicArrayGet0(v1, 0);
  v5 := DynamicArrayGet0(v1, 1);
  DynamicArrayDrop0(v1);
  v6 := DynamicArrayGet1(v4, 0);
  v7 := DynamicArrayGet1(v4, 1);
  DynamicArrayDrop1(v4);
  v8 := (v6 + v7);
  v9 := DynamicArrayGet1(v5, 0);
  v10 := (v8 + v9);
  v11 := DynamicArrayGet1(v5, 1);
  DynamicArrayDrop1(v5);
  v12 := (v10 + v11);
  v13 := (v12 - 18);
  Exit(v13);
end;

begin
  Halt(SpiralMain);
end.
