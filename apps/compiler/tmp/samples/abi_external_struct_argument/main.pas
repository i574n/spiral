program SpiralGenerated;
{$mode objfpc}{$H+}

type
  SpiralLibmComplex64 = record
    re: Double;
    im: Double;
  end;

function spiral_libm_cabs(value: SpiralLibmComplex64): Double; cdecl; external 'm' name 'cabs';

function spiral_abi_libm_cabs_pack(realValue: LongInt; imaginaryValue: LongInt): LongInt; inline;
var
  value: SpiralLibmComplex64;
  magnitude: Double;
begin
  value.re := realValue;
  value.im := imaginaryValue;
  magnitude := spiral_libm_cabs(value);
  if magnitude < 0.0 then Halt(94);
  if magnitude > High(LongInt) then Halt(95);
  if magnitude <> Trunc(magnitude) then Halt(96);
  Result := Trunc(magnitude);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := spiral_abi_libm_cabs_pack(3, 4);
  Exit(v0);
end;

begin
  Halt(SpiralMain);
end.
