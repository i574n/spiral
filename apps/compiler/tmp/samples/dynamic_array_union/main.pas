program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array0 = array of LongInt;
  Tuple9000 = record
    v0: LongInt;
    v1: Array0;
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

function TupleCreate9000(v0: LongInt; v1: Array0): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

function score0(v0: Tuple9000): LongInt;
var
  v1: Array0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  if (v0.v0 = 0) then begin
    Exit(0);
  end else begin
    v1 := v0.v1;
    v2 := DynamicArrayLen0(v1);
    v3 := DynamicArrayGet0(v1, 0);
    v4 := (v2 + v3);
    v5 := DynamicArrayGet0(v1, 1);
    DynamicArrayDrop0(v1);
    v6 := (v4 + v5);
    Exit(v6);
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: Tuple9000;
  v3: LongInt;
  v4: LongInt;
begin
  v0 := 2;
  v1 := ArrayCreate0(v0, False);
  DynamicArraySet0(v1, 0, 4);
  DynamicArraySet0(v1, 1, 5);
  v2 := TupleCreate9000(1, v1);
  DynamicArrayDrop0(v1);
  v3 := score0(v2);
  v4 := (v3 - 11);
  Exit(v4);
end;

begin
  Halt(SpiralMain);
end.
