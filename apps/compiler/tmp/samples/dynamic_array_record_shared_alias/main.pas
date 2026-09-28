program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array0 = array of LongInt;
  Tuple0 = record
    v0: Array0;
    v1: LongInt;
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
procedure DynamicArrayDrop0(var data: Array0);
begin
  SetLength(data, 0);
end;

function TupleCreate0(v0: Array0; v1: LongInt): Tuple0;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

function method0: Tuple0;
var
  v0: LongInt;
  v1: Array0;
begin
  v0 := 2;
  v1 := ArrayCreate0(v0, False);
  DynamicArraySet0(v1, 0, 3);
  DynamicArraySet0(v1, 1, 4);
  Exit(TupleCreate0(v1, 1));
end;

function method1(v0: Array0; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v2 := DynamicArrayGet0(v0, 0);
  DynamicArrayDrop0(v0);
  v3 := (v2 + v1);
  v4 := (v3 - 1);
  Exit(v4);
end;

function method2(v0: Array0; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v2 := DynamicArrayGet0(v0, 0);
  v3 := DynamicArrayGet0(v0, 1);
  DynamicArrayDrop0(v0);
  v4 := (v2 + v3);
  v5 := (v4 + v1);
  Exit(v5);
end;

function SpiralMain: LongInt;
var
  v0: Array0;
  v1: LongInt;
  tmp0: Tuple0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  tmp0 := method0();
  v0 := tmp0.v0;
  v1 := tmp0.v1;
  v2 := method1(v0, v1);
  v3 := method2(v0, v1);
  DynamicArrayDrop0(v0);
  v4 := (v2 + v3);
  v5 := (v4 - 11);
  Exit(v5);
end;

begin
  Halt(SpiralMain);
end.
