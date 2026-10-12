program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: Int64;
  v1: Int64;
  v2: Int64;
  v3: Boolean;
begin
  v0 := 5000000007;
  v1 := 1000;
  v2 := spiral_abi_libc_lldiv_pack(v0,v1);
  v3 := v2 == 5000000007;
  if v3 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
begin
  Halt(SpiralMain);
end.
