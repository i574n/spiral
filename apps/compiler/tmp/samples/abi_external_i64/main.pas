program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: Int64;
  v1: Int64;
  v2: Boolean;
begin
  v0 := (-5000000000);
  v1 := spiral_abi_libc_llabs(v0);
  v2 := v1 == 5000000000;
  if v2 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
begin
  Halt(SpiralMain);
end.
