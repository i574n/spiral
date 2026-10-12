program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := spiral_abi_libm_cabs_pack(3,4);
  Result := v0;
end;
begin
  Halt(SpiralMain);
end.
