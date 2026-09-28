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
  v2: TArray0;
  tmp4: TArray0;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: Boolean;
  v8: Boolean;
  v9: Byte;
  v10: Boolean;
  v11: Byte;
  v12: Boolean;
begin
  v0 := 4;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  tmp4 := nil;
  SetLength(tmp4, v0);
  v2 := tmp4;
  v1[0] := 65;
  v1[1] := 66;
  v1[2] := 67;
  v1[3] := 68;
  v2[0] := 65;
  v2[1] := 66;
  v2[2] := 67;
  v2[3] := 69;
  v3 := 3;
  v4 := 4;
  v5 := spiral_abi_libc_memcmp(v1,v2,v3);
  v6 := spiral_abi_libc_memcmp(v1,v2,v4);
  v7 := v5 = 0;
  if v7 then begin
      v8 := v6 = 0;
      if v8 then begin
          Result := 2;
      end else begin
          v9 := v1[3];
          v10 := v9 = 68;
          if v10 then begin
              v11 := v2[3];
              v12 := v11 = 69;
              if v12 then begin
                  Result := 0;
              end else begin
                  Result := 4;
              end;
          end else begin
              Result := 3;
          end;
      end;
  end else begin
      Result := 1;
  end;
end;
begin
  Halt(SpiralMain);
end.
