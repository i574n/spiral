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
procedure DynamicArrayClone0(const data: Array0);
begin
end;
procedure DynamicArrayDrop0(var data: Array0);
begin
  SetLength(data, 0);
end;

function method1(v0: LongInt; v1: Array0; v2: Array0): Array0;
var
  v3: LongInt;
  v4: Boolean;
  __spiral_tail_arg0: LongInt;
  __spiral_tail_arg1: Array0;
  __spiral_tail_arg2: Array0;
begin
  while True do begin
    v3 := (v0 - 1);
    v4 := (v3 = 0);
    if v4 then begin
      DynamicArrayDrop0(v1);
      Exit(v2);
    end else begin
      __spiral_tail_arg0 := v3;
      __spiral_tail_arg1 := v2;
      __spiral_tail_arg2 := v1;
      v0 := __spiral_tail_arg0;
      DynamicArrayClone0(__spiral_tail_arg1);
      DynamicArrayDrop0(v1);
      v1 := __spiral_tail_arg1;
      DynamicArrayClone0(__spiral_tail_arg2);
      DynamicArrayDrop0(v2);
      v2 := __spiral_tail_arg2;
      Continue;
    end;
  end;
end;

function method0(v0: Array0; v1: Array0): Array0;
var
  v2: LongInt;
  v3: Boolean;
begin
  v2 := 1000000;
  v3 := (v2 = 0);
  if v3 then begin
    DynamicArrayDrop0(v1);
    Exit(v0);
  end else begin
    Exit(method1(v2, v0, v1));
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: Array0;
  v3: Array0;
  v4: LongInt;
  v5: Boolean;
  v6: LongInt;
  v7: Boolean;
begin
  v0 := 1;
  v1 := ArrayCreate0(v0, False);
  v2 := ArrayCreate0(v0, False);
  DynamicArraySet0(v1, 0, 7);
  DynamicArraySet0(v2, 0, 11);
  DynamicArrayClone0(v1);
  DynamicArrayClone0(v2);
  v3 := method0(v1, v2);
  DynamicArraySet0(v3, 0, 13);
  DynamicArrayDrop0(v3);
  v4 := DynamicArrayGet0(v1, 0);
  DynamicArrayDrop0(v1);
  v5 := (v4 = 13);
  if v5 then begin
    v6 := DynamicArrayGet0(v2, 0);
    DynamicArrayDrop0(v2);
    v7 := (v6 = 11);
    if v7 then begin
      Exit(0);
    end else begin
      Exit(2);
    end;
  end else begin
    DynamicArrayDrop0(v2);
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
