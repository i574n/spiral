program SpiralGenerated;
{$mode objfpc}{$H+}

type
  SpiralLibcLldivResult = record
    quot: Int64;
    rem: Int64;
  end;

function spiral_libc_lldiv(numerator: Int64; denominator: Int64): SpiralLibcLldivResult; cdecl; external 'c' name 'lldiv';

function spiral_abi_libc_lldiv_pack(numerator: Int64; denominator: Int64): Int64; inline;
var
  rawResult: SpiralLibcLldivResult;
begin
  if denominator = 0 then Halt(97);
  if SizeOf(SpiralLibcLldivResult) <> 2 * SizeOf(Int64) then Halt(98);
  rawResult := spiral_libc_lldiv(numerator, denominator);
  Result := rawResult.quot * denominator + rawResult.rem;
end;

function SpiralMain: LongInt;
var
  v0: Int64;
  v1: Int64;
  v2: Int64;
  v3: Boolean;
begin
  v0 := 5000000007;
  v1 := 1000;
  v2 := spiral_abi_libc_lldiv_pack(v0, v1);
  v3 := (v2 = 5000000007);
  if v3 then begin
    Exit(0);
  end else begin
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
