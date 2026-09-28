program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array0 = array of Double;

function ArrayCreate0(len: LongInt; init_at_zero: Boolean): Array0;
begin
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  SetLength(Result, len);
  if not init_at_zero then begin end;
end;
procedure DynamicArraySet0(var data: Array0; index: LongInt; value: Double);
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  data[index] := value;
end;
function DynamicArrayGet0(const data: Array0; index: LongInt): Double;
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
  v2: LongInt;
  v3: Double;
  v4: Boolean;
begin
  v0 := 2;
  v1 := ArrayCreate0(v0, False);
  DynamicArraySet0(v1, 0, 1.5);
  DynamicArraySet0(v1, 1, 2.5);
  v2 := 1;
  v3 := DynamicArrayGet0(v1, v2);
  DynamicArrayDrop0(v1);
  v4 := (v3 >= 2.0);
  if v4 then begin
    Exit(0);
  end else begin
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
