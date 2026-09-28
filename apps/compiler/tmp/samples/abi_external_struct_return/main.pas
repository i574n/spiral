program SpiralGenerated;
{$mode objfpc}{$H+}

type
  SpiralLibcDivResult = record
    quot: LongInt;
    rem: LongInt;
  end;

function spiral_libc_div(numerator: LongInt; denominator: LongInt): SpiralLibcDivResult; cdecl; external 'c' name 'div';

function spiral_abi_libc_div_pack(numerator: LongInt; denominator: LongInt): LongInt; inline;
var
  rawResult: SpiralLibcDivResult;
begin
  if denominator = 0 then Halt(93);
  rawResult := spiral_libc_div(numerator, denominator);
  Result := rawResult.quot * 10 + rawResult.rem;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := spiral_abi_libc_div_pack(17, 5);
  Exit(v0);
end;

begin
  Halt(SpiralMain);
end.
