program SpiralGenerated;
{$mode objfpc}{$H+}

type
  SpiralLibcCompareI32 = function(leftValue: Pointer; rightValue: Pointer): LongInt; cdecl;

function spiral_libc_compare_i32(leftValue: Pointer; rightValue: Pointer): LongInt; cdecl;
var
  leftInteger: LongInt;
  rightInteger: LongInt;
begin
  leftInteger := PLongInt(leftValue)^;
  rightInteger := PLongInt(rightValue)^;
  if leftInteger < rightInteger then Exit(-1);
  if leftInteger > rightInteger then Exit(1);
  Result := 0;
end;

procedure spiral_libc_qsort(base: Pointer; count: SizeUInt; width: SizeUInt; compare: SpiralLibcCompareI32); cdecl; external 'c' name 'qsort';

function spiral_abi_libc_qsort3_pack(firstValue: LongInt; secondValue: LongInt; thirdValue: LongInt): LongInt; inline;
var
  values: array[0..2] of LongInt;
begin
  values[0] := firstValue;
  values[1] := secondValue;
  values[2] := thirdValue;
  spiral_libc_qsort(@values[0], 3, SizeOf(LongInt), @spiral_libc_compare_i32);
  Result := values[0] * 100 + values[1] * 10 + values[2];
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := spiral_abi_libc_qsort3_pack(3, 1, 2);
  Exit(v0);
end;

begin
  Halt(SpiralMain);
end.
