program SpiralGenerated;
{$mode objfpc}{$H+}

function spiral_libc_llabs(value: Int64): Int64; cdecl; external 'c' name 'llabs';

function spiral_abi_libc_llabs(value: Int64): Int64; inline;
begin
  Result := spiral_libc_llabs(value);
end;

function SpiralMain: LongInt;
var
  v0: Int64;
  v1: Int64;
  v2: Boolean;
begin
  v0 := (-5000000000);
  v1 := spiral_abi_libc_llabs(v0);
  v2 := (v1 = 5000000000);
  if v2 then begin
    Exit(0);
  end else begin
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
