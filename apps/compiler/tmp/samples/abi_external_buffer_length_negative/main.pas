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

function spiral_libc_memset(destination: Pointer; byteValue: LongInt; count: SizeUInt): Pointer; cdecl; external 'c' name 'memset';

function spiral_abi_libc_memset(var value: Array0; byteValue: LongInt; count: LongInt): LongInt; inline;
begin
  if count < 0 then Halt(88);
  if count > Length(value) then Halt(89);
  if count <> 0 then spiral_libc_memset(@value[0], byteValue, SizeUInt(count));
  Result := count;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Array0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v0 := 2;
  v1 := ArrayCreate0(v0, False);
  DynamicArraySet0(v1, 0, 0);
  DynamicArraySet0(v1, 1, 0);
  v2 := 65;
  v3 := 3;
  v4 := spiral_abi_libc_memset(v1, v2, v3);
  DynamicArrayDrop0(v1);
  Exit(v4);
end;

begin
  Halt(SpiralMain);
end.
