program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array1 = array of LongInt;
  Array0 = array of Array1;
  Tuple9000 = record
    v0: LongInt;
    v1: Array0;
  end;

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

function TupleCreate9000(v0: LongInt; v1: Array0): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
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
begin
  if (v0.v0 = 0) then begin
    Exit(0);
  end else begin
    v1 := v0.v1;
    v2 := DynamicArrayGet0(v1, 0);
    v3 := DynamicArrayGet0(v1, 1);
    v4 := DynamicArrayLen0(v1);
    DynamicArrayDrop0(v1);
    v5 := DynamicArrayGet1(v2, 0);
    v6 := (v4 + v5);
    v7 := DynamicArrayGet1(v2, 1);
    DynamicArrayDrop1(v2);
    v8 := (v6 + v7);
    v9 := DynamicArrayGet1(v3, 0);
    v10 := (v8 + v9);
    v11 := DynamicArrayGet1(v3, 1);
    DynamicArrayDrop1(v3);
    v12 := (v10 + v11);
    Exit(v12);
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
  DynamicArrayDrop1(v3);
  v4 := TupleCreate9000(1, v1);
  DynamicArrayDrop0(v1);
  v5 := score0(v4);
  v6 := (v5 - 20);
  Exit(v6);
end;

begin
  Halt(SpiralMain);
end.
