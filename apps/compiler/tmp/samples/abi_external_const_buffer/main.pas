program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array0 = array of Byte;

function ArrayCreate0(len: LongInt; init_at_zero: Boolean): Array0;
begin
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  SetLength(Result, len);
  if not init_at_zero then begin end;
end;
procedure DynamicArraySet0(var data: Array0; index: LongInt; value: Byte);
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  data[index] := value;
end;
function DynamicArrayGet0(const data: Array0; index: LongInt): Byte;
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

function spiral_libc_memcmp(leftValue: Pointer; rightValue: Pointer; count: SizeUInt): LongInt; cdecl; external 'c' name 'memcmp';

function spiral_abi_libc_memcmp(const leftValue: Array0; const rightValue: Array0; count: LongInt): LongInt; inline;
var
  leftPointer: Pointer;
  rightPointer: Pointer;
begin
  if count < 0 then Halt(90);
  if count > Length(leftValue) then Halt(91);
  if count > Length(rightValue) then Halt(92);
  if count = 0 then Exit(0);
  leftPointer := @leftValue[0];
  rightPointer := @rightValue[0];
  Result := spiral_libc_memcmp(leftPointer, rightPointer, SizeUInt(count));
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: Array0;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: Boolean;
  v8: Boolean;
  v9: Byte;
  v10: Boolean;
  v11: Byte;
  v12: Boolean;
begin
  v0 := 4;
  v1 := ArrayCreate0(v0, False);
  v2 := ArrayCreate0(v0, False);
  DynamicArraySet0(v1, 0, 65);
  DynamicArraySet0(v1, 1, 66);
  DynamicArraySet0(v1, 2, 67);
  DynamicArraySet0(v1, 3, 68);
  DynamicArraySet0(v2, 0, 65);
  DynamicArraySet0(v2, 1, 66);
  DynamicArraySet0(v2, 2, 67);
  DynamicArraySet0(v2, 3, 69);
  v3 := 3;
  v4 := 4;
  v5 := spiral_abi_libc_memcmp(v1, v2, v3);
  v6 := spiral_abi_libc_memcmp(v1, v2, v4);
  v7 := (v5 = 0);
  if v7 then begin
    v8 := (v6 = 0);
    if v8 then begin
      DynamicArrayDrop0(v1);
      DynamicArrayDrop0(v2);
      Exit(2);
    end else begin
      v9 := DynamicArrayGet0(v1, 3);
      DynamicArrayDrop0(v1);
      v10 := (v9 = 68);
      if v10 then begin
        v11 := DynamicArrayGet0(v2, 3);
        DynamicArrayDrop0(v2);
        v12 := (v11 = 69);
        if v12 then begin
          Exit(0);
        end else begin
          Exit(4);
        end;
      end else begin
        DynamicArrayDrop0(v2);
        Exit(3);
      end;
    end;
  end else begin
    DynamicArrayDrop0(v1);
    DynamicArrayDrop0(v2);
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
