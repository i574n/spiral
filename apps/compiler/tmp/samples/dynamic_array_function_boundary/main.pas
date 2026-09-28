program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array0 = array of LongInt;

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
procedure DynamicArrayDrop0(var data: Array0);
begin
  SetLength(data, 0);
end;

function method0(v0: Array0; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v2 := DynamicArrayGet0(v0, v1);
  v3 := DynamicArrayLen0(v0);
  DynamicArrayDrop0(v0);
  v4 := (v2 + v3);
  v5 := (v4 - 10);
  Exit(v5);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: LongInt;
begin
  v0 := 3;
  v1 := ArrayCreate0(v0, False);
  DynamicArraySet0(v1, 0, 2);
  DynamicArraySet0(v1, 1, 5);
  DynamicArraySet0(v1, 2, 7);
  v2 := 2;
  Exit(method0(v1, v2));
end;

begin
  Halt(SpiralMain);
end.
