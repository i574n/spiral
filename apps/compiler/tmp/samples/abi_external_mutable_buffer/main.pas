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
  v5: Boolean;
  v6: Byte;
  v7: Boolean;
  v8: Byte;
  v9: Boolean;
  v10: Byte;
  v11: Boolean;
  v12: Byte;
  v13: Boolean;
begin
  v0 := 4;
  v1 := ArrayCreate0(v0, False);
  DynamicArraySet0(v1, 0, 0);
  DynamicArraySet0(v1, 1, 0);
  DynamicArraySet0(v1, 2, 0);
  DynamicArraySet0(v1, 3, 0);
  v2 := 65;
  v3 := 3;
  v4 := spiral_abi_libc_memset(v1, v2, v3);
  v5 := (v4 = 3);
  if v5 then begin
    v6 := DynamicArrayGet0(v1, 0);
    v7 := (v6 = 65);
    if v7 then begin
      v8 := DynamicArrayGet0(v1, 1);
      v9 := (v8 = 65);
      if v9 then begin
        v10 := DynamicArrayGet0(v1, 2);
        v11 := (v10 = 65);
        if v11 then begin
          v12 := DynamicArrayGet0(v1, 3);
          DynamicArrayDrop0(v1);
          v13 := (v12 = 0);
          if v13 then begin
            Exit(0);
          end else begin
            Exit(4);
          end;
        end else begin
          DynamicArrayDrop0(v1);
          Exit(3);
        end;
      end else begin
        DynamicArrayDrop0(v1);
        Exit(2);
      end;
    end else begin
      DynamicArrayDrop0(v1);
      Exit(1);
    end;
  end else begin
    DynamicArrayDrop0(v1);
    Exit(5);
  end;
end;

begin
  Halt(SpiralMain);
end.
