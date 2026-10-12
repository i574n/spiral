program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of Byte;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v0 := 2;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 0;
  v1[1] := 0;
  v2 := 65;
  v3 := 3;
  v4 := spiral_abi_libc_memset(v1,v2,v3);
  Result := v4;
end;
begin
  Halt(SpiralMain);
end.
