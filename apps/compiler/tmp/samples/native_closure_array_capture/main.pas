program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array0 = array of LongInt;
  ClosureValue0 = record
    v0: Array0;
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

function ClosureValueCreate0(v0: Array0): ClosureValue0;
begin
  Result.v0 := v0;
end;

function ClosureInvoke0(x: ClosureValue0; v1: LongInt): LongInt;
var
  v0: Array0;
  v2: LongInt;
  v3: LongInt;
begin
  v0 := x.v0;
  v2 := DynamicArrayLen0(v0);
  v3 := (v2 + v1);
  Exit(v3);
end;

function SpiralMain: LongInt;
var
  v0: Array0;
  v1: ClosureValue0;
begin
  v0 := ArrayCreate0(2, False);
  DynamicArrayClone0(v0);
  v1 := ClosureValueCreate0(v0);
  DynamicArrayDrop0(v0);
  Exit(ClosureInvoke0(v1, 40));
end;

begin
  Halt(SpiralMain);
end.
