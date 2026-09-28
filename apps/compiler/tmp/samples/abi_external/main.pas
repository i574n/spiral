program SpiralGenerated;
{$mode objfpc}{$H+}

function spiral_libc_abs(value: LongInt): LongInt; cdecl; external 'c' name 'abs';

function spiral_abi_libc_abs(value: LongInt): LongInt; inline;
begin
  Result := spiral_libc_abs(value);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
begin
  v0 := (-42);
  v1 := spiral_abi_libc_abs(v0);
  Exit(v1);
end;

begin
  Halt(SpiralMain);
end.
